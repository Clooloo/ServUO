using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Engines.CannedEvil;
using System.Collections.Generic;

namespace Server.Mobiles
{
	public class Topboss : BaseCreature
	{

        public MonsterStatuetteType[] StatueTypes{ get{ return new MonsterStatuetteType[] { }; } }

		private bool m_TrueForm;
		private Item m_GateItem;
		private List<bossslave> m_Spirits;
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
		public Topboss() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.6 )
		{
			m_Instances.Add( this );

           switch ( Utility.Random(15) )
            {
                case 0: // crong
                    this.Name = " Beast Crong ";
                    this.Body = 1431;
                    this.BaseSoundID = 367;
                    Hue = 0;
                    break;
                case 1: // Diablo
                    this.Name = " Dread Lord Diablo ";
                    this.Body = 1433;
                    this.BaseSoundID = 604;
                  Hue = 0;
                    break;
                case 2: // deamon
                    this.Name = " Lord Berserk ";
                    this.Body = 9;
                    this.BaseSoundID = 0x47D;
                    Hue = 2791;
                    break;
                case 3: // Shadow Knight
			Name = " Lord Shadow Knight ";
			Body = 311;
	 		BaseSoundID = 0x47D;
                        Hue = 2791;
                    break;
                case 4: // water
                    this.Name =  "Beast Parasyte ";
                    this.Body = 1427;
                    this.BaseSoundID = 278;
                    Hue = 0;
                    break;
                case 5: // trex
                    this.Name = " Ancient Tyrannosaurus ";
                    this.Body = 1400;
                    this.BaseSoundID = 362;
                        Hue = 2791;
                    break;
                case 6: // kraken
                    this.Name =  " Dread Lord Kraken ";
                    this.Body = 1068;
                    this.BaseSoundID = 1149;
                   Hue = 2781;
                    break;
                case 7: // queen
			Name = " Ancient legendary Queen ";
			Body = 1404;
			BaseSoundID = 959;
                        Hue = 0;
                    break;
                case 8: // Drspector
			Name = " Dread Lord Dr.Giant ";
			Body = 1405;
			BaseSoundID = 604;
                        Hue = 2450;
                    break;
                case 9: // tornado
			Name = " Deathful Tornado ";
			Body = 1432;
			BaseSoundID = 367;
                        Hue = 2791;
                    break;
                case 10: // VirtueBane
			Name = " Dread Lord VirtueBane ";
			Body = 1071;
			BaseSoundID = 609;
                        Hue = 0;
                    break;
                case 11: // CrimsonDragon
			Name = " Lord Crimson Wyrm ";
			Body = 197;
			BaseSoundID = 362;
                        Hue = 16385;
                    break;
               case 12: // Navrey
			Name = " Ancient legendary Tarantula ";
			Body = 735;
			BaseSoundID = 389;
                        Hue = 16385;
                    break;
               case 13: // Orcbrute
			Name = "  Dread Lord Ares  ";
			Body = 189;
			BaseSoundID = 0x45A;
                        Hue = 16385;
                    break;
               case 14: // Moloch
			Name = "  Mortal Kombat ";
			Body = 0x311;
			BaseSoundID = 0x300;
                        Hue = 2792;
                    break;

            }


			this.SetStr( 2000, 2010 );
			this.SetDex( 5000, 6000 );
			this.SetInt( 3000, 3200 );
			this.SetDamage( 35, 60 );

                        this.SetMana(163170, 277990);

                        SetDamageType(ResistanceType.Fire, 20);
                        SetDamageType(ResistanceType.Cold, 20);
                        SetDamageType(ResistanceType.Energy, 20);
                        SetDamageType(ResistanceType.Physical, 20);
                        SetDamageType(ResistanceType.Poison, 20);

			SetResistance( ResistanceType.Physical,75, 85 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 70, 80 );
			SetResistance( ResistanceType.Energy, 40, 50 );

                        this.SetSkill(SkillName.Anatomy, 115.0, 150.0);
			this.SetSkill( SkillName.Wrestling, 170.9, 225.5 );
			this.SetSkill( SkillName.Tactics, 146.9, 200.2 );
			this.SetSkill( SkillName.MagicResist, 131.4, 140.8 );
			this.SetSkill( SkillName.EvalInt, 200.0 );
			this.SetSkill( SkillName.Meditation, 500.0 );
	                this.SetSkill(SkillName.Focus, 1110);

			Fame = 18000;
			Karma = -18000;

			m_Spirits = new List<bossslave>();

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
						PackItem (new TrashPack());
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

          //  if (0.05 > Utility.RandomDouble()) // 
         ///   {           
         //       c.DropItem(new HeroWeapondeed());             
         //   }

            if (0.10 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Robedeed());             
            }

