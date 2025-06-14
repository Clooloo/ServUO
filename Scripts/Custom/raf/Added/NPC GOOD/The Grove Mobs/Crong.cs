using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a crong corpse" )]
	public class Crong2: BaseCreature
	{
		[Constructable]
		public Crong2(): base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
		//	AuraMessage = "The intense cold is damaging you!"; // TODO Cliloc support: 1008111
		//	AuraType = ResistanceType.Cold;
		//	MinAuraDelay = 5;
		//	MaxAuraDelay = 15;
		//	MinAuraDamage = 20;
		//	MaxAuraDamage = 25;
		//	AuraRange = 10;

			Name = " Earth Titan ";
			Body = 1431;
			BaseSoundID = 367;
                        Hue = 2500;

			SetStr( 1500, 1700 );
			SetDex( 1400, 1995 );
			SetInt( 2501, 2925 );

			SetHits( 55000, 63000 );

			SetDamage( 35, 60 );

                        SetDamageType(ResistanceType.Physical,40);
                        SetDamageType(ResistanceType.Fire, 40);
                        SetDamageType(ResistanceType.Cold, 20);

			SetSkill( SkillName.EvalInt, 100, 120.0 );
			SetSkill( SkillName.Magery, 100, 120.0 );
			SetSkill( SkillName.MagicResist, 75.1, 105.0 );
			SetSkill( SkillName.Tactics, 100, 120.0 );
			SetSkill( SkillName.Wrestling, 170, 180.0 );

			SetResistance( ResistanceType.Physical,65, 85 );
			SetResistance( ResistanceType.Fire, 70, 80 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Poison, 70, 80 );
			SetResistance( ResistanceType.Energy, 70, 80 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 60;
                        
                        PackItem (new CrystallineBlackrock(10));
                        PackItem (new RelicFragment(10));
                        PackItem (new RAD());
                        AddLoot( LootPack.SuperBoss, 3 );
			AddLoot( LootPack.Meager );
			
		}

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);
                  c.DropItem( new MasterCoin( 30 ) );
                 

      if (0.02 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Herodeed());             
            }

           // if (0.02 > Utility.RandomDouble()) // 
          //  {           
          //      c.DropItem(new HeroWeapondeed());             
          //  }

            if (0.04 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Robedeed());             
            }


        //    if (0.02 > Utility.RandomDouble()) // 
        //    {           
        //        c.DropItem(new EverlastingBandage());             
        //    }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicClothDeed());             

			}

            }


                public override Poison HitPoison { get { return Poison.Deadly; } } 
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }  
                public override bool AutoDispel{ get{ return true; } }
	        public override bool BardImmune{ get{ return true; } }
                public override bool AlwaysMurderer { get { return true; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }
                

		public Crong2( Serial serial ) : base( serial )
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