using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a ancient nightmare corpse")]
    public class AncientNightmare : BaseMount
    {
        [Constructable]
        public AncientNightmare()
            : this("an Ancient Nightmare")
        {
        }

        [Constructable]
        public AncientNightmare(string name)
            : base(name, 0x74, 0x3EA7, AIType.AI_Paladin, FightMode.Closest, 10, 1, 0.1, 0.2)
        {
            this.BaseSoundID = Core.AOS ? 0xA8 : 0x16A;

            this.SetStr(666, 666);
            this.SetDex(666, 666);
            this.SetInt(666, 666);

            this.SetHits(4928, 5315);
			this.SetMana(3328, 3915);

            this.SetDamage(42, 48);

            this.SetDamageType(ResistanceType.Physical, 40);
            this.SetDamageType(ResistanceType.Fire, 40);
            this.SetDamageType(ResistanceType.Energy, 20);

            this.SetResistance(ResistanceType.Physical, 82, 82);
            this.SetResistance(ResistanceType.Fire, 82, 82);
            this.SetResistance(ResistanceType.Cold, 82, 82);
            this.SetResistance(ResistanceType.Poison, 82, 82);
            this.SetResistance(ResistanceType.Energy, 82, 82);

            this.SetSkill(SkillName.Chivalry, 333.4, 334.0);
            this.SetSkill(SkillName.MagicResist, 185.3, 210.0);
            this.SetSkill(SkillName.Tactics, 187.6, 200.0);
            this.SetSkill(SkillName.Parry, 290.0, 290.0);
			this.SetSkill(SkillName.Focus, 310.6, 333.0);
			this.SetSkill(SkillName.Meditation, 310.6, 333.0);
            this.SetSkill(SkillName.Wrestling, 353.5, 355.5);

            this.Fame = 24000;
            this.Karma = -24000;

            this.VirtualArmor = 80;

            this.Tamable = true;
            this.ControlSlots = 2;
            this.MinTameSkill = 270.0;

			switch (Utility.Random(12))
            {
                case 0: PackItem(new BloodOathScroll()); break;
                case 1: PackItem(new HorrificBeastScroll()); break;
                case 2: PackItem(new StrangleScroll()); break;
                case 3: PackItem(new VengefulSpiritScroll()); break;
			}

            switch (Utility.Random(4))
            {
                case 0:
                    {
                        BodyValue = 116;
                        ItemID = 16039;
                        break;
                    }
                case 1:
                    {
                        BodyValue = 177;
                        ItemID = 16053;
                        break;
                    }
                case 2:
                    {
                        BodyValue = 178;
                        ItemID = 16041;
                        break;
                    }
                case 3:
                    {
                        BodyValue = 179;
                        ItemID = 16055;
                        break;
                    }
            }

            if (Utility.RandomDouble() < 0.99)
                Hue = 1910;

            this.PackItem(new SulfurousAsh(Utility.RandomMinMax(3, 5)));

            SetWeaponAbility(WeaponAbility.ArmorIgnore);			
        }

        public AncientNightmare(Serial serial)
            : base(serial)
        {
        }
        public override bool StatLossAfterTame
        {
            get
            {
                return false;
            }
        }
      
        public override int Meat
        {
            get
            {
                return 5;
            }
        }
        public override int Hides
        {
            get
            {
                return 10;
            }
        }
        public override HideType HideType
        {
            get
            {
                return HideType.Barbed;
            }
        }
        public override FoodType FavoriteFood
        {
            get
            {
                return FoodType.Meat;
            }
        }
        public override PackInstinct PackInstinct
        {
            get
            {
                return PackInstinct.Equine;
            }
        }			
        public override bool CanAngerOnTame
        {
            get
            {
                return true;
            }
        }
        public override void GenerateLoot()
        {
            this.AddLoot(LootPack.Rich);
            this.AddLoot(LootPack.Average);
            this.AddLoot(LootPack.LowScrolls);
            this.AddLoot(LootPack.Potions);
        }

        public override int GetAngerSound()
        {
            if (!this.Controlled)
                return 0x16A;

            return base.GetAngerSound();
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

            if (Core.AOS && this.BaseSoundID == 0x16A)
                this.BaseSoundID = 0xA8;
            else if (!Core.AOS && this.BaseSoundID == 0xA8)
                this.BaseSoundID = 0x16A;
        }
    }
}