            if (0.05 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new GladiatorDeed());             
            }

            if (0.06 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new CthulhuArmorDeed());             
            }

            if (0.05 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new MagicClothDeed());             
            }

          //  if (0.06 > Utility.RandomDouble()) // 
           // {           
           //     c.DropItem(new HeroAxeThrow());             
           // }

       //     if (0.05 > Utility.RandomDouble()) // 
        //    {           
         //       c.DropItem(new EverlastingBandage());             
          //  }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicClothDeed());             

			}



         }


	        public override bool BardImmune{ get{ return true; } }
		public override bool CanFly{ get{ return true; } }
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
                   
                        Hue = 2793;
			Hits = HitsMax;
			Stam = StamMax;
			Mana = ManaMax;

			ProcessDelta();

			Say( 1049499 ); // Don't make me MAD !!!!!

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

					m_Spirits.Add( spawn );
				}
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public override int HitsMax{ get{ return m_TrueForm ? 45000 : 20000; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public override int ManaMax{ get{ return 50000; } }

		public Topboss( Serial serial ) : base( serial )
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
			writer.WriteMobileList<bossslave>( m_Spirits );
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
					m_Spirits = reader.ReadStrongMobileList<bossslave>();

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

					for ( int i = 0; i < m_Spirits.Count; ++i )
					{
						Mobile m = m_Spirits[i];

						if ( !m.Deleted )
							m.Kill();

						RegisterDamageTo( m );
					}

					m_Spirits.Clear();

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

				Gold g = new Gold( 800, 1000 );
				
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

	[CorpseName( "a Slave corpse" )]
	public class bossslave : BaseCreature
	{
        private DateTime m_NextBomb;
        private int m_Thrown;

		private Mobile m_Topboss;

		private DrainTimer m_Timer;

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Topboss
		{
			get
			{
				return m_Topboss;
			}
			set
			{
				m_Topboss = value;
			}
		}

		[Constructable]
		public bossslave() : this( null )
		{
		}
		
		public bossslave( Mobile Topboss ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			m_Topboss = Topboss;



            switch (Utility.Random(30))
            {
                case 0: Body = 312; break;
                case 1: Body = 742; break;
                case 2: Body = 40; break;
                case 3: Body = 308; break;
                case 4: Body = 75; break;
                case 5: Body = 313; break;
                case 6: Body = 318; break;
                case 7: Body = 303; break; 
                case 8: Body = 740; break; 
                case 9: Body = 123; break; 
                case 10: Body = 124; break;
                case 11: Body = 315; break; 
                case 12: Body = 730; break; 
                case 13: Body = 306; break;
                case 14: Body = 766; break; 
                case 15: Body = 241; break;
                case 16: Body = 189; break; 
                case 17: Body = 199; break;
                case 18: Body = 314; break; 
                case 19: Body = 244; break;
                case 20: Body = 104; break;
                case 21: Body = 301; break;
                case 22: Body = 1255; break;
                case 23: Body = 174; break;
                case 24: Body = 728; break;
                case 25: Body = 176; break;
                case 26: Body = 1290; break;
                case 27: Body = 1287; break;
                case 28: Body = 1286; break;
                case 29: Body = 1403; break;
            }
			Hue = 2700;
			Name = "Dark Guardian         ";
                        Title = "The Slave";

			SetStr( 500, 1000 );
			SetDex( 500, 500 );
			SetInt( 2001, 2200 );

			SetHits( 1500, 3000 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Fire, 20 );
			SetDamageType( ResistanceType.Cold, 20 );
			SetDamageType( ResistanceType.Poison, 20 );
			SetDamageType( ResistanceType.Energy, 20 );

			SetResistance( ResistanceType.Physical, 75, 85 );
			SetResistance( ResistanceType.Fire, 65, 70 );
			SetResistance( ResistanceType.Cold, 45, 55 );
			SetResistance( ResistanceType.Poison, 80, 95 );
			SetResistance( ResistanceType.Energy, 40, 45 );

			SetSkill( SkillName.Meditation, 120.0 );
			SetSkill( SkillName.MagicResist, 120.1, 140.0 );
			SetSkill( SkillName.Tactics, 100.1, 130.0 );
			SetSkill( SkillName.Wrestling, 120.1, 160.0 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 30;

			m_Timer = new DrainTimer( this );
			m_Timer.Start();


                        PackItem (new VoidOrb(5));
                        PackItem (new WhitePearl(5));
                        PackItem (new MagicalResidue(5));
                       
                        PackItem (new CrystalShards(5));
                        PackItem (new DelicateScales(5));
                        PackItem (new BouraPelt(5));
			PackReg( 10 );
			PackNecroReg( 15, 20 );
		}

		public override void CheckReflect( Mobile caster, ref bool reflect )
		{
			reflect = true;
		}

		public override int GetIdleSound()
		{
			return 0x2F8;
		}

		public override int GetAngerSound()
		{
			return 0x2F8;
		}

		public override int GetDeathSound()
		{
			return 0x2F7;
		}

		public override int GetAttackSound()
		{
			return Utility.Random(0x2F5, 2);
		}

		public override int GetHurtSound()
		{
			return 1608;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.MedScrolls, 2 );
			AddLoot( LootPack.HighScrolls, 2 );
		}

		public override bool CanFly{ get{ return true; } }
		public override bool AutoDispel{ get{ return true; } }
		public override bool Unprovokable{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }


      public override void OnActionCombat()
        {
            Mobile combatant = this.Combatant as Mobile;

            if (combatant == null || combatant.Deleted || combatant.Map != this.Map || !this.InRange(combatant, 12) || !this.CanBeHarmful(combatant) || !this.InLOS(combatant))
                return;

            if (DateTime.UtcNow >= this.m_NextBomb)
            {
                this.ThrowBomb(combatant);

                this.m_Thrown++;

                if (0.75 >= Utility.RandomDouble() && (this.m_Thrown % 2) == 1) // 75% chance to quickly throw another bomb
                    this.m_NextBomb = DateTime.UtcNow + TimeSpan.FromSeconds(3.0);
                else
                    this.m_NextBomb = DateTime.UtcNow + TimeSpan.FromSeconds(5.0 + (10.0 * Utility.RandomDouble())); // 5-15 seconds
            }
        }

        public void ThrowBomb(Mobile m)
        {
            this.DoHarmful(m);

            this.MovingParticles(m, 0x1C19, 3, 0, false, true, 0, 0, 9502, 6014, 0x11D, EffectLayer.Waist, 0);

            new InternalTimer(m, this).Start();
        }

       private class InternalTimer : Timer
        {
            private readonly Mobile m_Mobile;
            private readonly Mobile m_From;
            public InternalTimer(Mobile m, Mobile from)
                : base(TimeSpan.FromSeconds(1.0))
            {
                this.m_Mobile = m;
                this.m_From = from;
                this.Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                this.m_Mobile.PlaySound(0x11D);
                AOS.Damage(this.m_Mobile, this.m_From, Utility.RandomMinMax(90, 110), 0, 100, 0, 0, 0);
            }
        }


		public bossslave( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( m_Topboss );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Topboss = reader.ReadMobile();

					m_Timer = new DrainTimer( this );
					m_Timer.Start();

					break;
				}
			}
		}

		public override void OnAfterDelete()
		{
			if ( m_Timer != null )
				m_Timer.Stop();

			m_Timer = null;

			base.OnAfterDelete();
		}

		private class DrainTimer : Timer
		{
			private bossslave m_Owner;

			public DrainTimer( bossslave owner ) : base( TimeSpan.FromSeconds( 5.0 ), TimeSpan.FromSeconds( 5.0 ) )
			{
				m_Owner = owner;
				Priority = TimerPriority.TwoFiftyMS;
			}

			private static ArrayList m_ToDrain = new ArrayList();

			protected override void OnTick()
			{
				if ( m_Owner.Deleted )
				{
					Stop();
					return;
				}

				foreach ( Mobile m in m_Owner.GetMobilesInRange( 9 ) )
				{
					if ( m == m_Owner || m == m_Owner.Topboss || !m_Owner.CanBeHarmful( m ) )
						continue;

					if ( m is BaseCreature )
					{
						BaseCreature bc = m as BaseCreature;

						if ( bc.Controlled || bc.Summoned )
							m_ToDrain.Add( m );
					}
					else if ( m.Player )
					{
						m_ToDrain.Add( m );
					}
				}

				foreach ( Mobile m in m_ToDrain )
				{
					m_Owner.DoHarmful( m );

					m.FixedParticles( 0x374A, 10, 15, 5013, 0x455, 0, EffectLayer.Waist );
					m.PlaySound( 0x1F1 );

					int drain = Utility.RandomMinMax( 10, 15 );

					m_Owner.Hits += drain;

					if ( m_Owner.Topboss != null )
						m_Owner.Topboss.Hits += drain;

					m.Damage( drain, m_Owner );
				}

				m_ToDrain.Clear();
			}
		}
	}
}

