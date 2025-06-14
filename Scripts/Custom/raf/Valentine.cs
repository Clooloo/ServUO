//Script by Safera @Skeldergate.com/Staff
//Learned from Ace2082 runuo.com/community/threads/to-from-coding-question.44038
//Downloadable at UOArchive.com

using System;
using Server.Items;
using Server.Mobiles;
using Server.Prompts;
using Server.Network;


namespace Server.Items
{
		public class ValentineRose : Item
	{
		[Constructable]
		public ValentineRose() : base( 0x234B ) //deed itemid
		{
			Hue = 0x26; //red hue
			LootType = LootType.Blessed;
			Name = "Valentine Rose";
		}

		public ValentineRose( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1042001 );
			}
			else
			{
				from.SendMessage( "Who Would Do You Wish To Give This Gift To?" );
				from.Prompt = new Gift2Prompt( this );
			}
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
	

	public class RedRose : Item
	{

		[Constructable]
		public RedRose( string from, string to )
		{
			Weight = 1.0;
			Name = "a Valentine Rose from " + from + " to " + to;
			ItemID = 0x234B; //gifted roses itemid
			Hue = 0x26; //red
		}

		public RedRose( Serial serial ) : base( serial )
		{
		}
		
//
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
	
			public class Gift2Prompt : Prompt
	{
		public ValentineRose deed;

		public Gift2Prompt( ValentineRose item )
		{
			deed = item;
		}

		public override void OnCancel( Mobile from )
		{
			from.SendMessage( "You decide not to give a gift out." );
		}

		public override void OnResponse( Mobile from, string text )
		{
			if( text.Length >= 1 )
			{
				deed.Delete();
				from.AddToBackpack( new RedRose( from.Name, text ) );
				from.SendMessage( "A Valentine Rose has been added to your backpack." );
			}
			else
			{
				from.SendMessage( "You must address the gift to someone!" );
			}
		}
	}
}
