using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an Master ice fiend corpse" )]
	public class MasterIceFiend : BaseCreature
	{
		[Constructable]
		public MasterIceFiend () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			//AuraMessage = "The intense cold is damaging you!"; // TODO Cliloc support: 1008111
			//AuraType = ResistanceType.Cold;
		//	MinAuraDelay = 5;
		//	MaxAuraDelay = 15;
		//	MinAuraDamage = 15;
		//	MaxAuraDamage = 25;
		//	AuraRange = 2;

			Name = "Master ice fiend";
			Body = 43;
			BaseSoundID = 357;
            Hue = 1151;

			SetStr( 1176, 1405 );
			SetDex( 376, 995 );
			SetInt( 301, 925 );

			SetHits( 56000, 67543 );

			SetDamage( 40, 55 );

			SetSkill( SkillName.EvalInt, 150.1, 170.0 );
			SetSkill( SkillName.Magery, 180.1, 190.0 );
			SetSkill( SkillName.MagicResist, 75.1, 105.0 );
			SetSkill( SkillName.Tactics, 180.1, 190.0 );
			SetSkill( SkillName.Wrestling, 140.1, 160.0 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 50, 70 );
			SetResistance( ResistanceType.Cold, 80, 90 );
			SetResistance( ResistanceType.Poison, 70, 80 );
			SetResistance( ResistanceType.Energy, 60, 80 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 60;
                       
                       
                        PackItem( new MasterCoin( 30 ) );
                        AddLoot( LootPack.SuperBoss, 15 );
	
		}


		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

         //   if (0.03 > Utility.RandomDouble()) // 
          //  {           
          //      c.DropItem(new Herobow2());             
          //  }

            if (0.04 > Utility.RandomDouble()) //
            {           
                c.DropItem(new Herotalisman());             
            }

            if (0.03 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new HerobloodyApron());             
            }

            if (0.04 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new HerohoodedRobe());             
            }

            if (0.04 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Heroquiver());             
            }
        
            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicClothDeed());             

		}


		}


                public override bool AutoDispel{ get{ return true; } }
	        public override bool BardImmune{ get{ return true; } }
                public override bool AlwaysMurderer { get { return true; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }
                
 
		public MasterIceFiend( Serial serial ) : base( serial )
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