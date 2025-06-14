using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Items
{
	public class LightDeed : Item
	{
		[Constructable]
		public LightDeed()
		{
			ItemID = 1;
			Weight = 1.0;
			Name = "A dark deed";
			Movable = false;
		}

		public LightDeed( Serial serial ) : base( serial )
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


