using System;

namespace Server.Mobiles
{
    [CorpseName("a timber wolf corpse")]
    [TypeAlias("Server.Mobiles.Timberwolf")]
    public class DarkenTimberWolf : BaseCreature
    {
        [Constructable]
        public DarkenTimberWolf()
            : base(AIType.AI_Predator, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.Name = "a darken wolf";
            this.Body = 225;
            this.BaseSoundID = 0xE5;
            this.Hue = 1910;

            this.SetStr(66, 90);
            this.SetDex(66, 105);
            this.SetInt(11, 25);

            this.SetHits(64, 738);
            this.SetMana(0);

            this.SetDamage(9, 14);

            this.SetDamageType(ResistanceType.Physical, 100);

            this.SetResistance(ResistanceType.Physical, 15, 20);
            this.SetResistance(ResistanceType.Fire, 5, 10);
            this.SetResistance(ResistanceType.Cold, 10, 15);
            this.SetResistance(ResistanceType.Poison, 5, 10);
            this.SetResistance(ResistanceType.Energy, 5, 10);

            this.SetSkill(SkillName.MagicResist, 27.6, 75.0);
            this.SetSkill(SkillName.Tactics, 30.1, 80.0);
            this.SetSkill(SkillName.Wrestling, 40.1, 60.0);

            this.Fame = 450;
            this.Karma = 0;

            this.VirtualArmor = 18;
            
            this.Tamable = true;
            this.ControlSlots = 2;
            this.MinTameSkill = 100.3;
        }

        public DarkenTimberWolf(Serial serial)
            : base(serial)
        {
        }

        public override int Meat
        {
            get
            {
                return 1;
            }
        }
        public override int Hides
        {
            get
            {
                return 5;
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
                return PackInstinct.Canine;
            }
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