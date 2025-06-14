using System; 
using Server; 
using Server.Items;

namespace Server.Items
{ 
   public class HeroGiftBox : Bag 
   { 
		[Constructable] 
		public HeroGiftBox() : this( 1 ) 
		{ 
			Movable = true;  
			Name = "Full 2.0 Hero Warrior Package";
			Hue = 73;
		}
		[Constructable]
		public HeroGiftBox( int amount )
		{
			DropItem( new HerosArmor2() );
			DropItem( new HerosLeggings2() );
			DropItem( new HerosHelm2() );
			DropItem( new HerosGloves2() );
			DropItem( new HerosArms2() );
			DropItem( new HerosRobe2() );
			DropItem( new HerosRing2() );
			DropItem( new HerosBracelet2() );
			DropItem( new HerosEarrings2() );
			DropItem( new HerosSandals2() );
			DropItem( new HerosEQuiver2() );
		}

      public HeroGiftBox( Serial serial ) : base( serial ) 
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