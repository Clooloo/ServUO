using System;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Items
{
	[Flipable(0x99A4, 0x99A3)]
	public class StuffedBunny : Item
	{
				[Constructable]
		public StuffedBunny() : this( 1 )
		{
		}
		[Constructable]
		public StuffedBunny( int amount ) : base( 0x99A4 )
		{
			Name = "A Bunny Toy";
                        Weight = 1.0;
                        Hue = 0;
			
		}

		public StuffedBunny( Serial serial ) : base( serial )
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