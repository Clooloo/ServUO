// Created with UO Weapon Generator
// Created On: 9/11/2013 3:30:37 PM
// By: Tim

using System;
using Server;

namespace Server.Items
{
    public class GuardianSwords : Daisho
    {
        public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
        public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.WhirlwindAttack; } }
		public override int AosMinDamage{ get{ return 22; } }
		public override int AosMaxDamage{ get{ return 22; } }		
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

        [Constructable]
        public GuardianSwords()
        {
            Name = "Guardian's Sword";
            Hue = 1174;
            LootType = LootType.Blessed;
            Slayer = SlayerName.Exorcism;
			Attributes.AttackChance = 10;
			Attributes.DefendChance = 10;
			Attributes.WeaponDamage = 150;
			Attributes.SpellDamage = 50;
			Attributes.SpellChanneling = 1;
			Attributes.WeaponSpeed = 30;
			WeaponAttributes.SelfRepair = 3;
			WeaponAttributes.HitLeechStam = 50;
			WeaponAttributes.HitLeechMana = 50;
			WeaponAttributes.HitLeechHits = 50;
			WeaponAttributes.HitFireball = 80;
			WeaponAttributes.HitColdArea = 80;
			WeaponAttributes.HitLightning = 80;
			WeaponAttributes.DurabilityBonus = 20;
        }

        public GuardianSwords(Serial serial) : base( serial )
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
    } // End Class
} // End Namespace
