//Created with Script Creator By Marak & Rockstar
//Kevin Evans helped too xD
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Baalcloak : Cloak
  {


		public override int BasePhysicalResistance { get { return 8; } }
        public override int BaseFireResistance { get { return 7; } }
        public override int BaseColdResistance { get { return 8; } }
        public override int BasePoisonResistance { get { return 7; } }
        public override int BaseEnergyResistance { get { return 11; } }
      
      [Constructable]
		public Baalcloak()
		{
          Name = "Baal's cloak";
          Attributes.WeaponDamage = 5;
          Attributes.AttackChance = 5;
          Movable = false;
          Weight = 6.0;
          Hue = 2176;
		}

		public Baalcloak( Serial serial ) : base( serial )
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