namespace Server.Items
{
	public class GladiatorArms : DragonTurtleHideArms
	{
		public override int ArtifactRarity{ get{ return 100; } }

		public override int InitMinHits{ get{ return 200; } }
		public override int InitMaxHits{ get{ return 200; } }

		[Constructable]
		public GladiatorArms()
		{
			Weight = 10.0; 
            		Name = "Arms Of Gladiator"; 
            		Hue = 1152;

            Attributes.AttackChance = Utility.RandomMinMax(15, 25);
            Attributes.DefendChance = Utility.RandomMinMax(15, 25);
			Attributes.ReflectPhysical = 20;
			Attributes.SpellDamage = 15;
			Attributes.BonusStam = 15;
                       this.Attributes.WeaponSpeed = 20;
                       

			ArmorAttributes.MageArmor = 1;
			
			StrRequirement = 130;
            PhysicalBonus = Utility.RandomMinMax(15, 18);
            ColdBonus = Utility.RandomMinMax(10, 15);
            FireBonus = Utility.RandomMinMax(10, 15);
            PoisonBonus = Utility.RandomMinMax(10, 15);
            EnergyBonus = Utility.RandomMinMax(10, 15);
            Attributes.BonusStr = Utility.RandomMinMax(5, 10);
            Attributes.Luck = Utility.RandomMinMax(200, 400);
            Attributes.LowerManaCost = Utility.RandomMinMax(10, 20);
            Attributes.LowerRegCost = Utility.RandomMinMax(15, 25);

           switch( Utility.Random(16) )
            {
                case 0:  this.SkillBonuses.SetValues( 0, SkillName.EvalInt, 10);  break;
                case 1:  this.SkillBonuses.SetValues( 0, SkillName.Anatomy, 10);  break;
                case 2:  this.SkillBonuses.SetValues( 0, SkillName.Parry, 10);  break;
                case 3:  this.SkillBonuses.SetValues( 0, SkillName.Discordance, 10);  break;
                case 4:  this.SkillBonuses.SetValues( 0, SkillName.Healing, 10);  break;
                case 5:  this.SkillBonuses.SetValues( 0, SkillName.Magery, 10);  break;
                case 6:  this.SkillBonuses.SetValues( 0, SkillName.Tactics, 10);  break;
                case 7:  this.SkillBonuses.SetValues( 0, SkillName.Musicianship, 10);  break;
                case 8:  this.SkillBonuses.SetValues( 0, SkillName.Archery, 10);  break;
                case 9:  this.SkillBonuses.SetValues( 0, SkillName.AnimalTaming, 10);  break;
                case 10:  this.SkillBonuses.SetValues( 0, SkillName.Swords, 10);  break;
                case 11:  this.SkillBonuses.SetValues( 0, SkillName.Macing, 10);  break;
                case 12:  this.SkillBonuses.SetValues( 0, SkillName.Necromancy, 10);  break;
                case 13:  this.SkillBonuses.SetValues( 0, SkillName.Bushido, 10);  break;
                case 14:  this.SkillBonuses.SetValues( 0, SkillName.Ninjitsu, 10);  break;
                case 15:  this.SkillBonuses.SetValues( 0, SkillName.Chivalry, 10);  break;

                  }
		}

