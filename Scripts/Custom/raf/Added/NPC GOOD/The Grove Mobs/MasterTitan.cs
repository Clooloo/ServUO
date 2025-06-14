using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an Master titan corpse" )]
	public class MasterTitan : BaseCreature
	{
		public override bool StatLossAfterTame { get { return false; } }

		[Constructable]
		public MasterTitan () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.3, 0.5 )
		{
			Hue = 0x5555;
			Name = "The Master Titan";
			Body = 0x4C;
			BaseSoundID = 0x261;

			SetStr( 1025, 1425 );
			SetDex( 500, 648 );
			SetInt( 1475, 1675 );

			SetHits( 36000, 58000 );
			SetStam( 1500, 1648 );

			SetDamage( 35, 55 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Poison, 20 );

			SetResistance( ResistanceType.Physical, 70, 85 );
			SetResistance( ResistanceType.Fire, 75, 90 );
			SetResistance( ResistanceType.Cold, 70, 85 );
			SetResistance( ResistanceType.Poison, 70, 80 );
			SetResistance( ResistanceType.Energy, 70, 85 );

			SetSkill( SkillName.Meditation, 0 );
			SetSkill( SkillName.EvalInt, 140.0, 160.0 );
			SetSkill( SkillName.Magery, 110.0, 140.0 );
			SetSkill( SkillName.Poisoning, 110.0, 140.0 );
			SetSkill( SkillName.Anatomy, 110.0, 140.0 );
			SetSkill( SkillName.MagicResist, 110.0, 140.0 );
			SetSkill( SkillName.Tactics, 110.0, 140.0 );
			SetSkill( SkillName.Wrestling, 122.0, 160.0 );

			Fame = 22000;
			Karma = -15000;

			VirtualArmor = 75;
		

                       
                        PackItem( new MasterCoin( 25 ) );
                        AddLoot( LootPack.SuperBoss, 10 );
	
		}


		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

       //     if (0.007 > Utility.RandomDouble()) // 
       //     {           
       //         c.DropItem(new Herobow2());             
       //     }

            if (0.007 > Utility.RandomDouble()) //
            {           
                c.DropItem(new Herotalisman());             
            }

            if (0.007 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new HerobloodyApron());             
            }

            if (0.005 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new HerohoodedRobe());             
            }

            if (0.006 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Heroquiver());             
            }

          

     //       if (0.008 > Utility.RandomDouble()) // 
     //       {           
      //          c.DropItem(new EverlastingBandage());             
     //       }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicClothDeed());             
            }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicKilt());             
            }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicBoots());             
            }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicRobe());             
            }

                            
		}
                
                
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 6; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 30; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( Body == 12 ? ScaleType.Yellow : ScaleType.Red ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		public MasterTitan( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			SetDamage( 5, 35 );

			if( version == 0 )
			{
				Server.SkillHandlers.AnimalTaming.ScaleStats( this, 0.50 );
				Server.SkillHandlers.AnimalTaming.ScaleSkills( this, 0.8, 0.9, true ); // 90% * 80% = 72% of original skills trainable to 90%
				Skills[SkillName.Magery].Base = Skills[SkillName.Magery].Cap; // Greater dragons have a 90% cap reduction and 90% skill reduction on magery
			}
		}
	}
}