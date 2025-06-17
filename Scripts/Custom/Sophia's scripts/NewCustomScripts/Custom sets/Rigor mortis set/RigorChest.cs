//Created with Script Creator By Marak & Rockstar
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class RigorChest : BoneChest
  {
        public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override int BaseColdResistance{ get{ return 15; } } 
		public override int BaseEnergyResistance{ get{ return 4; } } 
		public override int BasePhysicalResistance{ get{ return 11; } } 
		public override int BasePoisonResistance{ get{ return 10; } } 
		public override int BaseFireResistance{ get{ return 6; } } 

      
      [Constructable]
		public RigorChest()
		{
          Weight = 3;
          Name = "Rigor Mortis Chest";
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

		public RigorChest( Serial serial ) : base( serial )
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
