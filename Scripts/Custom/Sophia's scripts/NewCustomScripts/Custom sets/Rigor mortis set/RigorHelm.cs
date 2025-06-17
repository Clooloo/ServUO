//Created with Script Creator By Marak & Rockstar
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class RigorHelm : BoneHelm
  {
    public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override int BaseColdResistance{ get{ return 11; } } 
		public override int BaseEnergyResistance{ get{ return 6; } } 
		public override int BasePhysicalResistance{ get{ return 11; } } 
		public override int BasePoisonResistance{ get{ return 9; } } 
		public override int BaseFireResistance{ get{ return 17; } } 

      
      [Constructable]
		public RigorHelm()
		{
         Weight = 3;
          Name = "Rigor Mortis Helm";
          Hue = 1390;
      ArmorAttributes.MageArmor = 1;
      Attributes.BonusMana = 5;
      Attributes.LowerManaCost = 8;
      Attributes.RegenMana = 2;
      Movable = false;
		}
public override void GetProperties(ObjectPropertyList list)
            {
 
            base.GetProperties(list);
            
            list.Add("Death does not hurt, or does it?");
            }
		public RigorHelm( Serial serial ) : base( serial )
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
