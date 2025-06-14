using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a Boss corpse" )]
	public class DrBiG: BaseCreature
	{
		[Constructable]
		public DrBiG(): base(AIType.AI_NecroMage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			
           switch ( Utility.Random(7) )
            {
                case 0: // 
                    this.Name = " Boss Lord Dark Mage ";
                    this.Body = 830;
                    this.BaseSoundID = 0x3E9;
                    Hue = 0;
                    break;
                case 1: //
                    this.Name = " Dread Lord Diablo ";
                    this.Body = 741;
                    this.BaseSoundID = 0x165;
                  Hue = 1986;
                    break;
                case 2: // 
                    this.Name = " Lord Death Titan ";
                    this.Body = 829;
	            BaseSoundID = 268;
                    Hue = 1920;
                    break;
                case 3: //
                    this.Name = " Lord Dark-Angel ";
                    this.Body = 123;
	            BaseSoundID = 604;
                    Hue = 1986;
                    break;
                case 4: //
                    this.Name = " Lord Dark Soul ";
                    this.Body = 746;
                    this.BaseSoundID = 268;
                  Hue = 2500;
                    break;
                case 5: //
                    this.Name = " Beast Hell Wyvern ";
                    this.Body = 62;
                    this.BaseSoundID = 362;
                  Hue = 1986;
                    break;

                case 6: //
                    this.Name = " Lord Lucifer ";
                    this.Body = 9;
                    this.BaseSoundID = 357;
                  Hue = 1986;
                    break;


           }

            this.ActiveSpeed = 0.1;
            this.PassiveSpeed = 0.2;

			SetStr( 600, 800 );
			SetDex( 1500, 1995 );
			SetInt( 2501, 2925 );


			this.SetHits( 60000, 68000 );
                        this.SetStam(6212, 9262);
                        this.SetMana(163170, 277990);

			SetDamage( 25, 35 );

                        SetDamageType(ResistanceType.Physical,10);
                        SetDamageType(ResistanceType.Fire, 60);
                        SetDamageType(ResistanceType.Cold, 30);

			this.SetSkill( SkillName.EvalInt, 200, 230.0 );
			this.SetSkill( SkillName.Magery, 200, 250.0 );
			this.SetSkill( SkillName.MagicResist, 125.1, 135.0 );
			this.SetSkill( SkillName.Tactics, 140, 160.0 );
			this.SetSkill( SkillName.Wrestling, 250, 320.0 );
	                this.SetSkill(SkillName.Necromancy, 350);
                        this.SetSkill(SkillName.SpiritSpeak, 350);
			this.SetSkill( SkillName.Focus, 500);
			this.SetSkill( SkillName.Meditation, 500);

			SetResistance( ResistanceType.Physical,65, 85 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Cold, 90, 95 );
			SetResistance( ResistanceType.Poison, 80, 90 );
			SetResistance( ResistanceType.Energy, 40, 60 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 60;
                        
                        PackItem (new CrystallineBlackrock(10));
                        PackItem (new RelicFragment(10));
                        PackItem (new RAD());
                        AddLoot( LootPack.SuperBoss, 3 );
			AddLoot( LootPack.Meager );
			
		}

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);
                  c.DropItem( new MasterCoin( 30 ) );
                 

            if (0.02 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Herodeed());             
            }

        //    if (0.02 > Utility.RandomDouble()) // 
       //     {           
       //         c.DropItem(new HeroWeapondeed());             
       //     }

            if (0.02 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Robedeed());             
            }

            if (0.02 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new GladiatorDeed());             
            }

            if (0.02 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new CthulhuArmorDeed());             
            }

     //       if (0.02 > Utility.RandomDouble()) // 
    //        {           
     //           c.DropItem(new EverlastingBandage());             
     //       }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicClothDeed());             

		}

            }


                public override Poison HitPoison { get { return Poison.Deadly; } } 
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }  
	        public override bool BardImmune{ get{ return true; } }
                public override bool AlwaysMurderer { get { return true; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }
                

        public override WeaponAbility GetWeaponAbility() 
        {
            int ability = Utility.Random(3);
            if (ability == 1)
                return WeaponAbility.ArmorIgnore;
            else if (ability == 2)
                return WeaponAbility.MortalStrike;
            else
                return WeaponAbility.ArmorIgnore;
        }

		public DrBiG( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}