		public GladiatorArms( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize( GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

				public override bool OnEquip( Mobile from )
		{
			return Validate( from ) && base.OnEquip( from );
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( Validate( Parent as Mobile ) )
				base.OnSingleClick( from );
		}

		public bool Validate( Mobile m )
		{
			if ( m == null || !m.Player )
				return true;
			{
				m.FixedParticles( 0x376A, 10, 30, 5052, EffectLayer.LeftFoot );
				m.PlaySound( 0x217 );
				m.SendMessage( "Power leaps up " );

			}
			
			return true;
		}
	}
}
namespace Server.Items
{
	public class GladiatorChest : DragonTurtleHideChest
	{
		public override int ArtifactRarity{ get{ return 100; } }

		public override int InitMinHits{ get{ return 300; } }
		public override int InitMaxHits{ get{ return 300; } }

		[Constructable]
		public GladiatorChest()
		{
			Weight = 10.0; 
            		Name = "Chest Of Gladiator"; 
            		Hue = 1152;

			Attributes.CastRecovery = 2;
			Attributes.CastSpeed = 2;
            Attributes.AttackChance = Utility.RandomMinMax(15, 25);
            Attributes.DefendChance = Utility.RandomMinMax(15, 25);
			Attributes.ReflectPhysical = 15;
			Attributes.SpellDamage = 15;
			           this.Attributes.WeaponSpeed = 20;
                      

			ArmorAttributes.MageArmor = 1;
			
			StrRequirement = 130;
            PhysicalBonus = Utility.RandomMinMax(15, 20);
            ColdBonus = Utility.RandomMinMax(12, 15);
            FireBonus = Utility.RandomMinMax(13, 22);
            PoisonBonus = Utility.RandomMinMax(10, 20);
            EnergyBonus = Utility.RandomMinMax(10, 20);
            Attributes.BonusStr = Utility.RandomMinMax(5, 10);
            Attributes.Luck = Utility.RandomMinMax(300, 500);
            Attributes.LowerManaCost = Utility.RandomMinMax(10, 15);
            Attributes.LowerRegCost = Utility.RandomMinMax(20, 35);

          switch( Utility.Random(16) )
            {
                case 0:  this.SkillBonuses.SetValues( 0, SkillName.EvalInt, 10);  break;
                case 1:  this.SkillBonuses.SetValues( 0, SkillName.Anatomy, 10);  break;
                case 2:  this.SkillBonuses.SetValues( 0, SkillName.Parry, 10);  break;
                case 3:  this.SkillBonuses.SetValues( 0, SkillName.Discordance, 10);  break;
                case 4:  this.SkillBonuses.SetValues( 0, SkillName.Healing, 10);  break;
                case 5:  this.SkillBonuses.SetValues( 0, SkillName.Magery, 10);  break;
                case 6:  this.SkillBonuses.SetValues( 0, SkillName.Tactics, 10);  break;
                case 7:  this.SkillBonuses.SetValues( 0, SkillName.Musicianship, 10);  break;
                case 8:  this.SkillBonuses.SetValues( 0, SkillName.Archery, 10);  break;
                case 9:  this.SkillBonuses.SetValues( 0, SkillName.AnimalTaming, 10);  break;
                case 10:  this.SkillBonuses.SetValues( 0, SkillName.Swords, 10);  break;
                case 11:  this.SkillBonuses.SetValues( 0, SkillName.Macing, 10);  break;
                case 12:  this.SkillBonuses.SetValues( 0, SkillName.Necromancy, 10);  break;
                case 13:  this.SkillBonuses.SetValues( 0, SkillName.Bushido, 10);  break;
                case 14:  this.SkillBonuses.SetValues( 0, SkillName.Ninjitsu, 10);  break;
                case 15:  this.SkillBonuses.SetValues( 0, SkillName.Chivalry, 10);  break;

                  }

		}

