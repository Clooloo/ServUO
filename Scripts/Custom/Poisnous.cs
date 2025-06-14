using System;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Spells;
using Server.Items;
using Server.SkillHandlers;

namespace Server.Mobiles
{
    [CorpseName("a poisonous destructor corpse")]
    public class PoisonousDestructor : BaseMount
    {
        private static readonly TimeSpan ResetCooldown = TimeSpan.FromSeconds(30);
        private static readonly TimeSpan HealInterval = TimeSpan.FromSeconds(5);
        private DateTime m_LastAttackTime;
        private DateTime m_LastHealTime;
        private int m_PoisonedCount;
        private const double MaxDamage = 10000.0;
        private static readonly double ReflectChance = 0.10;
        private int m_LastDamageDealt;

        [Constructable]
        public PoisonousDestructor() : base("Poisonous Destructor", 0x3E97, 0x3E98, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.1, 0.4)
        {
            Name = "Poisonous Destructor";
            Body = 226;
            BaseSoundID = 362;

            Hue = 1272;

            SetStr(1000, 1200);
            SetDex(200, 750);
            SetInt(600, 950);

            SetHits(500);
            SetMana(60000);

            SetDamage(30, 45);
            SetDamageType(ResistanceType.Poison, 100);

            SetResistance(ResistanceType.Physical, 70, 80);
            SetResistance(ResistanceType.Fire, 69, 90);
            SetResistance(ResistanceType.Cold, 70, 80);
            SetResistance(ResistanceType.Poison, 70, 80);
            SetResistance(ResistanceType.Energy, 70, 80);

            SetSkill(SkillName.Wrestling, 190.0, 210.0);
            SetSkill(SkillName.Tactics, 100.0, 190.0);
            SetSkill(SkillName.MagicResist, 75.0, 165.0);
            SetSkill(SkillName.Poisoning, 350.0);
            SetSkill(SkillName.Parry, 160.0, 200.0);
            SetSkill(SkillName.Healing, 200.0);
           
            Fame = 15000;
            Karma = -15000;
            VirtualArmor = 50;

            Tamable = true;
            ControlSlots = 5;
            MinTameSkill = 120.0;

            m_PoisonedCount = 0;
            m_LastAttackTime = DateTime.Now;
            m_LastHealTime = DateTime.Now;
            m_LastDamageDealt = 0;
        }

        public PoisonousDestructor(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
            writer.Write(m_PoisonedCount);
            writer.Write(m_LastAttackTime);
            writer.Write(m_LastHealTime);
            writer.Write(m_LastDamageDealt);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            m_PoisonedCount = reader.ReadInt();
            m_LastAttackTime = reader.ReadDateTime();
            m_LastHealTime = reader.ReadDateTime();
            m_LastDamageDealt = reader.ReadInt();
        }

        public override void OnThink()
        {
            base.OnThink();

            if (DateTime.Now >= m_LastHealTime + HealInterval && Hits < HitsMax)
            {
                Heal(m_LastDamageDealt / 2); // Cura metade do dano causado pela última habilidade
                m_LastHealTime = DateTime.Now;
            }
        }

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            base.OnDamage(amount, from, willKill);
            if (from != null && from != this && from.Alive && CanBeHarmful(from))
            {
                SporeAttack();
                
                if (Utility.RandomDouble() < ReflectChance)
                {
                    from.Damage(amount, this);
                    from.SendMessage("Your attack was reflected back at you!");
                }
            }
        }

        private void SporeAttack()
        {
            List<Mobile> targets = new List<Mobile>();

            foreach (Mobile m in GetMobilesInRange(12))
            {
                if (m != this && m != ControlMaster && m.Alive && !m.IsDeadBondedPet && CanBeHarmful(m))
                {
                    targets.Add(m);
                }
            }

            int currentPoisonedCount = 0;
            foreach (Mobile target in targets)
            {
                if (target != null && target.Alive && !target.IsDeadBondedPet)
                {
                    target.FixedParticles(0x3709, 10, 30, 5052, 1275, 0, EffectLayer.LeftFoot);
                    target.FixedParticles(0x36BD, 10, 30, 5052, 32, 0, EffectLayer.Waist);
                    target.FixedParticles(0x36B0, 15, 25, 5042, 1153, 0, EffectLayer.CenterFeet);
                    target.FixedParticles(0x372A, 10, 20, 5029, 1359, 0, EffectLayer.LeftFoot);
                    target.FixedParticles(0x36BD, 15, 35, 5054, 43, 0, EffectLayer.LeftFoot);
                    target.FixedParticles(0x374A, 20, 40, 5056, 1281, 0, EffectLayer.Waist);
                    target.FixedParticles(0x375A, 15, 30, 5025, 95, 0, EffectLayer.RightFoot);
                    target.FixedParticles(0x36D4, 25, 50, 5043, 50, 0, EffectLayer.LeftFoot);
                    target.ApplyPoison(this, Poison.Deadly);
                    currentPoisonedCount++;
                }
            }

            m_PoisonedCount += currentPoisonedCount;
            double baseDamage = Utility.RandomMinMax(500, 1000);
            double damageMultiplier = Math.Min(m_PoisonedCount, 100) * 0.1;
            double scaledDamage = baseDamage * (1 + damageMultiplier);
            scaledDamage = Math.Min(scaledDamage, MaxDamage);

            int totalDamageDealt = 0;
            foreach (Mobile target in targets)
            {
                if (target != null && target.Alive && !target.IsDeadBondedPet)
                {
                    int finalDamage = (int)(scaledDamage * (1 - target.PhysicalResistance / 100.0));
                    target.Damage(finalDamage, this);
                    totalDamageDealt += finalDamage;
                }
            }
            
            m_LastDamageDealt = totalDamageDealt;
            m_LastAttackTime = DateTime.Now;
        }
    }
}
