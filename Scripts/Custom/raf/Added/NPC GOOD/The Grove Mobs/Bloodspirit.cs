using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a blood Spirit corpse" )]
	public class bloodspirit : BaseCreature
	{
		[Constructable]
		public bloodspirit() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{

			Name = "Blood Spirit";
			Body = 692;

            if (Utility.RandomBool())
            {
                switch ( Utility.Random(3) )
                {
                  case 0:
			Tamable = true;
			ControlSlots = 4;
			MinTameSkill = 105.1;
                        break;
                  case 1: Tamable = false; break;
                  case 2: Tamable = false; break;

                }
             }

			BaseSoundID = 357;
                        Hue = 2348;

			SetStr( 2000, 2100 );
			SetDex( 800, 1000 );
			SetInt( 4000, 5100 );

			SetHits( 2000, 3000 );

			SetDamage( 20, 35 );

                        SetDamageType(ResistanceType.Physical, 20);
                        SetDamageType(ResistanceType.Fire, 50);
                        SetDamageType(ResistanceType.Cold, 50);

			SetResistance( ResistanceType.Physical,75, 85 );
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Cold, 20, 35 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 20, 25 );

                        SetSkill( SkillName.Healing, 50.1, 75.0);
                        SetSkill( SkillName.Anatomy, 100.1, 125.0 );
			SetSkill( SkillName.MagicResist, 100.1, 120.0 );
			SetSkill( SkillName.Tactics, 100.1, 120.0 );
			SetSkill( SkillName.Wrestling, 130.1, 140.0 );
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
            //    public override bool CanHeal { get { return true; } }
                
                public override bool AlwaysMurderer { get { return true; } }
                public override bool BardImmune{ get{ return true; } }
		public override bool CanAngerOnTame { get { return true; } }
                public override bool BleedImmune{ get{ return true; } }

  
        public override WeaponAbility GetWeaponAbility() 
        {
            int ability = Utility.Random(3);
            if (ability == 1)
                return WeaponAbility.ArmorIgnore;
            else if (ability == 2)
                return WeaponAbility.DoubleStrike;
            else
                return WeaponAbility.WhirlwindAttack;
        }



		public bloodspirit( Serial serial ) : base( serial )
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