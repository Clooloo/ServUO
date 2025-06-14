using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Engines.CannedEvil;
using System.Collections.Generic;

namespace Server.Mobiles
{
	public class BrideZilla : BaseCreature
	{

        public MonsterStatuetteType[] StatueTypes{ get{ return new MonsterStatuetteType[] { }; } }

		private bool m_TrueForm;
		private Item m_GateItem;
		private Timer m_Timer;

		private static ArrayList m_Instances = new ArrayList();

		public static ArrayList Instances{ get{ return m_Instances; } }

		public static bool CanSpawn
		{
			get
			{
				return ( m_Instances.Count == 0 );
			}
		}

		[Constructable]
		public BrideZilla() : base( AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			m_Instances.Add( this );

			Name = " kim kardashian  ";
			Hue = 700;
			Body = 401;
			BaseSoundID = 367;


			SetStr( 2000, 2010 );
			SetDex( 1500, 2000 );
			SetInt( 3000, 3200 );
			SetDamage( 30, 50 );

                        SetDamageType(ResistanceType.Fire, 20);
                        SetDamageType(ResistanceType.Cold, 20);
                        SetDamageType(ResistanceType.Energy, 20);
                        SetDamageType(ResistanceType.Physical, 20);
                        SetDamageType(ResistanceType.Poison, 20);

			SetResistance( ResistanceType.Physical,75, 85 );
			SetResistance( ResistanceType.Fire, 70, 80 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 70, 80 );
			SetResistance( ResistanceType.Energy, 70, 80 );

			SetSkill( SkillName.Throwing, 150.9, 185.5 );
			SetSkill( SkillName.Wrestling, 150.9, 185.5 );
			SetSkill( SkillName.Tactics, 146.9, 200.2 );
			SetSkill( SkillName.MagicResist, 131.4, 140.8 );
			SetSkill( SkillName.EvalInt, 200.0 );
			SetSkill( SkillName.Meditation, 420.0 );

			Fame = 18000;
			Karma = -18000;

            HHatchet th = new TTHatchet();
            th.Movable = false;
            AddItem( th );

			//m_Spirits = new List<bossslave>();

			m_Timer = new TeleportTimer( this );
			m_Timer.Start();
		}

		public override void GenerateLoot()
		{

                        PackItem (new CrystallineBlackrock(20));
                        PackItem (new RelicFragment(20));
                        PackItem (new RAD());
                        PackItem (new RAD());
                        PackItem (new RAD());
                        AddLoot( LootPack.SuperBoss, 3 );
			AddLoot( LootPack.Meager );          

			
		}

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);       
             
                  c.DropItem( new MasterCoin( 50 ) );
                 

