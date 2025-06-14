using System;
using Server;

namespace Server.Items
{
	public class NewbieLegs : LeatherLegs
	{

		[Constructable]
		public NewbieLegs()
		{
			Name = "Newbie Legs";
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
			PhysicalBonus= 8;
			FireBonus = 8;
			ColdBonus = 8;
			PoisonBonus = 8;
			EnergyBonus = 8;
		}

		public NewbieLegs( Serial serial ) : base( serial )
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