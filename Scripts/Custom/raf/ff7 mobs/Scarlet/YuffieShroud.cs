//Customized By Mrs Death
using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class YuffieShroud : HoodedShroudOfShadows
    {
        [Constructable]
        public YuffieShroud()
        {
            
            Hue = 253;
            Name = "[FF7] Yuffie's Shroud";
	    Attributes.BonusStam = Utility.Random( 10, 20 );
            Attributes.AttackChance = Utility.Random( 10, 20 );
            Attributes.BonusDex = 20;
            Attributes.BonusInt = 20;
            Attributes.BonusHits = Utility.Random( 10, 15 );
            Attributes.BonusMana = Utility.Random( 10, 20 );
            Attributes.DefendChance = Utility.Random( 10, 20 );
            Attributes.LowerManaCost = 10;
            Attributes.LowerRegCost = 20;
            Attributes.BonusStr = 20;

            LootType = LootType.Regular;
        }

        public YuffieShroud( Serial serial ) : base( serial )
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