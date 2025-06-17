//Created with Script Creator By Marak & Rockstar
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class NaturalArms : LeatherArms
  {

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override int BaseColdResistance{ get{ return 11; } } 
		public override int BaseEnergyResistance{ get{ return 6; } } 
		public override int BasePhysicalResistance{ get{ return 6; } } 
		public override int BasePoisonResistance{ get{ return 12; } } 
		public override int BaseFireResistance{ get{ return 13; } } 
      
      [Constructable]
		public NaturalArms()
		{
			Weight = 4;
          Name = "Natural Predator Arms";
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

		public NaturalArms( Serial serial ) : base( serial )
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
