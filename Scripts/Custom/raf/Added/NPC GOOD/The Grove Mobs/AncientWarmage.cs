using System;
using Server.Items;
using Server.Spells;

namespace Server.Mobiles
{
    [CorpseName("a WarMage corpse")]
    public class WarMage : BaseCreature
    {
        private static readonly int[] m_FireNorth = new int[]
        {
            -1, -1,
            1, -1,
            -1, 2,
            1, 2
        };
        private static readonly int[] m_FireEast = new int[]
        {
            -1, 0,
            2, 0
        };
        private Mobile m_MorphedInto;
        private DateTime m_LastMorph;
        private DateTime m_NextFireRing;
        [Constructable]
        public WarMage()
            : base(AIType.AI_NecroMage, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            this.Name = this.DefaultName;
            this.Body = 124;
            this.Hue = this.DefaultHue;


            this.ActiveSpeed = 0.1;
            this.PassiveSpeed = 0.2;

            this.SetStr(636, 805);
            this.SetDex(4212, 5262);
            this.SetInt(3317, 3399);

            this.SetHits(50201, 65211);
            this.SetStam(3212, 6262);
            this.SetMana(163170, 277990);

            this.SetDamage(25, 35);

            this.SetDamageType(ResistanceType.Physical, 40);
            this.SetDamageType(ResistanceType.Cold, 20);     	
            this.SetDamageType(ResistanceType.Fire, 40);

            this.SetResistance(ResistanceType.Physical, 95, 98);
            this.SetResistance(ResistanceType.Fire, 40, 50);
            this.SetResistance(ResistanceType.Cold, 92, 98);
            this.SetResistance(ResistanceType.Poison, 80, 90);
            this.SetResistance(ResistanceType.Energy, 43, 60);

            this.SetSkill(SkillName.Wrestling, 250.4, 342.5);
            this.SetSkill(SkillName.Tactics, 151.1, 128.3);
            this.SetSkill(SkillName.MagicResist, 351.6, 582.2);
            this.SetSkill(SkillName.Magery, 311.6, 420.5);
            this.SetSkill(SkillName.EvalInt, 151.5, 188.8);
            this.SetSkill(SkillName.Meditation, 1901.7, 1908.5);
	    this.SetSkill(SkillName.Necromancy, 350);
            this.SetSkill(SkillName.SpiritSpeak, 350);
	    this.SetSkill(SkillName.Focus, 1110);

            this.Fame = 15000;
            this.Karma = -15000;

            this.PackItem (new CrystallineBlackrock(10));
            this.PackItem (new RelicFragment(10));
            this.PackItem (new RAD());
            this.PackGem(2);
        }
		public override void OnDeath(Container c)
		{
			base.OnDeath(c);
                  c.DropItem( new MasterCoin( 30 ) );
                  

            if (0.02 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Herodeed());             
            }

           // if (0.02 > Utility.RandomDouble()) // 
          //  {           
          //      c.DropItem(new HeroWeapondeed());             
          //  }

            if (0.04 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Robedeed());             
            }


