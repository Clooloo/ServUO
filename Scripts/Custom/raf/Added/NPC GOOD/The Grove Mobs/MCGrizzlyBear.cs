//Edited by Darck...
using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a MC grizzly corpse" )]
	public class MCGrizzlyBear : BaseMount
	{
		[Constructable]
		public MCGrizzlyBear() : this( "a mc grizzly bear" )
		{
		}

		[Constructable]
		public MCGrizzlyBear( string name ) : base( name, 0xD5, 0x3EC5, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
            Hue = 2075;
			BaseSoundID = 0xA3;

            SetStr(1251, 1550);
            SetDex(801, 1050);
            SetInt(151, 400);

            SetHits(18751, 25930);
            SetMana(100);

            SetDamage(35, 45);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 70, 75);
            SetResistance(ResistanceType.Cold, 70, 80);
            SetResistance(ResistanceType.Poison, 70, 75);
            SetResistance(ResistanceType.Energy, 60, 80);

            SetSkill(SkillName.Wrestling, 120.4, 158.1);
            SetSkill(SkillName.Tactics, 120.6, 140.5);
            SetSkill(SkillName.MagicResist, 132.8, 154.6);
            SetSkill(SkillName.Anatomy, 90, 100);

			Fame = 20000;
			Karma = -20000;

            VirtualArmor = 24;
            

			Tamable = false;
			ControlSlots = 5;
			MinTameSkill = 180.0;
		}

		public override void GenerateLoot()
		{
			PackItem( new Ruby( Utility.RandomMinMax( 16, 30 ) ) );
            PackItem( new MasterCoin( 3 ) );
		}

        public override int Meat { get { return 4; } }
        public override int Hides { get { return 32; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
        public override PackInstinct PackInstinct { get { return PackInstinct.Daemon | PackInstinct.Bear; } }
        public override bool AlwaysMurderer { get { return true; } }

		public MCGrizzlyBear( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( BaseSoundID <= 0 )
				BaseSoundID = 0xA3;

			if( version < 1 )
			{
				for ( int i = 0; i < Skills.Length; ++i )
				{
					Skills[i].Cap = Math.Max( 100.0, Skills[i].Cap * 0.9 );

					if ( Skills[i].Base > Skills[i].Cap )
					{
						Skills[i].Base = Skills[i].Cap;
					}
				}
			}
		}
	}
}