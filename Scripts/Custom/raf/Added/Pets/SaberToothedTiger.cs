using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a saber-toothed tiger corpse")]
    public class SaberToothedTiger : BaseCreature
    {
        [Constructable]
        public SaberToothedTiger()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.Name = "a Saber-Toothed Tiger";
            this.Body = 251;
            this.Hue = 2579;

            this.SetStr(276, 325);
            this.SetDex(156, 175);
            this.SetInt(76, 105);

            this.SetHits(251, 280);

            this.SetDamage(18, 24);

            this.SetStr(1201, 1410);
            this.SetDex(171, 270);
            this.SetInt(301, 325);

            this.SetHits(901, 1100);
            this.SetMana(60);

            this.SetDamage(20, 30);

            this.SetDamageType(ResistanceType.Physical, 100);

            this.SetResistance(ResistanceType.Physical, 55, 70);
            this.SetResistance(ResistanceType.Fire, 70, 90);
            this.SetResistance(ResistanceType.Cold, 15, 25);
            this.SetResistance(ResistanceType.Poison, 40, 50);
            this.SetResistance(ResistanceType.Energy, 40, 50);

            this.SetSkill(SkillName.Anatomy, 75.1, 80.0);
            this.SetSkill(SkillName.MagicResist, 85.1, 100.0);
            this.SetSkill(SkillName.Tactics, 100.1, 110.0);
            this.SetSkill(SkillName.Wrestling, 100.1, 120.0);

            this.Fame = 18000;
            this.Karma = -18000;

            //this.PackNecroReg(6, 8);

            this.Tamable = true;
            this.ControlSlots = 3;
            this.MinTameSkill = 98.7;
			
            switch ( Utility.Random(10))
            {
                case 0:
                    this.PackItem(new LeftArm());
                    break;
                case 1:
                    this.PackItem(new RightArm());
                    break;
                case 2:
                    this.PackItem(new Torso());
                    break;
                case 3:
                    this.PackItem(new Bone());
                    break;
                case 4:
                    this.PackItem(new RibCage());
                    break;
                case 5:
                    this.PackItem(new RibCage());
                    break;
                case 6:
                    this.PackItem(new BonePile());
                    break;
                case 7:
                    this.PackItem(new BonePile());
                    break;
                case 8:
                    this.PackItem(new BonePile());
                    break;
                case 9:
                    this.PackItem(new BonePile());
                    break;
            }
        }

        public SaberToothedTiger(Serial serial)
            : base(serial)
        {
        }

        public override bool StatLossAfterTame
        {
            get
            {
                return true;
            }
        }

        public override bool BleedImmune
        {
            get
            {
                return true;
            }
        }
        public override Poison PoisonImmune
        {
            get
            {
                return Poison.Greater;
            }
        }
      /*  public override Poison HitPoison
        {
            get
            {
                return Poison.Greater;
            }
        }*/
         public override int Meat
        {
            get
            {
                return 16;
            }
        }
        public override int Hides
        {
            get
            {
                return 60;
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

        public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.BleedAttack;
        }

        public override int GetAngerSound()
        {
            return 0x518;
        }

        public override int GetIdleSound()
        {
            return 0x517;
        }

        public override int GetAttackSound()
        {
            return 0x516;
        }

        public override int GetHurtSound()
        {
            return 0x519;
        }

        public override int GetDeathSound()
        {
            return 0x515;
        }

        public override void GenerateLoot()
        {
            this.AddLoot(LootPack.Rich, 2);
            //this.AddLoot(LootPack.MedScrolls, 2);
            // TODO: Bone Pile
        }

        public override bool IsEnemy(Mobile m)
        {
            if (m.Player && m.FindItemOnLayer(Layer.TwoHanded) is BeastLord)
                return false;

            return base.IsEnemy(m);
        }

        public override void AggressiveAction(Mobile aggressor, bool criminal)
        {
            base.AggressiveAction(aggressor, criminal);

            Item item = aggressor.FindItemOnLayer(Layer.TwoHanded);

            if (item is BeastLord)
            {
                AOS.Damage(aggressor, 50, 0, 100, 0, 0, 0);
                item.Delete();
                aggressor.FixedParticles(0x36BD, 20, 10, 5044, EffectLayer.Head);
                aggressor.PlaySound(0x307);
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