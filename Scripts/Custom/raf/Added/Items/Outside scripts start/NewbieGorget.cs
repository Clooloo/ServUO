using System;
using Server;

namespace Server.Items
{
	public class NewbieGorget : LeatherGorget
	{

		[Constructable]
		public NewbieGorget()
		{
			Name = "Newbie Gorget";
			Hue = 1910;
			LootType = LootType.Newbied;
			Attributes.DefendChance = 2;
			Attributes.BonusMana = 2;
			Attributes.BonusStam = 2;
			Attributes.BonusHits = 2;
			Attributes.Luck = 10;
			Attributes.WeaponDamage = 10;
			Attributes.SpellDamage = 10;
			Attributes.LowerRegCost = 20;
			MaxHitPoints = 80;
			HitPoints = 80;
			PhysicalBonus = 8;
			FireBonus = 6;
			ColdBonus = 7;
			PoisonBonus = 7;
			EnergyBonus = 7;
		}

		public NewbieGorget( Serial serial ) : base( serial )
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