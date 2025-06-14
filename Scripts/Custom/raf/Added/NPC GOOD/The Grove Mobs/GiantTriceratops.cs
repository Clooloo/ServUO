using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a Giant Triceratops corpse" )]
	public class GiantTriceratops : BaseCreature
	{
		[Constructable]
		public GiantTriceratops () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			//AuraMessage = " Bump "; // TODO Cliloc support: 1008111
		//	AuraType = ResistanceType.Cold;
		//	MinAuraDelay = 5;
		//	MaxAuraDelay = 15;
		//	MinAuraDamage = 15;
		//	MaxAuraDamage = 25;
		//	AuraRange = 2;

			Name = "Giant Triceratops";
			Body = 1415;
	 		BaseSoundID = 0x64;
                        Hue = 2793;

			SetStr( 500, 1000 );
			SetDex( 376, 995 );
			SetInt( 301, 925 );

			SetHits( 26000, 47543 );

			SetDamage( 35, 50 );

			SetSkill( SkillName.EvalInt, 100.1, 120.0 );
			SetSkill( SkillName.Magery, 100.1, 120.0 );
			SetSkill( SkillName.MagicResist, 75.1, 105.0 );
			SetSkill( SkillName.Tactics, 100.1, 120.0 );
			SetSkill( SkillName.Wrestling, 100.1, 120.0 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 60, 80 );
			SetResistance( ResistanceType.Cold, 65, 70 );
			SetResistance( ResistanceType.Poison, 68, 80 );
			SetResistance( ResistanceType.Energy, 70, 76 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 60;
                        


                       
                        PackItem( new MasterCoin( 20 ) );
                        AddLoot( LootPack.SuperBoss, 1 );
	
		}


		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

        //    if (0.007 > Utility.RandomDouble()) // 
         //   {           
         //       c.DropItem(new Herobow2());             
         //   }

            if (0.007 > Utility.RandomDouble()) //
            {           
                c.DropItem(new Herotalisman());             
            }

            if (0.007 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new HerobloodyApron());             
            }

            if (0.007 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new HerohoodedRobe());             
            }

            if (0.007 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Heroquiver());             
            }


      //      if (0.007 > Utility.RandomDouble()) // 
    //        {           
     //           c.DropItem(new EverlastingBandage());             
     //       }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicClothDeed());             
            }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicKilt());             
            }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicBoots());             
            }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicRobe());             
            }


		}

                
                public override bool AlwaysMurderer { get { return true; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }
                
 
		public GiantTriceratops( Serial serial ) : base( serial )
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