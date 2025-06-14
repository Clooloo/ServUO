//presented for your consideration -BaleFire-
using System;
using System.Collections;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Engines.CannedEvil;

namespace Server.Mobiles
{
    [CorpseName( "Wait What??" )]
	    public class RainbowMinion : BaseCreature
        {
            
        private Timer m_Timer;

        public override bool IsScaredOfScaryThings { get { return false; } }
        public override bool IsScaryToPets { get { return false; } }

        [Constructable]
        public RainbowMinion () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            Name = "Rainbow Minion";
            Body = 0x308;
            Hue = 1927; 
            BaseSoundID = 357;

            SetStr(700);//Adjust this to fit your shard.
            SetDex(200);//Adjust this to fit your shard.
            SetInt(150);//Adjust this to fit your shard.

            SetHits(10000);//Adjust this to fit your shard.

            SetDamage(19, 27);//Adjust this to fit your shard.

            SetDamageType(ResistanceType.Fire, 50);//Adjust this to fit your shard.
            SetDamageType(ResistanceType.Energy, 50);//Adjust this to fit your shard.

            SetResistance(ResistanceType.Physical, 55);//Adjust this to fit your shard.
            SetResistance(ResistanceType.Fire, 60);//Adjust this to fit your shard.
            SetResistance(ResistanceType.Poison, 50);//Adjust this to fit your shard.
            SetResistance(ResistanceType.Energy, 40);//Adjust this to fit your shard.

            SetSkill(SkillName.EvalInt, 100);//Adjust this to fit your shard.
            SetSkill(SkillName.Tactics, 98);//Adjust this to fit your shard.
            SetSkill(SkillName.MagicResist, 85);//Adjust this to fit your shard.
            SetSkill(SkillName.Wrestling, 110);//Adjust this to fit your shard.
            SetSkill(SkillName.Meditation, 100);//Adjust this to fit your shard.
            SetSkill(SkillName.Focus, 100);//Adjust this to fit your shard.
            SetSkill(SkillName.Magery, 115);//Adjust this to fit your shard.

            Fame = 1500;//Adjust this to fit your shard.
            Karma = -25000;//Adjust this to fit your shard.

            VirtualArmor = 55;//Adjust this to fit your shard.
                                          
            
            //m_Timer = new TeleportTimer(this);
            //m_Timer.Start();
        }
            
        public override bool CanRummageCorpses { get { return true; } }
        public override bool BardImmune { get { return false; } }
        public override bool Unprovokable { get { return false; } }
        public override bool Uncalmable { get { return false; } }
        public override Poison PoisonImmune { get { return Poison.Greater; } }
        public override bool AlwaysMurderer { get { return true; } }

            
                    

        private class TeleportTimer : Timer
        {
            private Mobile m_Owner;

            private static int[] m_Offsets = new int[]
			{
				-1, -1,
				-1,  0,
				-1,  1,
				0, -1,
				0,  1,
				1, -1,
				1,  0,
				1,  1
			};

            public TeleportTimer(Mobile owner)
                : base(TimeSpan.FromSeconds(5.0), TimeSpan.FromSeconds(5.0))
            {
                m_Owner = owner;
            }

            protected override void OnTick()
            {
                if (m_Owner.Deleted)
                {
                    Stop();
                    return;
                }

                Map map = m_Owner.Map;

                if (map == null)
                    return;

                if (0.25 < Utility.RandomDouble())
                    return;

                Mobile toTeleport = null;

                foreach (Mobile m in m_Owner.GetMobilesInRange(16))
                {
                    if (m != m_Owner && m.Player && m_Owner.CanBeHarmful(m) && m_Owner.CanSee(m))
                    {
                        toTeleport = m;
                        break;
                    }
                }

                if (toTeleport != null)
                {
                    int offset = Utility.Random(8) * 2;

                    Point3D to = m_Owner.Location;

                    for (int i = 0; i < m_Offsets.Length; i += 2)
                    {
                        int x = m_Owner.X + m_Offsets[(offset + i) % m_Offsets.Length];
                        int y = m_Owner.Y + m_Offsets[(offset + i + 1) % m_Offsets.Length];

                        if (map.CanSpawnMobile(x, y, m_Owner.Z))
                        {
                            to = new Point3D(x, y, m_Owner.Z);
                            break;
                        }
                        else
                        {
                            int z = map.GetAverageZ(x, y);

                            if (map.CanSpawnMobile(x, y, z))
                            {
                                to = new Point3D(x, y, z);
                                break;
                            }
                        }
                    }

                    Mobile m = toTeleport;

                    Point3D from = m.Location;

                    m.Location = to;

                    Server.Spells.SpellHelper.Turn(m_Owner, toTeleport);
                    Server.Spells.SpellHelper.Turn(toTeleport, m_Owner);

                    m.ProcessDelta();

                    Effects.SendLocationParticles(EffectItem.Create(from, m.Map, EffectItem.DefaultDuration), 0x3709, 1, 30, 9904, 1108);
                    Effects.SendLocationParticles(EffectItem.Create(to, m.Map, EffectItem.DefaultDuration), 0x3709, 1, 30, 9904, 1108);

                    m.PlaySound(0x1FE);

                    m_Owner.Combatant = toTeleport;
                    m_Owner.PrivateOverheadMessage(MessageType.Regular, 1153, false, "AHHHHH!!!! Help me!!!", m_Owner.NetState);
                }
            }
        }


            public RainbowMinion(Serial serial) : base(serial)
        {
        }
        

        private static void SayRandom(string[] say, Mobile m)
        {
            m.Say(say[Utility.Random(say.Length)]);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
        public override void OnDeath(Container c)
        {
            RainbowBigBoss TD = new RainbowBigBoss();
            TD.Map = this.Map;
            TD.Location = this.Location;

            base.OnDeath(c);
            c.Delete();
        }
    }
}
