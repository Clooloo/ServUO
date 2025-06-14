//	Originally by Methril UODarwinism.com
//		Last Modified:
//
//	Version: 1.0
//
using System; 
using Server; 
using Server.Items;

namespace Server.Items
{ 
   public class EnigmaGiftBox : Bag 
   { 
		[Constructable] 
		public EnigmaGiftBox() : this( 1 ) 
		{ 
			Movable = true;  
			Name = "Full Enigma Package";
			Hue = 73;
		}
		[Constructable]
		public EnigmaGiftBox( int amount )
		{
			DropItem( new SlightlySingedEnigmaChest() );
			DropItem( new SingedEnigmaArms() );
			DropItem( new UnblemishedEnigmaLegs() );
			DropItem( new ThickSkullOfEnigma() );
			DropItem( new CharredEnigmaGloves() );
			DropItem( new EnigmasCrook() );
			DropItem( new EnigmaEcruRing() );
			DropItem( new LuckyNecklace() );
			DropItem( new AlchemistsBauble() );
		//	DropItem( new AlchemyHalf() );
			DropItem( new SmokingShroudOfEnigma() );
			DropItem( new TreatiseonAlchemyTalisman() );
			DropItem( new EnigmaEarrings() );
		}

      public EnigmaGiftBox( Serial serial ) : base( serial ) 
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