		public GladiatorChest( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize( GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	
				public override bool OnEquip( Mobile from )
		{
			return Validate( from ) && base.OnEquip( from );
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( Validate( Parent as Mobile ) )
				base.OnSingleClick( from );
		}

		public bool Validate( Mobile m )
		{
			if ( m == null || !m.Player )
				return true;
			{
				m.FixedParticles( 0x376A, 10, 30, 5052, EffectLayer.LeftFoot );
				m.PlaySound( 0x217 );
				m.SendMessage( "Power leaps up " );

			}
			
			return true;
		}
	}
}
namespace Server.Items
{
	public class GladiatorGlove : BoneGloves
	{
		public override int ArtifactRarity{ get{ return 90; } }

		public override int InitMinHits{ get{ return 300; } }
		public override int InitMaxHits{ get{ return 300; } }

		[Constructable]
		public GladiatorGlove()
		{
			Weight = 20.0; 
            		Name = "Gloves of Gladiator"; 
            		Hue = 1152;

            Attributes.AttackChance = Utility.RandomMinMax(15, 20);
            Attributes.DefendChance = Utility.RandomMinMax(15, 20);
			Attributes.SpellDamage = 15;
			Attributes.BonusStam = 20;
                       this.Attributes.WeaponSpeed = 20;
                      

			ArmorAttributes.MageArmor = 1;
			
			StrRequirement = 130;
            PhysicalBonus = Utility.RandomMinMax(15, 20);
            ColdBonus = Utility.RandomMinMax(12, 16);
            FireBonus = Utility.RandomMinMax(15, 22);
            PoisonBonus = Utility.RandomMinMax(10, 18);
            EnergyBonus = Utility.RandomMinMax(10, 18);
            Attributes.BonusStr = Utility.RandomMinMax(5, 10);
            Attributes.Luck = Utility.RandomMinMax(300, 500);
            Attributes.LowerManaCost = Utility.RandomMinMax(10, 15);
            Attributes.LowerRegCost = Utility.RandomMinMax(20, 30);

          switch( Utility.Random(16) )
            {
                case 0:  this.SkillBonuses.SetValues( 0, SkillName.EvalInt, 10);  break;
                case 1:  this.SkillBonuses.SetValues( 0, SkillName.Anatomy, 10);  break;
                case 2:  this.SkillBonuses.SetValues( 0, SkillName.Parry, 10);  break;
                case 3:  this.SkillBonuses.SetValues( 0, SkillName.Discordance, 10);  break;
                case 4:  this.SkillBonuses.SetValues( 0, SkillName.Healing, 10);  break;
                case 5:  this.SkillBonuses.SetValues( 0, SkillName.Magery, 10);  break;
                case 6:  this.SkillBonuses.SetValues( 0, SkillName.Tactics, 10);  break;
                case 7:  this.SkillBonuses.SetValues( 0, SkillName.Musicianship, 10);  break;
                case 8:  this.SkillBonuses.SetValues( 0, SkillName.Archery, 10);  break;
                case 9:  this.SkillBonuses.SetValues( 0, SkillName.AnimalTaming, 10);  break;
                case 10:  this.SkillBonuses.SetValues( 0, SkillName.Swords, 10);  break;
                case 11:  this.SkillBonuses.SetValues( 0, SkillName.Macing, 10);  break;
                case 12:  this.SkillBonuses.SetValues( 0, SkillName.Necromancy, 10);  break;
                case 13:  this.SkillBonuses.SetValues( 0, SkillName.Bushido, 10);  break;
                case 14:  this.SkillBonuses.SetValues( 0, SkillName.Ninjitsu, 10);  break;
                case 15:  this.SkillBonuses.SetValues( 0, SkillName.Chivalry, 10);  break;

                  }
		}

