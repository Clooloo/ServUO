//Customized By Mrs Death
using System;
using Server;

namespace Server.Items
{
	public class SephirothRing : GoldRing
	{
		public override int ArtifactRarity{ get{ return 69; } }

		[Constructable]
		public SephirothRing()
		{
			Name = "Sephiroth's Ring";
			Hue = 1175;
			SkillBonuses.SetValues(0, SkillName.EvalInt, 30);
			SkillBonuses.SetValues(1, SkillName.Tactics, 30);
			Attributes.CastRecovery = 6;
			Attributes.CastSpeed = 4;
			Attributes.BonusDex = 25;
			Attributes.BonusStr = 25;
			Attributes.BonusInt = 25;
			Attributes.BonusHits = 25;
            Attributes.SpellDamage = 50;
            Attributes.WeaponDamage = 50;
		}

		public SephirothRing( Serial serial ) : base( serial )
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