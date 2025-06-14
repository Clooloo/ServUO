using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
    public class GeneralStore : BaseVendor
    {
        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

        [Constructable]
        public GeneralStore() : base( "-Black Market Sockets-" )
        {
            SetSkill( SkillName.ArmsLore, 80.0, 120.0 );
            SetSkill( SkillName.Magery, 80.0, 100.0 );
        }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBGeneralStore () );
        }

        public override VendorShoeType ShoeType
        {
            get{ return VendorShoeType.Boots; }
        }

        public override int GetShoeHue()
        {
            return 0;
        }

        public override void InitOutfit()
        {
            base.InitOutfit();

            AddItem( new Server.Items.Cap( Utility.RandomNeutralHue() ) );
        }

        public GeneralStore(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}
    

