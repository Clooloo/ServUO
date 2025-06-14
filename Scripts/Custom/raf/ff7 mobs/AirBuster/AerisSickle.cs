// Customized By Mrs Death
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class AerisSickle : BoneHarvester
  {
		public override int OldMinDamage{ get{ return 20; } }
		public override int AosMinDamage{ get{ return 20; } }
		public override int OldMaxDamage{ get{ return 40; } }
		public override int AosMaxDamage{ get{ return 40; } }
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ShadowStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }

		public override int DefMaxRange{ get{ return 5; } }

      [Constructable]
		public AerisSickle()
		{
          Name = "[FF7] Aeris' Princess Guard";
          Hue = 1166;
      Attributes.BonusStr = 15;
      Attributes.BonusDex = 15;
      Attributes.BonusInt = 15;
      Attributes.BonusHits = 10;
      Attributes.BonusStam = 10;
      Attributes.BonusMana = 10;


      WeaponAttributes.UseBestSkill = 1;
      Attributes.AttackChance = 20;
      Attributes.DefendChance = 20;
      Attributes.ReflectPhysical = 20;
      WeaponAttributes.HitHarm = 100;
      WeaponAttributes.HitLightning = 75;
      WeaponAttributes.HitFireball = 50;
      Attributes.SpellDamage = 20;
      Attributes.WeaponDamage = 20;
      Attributes.WeaponSpeed = 20;
      LootType = LootType.Regular;
     Slayer = SlayerName.Repond ;
		}

		public AerisSickle( Serial serial ) : base( serial )
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
	}
}
