//	Originally by Methril UODarwinism.com
//		Last Modified:
//
//	Version: 1.0
//
using System;
using Server;

namespace Server.Items
{
	public class EnigmaFragment : Item //add a name before Deed(LayerDeed or HouseJoinDeed)also for the Deed below same name
	{
		[Constructable]
		public EnigmaFragment() : base(0x14F0) // check this number to be sure its for a blank deed 
		{
			Name = "A Enigma Fragment";
			Hue = 2411;
			ItemID = 0x1870;
			Stackable = true;
			// LootType = LootType.Blessed;
		}

		public EnigmaFragment(Serial serial) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();
		}
	}
}