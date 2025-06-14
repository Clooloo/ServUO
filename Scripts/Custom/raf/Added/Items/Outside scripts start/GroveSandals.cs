using System;
using Server;

namespace Server.Items
{
	public class HeroquestSandals : Sandals
	{

		[Constructable]
		public HeroquestSandals()
		{
			Name = "Thank You For Playing The HeroQuest";
			Hue = 1910;
			LootType = LootType.Blessed;
			Attributes.BonusMana = 2;
			Attributes.BonusStam = 2;
			Attributes.BonusHits = 2;
			Attributes.Luck = 10;
			Attributes.CastRecovery = 1;
			Attributes.CastSpeed = 1;
		}

		public HeroquestSandals( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

	}
}