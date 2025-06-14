using System;
using Server.Items;
using Server.Items.Holiday;

namespace Server.Mobiles
{
    [CorpseName("a Sleepy Hollow corpse")]
    public class SleepyHollow : BaseCreature
    {
        [Constructable]
        public SleepyHollow()
            : base(Utility.RandomBool() ? AIType.AI_Melee : AIType.AI_Mage, FightMode.Closest, 10, 1, 0.05, 0.1)
        {
            this.Name = " Sleepy Hollow ";
            this.Body = 1246 + Utility.Random(2);
            
            Hue = 1473;
            this.BaseSoundID = 268;

            this.SetStr(500);
            this.SetDex(500);
            this.SetInt(200);

            this.SetHits(24000);
            this.SetMana(2450);

            this.SetDamage(10, 15);

            this.SetDamageType(ResistanceType.Physical, 100);

            this.SetResistance(ResistanceType.Physical, 85);
            this.SetResistance(ResistanceType.Fire, 45);
            this.SetResistance(ResistanceType.Cold, 50);
            this.SetResistance(ResistanceType.Poison, 65);
            this.SetResistance(ResistanceType.Energy, 80);

            this.SetSkill(SkillName.DetectHidden, 100.0);
            this.SetSkill(SkillName.Meditation, 300.0);
            this.SetSkill(SkillName.Necromancy, 100.0);
            this.SetSkill(SkillName.SpiritSpeak, 180.0);
            this.SetSkill(SkillName.Magery, 120.0);
            this.SetSkill(SkillName.EvalInt, 100.0);
            this.SetSkill(SkillName.MagicResist, 100.0);
            this.SetSkill(SkillName.Tactics, 110.0);
            this.SetSkill(SkillName.Wrestling, 110.0);

            this.Fame = 15000;
            this.Karma = -15000;

            this.VirtualArmor = 55;
           

                        
                        PackItem( new MasterCoin(1));
                        AddLoot( LootPack.SuperBoss, 1 );
	
		}


		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

       //     if (0.001 > Utility.RandomDouble()) // 
      //      {           
      //          c.DropItem(new EverlastingBandage());             
     //       }

            if (0.001 > Utility.RandomDouble()) //
            {           
                c.DropItem(new Herotalisman());             
            }

            if (0.001 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new HerobloodyApron());             
            }

            if (0.001 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new HerohoodedRobe());             
            }

        //    if (0.02 > Utility.RandomDouble()) // 
         //   {           
         //       c.DropItem(new CinctureDeed());             
         //   }
                          
            if (0.07 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicClothDeed());             
            }

            if (0.1 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicKilt());             
            }

            if (0.1 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicBoots());             
            }

            if (0.08 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicRobe());             
            }

       
		}



        public SleepyHollow(Serial serial)
            : base(serial)
        {
        }

        public override bool AutoDispel
        {
            get
            {
                return true;
            }
        }
        public override bool BardImmune
        {
            get
            {
                return true;
            }
        }
        public override bool Unprovokable
        {
            get
            {
                return true;
            }
        }
        public override bool AreaPeaceImmune
        {
            get
            {
                return true;
            }
        }
        
        public override bool AlwaysMurderer{ get{ return true; } }
        public override WeaponAbility GetWeaponAbility()
            {
			return WeaponAbility.BleedAttack;
		}


        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            base.OnDamage(amount, from, willKill);
			
            // eats pet or summons
           // if (from is BaseCreature)
           // {
            //    BaseCreature creature = (BaseCreature)from;
				
         //       if (creature.Controlled || creature.Summoned)
           //     {
           //         this.Heal(creature.Hits);					
            //        creature.Kill();				
					
            //        Effects.PlaySound(this.Location, this.Map, 0x574);
             //   }
           // }
        }

        public override void GenerateLoot()
        {
            PackItem(new MasterCoin(2));
            if (Utility.RandomDouble() < .02)
            {
            //PackItem( new TwilightLantern() );  OLD Halloween
                switch( Utility.Random(5) )
                {
                    case 0:
                        this.PackItem(new PaintedEvilClownMask());
                        break;
                    case 1:
                        this.PackItem(new PaintedDaemonMask());
                        break;
                    case 2:
                        this.PackItem(new PaintedPlagueMask());
                        break;
                    case 3:
                        this.PackItem(new PaintedEvilJesterMask());
                        break;
                    case 4:
                        this.PackItem(new PaintedPorcelainMask());
                        break;
                    default:
                        break;
                }
            }

            this.PackItem(new WrappedCandy());
            this.AddLoot(LootPack.UltraRich, 2);
        }

        public virtual void Lifted_Callback(Mobile from)
        {
            if (from != null && !from.Deleted && from is PlayerMobile)
            {
                this.Combatant = from;

                this.Warmode = true;
            }
        }

        public override Item NewHarmfulItem()
        {
            Item bad = new AcidSlime(TimeSpan.FromSeconds(30), 10, 10);

            bad.Name = "gooey nasty pumpkin hummus";

            bad.Hue = 144;

            return bad;
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