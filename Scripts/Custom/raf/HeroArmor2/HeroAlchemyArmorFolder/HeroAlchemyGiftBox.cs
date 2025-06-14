using System; 
using Server; 
using Server.Items;

namespace Server.Items
{ 
   public class HeroAlchemyGiftBox : Bag 
   { 
		[Constructable] 
		public HeroAlchemyGiftBox() : this( 1 ) 
		{ 
			Movable = true;  
			Name = "Full 2.0 Hero Chemist Package";
			Hue = 73;
		}
		[Constructable]
		public HeroAlchemyGiftBox( int amount )
		{
			DropItem( new HerosAlchemyArmor2() );
			DropItem( new HerosAlchemyLeggings2() );
			DropItem( new HerosAlchemyHelm2() );
			DropItem( new HerosAlchemyGloves2() );
			DropItem( new HerosAlchemyArms2() );
			DropItem( new HerosAlchemyRobe2() );
			DropItem( new HerosEcruChemistRing2() );
			DropItem( new HerosBauble2() );
			DropItem( new HerosAlchemyEarrings2() );
			DropItem( new HerosAlchemySandals2() );
			DropItem( new HerosAlchemyQuiver2() );
			DropItem( new HerosAlchemyCrook2() );
		}

      public HeroAlchemyGiftBox( Serial serial ) : base( serial ) 
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