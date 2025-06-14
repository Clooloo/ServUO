//Customized By Mrs Death
using System;
using Server;

namespace Server.Items
{
	public class SephirothArms : LeafArms
	{
		public override int ArtifactRarity{ get{ return 69; } }

		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 15; } }
		public override int BaseColdResistance{ get{ return 15; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 15; } }

		public override int InitMinHits{ get{ return 100; } }
		public override int InitMaxHits{ get{ return 300; } }
			public override bool CanBeWornByGargoyles{ get{ return true; } }

		[Constructable]
		public SephirothArms()
		{
			Name = "[FF7] Sephiroth's Arms";
			Hue = 1175;
                  Attributes.BonusDex = 25;
                  Attributes.BonusHits = 15;
                  Attributes.BonusInt = 25;
                  Attributes.BonusMana = 20;
                  Attributes.BonusStam = 20;
                  Attributes.BonusStr = 25;
                  Attributes.CastRecovery = 2;
                  Attributes.CastSpeed = 2;
                  Attributes.LowerManaCost = 15;
                  Attributes.LowerRegCost = 20;
                  Attributes.ReflectPhysical = 25;
                  Attributes.SpellDamage = 30;
		}

		public SephirothArms( Serial serial ) : base( serial )
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

			if ( Hue == 0x55A )
				Hue = 0x4F6;
		}
	}
}