//Created with Script Creator By Marak & Rockstar
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class BardArms : DragonArms
  {

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override int BaseColdResistance{ get{ return 7; } } 
		public override int BaseEnergyResistance{ get{ return 9; } } 
		public override int BasePhysicalResistance{ get{ return 9; } } 
		public override int BasePoisonResistance{ get{ return 11; } } 
		public override int BaseFireResistance{ get{ return 5; } } 
      
      [Constructable]
		public BardArms()
		{
			Weight = 3;
          Name = "War Song Arms";
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
		public BardArms( Serial serial ) : base( serial )
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
