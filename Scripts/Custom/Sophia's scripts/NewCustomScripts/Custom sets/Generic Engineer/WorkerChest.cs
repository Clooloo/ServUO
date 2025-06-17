//Created with Script Creator By Marak & Rockstar
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class WorkerChest : RingmailChest
  {

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		public override int BaseColdResistance{ get{ return 13; } } 
		public override int BaseEnergyResistance{ get{ return 8; } } 
		public override int BasePhysicalResistance{ get{ return 10; } } 
		public override int BasePoisonResistance{ get{ return 8; } } 
		public override int BaseFireResistance{ get{ return 6; } } 

      
      [Constructable]
		public WorkerChest()
		{
			Weight = 10;
          Name = "Engineer Chest";
          Hue = 1989;
          ArmorAttributes.MageArmor = 1;
      ArmorAttributes.SelfRepair = 3;
      Attributes.LowerRegCost = 20;
      Movable = false;
		}
		public override void GetProperties(ObjectPropertyList list)
            {
 
            base.GetProperties(list);
            
            list.Add("Just do it... [Generic Engineer] [4 pieces based set]");
            }

		public WorkerChest( Serial serial ) : base( serial )
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
