using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a Lesser Hero Dragon corpse")]
    public class LesserHeroDragon : BaseCreature
    {
        [Constructable]
        public LesserHeroDragon()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.Name = "a Lesser Hero Dragon";
            this.Body = 0x58E;
            this.BaseSoundID = 362;

            this.SetStr(900, 1100);
            this.SetDex(200, 250);
            this.SetInt(1600, 1800);

            this.SetHits(1800, 2100);

            this.SetDamage(38, 48);

            this.SetDamageType(ResistanceType.Fire, 30);
			this.SetDamageType(ResistanceType.Poison, 20);
			this.SetDamageType(ResistanceType.Physical, 50);

            this.SetResistance(ResistanceType.Physical, 70, 70);
            this.SetResistance(ResistanceType.Fire, 70, 70);
            this.SetResistance(ResistanceType.Cold, 65, 65);
            this.SetResistance(ResistanceType.Poison, 70, 70);
            this.SetResistance(ResistanceType.Energy, 70, 70);

            this.SetSkill(SkillName.SpiritSpeak, 290.0, 290.0);
            this.SetSkill(SkillName.Necromancy, 150.0, 150.0);
            this.SetSkill(SkillName.MagicResist, 150.0, 150.0);
            this.SetSkill(SkillName.Tactics, 250.0, 250.0);
            this.SetSkill(SkillName.Wrestling, 180.0, 180.0);
			this.SetSkill(SkillName.Parry, 180.0, 180.0);
            this.SetSkill(SkillName.Focus, 220.0, 220.0);
			this.SetSkill(SkillName.Anatomy, 150.0, 150.0);
			this.SetSkill(SkillName.Meditation, 150.0, 150.0);
			this.SetSkill(SkillName.Bushido, 233.0, 233.0);
			
            this.Fame = 15000;
            this.Karma = -15000;

            this.VirtualArmor = 60;

            this.Tamable = true;
            ControlSlotsMin = 4;
			ControlSlots = 4;
            ControlSlotsMax = 4;
            this.MinTameSkill = 170;
			
        
            SetWeaponAbility(WeaponAbility.WhirlwindAttack);
        }		

        public LesserHeroDragon(Serial serial)
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
            PackItem(new HeroCoin(10));
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
