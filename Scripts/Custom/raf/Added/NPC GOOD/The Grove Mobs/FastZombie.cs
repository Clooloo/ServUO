using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a Toxic corpse" )]
	public class FastZombie : BaseCreature
	{
		[Constructable]
		public FastZombie() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.6 )
		{
            Name = "-Fast Zombie-";
			Body = 0x309;
			BaseSoundID = 471;
            Hue = 0;

			SetStr( 900, 1200 );
			SetDex( 500, 650 );
			SetInt( 300, 350 );

			SetHits( 3000, 4000 );

			SetDamage( 20, 30 );

			SetDamageType( ResistanceType.Physical, 15 );
            SetDamageType( ResistanceType.Poison, 85);

			SetResistance( ResistanceType.Physical,75, 85 );
			SetResistance( ResistanceType.Fire, 50, 55 );
			SetResistance( ResistanceType.Cold, 85, 88 );
			SetResistance( ResistanceType.Poison, 90, 100 );
			SetResistance( ResistanceType.Energy, 70, 90 );

            SetSkill( SkillName.Poisoning, 175.5);
			SetSkill( SkillName.MagicResist, 145.0 );
			SetSkill( SkillName.Tactics, 135.5 );
			SetSkill( SkillName.Wrestling, 120.0 );

			Fame = 16000;
			Karma = -16000;

			VirtualArmor = 60;

            PackItem(new RandomTalisman());
            PackGold(100, 300);
          //  PackWeapon(8, 9);
          //  PackWeapon(8, 9);
          //  PackArmor(8, 9);
          //  PackArmor(8, 9);
          //  PackScroll(7, 8);
          //  PackScroll(7, 8);
          //  PackScroll(7, 8);
			
			switch ( Utility.Random( 10 ))
			{
				case 0: PackItem( new Taint() ); break;
				case 1: PackItem( new RightArm() ); break;
				case 2: PackItem( new Torso() ); break;
				case 3: PackItem( new Bone() ); break;
				case 4: PackItem( new RibCage() ); break;
				case 5: PackItem( new RibCage() ); break;
				case 6: PackItem( new EssenceControl() ); break;
				case 7: PackItem( new BonePile() ); break;
				case 8: PackItem( new BonePile() ); break;
				case 9: PackItem( new MasterCoin() ); break;
			}
		}
        	
                	
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }

        public FastZombie(Serial serial): base(serial)
            
		{
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}