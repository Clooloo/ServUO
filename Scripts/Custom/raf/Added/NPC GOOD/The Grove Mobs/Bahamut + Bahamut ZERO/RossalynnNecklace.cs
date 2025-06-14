using System;
using Server;

namespace Server.Items
{
	public class RossalynnNecklace : SilverNecklace
	{
		public override int ArtifactRarity{ get{ return 21; } }

		public override int InitMinHits{ get{ return 495; } }
		public override int InitMaxHits{ get{ return 495; } }

		[Constructable]
		public RossalynnNecklace()
		{
			Name = "Rossalynn's Necklace";
			Hue = 34;
			LootType = LootType.Blessed;
			Attributes.BonusDex = 10;
			Attributes.BonusStam = 10;
			Attributes.RegenStam = 5;
			Attributes.WeaponSpeed = 25;
		}

		public RossalynnNecklace( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

		}
	}
}