		public GladiatorGlove( Serial serial ) : base( serial )
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

		public override bool OnEquip( Mobile from )
		{
			return Validate( from ) && base.OnEquip( from );
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( Validate( Parent as Mobile ) )
				base.OnSingleClick( from );
		}

		public bool Validate( Mobile m )
		{
			if ( m == null || !m.Player )
				return true;
			{
				m.FixedParticles( 0x376A, 10, 30, 5052, EffectLayer.LeftFoot );
				m.PlaySound( 0x217 );
				m.SendMessage( "Power leaps up " );

			}
			
			return true;
		}
	}
}
namespace Server.Items
{
	public class GladiatorHelm : BoneHelm
  {
		public override int ArtifactRarity{ get{ return 90; } }

		public override int InitMinHits{ get{ return 300; } }
		public override int InitMaxHits{ get{ return 300; } }

		[Constructable]
		public GladiatorHelm()
		{
			Weight = 5.0; 
			Name = "Helm of Gladiator";
			Hue = 1152;


            Attributes.AttackChance = Utility.RandomMinMax(15, 20);
            Attributes.DefendChance = Utility.RandomMinMax(15, 20);
			Attributes.SpellDamage = 15;
			Attributes.BonusStam = 20;
                

			ArmorAttributes.MageArmor = 1;
			
			StrRequirement = 130;
            PhysicalBonus = Utility.RandomMinMax(10, 20);
            ColdBonus = Utility.RandomMinMax(15, 20);
            FireBonus = Utility.RandomMinMax(12, 13);
            PoisonBonus = Utility.RandomMinMax(16, 20);
            EnergyBonus = Utility.RandomMinMax(16, 20);
            Attributes.BonusStr = Utility.RandomMinMax(10, 20);
            Attributes.BonusInt = Utility.RandomMinMax(10, 20);
            Attributes.Luck = Utility.RandomMinMax(300, 400);
            Attributes.LowerManaCost = Utility.RandomMinMax(10, 15);
            Attributes.LowerRegCost = Utility.RandomMinMax(20, 30);

          switch( Utility.Random(16) )
            {
                case 0:  this.SkillBonuses.SetValues( 0, SkillName.EvalInt, 10);  break;
                case 1:  this.SkillBonuses.SetValues( 0, SkillName.Anatomy, 10);  break;
                case 2:  this.SkillBonuses.SetValues( 0, SkillName.Parry, 10);  break;
                case 3:  this.SkillBonuses.SetValues( 0, SkillName.Discordance, 10);  break;
                case 4:  this.SkillBonuses.SetValues( 0, SkillName.Healing, 10);  break;
                case 5:  this.SkillBonuses.SetValues( 0, SkillName.Magery, 10);  break;
                case 6:  this.SkillBonuses.SetValues( 0, SkillName.Tactics, 10);  break;
                case 7:  this.SkillBonuses.SetValues( 0, SkillName.Musicianship, 10);  break;
                case 8:  this.SkillBonuses.SetValues( 0, SkillName.Archery, 10);  break;
                case 9:  this.SkillBonuses.SetValues( 0, SkillName.AnimalTaming, 10);  break;
                case 10:  this.SkillBonuses.SetValues( 0, SkillName.Swords, 10);  break;
                case 11:  this.SkillBonuses.SetValues( 0, SkillName.Macing, 10);  break;
                case 12:  this.SkillBonuses.SetValues( 0, SkillName.Necromancy, 10);  break;
                case 13:  this.SkillBonuses.SetValues( 0, SkillName.Bushido, 10);  break;
                case 14:  this.SkillBonuses.SetValues( 0, SkillName.Ninjitsu, 10);  break;
                case 15:  this.SkillBonuses.SetValues( 0, SkillName.Chivalry, 10);  break;

                  }
			
		}

		public GladiatorHelm( Serial serial ) : base( serial )
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

