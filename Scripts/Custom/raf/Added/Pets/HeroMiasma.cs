using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a Hero Miasma corpse")]
    public class HeroMiasma : Scorpion
    {
        [Constructable]
        public HeroMiasma()
        {
            Name = "Hero Miasma";
            Hue = 2746;

            SetStr(800, 950);
            SetDex(245, 300);
            SetInt(999, 1200);

            SetHits(2900, 3100);
            SetMana(600, 700);

            SetDamage(23, 28);

            SetDamageType(ResistanceType.Physical, 60);
            SetDamageType(ResistanceType.Poison, 40);

            SetResistance(ResistanceType.Physical, 65, 70);
            SetResistance(ResistanceType.Fire, 65, 70);
            SetResistance(ResistanceType.Cold, 65, 70);
            SetResistance(ResistanceType.Poison, 80, 85);
            SetResistance(ResistanceType.Energy, 65, 70);

            SetSkill(SkillName.Wrestling, 367.0, 367.0);
            SetSkill(SkillName.Tactics, 225.0, 225.0);
            SetSkill(SkillName.MagicResist, 140.0, 140.0);
            SetSkill(SkillName.Poisoning, 128.5, 143.6);
			SetSkill(SkillName.Focus, 235.0, 235.0);
			SetSkill(SkillName.Parry, 290.0, 290.0);
			SetSkill(SkillName.Anatomy, 190.0, 190.0);
			
            Fame = 21000;
            Karma = -21000;

            Tamable = true;
            ControlSlotsMin = 2;
			ControlSlots = 2;
            ControlSlotsMax = 2;
			MinTameSkill = 245;
			
			 for (int i = 0; i < Utility.RandomMinMax(0, 1); i++)

            SetWeaponAbility(WeaponAbility.ArmorIgnore);
        }

        public HeroMiasma(Serial serial)
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
           PackItem(new HeroCoin(15));
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
