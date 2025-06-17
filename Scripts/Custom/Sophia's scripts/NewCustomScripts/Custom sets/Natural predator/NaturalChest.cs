//Created with Script Creator By Marak & Rockstar
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class NaturalChest : LeatherChest
  {

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		public override int BaseColdResistance{ get{ return 8; } } 
		public override int BaseEnergyResistance{ get{ return 14; } } 
		public override int BasePhysicalResistance{ get{ return 7; } } 
		public override int BasePoisonResistance{ get{ return 14; } } 
		public override int BaseFireResistance{ get{ return 11; } } 

      
      [Constructable]
		public NaturalChest()
		{
          Name = "Natural Predator Chest";
          Hue = 1152;
      Attributes.BonusMana = 5;
      Attributes.LowerManaCost = 8;
      Attributes.LowerRegCost = 15;
      Attributes.Luck = 100;
      Attributes.BonusMana = 5;
      Movable = false;
		}
		public override void GetProperties(ObjectPropertyList list)
            {
 
            base.GetProperties(list);
            
            list.Add("Beast Controller [Natural Predator] [4 pieces based set]");
            }

		public NaturalChest( Serial serial ) : base( serial )
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
