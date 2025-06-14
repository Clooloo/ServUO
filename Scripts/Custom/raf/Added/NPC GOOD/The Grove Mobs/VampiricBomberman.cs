using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a Bomber man corpse" )]
	public class VBomberman : BaseMount
	{

        private DateTime m_NextBomb;
        private int m_Thrown;

		[Constructable]
		public VBomberman() : this( "  The Bomber Man  " )
		{
		}

		public override bool SubdueBeforeTame{ get{ return true; } } // Must be beaten into submission

		[Constructable]
		public VBomberman( string name ) : base( name, 766, 0x3EBA, AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			
                        Hue = 2678;

			SetStr( 1000, 2000 );
			SetDex( 2000, 3000 );
			SetInt( 3000, 3500 );

			SetHits( 1500, 5000 );

			SetDamage( 35, 40 );

                        SetDamageType(ResistanceType.Physical, 25);
                        SetDamageType(ResistanceType.Fire, 25);
                        SetDamageType(ResistanceType.Cold, 25);
                        SetDamageType(ResistanceType.Energy, 25);

			SetResistance( ResistanceType.Physical,60, 70 );
			SetResistance( ResistanceType.Fire, 55, 75 );
			SetResistance( ResistanceType.Cold, 55, 75 );
			SetResistance( ResistanceType.Poison, 55, 70 );
			SetResistance( ResistanceType.Energy, 50, 75 );

                        SetSkill( SkillName.Healing, 40.1, 50.0);
                        SetSkill( SkillName.Anatomy, 70.1, 80.0 );
			SetSkill( SkillName.MagicResist, 100.1, 110.0 );
			SetSkill( SkillName.Tactics, 110.1, 130.0 );
			SetSkill( SkillName.Throwing, 130.1, 150.0 );
			SetSkill( SkillName.Wrestling, 130.1, 150.0 );
			SetSkill( SkillName.Swords, 130.1, 150.0 );
		        SetSkill( SkillName.Meditation, 80.0, 100.0 );


			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 50;

			Tamable = true;
			ControlSlots = 4;
			MinTameSkill = 115.1;

            HSais sais = new HHSais();
            sais.Movable = false;
            AddItem( sais );

            PackItem(new RandomTalisman());
            PackGold(100, 200);
          //  PackWeapon(1, 2);
          //  PackWeapon(1, 2);
          //  PackArmor(1, 2);
			
			switch ( Utility.Random( 4 ))
			{
				case 0: PackItem( new Taint() ); break;
				case 1: PackItem( new RightArm() ); break;
				case 2: PackItem( new Torso() ); break;
				case 3: PackItem( new Bone() ); break;
			}
		}
        	
                public override bool StatLossAfterTame { get { return true; } }	 
                public override Poison HitPoison { get { return Poison.Deadly; } }           
              //  public override bool CanHeal { get { return true; } }
                
                public override bool AlwaysMurderer { get { return true; } }
                public override bool BardImmune{ get{ return true; } }
		public override bool CanAngerOnTame { get { return true; } }


        public override int GetIdleSound()
        {
            return 0x262;
        }

        public override int GetAngerSound()
        {
            return 0x263;
        }

        public override int GetHurtSound()
        {
            return 0x1D0;
        }

        public override int GetDeathSound()
        {
            return 0x28D;
        }


        public override void OnActionCombat()
        {
            Mobile combatant = this.Combatant as Mobile;

            if (combatant == null || combatant.Deleted || combatant.Map != this.Map || !this.InRange(combatant, 12) || !this.CanBeHarmful(combatant) || !this.InLOS(combatant))
                return;

            if (DateTime.UtcNow >= this.m_NextBomb)
            {
                this.ThrowBomb(combatant);

                this.m_Thrown++;

                if (1.0 >= Utility.RandomDouble() && (this.m_Thrown % 2) == 1) // 90% chance to quickly throw another bomb
                    this.m_NextBomb = DateTime.UtcNow + TimeSpan.FromSeconds(1.0);
                else
                    this.m_NextBomb = DateTime.UtcNow + TimeSpan.FromSeconds(1.0 + (1.0 * Utility.RandomDouble())); // 6 seconds
            }
        }

        public void ThrowBomb(Mobile m)
        {
            this.DoHarmful(m);

            this.MovingParticles(m, 0x2256, 3, 0, false, true, 2348, 0, 9502, 6014, 0x11D, EffectLayer.Waist, 0);

            new InternalTimer(m, this).Start();
        }

       private class InternalTimer : Timer
        {
            private readonly Mobile m_Mobile;
            private readonly Mobile m_From;
            public InternalTimer(Mobile m, Mobile from)
                : base(TimeSpan.FromSeconds(1.0))
            {
                this.m_Mobile = m;
                this.m_From = from;
                this.Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                this.m_Mobile.PlaySound(0x11D);
                AOS.Damage(this.m_Mobile, this.m_From, Utility.RandomMinMax(70, 100), 0, 100, 0, 0, 0);
            }
        }



		public VBomberman( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}


namespace Server.Items
{
	public class HHSais : HSais
	{

      		public override int AosMinDamage{ get{ return 16; } } 
      		public override int AosMaxDamage{ get{ return 20; } } 
      		public override int AosSpeed{ get{ return 20; } } 

                public override int ArtifactRarity{ get{ return 10; } }   

		public override int InitMinHits{ get{ return 200; } }
		public override int InitMaxHits{ get{ return 200; } }

	

		[Constructable]
		public HHSais()
		{
			Name = " War Sais ";
			Hue = 1152;
                        Weight = 40.0;
			
			LootType = LootType.Blessed;
			DurabilityLevel = WeaponDurabilityLevel.Indestructible;
         		Quality = ItemQuality.Exceptional;

                                WeaponAttributes.HitLightning = 100;
			  	WeaponAttributes.HitLeechMana = 50;
                                WeaponAttributes.HitLeechStam = 50;
                                WeaponAttributes.HitLeechHits = 50;
                                ExtendedWeaponAttributes.HitSwarm = 20;
				Attributes.RegenStam = 10;
				Attributes.RegenMana = 10;
                                Attributes.WeaponSpeed = 60;
                               this.WeaponAttributes.SelfRepair = 5;
			MaxHitPoints = 500;
			HitPoints = 500;
                        StrRequirement = 40;
                         this.AosElementDamages.Chaos = 100;
				}
        public override int MinThrowRange
        {
            get
            {
                return 1;
            }
        }// MaxRange 11					


        public HHSais( Serial serial ) : base( serial )
		{
		}

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
    public class HSais : BaseThrown
    {
        [Constructable]
        public HSais()
            : base(0x27A3)
        {
            this.Weight = 6.0;
            this.Layer = Layer.TwoHanded;
        }

        public HSais(Serial serial)
            : base(serial)
        {
        }
        public override int MinThrowRange
        {
            get
            {
                return 1;
            }
        }// MaxRange 11			

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