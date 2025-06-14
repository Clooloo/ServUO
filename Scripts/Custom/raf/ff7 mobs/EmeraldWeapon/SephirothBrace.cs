//C:\Users\ruste\OneDrive\Desktop\UOHQOSIUpdate-master\UOHQOSIUpdate-master\Scripts\Custom\extras\ff7 mobs\EmeraldWeapon\SephirothBrace.cs
//Customized By Mrs Death

using System;
using Server;

namespace Server.Items
{
	public class SephirothBrace : GoldBracelet
	{
		public override int ArtifactRarity{ get{ return 69; } }
		
		private Mobile m_Owner;

		[Constructable]
		public SephirothBrace()
		{
			Name = "Sephiroth's Bracelet";
			Hue = 1175;
			SkillBonuses.SetValues(0, SkillName.EvalInt, 30);
			SkillBonuses.SetValues(1, SkillName.Tactics, 30);
			Attributes.CastRecovery = 6;
			Attributes.CastSpeed = 4;
			Attributes.BonusDex = 25;
			Attributes.BonusStr = 25;
			Attributes.BonusInt = 25;
			Attributes.LowerManaCost = 20;
			Attributes.LowerRegCost = 20;
            Attributes.SpellDamage = 50;
            Attributes.WeaponDamage = 50;
		}

		public SephirothBrace( Serial serial ) : base( serial )
		{
		}

 		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

            writer.Write(m_Owner); // Version 1
		}		
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    m_Owner = reader.ReadMobile();
                    break;
            }
		}		
    }
}
