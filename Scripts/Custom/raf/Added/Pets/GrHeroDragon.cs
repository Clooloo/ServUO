using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a Greater Hero Dragon corpse")]
    public class GreaterHeroDragon : BaseCreature
    {
        [Constructable]
        public GreaterHeroDragon()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.Name = "a Greater Hero Dragon";
            this.Body = 826;
            this.BaseSoundID = 362;

            this.SetStr(1800, 2000);
            this.SetDex(600, 700);
            this.SetInt(2300, 2500);

            this.SetHits(5100, 5600);

            this.SetDamage(75, 90);

            this.SetDamageType(ResistanceType.Fire, 75);
			this.SetDamageType(ResistanceType.Poison, 20);
			this.SetDamageType(ResistanceType.Physical, 5);

            this.SetResistance(ResistanceType.Physical, 85, 85);
            this.SetResistance(ResistanceType.Fire, 85, 85);
            this.SetResistance(ResistanceType.Cold, 85, 85);
            this.SetResistance(ResistanceType.Poison, 85, 85);
            this.SetResistance(ResistanceType.Energy, 85, 85);

            this.SetSkill(SkillName.EvalInt, 450.0, 450.0);
            this.SetSkill(SkillName.Magery, 233.0, 233.0);
            this.SetSkill(SkillName.MagicResist, 233.0, 233.0);
            this.SetSkill(SkillName.Tactics, 345.0, 345.0);
            this.SetSkill(SkillName.Wrestling, 350.0, 350.0);
			this.SetSkill(SkillName.Parry, 233.0, 233.0);
            this.SetSkill(SkillName.Focus, 345.0, 345.0);
			this.SetSkill(SkillName.Anatomy, 233.0, 233.0);
			this.SetSkill(SkillName.Meditation, 233.0, 233.0);
			this.SetSkill(SkillName.Bushido, 283.0, 283.0);
			
            this.Fame = 15000;
            this.Karma = -15000;

            this.VirtualArmor = 60;

            this.Tamable = true;
            ControlSlotsMin = 4;
			ControlSlots = 4;
            ControlSlotsMax = 5;
            this.MinTameSkill = 265;

            SetWeaponAbility(WeaponAbility.WhirlwindAttack);
        }
        public GreaterHeroDragon(Serial serial)
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
                return 7;
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
            PackItem(new HeroCoin(20));
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
