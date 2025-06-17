//Created with Script Creator By Marak & Rockstar
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class GorgetOfBaal : PlateGorget
  {

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }
		public override int BaseColdResistance{ get{ return 11; } } 
		public override int BaseEnergyResistance{ get{ return 10; } } 
		public override int BasePhysicalResistance{ get{ return 9; } } 
		public override int BasePoisonResistance{ get{ return 8; } } 
		public override int BaseFireResistance{ get{ return 9; } } 
      
      [Constructable]
		public GorgetOfBaal()
		{
          Name = "Gorget Of Baal";
           Attributes.WeaponSpeed = 10;
                Attributes.WeaponDamage = 5;
                Attributes.AttackChance = 5;
            Weight = 1.0;
            Hue = 2176;
             Movable = false;
		}
		public override void GetProperties(ObjectPropertyList list)
            {
 
            base.GetProperties(list);
            
            list.Add("Demon skin [Apocalypse] [6 pieces based set]");
            }

		public GorgetOfBaal( Serial serial ) : base( serial )
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
