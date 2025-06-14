using System;	
using Server;

namespace Server.Items
{
	
	public class HeroShield : MetalKiteShield
	{

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override int ArtifactRarity{ get{ return 50; } }

		[Constructable]
		public HeroShield()
		{
			Name = "Hero Shield";
			Hue = 1161;

			Attributes.DefendChance = 35;
			Attributes.AttackChance = 35;
			PhysicalBonus = 25;
			Attributes.SpellDamage = 35;
			Attributes.WeaponSpeed = 15;
			ArmorAttributes.SelfRepair = 5;
			Attributes.SpellChanneling = 1;

		}

		public HeroShield( Serial serial ) : base( serial )
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