//Created with Script Creator By Marak & Rockstar
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class BardChest : DragonChest
  {

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override int BaseColdResistance{ get{ return 9; } } 
		public override int BaseEnergyResistance{ get{ return 8; } } 
		public override int BasePhysicalResistance{ get{ return 9; } } 
		public override int BasePoisonResistance{ get{ return 12; } } 
		public override int BaseFireResistance{ get{ return 9; } } 
      
      [Constructable]
		public BardChest()
		{
			Weight = 8;
          Name = "War Song Chest";
           Hue = 1387;
      ArmorAttributes.MageArmor = 1;
      Attributes.LowerManaCost = 5;
      Attributes.Luck = 100;
      Attributes.RegenMana = 2;
      Attributes.SpellDamage = 10;
      Movable = false;
		}

		public override void GetProperties(ObjectPropertyList list)
            {
 
            base.GetProperties(list);
            
            list.Add("I'm just a bard? [War song] [5 pieces based set]");
            }

		public BardChest( Serial serial ) : base( serial )
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