            if (0.05 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Herodeed());             
            }

        //    if (0.05 > Utility.RandomDouble()) // 
        //    {           
        //        c.DropItem(new HeroWeapondeed());             
        //    }

            if (0.10 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Robedeed());             
            }

            if (0.06 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new GladiatorDeed());             
            }              

            if (0.08 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new BHatchet());             
            }


            if (0.08 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new MagicClothDeed());             
            }

           // if (0.07 > Utility.RandomDouble()) // 
           // {           
           //     c.DropItem(new EverlastingBandage());             
          //  }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicClothDeed());             

		}



            }


		public override bool CanFly{ get{ return true; } }
		public override bool AutoDispel{ get{ return true; } }
	        public override bool BardImmune{ get{ return true; } }
                public override bool AlwaysMurderer { get { return true; } }
               
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } } 
                public override Poison HitPoison { get { return Poison.Deadly; } }

        public override WeaponAbility GetWeaponAbility() 
        {
            int ability = Utility.Random(3);
            if (ability == 1)
                return WeaponAbility.BleedAttack;
            else if (ability == 2)
                return WeaponAbility.MortalStrike;
            else
                return WeaponAbility.WhirlwindAttack;
        }


                public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            base.OnDamage(amount, from, willKill);
			
            // eats pet or summons
         //   if (from is BaseCreature)
          //  {
          //      BaseCreature creature = (BaseCreature)from;
				
        //        if (creature.Controlled || creature.Summoned)
          //      {
          //          this.Heal(creature.Hits);					
           //         creature.Kill();				
					
           //         Effects.PlaySound(this.Location, this.Map, 0x574);
            //    }
        //}
}

		private static readonly double[] m_Offsets = new double[]
			{
				Math.Cos( 000.0 / 180.0 * Math.PI ), Math.Sin( 000.0 / 180.0 * Math.PI ),
				Math.Cos( 040.0 / 180.0 * Math.PI ), Math.Sin( 040.0 / 180.0 * Math.PI ),
				Math.Cos( 080.0 / 180.0 * Math.PI ), Math.Sin( 080.0 / 180.0 * Math.PI ),
				Math.Cos( 120.0 / 180.0 * Math.PI ), Math.Sin( 120.0 / 180.0 * Math.PI ),
				Math.Cos( 160.0 / 180.0 * Math.PI ), Math.Sin( 160.0 / 180.0 * Math.PI ),
				Math.Cos( 200.0 / 180.0 * Math.PI ), Math.Sin( 200.0 / 180.0 * Math.PI ),
				Math.Cos( 240.0 / 180.0 * Math.PI ), Math.Sin( 240.0 / 180.0 * Math.PI ),
				Math.Cos( 280.0 / 180.0 * Math.PI ), Math.Sin( 280.0 / 180.0 * Math.PI ),
				Math.Cos( 320.0 / 180.0 * Math.PI ), Math.Sin( 320.0 / 180.0 * Math.PI ),
			};

		public void Morph()
		{
			if ( m_TrueForm )
				return;

			m_TrueForm = true;
			
			Name = " BrideZilla ";
            Hue = 800;
			Hits = HitsMax;
			Stam = StamMax;
			Mana = ManaMax;
			Body = 1400;
			ProcessDelta();

			Say( "Don't Leave me my Love !!!!!"); // Don't Leave me my Love !!!!!

			Map map = this.Map;

			if ( map != null )
			{
				for ( int i = 0; i < m_Offsets.Length; i += 2 )
				{
					double rx = m_Offsets[i];
					double ry = m_Offsets[i + 1];

					int dist = 0;
					bool ok = false;
					int x = 0, y = 0, z = 0;

					while ( !ok && dist < 10 )
					{
						int rdist = 10 + dist;

						x = this.X + (int)(rx * rdist);
						y = this.Y + (int)(ry * rdist);
						z = map.GetAverageZ( x, y );

						if ( !(ok = map.CanFit( x, y, this.Z, 16, false, false ) ) )
							ok = map.CanFit( x, y, z, 16, false, false );

						if ( dist >= 0 )
							dist = -(dist + 1);
						else
							dist = -(dist - 1);
					}

					if ( !ok )
						continue;

					bossslave spawn = new bossslave( this );

					spawn.Team = this.Team;

					spawn.MoveToWorld( new Point3D( x, y, z ), map );

					//m_Spirits.Add( spawn );
				}
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public override int HitsMax{ get{ return m_TrueForm ? 44000 : 20000; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public override int ManaMax{ get{ return 50000; } }

		public BrideZilla( Serial serial ) : base( serial )
		{
			m_Instances.Add( this );
		}

		public override void OnAfterDelete()
		{
			m_Instances.Remove( this );

			base.OnAfterDelete();
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( m_TrueForm );
			writer.Write( m_GateItem );
			//writer.WriteMobileList<bossslave>( m_Spirits );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_TrueForm = reader.ReadBool();
					m_GateItem = reader.ReadItem();
					//m_Spirits = reader.ReadStrongMobileList<bossslave>();

					m_Timer = new TeleportTimer( this );
					m_Timer.Start();

					break;
				}
			}
		}

		public override bool OnBeforeDeath()
		{
			if ( m_TrueForm )
			{
				 List<DamageStore> rights = GetLootingRights();

				if ( !NoKillAwards )
				{
					Map map = this.Map;

					if ( map != null )
					{
						for ( int x = -5; x <= 5; ++x )
						{
							for ( int y = -5; y <= 5; ++y )
							{
								double dist = Math.Sqrt(x*x+y*y);

								if ( dist <= 7 )
									new GoodiesTimer( map, X + x, Y + y ).Start();
							}
						}
					}

					m_DamageEntries = new Dictionary<Mobile, int>();

				//	for ( int i = 0; i < m_Spirits.Count; ++i )
				//	{
				//		Mobile m = m_Spirits[i];

				//		if ( !m.Deleted )
				//			m.Kill();

				//		RegisterDamageTo( m );
				//	}

					//m_Spirits.Clear();

					RegisterDamageTo( this );

					if ( m_GateItem != null )
						m_GateItem.Delete();
				}
				
				return base.OnBeforeDeath();

				
			}
			else
			{
				Morph();
				return false;
			}
		}

		Dictionary<Mobile, int> m_DamageEntries;

		public virtual void RegisterDamageTo( Mobile m )
		{
			if( m == null )
				return;

			foreach( DamageEntry de in m.DamageEntries )
			{
				Mobile damager = de.Damager;

				Mobile master = damager.GetDamageMaster( m );

				if( master != null )
					damager = master;

				RegisterDamage( damager, de.DamageGiven );
			}
		}

		public void RegisterDamage( Mobile from, int amount )
		{
			if( from == null || !from.Player )
				return;

			if( m_DamageEntries.ContainsKey( from ) )
				m_DamageEntries[from] += amount;
			else
				m_DamageEntries.Add( from, amount );

			from.SendMessage(String.Format("Total Damage: {0}", m_DamageEntries[from]) );
		}

		public void AwardArtifact( Item artifact )
		{
			if (artifact == null )
				return;

			int totalDamage = 0;

			Dictionary<Mobile, int> validEntries = new Dictionary<Mobile, int>();

			foreach (KeyValuePair<Mobile, int> kvp in m_DamageEntries)
			{
				if( IsEligible( kvp.Key, artifact ) )
				{
					validEntries.Add( kvp.Key, kvp.Value );
					totalDamage += kvp.Value;
				}
			}

			int randomDamage = Utility.RandomMinMax( 1, totalDamage );

			totalDamage = 0;

			foreach (KeyValuePair<Mobile, int> kvp in m_DamageEntries)
			{
				totalDamage += kvp.Value;

				if( totalDamage > randomDamage )
				{
					GiveArtifact( kvp.Key, artifact );
					break;
				}
			}
		}

		public void GiveArtifact( Mobile to, Item artifact )
		{
			if ( to == null || artifact == null )
				return;

			Container pack = to.Backpack;

			if ( pack == null || !pack.TryDropItem( to, artifact, false ) )
				artifact.Delete();
			else
				to.SendLocalizedMessage( 1062317 ); // For your valor in combating the fallen beast, a special artifact has been bestowed on you.
		}

		public bool IsEligible( Mobile m, Item Artifact )
		{
			return m.Player && m.Alive && m.InRange( Location, 32 ) && m.Backpack != null && m.Backpack.CheckHold( m, Artifact, false );
		}

        public Item CreateArtifact(Type[] list)
        {
            if (list.Length == 0)
                return null;

            int random = Utility.Random(list.Length);

            Type type = list[random];

            Item artifact = Loot.Construct(type);

            if (artifact is MonsterStatuette && StatueTypes.Length > 0)
            {
                ((MonsterStatuette)artifact).Type = StatueTypes[Utility.Random(StatueTypes.Length)];
                ((MonsterStatuette)artifact).LootType = LootType.Regular;
            }

            return artifact;
        }

		private class TeleportTimer : Timer
		{
			private Mobile m_Owner;

			private static int[] m_Offsets = new int[]
			{
				-1, -1,
				-1,  0,
				-1,  1,
				0, -1,
				0,  1,
				1, -1,
				1,  0,
				1,  1
			};

			public TeleportTimer( Mobile owner ) : base( TimeSpan.FromSeconds( 5.0 ), TimeSpan.FromSeconds( 5.0 ) )
			{
				Priority = TimerPriority.TwoFiftyMS;

				m_Owner = owner;
			}

			protected override void OnTick()
			{
				if ( m_Owner.Deleted )
				{
					Stop();
					return;
				}

				Map map = m_Owner.Map;

				if ( map == null )
					return;

				if ( 0.25 < Utility.RandomDouble() )
					return;

				Mobile toTeleport = null;

				foreach ( Mobile m in m_Owner.GetMobilesInRange( 16 ) )
				{
					if ( m != m_Owner && m.Player && m_Owner.CanBeHarmful( m ) && m_Owner.CanSee( m ) )
					{
						toTeleport = m;
						break;
					}
				}

				if ( toTeleport != null )
				{
					int offset = Utility.Random( 8 ) * 2;

					Point3D to = m_Owner.Location;

					for ( int i = 0; i < m_Offsets.Length; i += 2 )
					{
						int x = m_Owner.X + m_Offsets[(offset + i) % m_Offsets.Length];
						int y = m_Owner.Y + m_Offsets[(offset + i + 1) % m_Offsets.Length];

						if ( map.CanSpawnMobile( x, y, m_Owner.Z ) )
						{
							to = new Point3D( x, y, m_Owner.Z );
							break;
						}
						else
						{
							int z = map.GetAverageZ( x, y );

							if ( map.CanSpawnMobile( x, y, z ) )
							{
								to = new Point3D( x, y, z );
								break;
							}
						}
					}

					Mobile m = toTeleport;

					Point3D from = m.Location;

					m.Location = to;

					Server.Spells.SpellHelper.Turn( m_Owner, toTeleport );
					Server.Spells.SpellHelper.Turn( toTeleport, m_Owner );

					m.ProcessDelta();

					Effects.SendLocationParticles( EffectItem.Create( from, m.Map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 2023 );
					Effects.SendLocationParticles( EffectItem.Create(   to, m.Map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 5023 );

					m.PlaySound( 0x1FE );

					m_Owner.Combatant = toTeleport;
				}
			}
		}

		private class GoodiesTimer : Timer
		{
			private Map m_Map;
			private int m_X, m_Y;

			public GoodiesTimer( Map map, int x, int y ) : base( TimeSpan.FromSeconds( Utility.RandomDouble() * 5.0 ) )
			{
				Priority = TimerPriority.TwoFiftyMS;

				m_Map = map;
				m_X = x;
				m_Y = y;
			}

			protected override void OnTick()
			{
				int z = m_Map.GetAverageZ( m_X, m_Y );
				bool canFit = m_Map.CanFit( m_X, m_Y, z, 6, false, false );

				for ( int i = -3; !canFit && i <= 2; ++i )
				{
					canFit = m_Map.CanFit( m_X, m_Y, z + i, 6, false, false );

					if ( canFit )
						z += i;
				}

				if ( !canFit )
					return;

				Gold g = new Gold( 300, 500 );
				
				g.MoveToWorld( new Point3D( m_X, m_Y, z ), m_Map );

				if ( 0.8 >= Utility.RandomDouble() )
				{
					switch ( Utility.Random( 3 ) )
					{
						case 0: // Fire column
						{
							Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x3709, 10, 10, 5052 );
							Effects.PlaySound( g, g.Map, 0x665 );

							break;
						}
						case 1: // Explosion
						{
							Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x36BD, 20, 10, 5044 );
							Effects.PlaySound( g, g.Map, 0x656 );

							break;
						}
						case 2: // Ball of fire
						{
							Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x36FE, 10, 10, 5052 );

							break;
						}
					}
				}
			}
		}
	}
}