       //     if (0.02 > Utility.RandomDouble()) // 
        //    {           
        //        c.DropItem(new EverlastingBandage());             
        //    }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicClothDeed());             

			}

            if (0.02 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new CthulhuArmorDeed());             
            }

            }

                public override Poison HitPoison { get { return Poison.Deadly; } } 
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }  
	        public override bool BardImmune{ get{ return true; } }
                public override bool AlwaysMurderer { get { return true; } }
                
                public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.ArmorIgnore;
        }



        public WarMage(Serial serial)
            : base(serial)
        {
        }

        public virtual string DefaultName
        {
            get
            {
                return "Ancient WarMage";
            }
        }
        public virtual int DefaultHue
        {
            get
            {
                return 1992;
            }
        }

        public override bool UseSmartAI { get { return true; } }

        public override bool ShowFameTitle
        {
            get
            {
                return false;
            }
        }
        public override bool InitialInnocent
        {
            get
            {
                return (this.m_MorphedInto != null);
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile MorphedInto
        {
            get
            {
                return this.m_MorphedInto;
            }
            set
            {
                if (value == this)
                    value = null;

                if (this.m_MorphedInto != value)
                {
                    this.Revert();

                    if (value != null)
                    {
                        this.Morph(value);
                        this.m_LastMorph = DateTime.UtcNow;
                    }

                    this.m_MorphedInto = value;
                    this.Delta(MobileDelta.Noto);
                }
            }
        }
        public override void GenerateLoot()
        {
            this.AddLoot(LootPack.AosRich, 3);
            AddLoot(LootPack.LowScrolls);
            AddLoot(LootPack.MedScrolls);
        }

        public override int GetAngerSound()
        {
            return 0x46E;
        }

        public override int GetIdleSound()
        {
            return 0x470;
        }

        public override int GetAttackSound()
        {
            return 0x46D;
        }

        public override int GetHurtSound()
        {
            return 0x471;
        }

        public override int GetDeathSound()
        {
            return 0x46F;
        }

        public override void OnThink()
        {
            base.OnThink();

            if (this.Combatant != null)
            {
                if (this.m_NextFireRing <= DateTime.UtcNow && Utility.RandomDouble() < 0.02)
                {
                    this.FireRing();
                    this.m_NextFireRing = DateTime.UtcNow + TimeSpan.FromMinutes(2);
                }

                if (this.Combatant is PlayerMobile && this.m_MorphedInto != this.Combatant && Utility.RandomDouble() < 0.05)
                    this.MorphedInto = this.Combatant as Mobile;
            }
        }

        public override bool CheckIdle()
        {
            bool idle = base.CheckIdle();

            if (idle && this.m_MorphedInto != null && DateTime.UtcNow - this.m_LastMorph > TimeSpan.FromSeconds(30))
                this.MorphedInto = null;

            return idle;
        }

        public void DeleteClonedItems()
        {
            for (int i = this.Items.Count - 1; i >= 0; --i)
            {
                Item item = this.Items[i];

                if (item is ClonedItem)
                    item.Delete();
            }

            if (this.Backpack != null)
            {
                for (int i = this.Backpack.Items.Count - 1; i >= 0; --i)
                {
                    Item item = this.Backpack.Items[i];

                    if (item is ClonedItem)
                        item.Delete();
                }
            }
        }

        public override void OnAfterDelete()
        {
            this.DeleteClonedItems();

            base.OnAfterDelete();
        }

        public override void ClearHands()
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
            writer.Write((this.m_MorphedInto != null));
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (reader.ReadBool())
                ValidationQueue<WarMage>.Add(this);
        }

        public void Validate()
        {
            this.Revert();
        }

        protected virtual void FireRing()
        {
            this.FireEffects(0x3E27, m_FireNorth);
            this.FireEffects(0x3E31, m_FireEast);
        }

        protected virtual void Morph(Mobile m)
        {
            this.Body = m.Body;
            this.Hue = m.Hue;
            this.Female = m.Female;
            this.Name = m.Name;
            this.NameHue = m.NameHue;
            this.Title = m.Title;
            this.Kills = m.Kills;
            this.HairItemID = m.HairItemID;
            this.HairHue = m.HairHue;
            this.FacialHairItemID = m.FacialHairItemID;
            this.FacialHairHue = m.FacialHairHue;

            // TODO: Skills?

            foreach (Item item in m.Items)
            {
                if (item.Layer != Layer.Backpack && item.Layer != Layer.Mount && item.Layer != Layer.Bank)
                    this.AddItem(new ClonedItem(item)); // TODO: Clone weapon/armor attributes
            }

            this.PlaySound(0x511);
            this.FixedParticles(0x376A, 1, 14, 5045, EffectLayer.Waist);
        }

        protected virtual void Revert()
        {
            this.Body = 264;
            this.Hue = (this.IsParagon && this.DefaultHue == 0) ? Paragon.Hue : this.DefaultHue;
            this.Female = false;
            this.Name = this.DefaultName;
            this.NameHue = -1;
            this.Title = null;
            this.Kills = 0;
            this.HairItemID = 0;
            this.HairHue = 0;
            this.FacialHairItemID = 0;
            this.FacialHairHue = 0;

            this.DeleteClonedItems();

            this.PlaySound(0x511);
            this.FixedParticles(0x376A, 1, 14, 5045, EffectLayer.Waist);
        }

        private void FireEffects(int itemID, int[] offsets)
        {
            for (int i = 0; i < offsets.Length; i += 2)
            {
                Point3D p = this.Location;

                p.X += offsets[i];
                p.Y += offsets[i + 1];

                if (SpellHelper.AdjustField(ref p, this.Map, 12, false))
                    Effects.SendLocationEffect(p, this.Map, itemID, 50);
            }
        }

        private class ClonedItem : Item
        {
            public ClonedItem(Item item)
                : base(item.ItemID)
            {
                this.Name = item.Name;
                this.Weight = item.Weight;
                this.Hue = item.Hue;
                this.Layer = item.Layer;
                this.Movable = false;
            }

            public ClonedItem(Serial serial)
                : base(serial)
            {
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
}