using System;
using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefTailoring), typeof(GargishCrimsonCincture))]
    public class HerosCrimsonCincture : HalfApron
	{
		public override bool IsArtifact { get { return true; } }
        public override SetItem SetID{ get{ return SetItem.Virtuoso; } }
		public override int Pieces{ get{ return 5; } }
        public override bool BardMasteryBonus { get { return true; } }
		
        [Constructable]
        public HerosCrimsonCincture()
            : base()
        {
            Hue = 0x485;	
            
			SkillBonuses.SetValues(0, SkillName.Veterinary, 45.0);
			SkillBonuses.SetValues(1, SkillName.Bushido, 25.0);
			SkillBonuses.SetValues(2, SkillName.Musicianship, 25.0);    
            LootType = LootType.Blessed;
            Attributes.BonusDex = 15;
			Attributes.BonusStr = 15;
            Attributes.BonusHits = 20;
            Attributes.RegenMana = 4;
        }
        public HerosCrimsonCincture(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber
        {
            get
            {
                return 1075043;
            }
        }// Heros Crimson Cincture
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
			
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
			
            int version = reader.ReadInt();
        }
    }

    public class HerosGargishCrimsonCincture : GargoyleHalfApron
    {
        public override bool IsArtifact { get { return true; } }

        [Constructable]
        public HerosGargishCrimsonCincture()
            : base()
        {
            Hue = 0x485;	
			SkillBonuses.SetValues(0, SkillName.Provocation, 15.0);
			SkillBonuses.SetValues(1, SkillName.Veterinary, 45.0);
			SkillBonuses.SetValues(2, SkillName.Peacemaking, 15.0);
			SkillBonuses.SetValues(3, SkillName.Bushido, 21.0);
			SkillBonuses.SetValues(4, SkillName.Tracking, 45.0);		
            Attributes.BonusDex = 15;
			Attributes.BonusStr = 15;
            Attributes.BonusHits = 20;
            Attributes.RegenMana = 4;
        }
        public HerosGargishCrimsonCincture(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber
        {
            get
            {
                return 1075043;
            }
        }// Heros Crimson Cincture
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