namespace Server.Items
{
	public class BHatchet : Hatchet
	{

      		public override int AosMinDamage{ get{ return 35; } } 
      		public override int AosMaxDamage{ get{ return 45; } } 
      		public override int AosSpeed{ get{ return 40; } } 

                public override int ArtifactRarity{ get{ return 2002; } }   

		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }

		[Constructable]
		public BHatchet()
		{
			Name = " - Gladiator's Hatchet - ";
			Hue = 1152;
                        Weight = 40.0;
			
			DurabilityLevel = WeaponDurabilityLevel.Indestructible;
         		Quality = ItemQuality.Exceptional;


                                WeaponAttributes.HitLightning = 100;
			  	WeaponAttributes.HitLeechMana = 60;
                                WeaponAttributes.HitLeechStam = 60;
                                ExtendedWeaponAttributes.HitSwarm = 20;
                                this.Attributes.WeaponSpeed = 30;
                               this.AosElementDamages.Chaos = 100;
                               this.WeaponAttributes.HitManaDrain = 10;
				Attributes.BonusMana = 10;
				Attributes.BonusStam = 10;
				Attributes.WeaponDamage = 50;
				Attributes.RegenStam = 5;
				Attributes.SpellChanneling = 1;
				Attributes.CastSpeed = 1;
			MaxHitPoints = 100;
			HitPoints = 100;
                                StrRequirement = 150;
				}


        public BHatchet( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}