using System;
using Server;

namespace Server.Items
{
	public class NewbieHat : MagicWizardsHat
	{

		[Constructable]
		public NewbieHat()
		{
			Name = "Newbie Hat";
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
			Attributes.NightSight = 1;
			Resistances.Physical = 10;
			Resistances.Fire = 10;
			Resistances.Cold = 10;
			Resistances.Poison = 10;
			Resistances.Energy = 10;
			MaxHitPoints = 80;
			HitPoints = 80;
		}

		public NewbieHat( Serial serial ) : base( serial )
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