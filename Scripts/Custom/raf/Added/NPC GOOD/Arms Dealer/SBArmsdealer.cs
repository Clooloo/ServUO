using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
    public class SBArmsdealer : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBArmsdealer()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
		Add( new GenericBuyInfo( typeof( FireNeedle ), 15000, 1, 0x1401, 0 ) );
                Add( new GenericBuyInfo( typeof( EarthShaker ), 15000, 1, 0x1438, 0 ) );
                Add( new GenericBuyInfo( typeof( StormBringer ), 15000, 1, 0x13B5, 0 ) );
                Add( new GenericBuyInfo( typeof( TheImpaler ), 15000, 1, 0xF63, 0 ) );
                Add( new GenericBuyInfo( typeof( TheCleaver ), 15000, 1, 0xEC2, 0 ) );
                Add( new GenericBuyInfo( typeof( WaveCrusher ), 15000, 1, 0x13B1, 0 ) );
                Add( new GenericBuyInfo( typeof( ShroudOfBale ), 15000, 1, 0x2684, 0 ) );
                Add( new GenericBuyInfo( typeof( Bandage ), 15, 999, 0xEFA, 0));
                Add(new GenericBuyInfo(typeof( RuneEtchedRing ), 20000, 1, 0x108A, 0));
                Add(new GenericBuyInfo(typeof(AnkhPendant), 25000, 1, 0x3BB5, 0));
                //Add(new GenericBuyInfo(typeof(YardShovel), 25000, 1, 9569, 0));
                //Add(new GenericBuyInfo(typeof(DruidSpellbook), 1500000, 1, 0xEFA, 0));
                //Add(new GenericBuyInfo(typeof(RangerSpellbook), 1500000, 1, 0xEFA, 0));
                //Add(new GenericBuyInfo(typeof(RogueSpellbook), 1500000, 1, 0xEFA, 0));
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(FireNeedle), 1500);
                Add(typeof(EarthShaker), 1500);
                Add(typeof(WaveCrusher), 1500);
                Add(typeof(StormBringer), 1500);
                Add(typeof(TheImpaler), 2000);
                Add(typeof(TheCleaver), 1000);

            }
        }
    }
}