using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a slayer corpse" )]
	public class VampiricSlayer : BaseMount
	{
		[Constructable]
		public VampiricSlayer() : this( "Vampiric Slayer" )
		{
		}

		public override bool SubdueBeforeTame{ get{ return true; } } // Must be beaten into submission

		[Constructable]
		public VampiricSlayer( string name ) : base( name, 38, 0x3E92, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			

			BaseSoundID = 357;
                        Hue = 2348;

			SetStr( 1200, 1500 );
			SetDex( 600, 800 );
			SetInt( 2000, 3000 );

			SetHits( 2400, 4000 );

			SetDamage( 30, 40 );

                        SetDamageType(ResistanceType.Physical, 25);
                        SetDamageType(ResistanceType.Fire, 25);
                        SetDamageType(ResistanceType.Cold, 50);

			SetResistance( ResistanceType.Physical,65, 70 );
			SetResistance( ResistanceType.Fire, 60, 75 );
			SetResistance( ResistanceType.Cold, 60, 75 );
			SetResistance( ResistanceType.Poison, 65, 70 );
			SetResistance( ResistanceType.Energy, 60, 75 );

                        SetSkill( SkillName.Healing, 70.1, 115.0);
                        SetSkill( SkillName.Anatomy, 120.1, 125.0 );
			SetSkill( SkillName.MagicResist, 120.1, 130.0 );
			SetSkill( SkillName.Tactics, 120.1, 150.0 );
			SetSkill( SkillName.Wrestling, 120.1, 150.0 );
                        SetSkill( SkillName.Poisoning, 80.1, 100.0);
		        SetSkill( SkillName.Meditation, 80.0, 100.0 );


			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 50;
        
			Tamable = true;
			ControlSlots = 4;
			MinTameSkill = 115;


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
                public override Poison HitPoison { get { return Poison.Greater; } }               
            //    public override bool CanHeal { get { return true; } }
                
                public override bool AlwaysMurderer { get { return true; } }
                public override bool BardImmune{ get{ return true; } }
		public override bool CanAngerOnTame { get { return true; } }
                public override bool BleedImmune{ get{ return true; } }
		public override WeaponAbility GetWeaponAbility()

        {
            return WeaponAbility.WhirlwindAttack;
        }        



		public VampiricSlayer( Serial serial ) : base( serial )
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