				public override bool OnEquip( Mobile from )
		{
			return Validate( from ) && base.OnEquip( from );
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( Validate( Parent as Mobile ) )
				base.OnSingleClick( from );
		}

		public bool Validate( Mobile m )
		{
			if ( m == null || !m.Player )
				return true;
			{
				m.FixedParticles( 0x376A, 10, 30, 5052, EffectLayer.LeftFoot );
				m.PlaySound( 0x217 );
				m.SendMessage( "Power leaps up " );

			}
			
			return true;
		}
	}
}
namespace Server.Items
{
	public class GladiatorLegs : DragonTurtleHideLegs
	{
		public override int ArtifactRarity{ get{ return 90; } }

		public override int InitMinHits{ get{ return 300; } }
		public override int InitMaxHits{ get{ return 300; } }

		[Constructable]
		public GladiatorLegs()
		{
			Weight = 20.0; 
            		Name = "Legs Of Gladiator"; 
            		Hue = 1152;

		    Attributes.AttackChance = Utility.RandomMinMax(10, 15);
            Attributes.DefendChance = Utility.RandomMinMax(10, 15);
			Attributes.SpellDamage = 15;
			Attributes.BonusMana = 10;
                    

			ArmorAttributes.MageArmor = 1;
			
			StrRequirement = 130;
            PhysicalBonus = Utility.RandomMinMax(13, 17);
            ColdBonus = Utility.RandomMinMax(12, 17);
            FireBonus = Utility.RandomMinMax(13, 18);
            PoisonBonus = Utility.RandomMinMax(10, 17);
            EnergyBonus = Utility.RandomMinMax(10, 17);

            Attributes.BonusStr = Utility.RandomMinMax(5, 10);
            Attributes.Luck = Utility.RandomMinMax(300, 500);
            Attributes.LowerManaCost = Utility.RandomMinMax(10, 15);
            Attributes.LowerRegCost = Utility.RandomMinMax(20, 25);
                       this.Attributes.WeaponSpeed = 20;

          switch( Utility.Random(16) )
            {
                case 0:  this.SkillBonuses.SetValues( 0, SkillName.EvalInt, 10);  break;
                case 1:  this.SkillBonuses.SetValues( 0, SkillName.Anatomy, 10);  break;
                case 2:  this.SkillBonuses.SetValues( 0, SkillName.Parry, 10);  break;
                case 3:  this.SkillBonuses.SetValues( 0, SkillName.Discordance, 10);  break;
                case 4:  this.SkillBonuses.SetValues( 0, SkillName.Healing, 10);  break;
                case 5:  this.SkillBonuses.SetValues( 0, SkillName.Magery, 10);  break;
                case 6:  this.SkillBonuses.SetValues( 0, SkillName.Tactics, 10);  break;
                case 7:  this.SkillBonuses.SetValues( 0, SkillName.Musicianship, 10);  break;
                case 8:  this.SkillBonuses.SetValues( 0, SkillName.Archery, 10);  break;
                case 9:  this.SkillBonuses.SetValues( 0, SkillName.AnimalTaming, 10);  break;
                case 10:  this.SkillBonuses.SetValues( 0, SkillName.Swords, 10);  break;
                case 11:  this.SkillBonuses.SetValues( 0, SkillName.Macing, 10);  break;
                case 12:  this.SkillBonuses.SetValues( 0, SkillName.Necromancy, 10);  break;
                case 13:  this.SkillBonuses.SetValues( 0, SkillName.Bushido, 10);  break;
                case 14:  this.SkillBonuses.SetValues( 0, SkillName.Ninjitsu, 10);  break;
                case 15:  this.SkillBonuses.SetValues( 0, SkillName.Chivalry, 10);  break;

                  }
		}

		public GladiatorLegs( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize( GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

				public override bool OnEquip( Mobile from )
		{
			return Validate( from ) && base.OnEquip( from );
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( Validate( Parent as Mobile ) )
				base.OnSingleClick( from );
		}

		public bool Validate( Mobile m )
		{
			if ( m == null || !m.Player )
				return true;
			{
				m.FixedParticles( 0x376A, 10, 30, 5052, EffectLayer.LeftFoot );
				m.PlaySound( 0x217 );
				m.SendMessage( "Power leaps up " );

			}
			
			return true;
		}
	}
  }

  namespace Server.Items
{
	public class FemaleGladiatorChest : DragonTurtleHideChest
	{
		public override int ArtifactRarity{ get{ return 100; } }

		public override int InitMinHits{ get{ return 300; } }
		public override int InitMaxHits{ get{ return 300; } }

