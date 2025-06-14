using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a WereWolf corpse" )]
	public class WereWolf : BaseCreature
	{
		[Constructable]
		public WereWolf () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
		//	AuraMessage = "Get out!"; // TODO Cliloc support: 1008111
		//	AuraType = ResistanceType.Cold;
		//	MinAuraDelay = 5;
		//	MaxAuraDelay = 15;
		//	MinAuraDamage = 15;
		//	MaxAuraDamage = 25;
		//	AuraRange = 2;

			Name = "The WereWolf";
			Body = 1070;
			BaseSoundID = 0xE5;
                        Hue = 2075;

			SetStr( 1176, 1405 );
			SetDex( 2376, 2995 );
			SetInt( 2301, 2925 );

			SetHits( 36000, 47543 );

			SetDamage( 40, 60 );

			SetSkill( SkillName.EvalInt, 150.1, 170.0 );
			SetSkill( SkillName.Magery, 180.1, 190.0 );
			SetSkill( SkillName.MagicResist, 75.1, 105.0 );
			SetSkill( SkillName.Tactics, 180.1, 190.0 );
			SetSkill( SkillName.Wrestling, 140.1, 160.0 );

			SetResistance( ResistanceType.Physical, 75, 85 );
			SetResistance( ResistanceType.Fire, 60, 80 );
			SetResistance( ResistanceType.Cold, 70, 90 );
			SetResistance( ResistanceType.Poison, 60, 90 );
			SetResistance( ResistanceType.Energy, 60, 90 );

			Fame = 18000;
			Karma = -18000;
    
			VirtualArmor = 60;
 
                       
                        PackItem( new MasterCoin( 15 ) );
                        AddLoot( LootPack.SuperBoss, 2 );
	
		}


		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

       //     if (0.01 > Utility.RandomDouble()) // 
        //    {           
        //        c.DropItem(new Herobow2());             
        //    }

            if (0.01 > Utility.RandomDouble()) //
            {           
                c.DropItem(new Herotalisman());             
            }

            if (0.01 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new HerobloodyApron());             
            }

           // if (0.01 > Utility.RandomDouble()) // 
           // {           
           //     c.DropItem(new CinctureDeed());             
           // }

         //   if (0.01 > Utility.RandomDouble()) // 
         //   {           
         //       c.DropItem(new EverlastingBandage());             
         ///   }

          //  if (0.01 > Utility.RandomDouble()) // 
          //  {           
          //      c.DropItem(new EverlastingBandage());             
         //   }

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
                
		public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.BleedAttack;
        }
 
		public WereWolf( Serial serial ) : base( serial )
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
