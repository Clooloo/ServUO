//Customized By Mrs Death
using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class RedxIIILoincloth : FurSarong
    {
        [Constructable]
        public RedxIIILoincloth()
        {
            
            Hue = 338;
            Name = "[FF7] Red-xIII's Fur Sarong";

            Attributes.AttackChance = 10;
            Attributes.BonusStam = 10;
            Attributes.BonusHits = 10;
            Attributes.BonusStr = 10;
            Attributes.BonusDex = 10;
            Attributes.DefendChance = 10;
            Attributes.BonusMana = 10;
	    Attributes.BonusInt = 10;
	    Attributes.WeaponSpeed = 10;
	    Attributes.WeaponDamage = 10;

            LootType = LootType.Regular;
        }

        public RedxIIILoincloth( Serial serial ) : base( serial )
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