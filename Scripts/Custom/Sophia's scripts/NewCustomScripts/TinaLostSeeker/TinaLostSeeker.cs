using System; 
using System.Collections; 
using Server.Items; 
using Server.ContextMenus; 
using Server.Misc; 
using Server.Network; 

namespace Server.Mobiles 
{ 
	public class TinaLostSeeker: BaseCreature
	{ 
		[Constructable] 
		public TinaLostSeeker() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{ 
            Name = "Tina";
			Title = "*Lost Seeker*";
			Hue = 33795;
			Body = 401;
                  
            Female = true;

			SetStr( 100);
			SetDex( 80 );
        			SetInt( 110 );

			SetHits( 2000 );

			SetDamage( 25, 30 );

			SetMana( 20 );

            SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Cold, 100 );

			SetResistance( ResistanceType.Physical, 75, 75 );
			SetResistance( ResistanceType.Fire, 95, 95 );
			SetResistance( ResistanceType.Cold, 100, 110 );
			SetResistance( ResistanceType.Poison, 80, 90 );
			SetResistance( ResistanceType.Energy, 100, 110 );

			SetSkill( SkillName.EvalInt, 110.1 );
			SetSkill( SkillName.Magery, 110.0 );
			SetSkill( SkillName.MagicResist, 90 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 100.1 );
			SetSkill( SkillName.Macing, 110.0 );

			Fame = 2000;
			Karma = -2000;

			VirtualArmor = 40;
			
			

			Item Pants = new Item( 9799 );
            Pants.Hue = 1366;
            Pants.Name = "Lost Seeker Pants";
            Pants.Layer = Layer.Pants;
            Pants.LootType = LootType.Blessed;
            AddItem(Pants);
             
             this.HairItemID = 0x203C;
             this.HairHue = 0x3EA;
			
            Item Shoes = new Item( 5903 );
			Shoes.Hue = 1366;
			Shoes.Layer = Layer.Shoes;
			Shoes.LootType = LootType.Blessed;
			AddItem( Shoes );

            Item Shirt = new Item( 9793 );
			Shirt.Hue = 1366;
            Shirt.Name = "Lost Seeker Chest";
			Shirt.Layer = Layer.Shirt;
			Shirt.LootType = LootType.Blessed;
			AddItem( Shirt );

            Item SkullCap = new Item( 5444 );
			SkullCap.Hue = 1366;
			SkullCap.Layer = Layer.Helm;
			SkullCap.LootType = LootType.Blessed;
			AddItem( SkullCap );




            Item yumi = new Item(10149);
            yumi.LootType = LootType.Blessed;
            yumi.Name = "Lost Seeker Bow";
            yumi.Hue = 1366;
            yumi.Movable = false;
            yumi.Layer = Layer.FirstValid;
            AddItem(yumi);

            Item MetalKiteShield = new Item(7028);
            MetalKiteShield.Hue = 1366;
            MetalKiteShield.Name = "Lost Seeker Shield";
            MetalKiteShield.Layer = Layer.TwoHanded;
            MetalKiteShield.LootType = LootType.Blessed;
            AddItem(MetalKiteShield); 


                                                
                         Container pack = new Backpack();

                        PackItem( new Gold( 1000, 1200 ) );
                        if ( 0.40 > Utility.RandomDouble() ) // 0.40 = 45% = chance to drop
			switch ( Utility.Random( 4 )) //number of alternatives
			{
                        case 0: AddToBackpack( new LostSeekerShield()); break;
                        case 1: AddToBackpack( new LostSeekerBow()); break;
                        case 2: AddToBackpack(new LostSeekerPants()); break;
                        case 3: AddToBackpack(new LostSeekerChest()); break;
						


			}

		}

		public override bool AlwaysMurderer{ get{ return true; } }
                //public override bool IsScaryToPets{ get{ return true; } }

        public TinaLostSeeker(Serial serial)
            : base(serial)
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
