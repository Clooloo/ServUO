using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a tanker corpse" )]
	public class vtanker : BaseMount
	{
		[Constructable]
		public vtanker() : this( "Ridable Tanker" )
		{
		}

		[Constructable]
		public vtanker( string name ) : base( name, 0x33D, 0x3EA4, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			


            if (Utility.RandomBool())
            {
                switch ( Utility.Random(3) )
                {
                  case 0:
			Tamable = true;
			ControlSlots = 5;
			MinTameSkill = 105.1;
                        break;
                  case 1: Tamable = false; break;
                  case 2: Tamable = false; break;

                }
             }

			BaseSoundID = 357;
                        Hue = 0;

			SetStr( 100, 200 );
			SetDex( 200, 300 );
			SetInt( 2000, 3000 );

			SetHits( 3000, 3500 );

			SetDamage( 5, 10 );

                        SetDamageType(ResistanceType.Physical, 25);
                        SetDamageType(ResistanceType.Fire, 25);
                        SetDamageType(ResistanceType.Cold, 50);

			SetResistance( ResistanceType.Physical,75, 85 );
			SetResistance( ResistanceType.Fire, 65, 85 );
			SetResistance( ResistanceType.Cold, 80, 85 );
			SetResistance( ResistanceType.Poison, 85, 85 );
			SetResistance( ResistanceType.Energy, 80, 85 );

                        SetSkill( SkillName.Healing, 100.1, 125.0);
                        SetSkill( SkillName.Anatomy, 100.1, 125.0 );
			SetSkill( SkillName.MagicResist, 100.1, 120.0 );
			SetSkill( SkillName.Tactics, 100.1, 120.0 );
			SetSkill( SkillName.Wrestling, 110.1, 130.0 );
                        SetSkill( SkillName.Poisoning, 80.1, 100.0);
		        SetSkill( SkillName.Meditation, 100.0, 120.0 );


			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 50;
        

            PackItem(new RandomTalisman());
            PackGold(100, 200);
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
		public override Poison PoisonImmune{ get{ return Poison.Greater; } }             
            //    public override bool CanHeal { get { return true; } }
                
                public override bool AlwaysMurderer { get { return true; } }
                public override bool BardImmune{ get{ return true; } }
		public override bool CanAngerOnTame { get { return true; } }
                public override bool BleedImmune{ get{ return true; } }

        public override WeaponAbility GetWeaponAbility()
            {
			return WeaponAbility.BleedAttack;
		}

		public vtanker( Serial serial ) : base( serial )
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