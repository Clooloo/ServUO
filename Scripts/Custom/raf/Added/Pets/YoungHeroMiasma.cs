using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a Young Hero Miasma corpse")]
    public class YoungHeroMiasma : Scorpion
    {
        [Constructable]
        public YoungHeroMiasma()
        {
            Name = "Young Hero Miasma";
            Hue = 2746;

            SetStr(420, 680);
            SetDex(145, 200);
            SetInt(999, 1200);

            SetHits(850, 950);
            SetMana(1100, 1300);

            SetDamage(17, 22);

            SetDamageType(ResistanceType.Physical, 60);
            SetDamageType(ResistanceType.Poison, 40);

            SetResistance(ResistanceType.Physical, 65, 70);
            SetResistance(ResistanceType.Fire, 65, 70);
            SetResistance(ResistanceType.Cold, 65, 70);
            SetResistance(ResistanceType.Poison, 80, 85);
            SetResistance(ResistanceType.Energy, 65, 70);

            SetSkill(SkillName.Wrestling, 167.0, 177.0);
            SetSkill(SkillName.Tactics, 185.0, 185.0);
            SetSkill(SkillName.MagicResist, 140.0, 140.0);
            SetSkill(SkillName.Poisoning, 128.5, 143.6);
			SetSkill(SkillName.Focus, 235.0, 235.0);
			SetSkill(SkillName.Parry, 150.0, 150.0);
			SetSkill(SkillName.Anatomy, 190.0, 190.0);
			
            Fame = 21000;
            Karma = -21000;

            Tamable = true;
            ControlSlotsMin = 2;
			ControlSlots = 2;
            ControlSlotsMax = 2;
			MinTameSkill = 150;

            SetWeaponAbility(WeaponAbility.ArmorIgnore);
        }

        public YoungHeroMiasma(Serial serial)
            : base(serial)
        {
        }
		public override bool CanBeParagon { get { return false; } }

        public override bool GivesMLMinorArtifact
        {
            get
            {
                return false;
            }
        }
        public override int TreasureMapLevel
        {
            get
            {
                return 5;
            }
        }
        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich, 2);
           PackItem(new HeroCoin(10));
        }

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
