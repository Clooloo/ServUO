//Created with Script Creator By Marak & Rockstar
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class WorkerGloves : RingmailGloves
  {

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		public override int BaseColdResistance{ get{ return 12; } } 
		public override int BaseEnergyResistance{ get{ return 8; } } 
		public override int BasePhysicalResistance{ get{ return 8; } } 
		public override int BasePoisonResistance{ get{ return 6; } } 
		public override int BaseFireResistance{ get{ return 11; } } 

      
      [Constructable]
		public WorkerGloves()
		{
			Weight = 5;
          Name = "Engineer Gloves";
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

		public WorkerGloves( Serial serial ) : base( serial )
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
