using System; 
using Server; 
using Server.Items;

namespace Server.Items
{ 
   public class HeroMagiGiftBox : Bag 
   { 
		[Constructable] 
		public HeroMagiGiftBox() : this( 1 ) 
		{ 
			Movable = true;  
			Name = "Full 2.0 Hero Magi Package";
			Hue = 73;
		}
		[Constructable]
		public HeroMagiGiftBox( int amount )
		{
			DropItem( new HerosMagiArmor2() );
			DropItem( new HerosMagiLeggings2() );
			DropItem( new HerosMagiHelm2() );
			DropItem( new HerosMagiGloves2() );
			DropItem( new HerosMagiArms2() );
			DropItem( new HerosMagiRobe2() );
			DropItem( new HerosMagiRing2() );
			DropItem( new HerosMagiBracelet2() );
			DropItem( new HerosMagiEarrings2() );
			DropItem( new HerosMagiSandals2() );
			DropItem( new HerosMagiQuiver2() );
		}

      public HeroMagiGiftBox( Serial serial ) : base( serial ) 
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