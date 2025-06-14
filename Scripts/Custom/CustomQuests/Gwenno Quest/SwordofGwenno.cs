using System;
using Server;

namespace Server.Items
{
	public class SwordofGwenno : Broadsword
	{
		public override int ArtifactRarity{ get{ return 1591; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public SwordofGwenno()
		{
			Name = "The Sword Of Gwenno";
			Hue = 1131;
			
			DurabilityLevel = WeaponDurabilityLevel.Indestructible;
         	Quality = ItemQuality.Exceptional;

				WeaponAttributes.HitLightning = 20;
				WeaponAttributes.HitDispel = 70;
				WeaponAttributes.HitFireball = 60;
				WeaponAttributes.HitHarm = 70;
				WeaponAttributes.HitMagicArrow = 65;
				WeaponAttributes.HitLeechHits = 40;
				WeaponAttributes.HitLeechMana = 40;
				WeaponAttributes.HitLeechStam = 50;
				WeaponAttributes.HitLowerAttack = 40;
				WeaponAttributes.HitLowerDefend = 40;
				Attributes.WeaponDamage = 100;
				Attributes.RegenHits = 5;
				Attributes.SpellChanneling = 1;
				Attributes.CastSpeed = 2;
				Attributes.RegenMana = 5;
				Slayer = SlayerName.Silver; 
		}

		

		public SwordofGwenno( Serial serial ) : base( serial )
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