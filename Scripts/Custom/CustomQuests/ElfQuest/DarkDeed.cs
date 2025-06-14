using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Items
{
	public class DarkDeed : Item
	{
		[Constructable]
		public DarkDeed()
		{
			ItemID = 1;
			Weight = 1.0;
			Name = "A dark deed";
			Movable = false;
		}

		public DarkDeed( Serial serial ) : base( serial )
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

		public override void OnDoubleClick( Mobile from )
		{
			if ( IsChildOf( from.Backpack ) )
				{
				 if ( from.Karma > 100 )
				 	{
				 	from.SendMessage( "The pure good in your heart makes the deed crumble in your hands");
				 	this.Delete();
					}
				 else if ( from.Karma < 100 )
					{
						from.SendMessage( "You are already evil. You have no need for this, but keep it anyways" );
					}
				
			else
			{
				from.SendMessage("You must have the item in your backpack to use it.");
			}
			}
		}
	}
}


