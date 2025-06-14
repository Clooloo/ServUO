using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a meer's corpse")]
    public class VVampire : BaseMount
    {
        private DateTime m_NextAbilityTime;

		[Constructable]
		public VVampire() : this( "  Count Dracula  " )
		{
		}

		public override bool SubdueBeforeTame{ get{ return true; } } // Must be beaten into submission

		[Constructable]
		public VVampire( string name ) : base( name, 784, 0x3EBB, AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{

                         Hue = 2348;
                         this.BaseSoundID = 0x47D;

			SetStr( 1000, 2000 );
			SetDex( 2000, 3000 );
			SetInt( 3000, 3500 );

			SetHits( 1500, 4400 );

			SetDamage( 35, 40 );

                        SetDamageType(ResistanceType.Physical, 25);
                        SetDamageType(ResistanceType.Fire, 25);
                        SetDamageType(ResistanceType.Cold, 25);
                        SetDamageType(ResistanceType.Energy, 25);

			SetResistance( ResistanceType.Physical,65, 70 );
			SetResistance( ResistanceType.Fire, 50, 65 );
			SetResistance( ResistanceType.Cold, 70, 75 );
			SetResistance( ResistanceType.Poison, 90, 100 );
			SetResistance( ResistanceType.Energy, 50, 55 );

                        SetSkill( SkillName.Anatomy, 70.1, 110.0 );
			SetSkill( SkillName.MagicResist, 100.1, 110.0 );
			SetSkill( SkillName.Tactics, 110.1, 130.0 );
			SetSkill( SkillName.Wrestling, 130.1, 150.0 );
			SetSkill( SkillName.Throwing, 130.1, 150.0 );
		        SetSkill( SkillName.Meditation, 80.0, 100.0 );


			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 50;

			Tamable = true;
			ControlSlots = 4;
			MinTameSkill = 120;

            HHatchet th = new TTHatchet();
            th.Movable = false;
            AddItem( th );


			switch (Utility.Random(12))
            {
                case 0: PackItem(new StrangleScroll()); break;
                case 1: PackItem(new WitherScroll()); break;
                case 2: PackItem(new VampiricEmbraceScroll()); break;
			}

            this.m_NextAbilityTime = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(2, 4));
        }

        public VVampire(Serial serial)
            : base(serial)
        {
        }

                  public override bool StatLossAfterTame { get { return true; } }	 
                public override Poison HitPoison { get { return Poison.Deadly; } } 
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }            
                public override bool AlwaysMurderer { get { return true; } }
                public override bool BardImmune{ get{ return true; } }
		public override bool CanAngerOnTame { get { return true; } }
        public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.ConcussionBlow;
        }


        public override int GetAttackSound()
        {
            return 0x28B;
        }

        public override void OnThink()
        {
            if (DateTime.UtcNow >= this.m_NextAbilityTime)
            {
                Mobile combatant = this.Combatant as Mobile;

                if (combatant != null && combatant.Map == this.Map && combatant.InRange(this, 10))
                {
                    this.m_NextAbilityTime = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(4, 5));

                    int ability = Utility.Random(4);

                    switch ( ability )
                    {
                        case 0:
                            this.DoFocusedLeech(combatant, "Thine essence will fill my withering body with strength!");
                            break;
                        case 1:
                            this.DoFocusedLeech(combatant, "I rebuke thee, worm, and cleanse thy vile spirit of its tainted blood!");
                            break;
                        case 2:
                            this.DoAreaLeech();
                            break;
                    // TODO: Resurrect ability
                    }
                }
            }

            base.OnThink();
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

        private void DoAreaLeech()
        {
            this.m_NextAbilityTime += TimeSpan.FromSeconds(1.4);

            this.Say(true, "Beware, mortals!  You have provoked my wrath!");
            this.FixedParticles(0x376A, 10, 10, 9537, 33, 0, EffectLayer.Waist);

            Timer.DelayCall(TimeSpan.FromSeconds(2.0), new TimerCallback(DoAreaLeech_Finish));
        }

        private void DoAreaLeech_Finish()
        {
            ArrayList list = new ArrayList();

            foreach (Mobile m in this.GetMobilesInRange(9))
            {
                if (this.CanBeHarmful(m) && this.IsEnemy(m))
                    list.Add(m);
            }

            if (list.Count == 0)
            {
                this.Say(true, "Bah! You have escaped my grasp this time, mortal!");
            }
            else
            {
                double scalar;

                if (list.Count == 1)
                    scalar = 0.70;
                else if (list.Count == 2)
                    scalar = 0.60;
                else
                    scalar = 0.80;

                for (int i = 0; i < list.Count; ++i)
                {
                    Mobile m = (Mobile)list[i];

                    int damage = (int)(10 + scalar);

                    damage += Utility.RandomMinMax(70, 100);

                    if (damage < 1)
                        damage = 50;

                    m.MovingParticles(this, 0x36F4, 4, 0, false, false, 32, 0, 9535, 1, 0, (EffectLayer)255, 0x100);
                    m.MovingParticles(this, 0x0001, 4, 0, false, true, 32, 0, 9535, 9536, 0, (EffectLayer)255, 0);

                    this.DoHarmful(m);
                    this.Hits += AOS.Damage(m, this, damage, 100, 0, 0, 0, 0);
                }

                this.Say(true, "If I cannot cleanse thy soul, I will destroy it!");
            }
        }

        private void DoFocusedLeech(Mobile combatant, string message)
        {
            this.Say(true, message);

            Timer.DelayCall(TimeSpan.FromSeconds(0.5), new TimerStateCallback(DoFocusedLeech_Stage1), combatant);
        }

        private void DoFocusedLeech_Stage1(object state)
        {
            Mobile combatant = (Mobile)state;

            if (this.CanBeHarmful(combatant))
            {
                this.MovingParticles(combatant, 0x36FA, 1, 0, false, false, 1108, 0, 9533, 1, 0, (EffectLayer)255, 0x100);
                this.MovingParticles(combatant, 0x0001, 1, 0, false, true, 1108, 0, 9533, 9534, 0, (EffectLayer)255, 0);
                this.PlaySound(0x1FB);

                Timer.DelayCall(TimeSpan.FromSeconds(1.0), new TimerStateCallback(DoFocusedLeech_Stage2), combatant);
            }
        }

        private void DoFocusedLeech_Stage2(object state)
        {
            Mobile combatant = (Mobile)state;

            if (this.CanBeHarmful(combatant))
            {
                combatant.MovingParticles(this, 0x36F4, 1, 0, false, false, 32, 0, 9535, 1, 0, (EffectLayer)255, 0x100);
                combatant.MovingParticles(this, 0x0001, 1, 0, false, true, 32, 0, 9535, 9536, 0, (EffectLayer)255, 0);

                this.PlaySound(0x209);
                this.DoHarmful(combatant);
                this.Hits += AOS.Damage(combatant, this, Utility.RandomMinMax(30, 60) - (Core.AOS ? 0 : 10), 100, 0, 0, 0, 0);
            }
        }
    }
}

