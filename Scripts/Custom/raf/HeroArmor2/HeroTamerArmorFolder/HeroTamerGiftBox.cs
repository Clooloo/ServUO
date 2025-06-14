using System; 
using Server; 
using Server.Items;

namespace Server.Items
{ 
   public class HeroTamerGiftBox : Bag 
   { 
		[Constructable] 
		public HeroTamerGiftBox() : this( 1 ) 
		{ 
			Movable = true;  
			Name = "Full 2.0 Hero Tamer Package";
			Hue = 73;
		}
		[Constructable]
		public HeroTamerGiftBox( int amount )
		{
			DropItem( new HerosTamerArmor2() );
			DropItem( new HerosTamerLeggings2() );
			DropItem( new HerosTamerHelm2() );
			DropItem( new HerosTamerGloves2() );
			DropItem( new HerosTamerArms2() );
			DropItem( new HerosTamerRobe2() );
			DropItem( new HerosTamerRing2() );
			DropItem( new HerosTamerBracelet2() );
			DropItem( new HerosTamerEarrings2() );
			DropItem( new HerosTamerSandals2() );
			DropItem( new HerosTamerQuiver2() );
			DropItem( new HerosHerdingCrook2() );
		}

      public HeroTamerGiftBox( Serial serial ) : base( serial ) 
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
