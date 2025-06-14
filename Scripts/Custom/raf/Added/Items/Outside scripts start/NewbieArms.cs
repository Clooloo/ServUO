using System;
using Server;

namespace Server.Items
{
	public class NewbieArms : LeatherArms
	{

		[Constructable]
		public NewbieArms()
		{
			Name = "Newbie Arms";
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
			PhysicalBonus = 10;
			FireBonus = 10;
			ColdBonus = 10;
			PoisonBonus = 10;
			EnergyBonus = 10;
		}

		public NewbieArms( Serial serial ) : base( serial )
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