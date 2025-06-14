using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("A Predator corpse")]
	public class Predator : BaseCreature
	{
		[Constructable]
		public Predator () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
            Name = "-Predator-";
			Body = 1248;
			BaseSoundID = 362;
			Hue = 0;

			SetStr( 1400, 2000 );
			SetDex( 2600, 2650 );
			SetInt( 2600, 2800 );

			SetHits( 15000, 19000 );

			SetDamage( 30, 50 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 75, 85 );
			SetResistance( ResistanceType.Fire, 70, 80 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 75, 85 );
			SetResistance( ResistanceType.Energy, 75, 85 );

			SetSkill( SkillName.EvalInt, 150.0, 170.0 );
			SetSkill( SkillName.Magery, 130.0, 150.0 );
			SetSkill( SkillName.MagicResist, 90.0, 110.0 );
			SetSkill( SkillName.Tactics, 150.0, 170.0 );
			SetSkill( SkillName.Wrestling, 120.0, 160.0 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 60;

			Tamable = false;
			ControlSlots = 5;
			MinTameSkill = 160.0;

			for ( int i = 0; i < 8; ++i )
		    PackGem();
			PackGold( 400, 1000 );
         
            switch ( Utility.Random ( 6 ) )
         	{
                case 0: PackItem(new MasterCoin(30)); break;
                case 1: PackItem(new HeartOfTheLionArms()); break;
                case 2: PackItem(new HeartOfTheLionCloseHelm()); break;
                case 3: PackItem(new HeartOfTheLionGloves()); break;
                case 4: PackItem(new HeartOfTheLionLegs()); break;
                case 5: PackItem(new HeartOfTheLion()); break;
                }

			
		}
		
        public override bool AlwaysMurderer{ get{ return true; } }
		
		public override bool AutoDispel{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override int Scales{ get{ return 20; } }
		public override ScaleType ScaleType{ get{ return ScaleType.White; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public Predator( Serial serial ) : base( serial )
		{
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