		[Constructable]
		public FemaleGladiatorChest()
		{
			Weight = 10.0; 
            		Name = "Female Chest Of Gladiator"; 
					ItemID = 7174;
            		Hue = 1152;

	        Attributes.AttackChance = Utility.RandomMinMax(15, 25);
            Attributes.DefendChance = Utility.RandomMinMax(15, 25);
			Attributes.ReflectPhysical = 15;
			Attributes.SpellDamage = 15;
			this.Attributes.WeaponSpeed = 20;
                      

			ArmorAttributes.MageArmor = 1;
			
			StrRequirement = 130;
            PhysicalBonus = Utility.RandomMinMax(15, 20);
            ColdBonus = Utility.RandomMinMax(12, 15);
            FireBonus = Utility.RandomMinMax(13, 22);
            PoisonBonus = Utility.RandomMinMax(10, 20);
            EnergyBonus = Utility.RandomMinMax(10, 20);
            Attributes.BonusStr = Utility.RandomMinMax(10, 20);
            Attributes.Luck = Utility.RandomMinMax(300, 500);
            Attributes.LowerManaCost = Utility.RandomMinMax(10, 15);
            Attributes.LowerRegCost = Utility.RandomMinMax(20, 35);

          switch( Utility.Random(16) )
            {
                case 0:  this.SkillBonuses.SetValues( 0, SkillName.EvalInt, 10);  break;
                case 1:  this.SkillBonuses.SetValues( 0, SkillName.Anatomy, 10);  break;
                case 2:  this.SkillBonuses.SetValues( 0, SkillName.Parry, 10);  break;
                case 3:  this.SkillBonuses.SetValues( 0, SkillName.Discordance, 10);  break;
                case 4:  this.SkillBonuses.SetValues( 0, SkillName.Healing, 10);  break;
                case 5:  this.SkillBonuses.SetValues( 0, SkillName.Magery, 10);  break;
                case 6:  this.SkillBonuses.SetValues( 0, SkillName.Tactics, 10);  break;
                case 7:  this.SkillBonuses.SetValues( 0, SkillName.Musicianship, 10);  break;
                case 8:  this.SkillBonuses.SetValues( 0, SkillName.Archery, 10);  break;
                case 9:  this.SkillBonuses.SetValues( 0, SkillName.AnimalTaming, 10);  break;
                case 10:  this.SkillBonuses.SetValues( 0, SkillName.Swords, 10);  break;
                case 11:  this.SkillBonuses.SetValues( 0, SkillName.Macing, 10);  break;
                case 12:  this.SkillBonuses.SetValues( 0, SkillName.Necromancy, 10);  break;
                case 13:  this.SkillBonuses.SetValues( 0, SkillName.Bushido, 10);  break;
                case 14:  this.SkillBonuses.SetValues( 0, SkillName.Ninjitsu, 10);  break;
                case 15:  this.SkillBonuses.SetValues( 0, SkillName.Chivalry, 10);  break;

                  }

		}

		public FemaleGladiatorChest( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize( GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	
				public override bool OnEquip( Mobile from )
		{
			return Validate( from ) && base.OnEquip( from );
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( Validate( Parent as Mobile ) )
				base.OnSingleClick( from );
		}

		public bool Validate( Mobile m )
		{
			if ( m == null || !m.Player )
				return true;
			{
				m.FixedParticles( 0x376A, 10, 30, 5052, EffectLayer.LeftFoot );
				m.PlaySound( 0x217 );
				m.SendMessage( "Power leaps up " );

			}
			
			return true;
		}
	}
}
  
namespace Server.Items
{

	public class GladiatorDeed : Item
	{

		[Constructable]
		public GladiatorDeed () : this( null )
		{
		}

		[Constructable]
		public GladiatorDeed ( string name ) : base ( 0x14F0 )
		{
			Name = "Random Gladiator Armor Deed ";
			Hue = 1152;
		}

		public GladiatorDeed ( Serial serial ) : base ( serial )
		{
		}

      		public override void OnDoubleClick( Mobile from ) 
      		{
			if ( !IsChildOf( from.Backpack ) )
			{
                from.SendLocalizedMessage(1042001);
            }
            else
            {
/////////////////Prize GladiatorDeed
                switch (Utility.Random(5))       
                {
                    case 0: from.AddToBackpack(new GladiatorArms()); break;
                    case 1: from.AddToBackpack(new GladiatorChest()); break;
                    case 2: from.AddToBackpack(new GladiatorGlove()); break;
                    case 3: from.AddToBackpack(new GladiatorHelm()); break;
                    case 4: from.AddToBackpack(new GladiatorLegs()); break;
					case 5: from.AddToBackpack(new FemaleGladiatorChest()); break;
                        
                }
                this.Delete();
			}

		}

		public override void Serialize ( GenericWriter writer)
		{
			base.Serialize ( writer );

			writer.Write ( (int) 0);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize ( reader );

			int version = reader.ReadInt();
		}
	}
}
