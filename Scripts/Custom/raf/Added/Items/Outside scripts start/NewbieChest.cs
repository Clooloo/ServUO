using System;
using Server;

namespace Server.Items
{
	public class NewbieChest : LeatherChest
	{

		[Constructable]
		public NewbieChest()
		{
			Name = "Newbie Chest";
			Hue = 1910;
			LootType = LootType.Newbied;
			Attributes.DefendChance = 5;
			Attributes.BonusMana = 5;
			Attributes.BonusStam = 5;
			Attributes.BonusHits = 5;
			Attributes.Luck = 10;
			Attributes.WeaponDamage = 10;
			Attributes.SpellDamage = 10;
			Attributes.LowerRegCost = 20;
			MaxHitPoints = 80;
			HitPoints = 80;
			PhysicalBonus = 8;
			FireBonus = 8;
			ColdBonus = 8;
			PoisonBonus = 8;
			EnergyBonus = 8;
		}

		public NewbieChest( Serial serial ) : base( serial )
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