//Deviously Created by The Jester!... This script is needed for the first forms body change. 
//Please if this is distributed please leave the credit for this base please..
using System;
using System.Collections;
using Server;
using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
	[CorpseName( "a Master Dragons Corpse" )]
	public class MasterDragon : BaseCreature
	{
		public override bool IgnoreYoungProtection { get { return true; } }

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

		[Constructable]
		public MasterDragon() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "The Master Dragon";
			Body = 0x33A; 
            Hue = 0x5555;

            SetStr(1500, 2000);
            SetDex(500, 600);
            SetInt(4000, 5200);

            SetHits(40000, 55000);

            SetDamage(40, 60);

            SetDamageType(ResistanceType.Physical, 10);
            SetDamageType(ResistanceType.Energy, 50);
			SetDamageType(ResistanceType.Fire, 40);

            SetResistance(ResistanceType.Physical, 85, 95);
            SetResistance(ResistanceType.Fire, 70, 80);
            SetResistance(ResistanceType.Cold, 80, 90);
            SetResistance(ResistanceType.Poison, 70, 80);
            SetResistance(ResistanceType.Energy, 70, 90);

            SetSkill(SkillName.Wrestling, 130.1, 160.0);
            SetSkill(SkillName.Tactics, 170.2, 180.0);
            SetSkill(SkillName.MagicResist, 120.2, 160.0);
            SetSkill(SkillName.Anatomy, 150.0);
            SetSkill(SkillName.Focus, 90.0, 120.0);
            SetSkill(SkillName.Magery, 150.0, 170.0);
            SetSkill(SkillName.EvalInt, 170.0, 180.0);
            SetSkill(SkillName.Meditation, 100.0, 120.0);

            Fame = 10000;
            Karma = -10000;

            VirtualArmor = 60;

                        
                        PackItem( new MasterCoin( 30 ) );
                        AddLoot( LootPack.SuperBoss, 15 );
	
		}


		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

     //       if (0.04 > Utility.RandomDouble()) // 
      //      {           
      //          c.DropItem(new Herobow2());             
      //      }

            if (0.03 > Utility.RandomDouble()) //
            {           
                c.DropItem(new Herotalisman());             
            }

            if (0.03 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new HerobloodyApron());             
            }

            if (0.04 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new HerohoodedRobe());             
            }

            if (0.03 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Heroquiver());             
            }

		}

		
                
                
                
		public override bool BardImmune{ get{ return !Core.SE; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool Unprovokable{ get{ return Core.SE; } }
		public override bool AreaPeaceImmune { get { return Core.SE; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override int TreasureMapLevel{ get{ return 5; } }

		private static bool m_InHere;

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			if ( from != null && from != this && !m_InHere )
			{
				m_InHere = true;
				AOS.Damage( from, this, Utility.RandomMinMax( 8, 20 ), 100, 0, 0, 0, 0 );

				MovingEffect( from, 0xECA, 10, 0, false, false, 0, 0 );
				PlaySound( 0x491 );

				if ( 0.05 > Utility.RandomDouble() )
					Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( CreateBones_Callback ), from );

				m_InHere = false;
			}
		}

		public virtual void CreateBones_Callback( object state )
		{
			Mobile from = (Mobile)state;
			Map map = from.Map;

			if ( map == null )
				return;

			int count = Utility.RandomMinMax( 1, 3 );

			for ( int i = 0; i < count; ++i )
			{
				int x = from.X + Utility.RandomMinMax( -1, 1 );
				int y = from.Y + Utility.RandomMinMax( -1, 1 );
				int z = from.Z;

				if ( !map.CanFit( x, y, z, 16, false, true ) )
				{
					z = map.GetAverageZ( x, y );

					if ( z == from.Z || !map.CanFit( x, y, z, 16, false, true ) )
						continue;
				}

				UnholyBone bone = new UnholyBone();

				bone.Hue = 0x497;
				bone.Name = "the previous heros' bones";
				bone.ItemID = Utility.Random( 0xECA, 9 );

				bone.MoveToWorld( new Point3D( x, y, z ), map );
			}
		}

		public MasterDragon( Serial serial ) : base( serial )
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