using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
    public class SBGeneralStore : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBGeneralStore()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {

		        Add( new GenericBuyInfo( typeof( GreaterCurePotion ), 15000, 10, 0x1401, 0 ) );
                Add(new GenericBuyInfo( typeof ( BouraPelt ), 1500, 999, 0x1438, 0));
                Add( new GenericBuyInfo( typeof( SilverSnakeSkin ), 1500, 999, 0x1438, 0 ) );
                Add( new GenericBuyInfo( typeof( EssenceControl ), 15000, 10, 0x13B5, 0 ) );
                Add( new GenericBuyInfo( typeof( MagicalResidue ), 1500, 10, 0xF63, 0 ) );
                Add( new GenericBuyInfo( typeof( GreaterHealPotion ), 150, 10, 0xEC2, 0 ) );
                Add(new GenericBuyInfo(typeof( NeonBeardDye ), 15000, 10, 0xEFF, 0x499));
                Add( new GenericBuyInfo( typeof( RandomTalisman ), 15000, 10, 0x2684, 0 ) );
            //    Add( new GenericBuyInfo( typeof( EverlastingBandage ), 950000, 999, 0xE21, 0));
                Add(new GenericBuyInfo(typeof( RuneEtchedRing ), 20000, 10, 0x108A, 0));
                Add(new GenericBuyInfo(typeof( AnkhPendant ), 25000, 10, 0x3BB5, 0));
                //Add(new GenericBuyInfo(typeof( YardShovel ), 2500, 10, 9569, 0));
                Add(new GenericBuyInfo(typeof(Bandage), 10, 999, 0xE21, 1152));
                Add(new GenericBuyInfo(typeof(LobsterTrap), 15000, 10, 0x44CF, 0));
                Add(new GenericBuyInfo(typeof(NeonHairDye), 15000, 1, 0xEFF, 0x499));
               // Add(new GenericBuyInfo(typeof(ExceptionalSocketHammer), 500000, 1, 0x13E4, 0x5));
                Add(new GenericBuyInfo(typeof(SkinDyeBottle), 700, 999, 0xE26, 1153));
                Add(new GenericBuyInfo(typeof(Tools_sorcery_scroll), 70000, 20, 0x14F0, 0xA2D));
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