namespace Server.Items
{
	public class TTHatchet : HHatchet
	{

      		public override int AosMinDamage{ get{ return 16; } } 
      		public override int AosMaxDamage{ get{ return 20; } } 
      		public override int AosSpeed{ get{ return 30; } } 

                public override int ArtifactRarity{ get{ return 9; } }   

		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }

		[Constructable]
		public TTHatchet()
		{
			Name = " TTHatchet ";
                        Weight = 20.0;
			
			DurabilityLevel = WeaponDurabilityLevel.Indestructible;
         		Quality = ItemQuality.Exceptional;

                                WeaponAttributes.HitLightning = 100;
			  	WeaponAttributes.HitLeechMana = 50;
                                WeaponAttributes.HitLeechStam = 50;
                               ExtendedWeaponAttributes.HitSwarm = 20;
				Attributes.WeaponDamage = 0;
				Attributes.RegenStam = 10;
				Attributes.RegenMana = 10;
                                Attributes.WeaponSpeed = 60;
                               this.WeaponAttributes.SelfRepair = 5;
			MaxHitPoints = 500;
			HitPoints = 500;
                        StrRequirement = 100;
                               this.AosElementDamages.Chaos = 100;

				}


        public TTHatchet( Serial serial ) : base( serial )
		{
		}
        public override int MinThrowRange
        {
            get
            {
                return 1;
            }
        }// MaxRange 11			

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}

namespace Server.Items
{
    public class HHatchet : BaseThrown
    {
        [Constructable]
        public HHatchet()
            : base(0xF43)
        {
            this.Weight = 6.0;
            this.Layer = Layer.TwoHanded;
        }

        public HHatchet(Serial serial)
            : base(serial)
        {
        }

		public override WeaponAbility PrimaryAbility
        {
            get
            {
                return WeaponAbility.ArmorIgnore;
            }
        }
        public override WeaponAbility SecondaryAbility
        {
            get
            {
                return WeaponAbility.Disarm;
            }
        }
        public override int AosStrengthReq
        {
            get
            {
                return 60;
            }
        }
        public override int MinThrowRange
        {
            get
            {
                return 1;
            }
        }// MaxRange 11		
        public override int AosMinDamage
        {
            get
            {
                return 13;
            }
        }
        public override int AosMaxDamage
        {
            get
            {
                return 18;
            }
        }
        public override int AosSpeed
        {
            get
            {
                return 25;
            }
        }
        public override float MlSpeed
        {
            get
            {
                return 4.00f;
            }
        }
        public override int OldStrengthReq
        {
            get
            {
                return 20;
            }
        }
        public override int OldMinDamage
        {
            get
            {
                return 9;
            }
        }
        public override int OldMaxDamage
        {
            get
            {
                return 41;
            }
        }
        public override int OldSpeed
        {
            get
            {
                return 20;
            }
        }
        public override int InitMinHits
        {
            get
            {
                return 31;
            }
        }
        public override int InitMaxHits
        {
            get
            {
                return 60;
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
