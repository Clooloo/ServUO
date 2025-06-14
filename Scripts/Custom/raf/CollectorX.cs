using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
 
namespace Server.Mobiles
{
    [CorpseName("a CollectorX corpse")]
    public class CollectorX : BaseCreature
    {
      //  private static Type[] m_ArtifactRarity11 = new Type[]
         //   {
          //      typeof( WeaponSpeedIncreaseDeed ),
         //       typeof( WeaponDamageIncreaseDeed ),
         //       typeof( UseBestSkillIncreaseDeed ),
          ////      typeof( SpellDamageIncreaseDeed ),
         //       typeof( MageWeaponIncreaseDeed ),
           //     typeof( HitPoisonAreaIncreaseDeed ),
            //    typeof( HitPhysicalAreaIncreaseDeed ),
        //        typeof( HitMagicArrowIncreaseDeed ),
         //       typeof( HitLowerDefendIncreaseDeed ),
          //      typeof( HitLowerAttackIncreaseDeed ),
           //     typeof( HitLightningIncreaseDeed ),
          //      typeof( HitLeechStamIncreaseDeed ),
          //      typeof( HitLeechManaIncreaseDeed ),
          //      typeof( HitLeechHitsIncreaseDeed ),
          //      typeof( HitHarmIncreaseDeed ),
          //      typeof( HitFireballIncreaseDeed ),
          //      typeof( HitFireAreaIncreaseDeed ),
           //     typeof( HitEnergyAreaIncreaseDeed ),
           //     typeof( HitColdAreaIncreaseDeed ),
           //     typeof( CastSpeedIncreaseDeed )
           // };
 
        public override WeaponAbility GetWeaponAbility()
        {
            switch (Utility.Random(3))
            {
                default:
                case 0: return WeaponAbility.DoubleStrike;
                case 1: return WeaponAbility.WhirlwindAttack;
                case 2: return WeaponAbility.CrushingBlow;
            }
        }
 
        public override void OnDeath(Container c)
        {
            base.OnDeath(c);
            Mobile mobile = DemonKnight.FindRandomPlayer(this);
if (mobile != null)
{
            double chance = Utility.RandomDouble();
            if (chance < 3.00) // 300% chance for drop
            {
               // mobile.AddToBackpack(Loot.Construct(m_ArtifactRarity11[Utility.Random(m_ArtifactRarity11.Length)]));
                mobile.SendLocalizedMessage(1062317); // For your valor in combating the fallen beast, a special reward has been bestowed on you.
            }
}
        }
 
        [Constructable]
        public CollectorX() : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "CollectorsX";
            Body = 318;
            BaseSoundID = 0x165;
 
            SetStr(1000);
            SetDex(500);
            SetInt(10000);
 
            SetHits(80000);
            SetMana(5000);
 
            SetDamage(200);
 
            SetDamageType(ResistanceType.Physical, 125);
            SetDamageType(ResistanceType.Fire, 125);
            SetDamageType(ResistanceType.Cold, 125);
            SetDamageType(ResistanceType.Poison, 125);
            SetDamageType(ResistanceType.Energy, 125);
 
            SetResistance(ResistanceType.Physical, 75);
            SetResistance(ResistanceType.Fire, 75);
            SetResistance(ResistanceType.Cold, 75);
            SetResistance(ResistanceType.Poison, 75);
            SetResistance(ResistanceType.Energy, 75);
 
            SetSkill(SkillName.Necromancy, 120, 120.0);
            SetSkill(SkillName.SpiritSpeak, 120.0, 120.0);
 
            SetSkill(SkillName.DetectHidden, 100.0);
            SetSkill(SkillName.EvalInt, 150.0);
            SetSkill(SkillName.Magery, 155.0);
            SetSkill(SkillName.Meditation, 175.0);
            SetSkill(SkillName.MagicResist, 175.0);
            SetSkill(SkillName.Tactics, 150.0);
            SetSkill(SkillName.Wrestling, 175.0);
 
            Fame = 10000;
            Karma = -12000;
 
            VirtualArmor = 64;
        }
 
        public override void GenerateLoot()
        {
            AddLoot(LootPack.SuperBoss, 10);
			this.PackItem(new MasterCoin(250));
			this.PackItem(new Gold(50000));
            AddLoot(LootPack.HighScrolls, Utility.RandomMinMax(0, 1));
        }
 
        public override bool BardImmune { get { return !Core.SE; } }
        public override bool Unprovokable { get { return Core.SE; } }
        public override bool AreaPeaceImmune { get { return Core.SE; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
 
        public override int TreasureMapLevel { get { return 6; } }
 
        private static bool m_InHere;
 
        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            if (from != null && from != this && !m_InHere)
            {
                m_InHere = true;
                AOS.Damage(from, this, Utility.RandomMinMax(0, 0), 100, 0, 0, 0, 0);
 
                MovingEffect(from, 0xECA, 10, 0, false, false, 0, 0);
                PlaySound(0x491);
 
                if (0.05 > Utility.RandomDouble())
                    Timer.DelayCall(TimeSpan.FromSeconds(1.0), new TimerStateCallback(CreateBones_Callback), from);
 
                m_InHere = false;
            }
        }
 
        public virtual void CreateBones_Callback(object state)
        {
            Mobile from = (Mobile)state;
            Map map = from.Map;
 
            if (map == null)
                return;
 
            int count = Utility.RandomMinMax(0, 0);
 
            for (int i = 0; i < count; ++i)
            {
                int x = from.X + Utility.RandomMinMax(-1, 1);
                int y = from.Y + Utility.RandomMinMax(-1, 1);
                int z = from.Z;
 
                if (!map.CanFit(x, y, z, 16, false, true))
                {
                    z = map.GetAverageZ(x, y);
 
                    if (z == from.Z || !map.CanFit(x, y, z, 16, false, true))
                        continue;
                }
 
                UnholyBone bone = new UnholyBone();
 
                bone.Hue = 0;
                bone.Name = "unholy bones";
                bone.ItemID = Utility.Random(0xECA, 9);
 
                bone.MoveToWorld(new Point3D(x, y, z), map);
            }
        }
 
        public CollectorX(Serial serial) : base(serial)
        {
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
