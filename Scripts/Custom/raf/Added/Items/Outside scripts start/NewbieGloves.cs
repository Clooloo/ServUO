using System;
using Server;

namespace Server.Items
{
	public class NewbieGloves : LeatherGloves
	{

		[Constructable]
		public NewbieGloves()
		{
			Name = "Newbie Gloves";
			Hue = 1910;
			LootType = LootType.Newbied;
			Attributes.AttackChance = 5;
			Attributes.BonusMana = 5;
			Attributes.BonusStam = 5;
			Attributes.BonusHits = 5;
			Attributes.Luck = 10;
			Attributes.WeaponDamage = 10;
			Attributes.SpellDamage = 10;
			Attributes.LowerRegCost = 20;
			MaxHitPoints = 80;
			HitPoints = 80;
			PhysicalBonus = 12;
			FireBonus = 12;
			ColdBonus = 12;
			PoisonBonus = 12;
			EnergyBonus = 12;
		}

		public NewbieGloves( Serial serial ) : base( serial )
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