using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a Hero Dragon corpse")]
    public class HeroDragon : BaseCreature
    {
        [Constructable]
        public HeroDragon()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.Name = "a Hero Dragon";
            this.Body = Utility.RandomList(12, 59);
            this.BaseSoundID = 362;

            this.SetStr(1200, 1400);
            this.SetDex(300, 400);
            this.SetInt(2100, 2300);

            this.SetHits(2800, 3200);

            this.SetDamage(52, 62);

            this.SetDamageType(ResistanceType.Fire, 30);
			this.SetDamageType(ResistanceType.Poison, 20);
			this.SetDamageType(ResistanceType.Physical, 50);

            this.SetResistance(ResistanceType.Physical, 75, 75);
            this.SetResistance(ResistanceType.Fire, 75, 75);
            this.SetResistance(ResistanceType.Cold, 70, 70);
            this.SetResistance(ResistanceType.Poison, 75, 75);
            this.SetResistance(ResistanceType.Energy, 75, 75);

            this.SetSkill(SkillName.SpiritSpeak, 365.0, 365.0);
            this.SetSkill(SkillName.Necromancy, 190.0, 190.0);
            this.SetSkill(SkillName.MagicResist, 190.0, 190.0);
            this.SetSkill(SkillName.Tactics, 280.0, 280.0);
            this.SetSkill(SkillName.Wrestling, 250.0, 250.0);
			this.SetSkill(SkillName.Parry, 190.0, 190.0);
            this.SetSkill(SkillName.Focus, 280.0, 280.0);
			this.SetSkill(SkillName.Anatomy, 190.0, 190.0);
			this.SetSkill(SkillName.Meditation, 190.0, 190.0);
			this.SetSkill(SkillName.Bushido, 233.0, 233.0);
			
            this.Fame = 15000;
            this.Karma = -15000;

            this.VirtualArmor = 60;

            this.Tamable = true;
            ControlSlotsMin = 4;
			ControlSlots = 4;
            ControlSlotsMax = 4;
            this.MinTameSkill = 215;
        
            SetWeaponAbility(WeaponAbility.WhirlwindAttack);
        }
        public HeroDragon(Serial serial)
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

        public override bool ReacquireOnMovement
        {
            get
            {
                return !this.Controlled;
            }
        }
     
        public override bool AutoDispel
        {
            get
            {
                return !this.Controlled;
            }
        }
        public override int TreasureMapLevel
        {
            get
            {
                return 4;
            }
        }
        public override int Meat
        {
            get
            {
                return 19;
            }
        }
        public override int DragonBlood
        {
            get
            {
                return 8;
            }
        }
        public override int Hides
        {
            get
            {
                return 20;
            }
        }
        public override HideType HideType
        {
            get
            {
                return HideType.Barbed;
            }
        }
        public override int Scales
        {
            get
            {
                return 7;
            }
        }
        public override ScaleType ScaleType
        {
            get
            {
                return (this.Body == 12 ? ScaleType.Yellow : ScaleType.Red);
            }
        }
        public override FoodType FavoriteFood
        {
            get
            {
                return FoodType.Meat;
            }
        }
        public override bool CanAngerOnTame
        {
            get
            {
                return true;
            }
        }
        public override bool CanFly
        {
            get
            {
                return true;
            }
        }
		
        public override void GenerateLoot()
        {
            this.AddLoot(LootPack.FilthyRich, 2);
            this.AddLoot(LootPack.Gems, 8);
            PackItem(new HeroCoin(15));
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
