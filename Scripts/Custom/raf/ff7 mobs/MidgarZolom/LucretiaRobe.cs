//Customized By Mrs Death
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class LucretiaRobe : Kamishimo
  {
public override int ArtifactRarity{ get{ return 666; } }


      
      [Constructable]
		public LucretiaRobe()
		{
			Weight = 5;
          Name = "[FF7] Lucretia's Robe";
      Hue = 1168;
      Attributes.AttackChance = 23;
      Attributes.BonusDex = 23;
  
      Attributes.BonusInt = 23;
      Attributes.BonusMana = 23;
      Attributes.BonusStam = 23;
      Attributes.DefendChance = 23;
      Attributes.LowerManaCost = 23;
      Attributes.LowerRegCost = 23;
      Attributes.Luck = 666;
      Attributes.ReflectPhysical = 23;
      Attributes.WeaponDamage = 23;
      Attributes.BonusMana = 23;
		}

		public LucretiaRobe( Serial serial ) : base( serial )
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
