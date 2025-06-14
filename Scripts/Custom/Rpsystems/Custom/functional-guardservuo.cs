using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace ServUO.Custom.ToupzyRobbery
{
    public class Guard_v3 : BaseCreature
    {
        private bool _isOnDuty;
        private DateTime _nextCallout;
        private DateTime _nextPatrolMove;
        private Point3D _homeLocation;
        private DateTime _nextTeleportStrike;
        private DateTime _nextDismountMessage;
        private DateTime _nextCombatMessage;
        private DateTime _nextPatrolMessage;
        private int _patrolRange = 30; // Patrol range in tiles

        [Constructable]
        public Guard_v3() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.15, 0.25)
        {
            _isOnDuty = true;
            _nextCallout = DateTime.UtcNow;
            _nextPatrolMove = DateTime.UtcNow;
            _nextTeleportStrike = DateTime.UtcNow;
            _nextDismountMessage = DateTime.UtcNow;
            _nextCombatMessage = DateTime.UtcNow;
            _nextPatrolMessage = DateTime.UtcNow;

            Name = "Ruthless Guard";
            Body = 400;
            Female = Utility.RandomBool();

            SetStr(95, 120);
            SetDex(105, 125);
            SetInt(65, 85);
            SetHits(100, 125);
            SetStam(85, 105);
            SetMana(40, 80);

            SetDamage(10, 18);
            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 30, 40);
            SetResistance(ResistanceType.Fire, 25, 35);
            SetResistance(ResistanceType.Cold, 25, 35);
            SetResistance(ResistanceType.Poison, 25, 35);
            SetResistance(ResistanceType.Energy, 25, 35);

            SetSkill(SkillName.Swords, 70.0, 85.0);
            SetSkill(SkillName.Tactics, 70.0, 85.0);
            SetSkill(SkillName.Anatomy, 65.0, 80.0);
            SetSkill(SkillName.MagicResist, 65.0, 80.0);
            SetSkill(SkillName.Parry, 65.0, 80.0);

            AddItem(new ChainChest());
            AddItem(new ChainLegs());
            AddItem(new PlateArms());
            AddItem(new LeatherGloves());
            AddItem(new ChainCoif());

            VikingSword weapon = new VikingSword();
            AddItem(weapon);
            AddItem(new MetalKiteShield());

            AddItem(new Gold(50, 100));

            Blessed = false;

            ActiveSpeed = 0.35;  // Slightly slower chase speed
            PassiveSpeed = 0.45;  // Slightly slower patrol speed
            CurrentSpeed = PassiveSpeed;
        }

        public Guard_v3(Serial serial) : base(serial) { }

        public override void OnAfterSpawn()
        {
            base.OnAfterSpawn();
            _homeLocation = Location;
        }

        public override bool CanRegenHits => true;
        public override bool InitialInnocent => true;
        public override bool AlwaysAttackable => true;
        public override bool CanRummageCorpses => true;
        public override bool ShowFameTitle => true;

        public override void OnThink()
        {
            base.OnThink();
            if (_isOnDuty)
            {
                if (Combatant == null)
                {
                    HandlePatrol();
                }
                HandleEnemies();
                HandleCallouts();
                HandleTeleportStrike();
                CurrentSpeed = Combatant != null ? ActiveSpeed : PassiveSpeed;
            }
        }

        private void HandlePatrol()
        {
            if (DateTime.UtcNow >= _nextPatrolMove)
            {
                if (DateTime.UtcNow >= _nextPatrolMessage && Utility.RandomDouble() < 0.15)
                {
                    string[] patrolMessages = new string[]
                    {
                        "Keeping the peace in these parts.",
                        "All seems quiet... for now.",
                        "Move along, citizen.",
                        "Nothing suspicious here.",
                        "Maintaining order in the realm."
                    };
                    Say(patrolMessages[Utility.Random(patrolMessages.Length)]);
                    _nextPatrolMessage = DateTime.UtcNow + TimeSpan.FromSeconds(30);
                }

                int distanceFromHome = (int)GetDistanceToSqrt(_homeLocation);

                if (distanceFromHome > _patrolRange)
                {
                    Direction homeDir = GetDirectionTo(_homeLocation);
                    Move(homeDir);
                }
                else
                {
                    Direction randomDir = (Direction)Utility.Random(8);
                    int newX = X;
                    int newY = Y;

                    switch (randomDir)
                    {
                        case Direction.North: newY--; break;
                        case Direction.South: newY++; break;
                        case Direction.East: newX++; break;
                        case Direction.West: newX--; break;
                        case Direction.Right: newX++; newY--; break;
                        case Direction.Left: newX--; newY--; break;
                        case Direction.Down: newX++; newY++; break;
                        case Direction.Up: newX--; newY++; break;
                    }

                    Point3D newLoc = new Point3D(newX, newY, Z);

                    if ((_homeLocation.X - newX) * (_homeLocation.X - newX) +
                        (_homeLocation.Y - newY) * (_homeLocation.Y - newY) <= _patrolRange * _patrolRange)
                    {
                        Move(randomDir);
                    }
                }

                _nextPatrolMove = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(5, 10));
            }
        }

        private void HandleEnemies()
        {
            IPooledEnumerable mobilesInRange = Map.GetMobilesInRange(Location, 25);
            foreach (Mobile mobile in mobilesInRange)
            {
                if (mobile is PlayerMobile player)
                {
                    // Skip dead or hidden players with less than 100 hiding skill
                    if (!player.Alive || (player.Hidden && player.Skills[SkillName.Hiding].Value < 100.0))
                        continue;

                    if (player.Criminal || player.Hue == 1970 || player.Hue == 1157)
                    {
                        Combatant = player;
                        SupportAllies(player);

                        // Combat messages with cooldown
                        if (DateTime.UtcNow >= _nextCombatMessage && Utility.RandomDouble() < 0.2)
                        {
                            string[] combatMessages = new string[]
                            {
                                "Justice will be served!",
                                "Your crimes end here!",
                                "Surrender now, criminal!",
                                "Face the law's judgment!",
                                "You'll pay for your misdeeds!"
                            };
                            Say(combatMessages[Utility.Random(combatMessages.Length)]);
                            _nextCombatMessage = DateTime.UtcNow + TimeSpan.FromSeconds(15);
                        }

                        double distance = GetDistanceToSqrt(player);
                        if (distance > 1)
                        {
                            // Check if player is mounted and attempt to dismount
                            if (player.Mounted && Utility.RandomDouble() < 0.15) // 15% chance to attempt dismount
                            {
                                IMount mount = player.Mount;
                                if (mount != null)
                                {
                                    mount.Rider = null;
                                    Effects.SendLocationParticles(EffectItem.Create(player.Location, player.Map, EffectItem.DefaultDuration), 
                                        0x3728, 10, 10, 2023);
                                    player.PlaySound(0x1FE);
                                    
                                    if (DateTime.UtcNow >= _nextDismountMessage)
                                    {
                                        Say("Get off that mount, criminal!");
                                        _nextDismountMessage = DateTime.UtcNow + TimeSpan.FromSeconds(10);
                                    }
                                }
                            }

                            // More aggressive movement when target is further away
                            if (distance > 10 && Utility.RandomDouble() < 0.3)
                            {
                                // Try to teleport closer if far away
                                Point3D targetLoc = new Point3D(
                                    player.X + Utility.RandomMinMax(-2, 2),
                                    player.Y + Utility.RandomMinMax(-2, 2),
                                    player.Z);
                                
                                if (Map.CanFit(targetLoc, 1))
                                {
                                    MoveToWorld(targetLoc, Map);
                                }
                            }
                            else
                            {
                                // Enhanced movement - try to move diagonally when possible
                                int deltaX = player.X - X;
                                int deltaY = player.Y - Y;
                                Direction moveDir;

                                if (Math.Abs(deltaX) > Math.Abs(deltaY))
                                {
                                    moveDir = deltaX > 0 ? Direction.East : Direction.West;
                                    if (deltaY > 0)
                                        moveDir |= Direction.South;
                                    else if (deltaY < 0)
                                        moveDir |= Direction.North;
                                }
                                else
                                {
                                    moveDir = deltaY > 0 ? Direction.South : Direction.North;
                                    if (deltaX > 0)
                                        moveDir |= Direction.East;
                                    else if (deltaX < 0)
                                        moveDir |= Direction.West;
                                }

                                Move(moveDir);
                            }
                        }
                        break;
                    }
                }
            }
            mobilesInRange.Free();
        }

        private void SupportAllies(Mobile target)
        {
            IPooledEnumerable nearbyAllies = Map.GetMobilesInRange(Location, 14);

            foreach (Mobile ally in nearbyAllies)
            {
                if (ally is Guard_v3 guard && guard != this && guard.Combatant == null)
                {
                    guard.Combatant = target;
                }
            }

            nearbyAllies.Free();
        }

        private void HandleCallouts()
        {
            _nextCallout = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(30, 120));
        }

        private void HandleTeleportStrike()
        {
            if (Combatant != null && DateTime.UtcNow >= _nextTeleportStrike)
            {
                if (Utility.RandomDouble() < 0.4) // 40% chance to teleport
                {
                    // Try to teleport slightly offset from the target for better positioning
                    Point3D targetLocation = new Point3D(
                        Combatant.X + Utility.RandomMinMax(-1, 1),
                        Combatant.Y + Utility.RandomMinMax(-1, 1),
                        Combatant.Z
                    );
                    
                    if (Map.CanFit(targetLocation, 1))
                    {
                        MoveToWorld(targetLocation, Map);
                    }
                }
                _nextTeleportStrike = DateTime.UtcNow + TimeSpan.FromSeconds(1.5); // Reduced cooldown
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
            writer.Write(_isOnDuty);
            writer.Write(_nextCallout);
            writer.Write(_homeLocation);
            writer.Write(_nextDismountMessage);
            writer.Write(_nextCombatMessage);
            writer.Write(_nextPatrolMessage);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            _isOnDuty = reader.ReadBool();
            _nextCallout = reader.ReadDateTime();
            _homeLocation = reader.ReadPoint3D();
            _nextDismountMessage = reader.ReadDateTime();
            _nextCombatMessage = reader.ReadDateTime();
            _nextPatrolMessage = reader.ReadDateTime();
        }
    }
}
