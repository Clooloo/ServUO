using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( " Jack the Ripper corpse" )]
	public class mmobJack: BaseCreature
	{
		[Constructable]
		public mmobJack() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.6 )
		{
		//	AuraMessage = "The intense cold is damaging you!"; // TODO Cliloc support: 1008111
		//	AuraType = ResistanceType.Cold;
		//	MinAuraDelay = 5;
		//	MaxAuraDelay = 10;
		//	MinAuraDamage = 35;
		//	MaxAuraDamage = 45;
		//	AuraRange = 10;

			Name = " Jack the Ripper ";
			Body = 991;
			BaseSoundID = 0x59F;
                        Hue = 0;

			SetStr( 2000, 2500 );
			SetDex( 1400, 1995 );
			SetInt( 5001, 5925 );

			SetHits( 60000, 75000 );

			SetDamage( 35, 65 );

			SetSkill( SkillName.EvalInt, 150, 180.0 );
			SetSkill( SkillName.Magery, 100, 120.0 );
			SetSkill( SkillName.MagicResist, 75.1, 105.0 );
			SetSkill( SkillName.Tactics, 100, 120.0 );
			SetSkill( SkillName.Wrestling, 130, 150.0 );
			SetSkill( SkillName.Meditation, 200.0 );

			SetResistance( ResistanceType.Physical,65, 85 );
			SetResistance( ResistanceType.Fire, 70, 80 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Poison, 70, 80 );
			SetResistance( ResistanceType.Energy, 70, 80 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 60;
                        
		        PackItem( new OrochimarusHeart());
                        PackItem (new CrystallineBlackrock(10));
                        PackItem (new RelicFragment(10));
                       
                        PackItem (new RAD());
                        PackItem (new RAD());
                        PackItem (new RAD());
                        PackItem( new MasterCoin( 30 ) );
                        AddLoot( LootPack.SuperBoss, 3 );
	
		}        


		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

            if (0.05 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Herodeed());             
            }

    //        if (0.04 > Utility.RandomDouble()) // 
      // //     {           
       //         c.DropItem(new HeroWeapondeed());             
       //     }

            if (0.10 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Robedeed());             
            }

       //     if (0.05 > Utility.RandomDouble()) // 
       //     {           
      //          c.DropItem(new EverlastingBandage());             
       //     }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicClothDeed());             

		}

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

		public void spawnmobs( Mobile target )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			int mobs = 0;

			foreach ( Mobile m in this.GetMobilesInRange( 10 ) )
			{
				if ( m is Ronin || m is MasterTheophilus || m is Troglodyte )
					++mobs;
			}

			if ( mobs < 4 )
			{
				int newmobs = 1;

				for ( int i = 0; i < newmobs; ++i )
				{
					BaseCreature Mob;

					switch ( Utility.Random( 6 ) )
					{
						default:
						case 0: case 1:	Mob = new Ronin(); break;
						case 2: case 3:	Mob = new MasterTheophilus(); break;
						case 4:	case 5:	Mob = new Troglodyte(); break;
					}

					Mob.Team = this.Team;

					bool validLocation = false;
					Point3D loc = this.Location;

					for ( int j = 0; !validLocation && j < 10; ++j )
					{
						int x = X + Utility.Random( 3 ) - 1;
						int y = Y + Utility.Random( 3 ) - 1;
						int z = map.GetAverageZ( x, y );

						if ( validLocation = map.CanFit( x, y, this.Z, 16, false, false ) )
							loc = new Point3D( x, y, Z );
						else if ( validLocation = map.CanFit( x, y, z, 16, false, false ) )
							loc = new Point3D( x, y, z );
					}

					Mob.MoveToWorld( loc, map );
					Mob.Combatant = target;
				}
			}
		}

		public void DoSpecialAbility( Mobile target )
		{

			if ( 0.75 >= Utility.RandomDouble() ) // 25% chance to more daemons
				spawnmobs( target );

		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			DoSpecialAbility( attacker );
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			DoSpecialAbility( defender );
		}


                public override bool AutoDispel{ get{ return true; } }
	        public override bool BardImmune{ get{ return true; } }
                public override bool AlwaysMurderer { get { return true; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }
                
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } } 
                public override Poison HitPoison { get { return Poison.Deadly; } }

        public override WeaponAbility GetWeaponAbility() 
        {
            int ability = Utility.Random(3);
            if (ability == 1)
                return WeaponAbility.Dismount;
            else if (ability == 2)
                return WeaponAbility.MortalStrike;
            else
                return WeaponAbility.WhirlwindAttack;
        }


		public mmobJack( Serial serial ) : base( serial )
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

	[CorpseName( " Beast Parasyte corpse " )]
	public class mmobWater : BaseCreature
	{
      	[Constructable]
		public mmobWater () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.6 )
		{
			//AuraMessage = "Get OUT!"; // TODO Cliloc support: 1008111
			//AuraType = ResistanceType.Cold;
		//	MinAuraDelay = 5;
		//	MaxAuraDelay = 10;
		//	MinAuraDamage = 35;
		//	MaxAuraDamage = 45;
		//	AuraRange = 10;

			Name = " Beast Parasyte ";
			Body = 1427;
			BaseSoundID = 278;
                        Hue = 0;

			SetStr( 1500, 1700 );
			SetDex( 2400, 2995 );
			SetInt( 5501, 5925 );

			SetHits( 55000, 75000 );

			SetDamage( 30, 65 );

			SetSkill( SkillName.EvalInt, 100, 120.0 );
			SetSkill( SkillName.Magery, 100, 120.0 );
			SetSkill( SkillName.MagicResist, 75.1, 105.0 );
			SetSkill( SkillName.Tactics, 100, 120.0 );
			SetSkill( SkillName.Wrestling, 150, 170.0 );
			SetSkill( SkillName.Meditation, 200.0 );

			SetResistance( ResistanceType.Physical,65, 85 );
			SetResistance( ResistanceType.Fire, 70, 80 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Poison, 70, 80 );
			SetResistance( ResistanceType.Energy, 70, 80 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 60;
               
		        PackItem( new OrochimarusHeart());
                        PackItem (new CrystallineBlackrock(10));
                        PackItem (new RelicFragment(10));
                    
                        PackItem (new RAD());
                        PackItem (new RAD());
                        PackItem (new RAD());
                        PackItem( new MasterCoin( 30 ) );
                        AddLoot( LootPack.SuperBoss, 3 );
	
		}


		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

             if (0.05 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Herodeed());             
            }

         //   if (0.03 > Utility.RandomDouble()) // 
       //     {           
       //         c.DropItem(new HeroWeapondeed());             
       //     }

            if (0.10 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Robedeed());             
            }


       //     if (0.05 > Utility.RandomDouble()) // 
       //     {           
       //         c.DropItem(new EverlastingBandage());             
       //     }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicClothDeed());             

		}
          }

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            base.OnDamage(amount, from, willKill);
			
            // eats pet or summons
            if (from is BaseCreature)
            {
                BaseCreature creature = (BaseCreature)from;
				
                if (creature.Controlled || creature.Summoned)
                {
                    this.Heal(creature.Hits);					
                    creature.Kill();				
					
                    Effects.PlaySound(this.Location, this.Map, 0x574);
                }
            }
			
            // teleports player near
            if (from is PlayerMobile && !this.InRange(from.Location, 1))
            {
                this.Combatant = from;
				
                from.MoveToWorld(this.GetSpawnPosition(1), this.Map);				
                from.FixedParticles(0x376A, 9, 32, 0x13AF, EffectLayer.Waist);
                from.PlaySound(0x1FE);
            }
        }


		public void spawnmobs( Mobile target )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			int mobs = 0;

			foreach ( Mobile m in this.GetMobilesInRange( 10 ) )
			{
				if ( m is LesserHiryu || m is MyrmidexWarrior || m is Ogre )
					++mobs;
			}

			if ( mobs < 4 )
			{
				int newmobs = 1;

				for ( int i = 0; i < newmobs; ++i )
				{
					BaseCreature Mob;

					switch ( Utility.Random( 6 ) )
					{
						default:
						case 0: case 1:	Mob = new LesserHiryu(); break;
						case 2: case 3:	Mob = new MyrmidexWarrior(); break;
						case 4:	case 5:	Mob = new Ogre(); break;
					}

					Mob.Team = this.Team;

					bool validLocation = false;
					Point3D loc = this.Location;

					for ( int j = 0; !validLocation && j < 10; ++j )
					{
						int x = X + Utility.Random( 3 ) - 1;
						int y = Y + Utility.Random( 3 ) - 1;
						int z = map.GetAverageZ( x, y );

						if ( validLocation = map.CanFit( x, y, this.Z, 16, false, false ) )
							loc = new Point3D( x, y, Z );
						else if ( validLocation = map.CanFit( x, y, z, 16, false, false ) )
							loc = new Point3D( x, y, z );
					}

					Mob.MoveToWorld( loc, map );
					Mob.Combatant = target;
				}
			}
		}

		public void DoSpecialAbility( Mobile target )
		{

			if ( 0.75 >= Utility.RandomDouble() ) // 25% chance to more daemons
				spawnmobs( target );

		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			DoSpecialAbility( attacker );
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			DoSpecialAbility( defender );
		}



                public override bool AutoDispel{ get{ return true; } }
	        public override bool BardImmune{ get{ return true; } }
                public override bool AlwaysMurderer { get { return true; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }
                
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } } 
                public override Poison HitPoison { get { return Poison.Deadly; } }

        public override WeaponAbility GetWeaponAbility() 
        {
            int ability = Utility.Random(3);
            if (ability == 1)
                return WeaponAbility.Dismount;
            else if (ability == 2)
                return WeaponAbility.MortalStrike;
            else
                return WeaponAbility.WhirlwindAttack;
        }


		public mmobWater( Serial serial ) : base( serial )
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


	[CorpseName( " Ancient Tyrannosaurus corpse " )]
	public class mmobrex : BaseCreature
	{
      	[Constructable]
		public mmobrex () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.6 )
		{
			//AuraMessage = "Get OUT!"; // TODO Cliloc support: 1008111
		//	AuraType = ResistanceType.Cold;
		//	MinAuraDelay = 5;
		//	MaxAuraDelay = 15;
		//	MinAuraDamage = 35;
		//	MaxAuraDamage = 45;
		//	AuraRange = 10;

			Name = " Ancient Tyrannosaurus ";
			Body = 1400;
			BaseSoundID = 362;
                        Hue = 2444;

			SetStr( 1500, 1700 );
			SetDex( 2400, 2995 );
			SetInt( 5501, 5925 );

			SetHits( 55000, 78000 );

			SetDamage( 30, 65 );

			SetSkill( SkillName.EvalInt, 100, 120.0 );
			SetSkill( SkillName.Magery, 100, 120.0 );
			SetSkill( SkillName.MagicResist, 75.1, 105.0 );
			SetSkill( SkillName.Tactics, 100, 120.0 );
			SetSkill( SkillName.Wrestling, 130, 170.0 );
			SetSkill( SkillName.Meditation, 200.0 );

			SetResistance( ResistanceType.Physical,65, 85 );
			SetResistance( ResistanceType.Fire, 70, 80 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Poison, 70, 80 );
			SetResistance( ResistanceType.Energy, 70, 80 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 60;

		        PackItem( new OrochimarusHeart());
                        PackItem (new CrystallineBlackrock(10));
                        PackItem (new RelicFragment(10));
                       
                        PackItem (new RAD());
                        PackItem (new RAD());
                        PackItem (new RAD());
                        PackItem( new MasterCoin( 30 ) );
                        AddLoot( LootPack.SuperBoss, 3 );
	
		}


		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

             if (0.05 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Herodeed());             
            }

          //  if (0.03 > Utility.RandomDouble()) // 
         //   {           
         //       c.DropItem(new HeroWeapondeed());             
        //    }

            if (0.10 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Robedeed());             
            }

        //    if (0.05 > Utility.RandomDouble()) // 
       //     {           
       //         c.DropItem(new EverlastingBandage());             
      //      }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicClothDeed());             

		}
          }

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            base.OnDamage(amount, from, willKill);
			
            // eats pet or summons
            if (from is BaseCreature)
            {
                BaseCreature creature = (BaseCreature)from;
				
                if (creature.Controlled || creature.Summoned)
                {
                    this.Heal(creature.Hits);					
                    creature.Kill();				
					
                    Effects.PlaySound(this.Location, this.Map, 0x574);
                }
            }
			
            // teleports player near
            if (from is PlayerMobile && !this.InRange(from.Location, 1))
            {
                this.Combatant = from;
				
                from.MoveToWorld(this.GetSpawnPosition(1), this.Map);				
                from.FixedParticles(0x376A, 9, 32, 0x13AF, EffectLayer.Waist);
                from.PlaySound(0x1FE);
            }
        }


		public void spawnmobs( Mobile target )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			int mobs = 0;

			foreach ( Mobile m in this.GetMobilesInRange( 10 ) )
			{
				if ( m is Raptor || m is CaveTroll || m is Najasaurus )
					++mobs;
			}

			if ( mobs < 4 )
			{
				int newmobs = 1;

				for ( int i = 0; i < newmobs; ++i )
				{
					BaseCreature Mob;

					switch ( Utility.Random( 6 ) )
					{
						default:
						case 0: case 1:	Mob = new Raptor(); break;
						case 2: case 3:	Mob = new CaveTroll(); break;
						case 4:	case 5:	Mob = new Najasaurus(); break;
					}

					Mob.Team = this.Team;

					bool validLocation = false;
					Point3D loc = this.Location;

					for ( int j = 0; !validLocation && j < 10; ++j )
					{
						int x = X + Utility.Random( 3 ) - 1;
						int y = Y + Utility.Random( 3 ) - 1;
						int z = map.GetAverageZ( x, y );

						if ( validLocation = map.CanFit( x, y, this.Z, 16, false, false ) )
							loc = new Point3D( x, y, Z );
						else if ( validLocation = map.CanFit( x, y, z, 16, false, false ) )
							loc = new Point3D( x, y, z );
					}

					Mob.MoveToWorld( loc, map );
					Mob.Combatant = target;
				}
			}
		}

		public void DoSpecialAbility( Mobile target )
		{

			if ( 0.75 >= Utility.RandomDouble() ) // 25% chance to more daemons
				spawnmobs( target );

		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			DoSpecialAbility( attacker );
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			DoSpecialAbility( defender );
		}



                public override bool AutoDispel{ get{ return true; } }
	        public override bool BardImmune{ get{ return true; } }
                public override bool AlwaysMurderer { get { return true; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }
                
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } } 
                public override Poison HitPoison { get { return Poison.Deadly; } }

        public override WeaponAbility GetWeaponAbility() 
        {
            int ability = Utility.Random(3);
            if (ability == 1)
                return WeaponAbility.Dismount;
            else if (ability == 2)
                return WeaponAbility.MortalStrike;
            else
                return WeaponAbility.WhirlwindAttack;
        }


		public mmobrex( Serial serial ) : base( serial )
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


	[CorpseName( " Lord Kraken corpse " )]
	public class mmobkraken : BaseCreature
	{
      	[Constructable]
		public mmobkraken () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.6 )
		{
		//	AuraType = ResistanceType.Cold;
		//	MinAuraDelay = 5;
		//	MaxAuraDelay = 15;
		//	MinAuraDamage = 35;
		//	MaxAuraDamage = 45;
		//	AuraRange = 10;

			Name = " Lord Kraken ";
			Body = 1068;
			BaseSoundID = 1149;
                        Hue = 0;

			SetStr( 1500, 1700 );
			SetDex( 2400, 2995 );
			SetInt( 5501, 5925 );

			SetHits( 55000, 78000 );

			SetDamage( 30, 65 );

			SetSkill( SkillName.EvalInt, 130, 150.0 );
			SetSkill( SkillName.Magery, 120, 140.0 );
			SetSkill( SkillName.MagicResist, 75.1, 105.0 );
			SetSkill( SkillName.Tactics, 100, 120.0 );
			SetSkill( SkillName.Wrestling, 130, 160.0 );
			SetSkill( SkillName.Meditation, 200.0 );

			SetResistance( ResistanceType.Physical,65, 85 );
			SetResistance( ResistanceType.Fire, 70, 80 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Poison, 70, 80 );
			SetResistance( ResistanceType.Energy, 70, 80 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 60;

		        PackItem( new OrochimarusHeart());
                        PackItem (new CrystallineBlackrock(10));
                        PackItem (new RelicFragment(10));
                        
                        PackItem (new RAD());
                        PackItem (new RAD());
                        PackItem (new RAD());
                        PackItem( new MasterCoin( 30 ) );
                        AddLoot( LootPack.SuperBoss, 3 );
	
		}


		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

             if (0.05 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Herodeed());             
            }

         //   if (0.03 > Utility.RandomDouble()) // 
         //   {           
         //       c.DropItem(new HeroWeapondeed());             
         //   }

            if (0.10 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Robedeed());             
            }

    //        if (0.05 > Utility.RandomDouble()) // 
     //       {           
     //           c.DropItem(new EverlastingBandage());             
    //        }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicClothDeed());             

		}
          }

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            base.OnDamage(amount, from, willKill);
			
            // eats pet or summons
            if (from is BaseCreature)
            {
                BaseCreature creature = (BaseCreature)from;
				
                if (creature.Controlled || creature.Summoned)
                {
                    this.Heal(creature.Hits);					
                    creature.Kill();				
					
                    Effects.PlaySound(this.Location, this.Map, 0x574);
                }
            }
			
            // teleports player near
            if (from is PlayerMobile && !this.InRange(from.Location, 1))
            {
                this.Combatant = from;
				
                from.MoveToWorld(this.GetSpawnPosition(1), this.Map);				
                from.FixedParticles(0x376A, 9, 32, 0x13AF, EffectLayer.Waist);
                from.PlaySound(0x1FE);
            }
        }


		public void spawnmobs( Mobile target )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			int mobs = 0;

			foreach ( Mobile m in this.GetMobilesInRange( 10 ) )
			{
				if ( m is RaiJu || m is BloodElemental || m is TsukiWolf )
					++mobs;
			}

			if ( mobs < 4 )
			{
				int newmobs = 1;

				for ( int i = 0; i < newmobs; ++i )
				{
					BaseCreature Mob;

					switch ( Utility.Random( 6 ) )
					{
						default:
						case 0: case 1:	Mob = new RaiJu(); break;
						case 2: case 3:	Mob = new BloodElemental(); break;
						case 4:	case 5:	Mob = new TsukiWolf(); break;
					}

					Mob.Team = this.Team;

					bool validLocation = false;
					Point3D loc = this.Location;

					for ( int j = 0; !validLocation && j < 10; ++j )
					{
						int x = X + Utility.Random( 3 ) - 1;
						int y = Y + Utility.Random( 3 ) - 1;
						int z = map.GetAverageZ( x, y );

						if ( validLocation = map.CanFit( x, y, this.Z, 16, false, false ) )
							loc = new Point3D( x, y, Z );
						else if ( validLocation = map.CanFit( x, y, z, 16, false, false ) )
							loc = new Point3D( x, y, z );
					}

					Mob.MoveToWorld( loc, map );
					Mob.Combatant = target;
				}
			}
		}

		public void DoSpecialAbility( Mobile target )
		{

			if ( 0.75 >= Utility.RandomDouble() ) // 25% chance to more daemons
				spawnmobs( target );

		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			DoSpecialAbility( attacker );
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			DoSpecialAbility( defender );
		}




                public override bool AutoDispel{ get{ return true; } }
	        public override bool BardImmune{ get{ return true; } }
                public override bool AlwaysMurderer { get { return true; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }
                
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } } 
                public override Poison HitPoison { get { return Poison.Deadly; } }

        public override WeaponAbility GetWeaponAbility() 
        {
            int ability = Utility.Random(3);
            if (ability == 1)
                return WeaponAbility.Dismount;
            else if (ability == 2)
                return WeaponAbility.MortalStrike;
            else
                return WeaponAbility.WhirlwindAttack;
        }

		public mmobkraken( Serial serial ) : base( serial )
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


	[CorpseName( " Ancient legend Queen corpse" )]
	public class mmobQueen: BaseCreature
	{
		[Constructable]
		public mmobQueen() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.6 )
		{
		//	AuraMessage = "The intense cold is damaging you!"; // TODO Cliloc support: 1008111
		//	AuraType = ResistanceType.Cold;
		//	MinAuraDelay = 5;
		//	MaxAuraDelay = 10;
		//	MinAuraDamage = 35;
		//	MaxAuraDamage = 45;
		//	AuraRange = 10;

			Name = " Ancient legendary Queen ";
			Body = 1404;
			BaseSoundID = 959;
                        Hue = 0;

			SetStr( 2000, 2500 );
			SetDex( 1400, 1995 );
			SetInt( 3501, 5925 );

			SetHits( 65000, 70000 );

			SetDamage( 30, 65 );

			SetSkill( SkillName.EvalInt, 150, 180.0 );
			SetSkill( SkillName.Magery, 100, 120.0 );
			SetSkill( SkillName.MagicResist, 75.1, 105.0 );
			SetSkill( SkillName.Tactics, 100, 120.0 );
			SetSkill( SkillName.Wrestling, 130, 150.0 );
			SetSkill( SkillName.Meditation, 200.0 );

			SetResistance( ResistanceType.Physical,65, 85 );
			SetResistance( ResistanceType.Fire, 70, 80 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Poison, 70, 80 );
			SetResistance( ResistanceType.Energy, 70, 80 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 60;

		        PackItem( new OrochimarusHeart());
                        PackItem (new CrystallineBlackrock(10));
                        PackItem (new RelicFragment(10));
                       
                        PackItem (new RAD());
                        PackItem (new RAD());
                        PackItem (new RAD());
                        PackItem( new MasterCoin( 30 ) );
                        AddLoot( LootPack.SuperBoss, 3 );
	
		}        


		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

            if (0.05 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Herodeed());             
            }

       //     if (0.04 > Utility.RandomDouble()) // 
       //     {           
        //        c.DropItem(new HeroWeapondeed());             
        //    }

            if (0.10 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Robedeed());             
            }


       //     if (0.05 > Utility.RandomDouble()) // 
      //      {           
      //          c.DropItem(new EverlastingBandage());             
      //      }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicClothDeed());             

		}

            }

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            base.OnDamage(amount, from, willKill);
			
            // eats pet or summons
            if (from is BaseCreature)
            {
                BaseCreature creature = (BaseCreature)from;
				
                if (creature.Controlled || creature.Summoned)
                {
                    this.Heal(creature.Hits);					
                    creature.Kill();				
					
                    Effects.PlaySound(this.Location, this.Map, 0x574);
                }
            }
			
            // teleports player near
            if (from is PlayerMobile && !this.InRange(from.Location, 1))
            {
                this.Combatant = from;
				
                from.MoveToWorld(this.GetSpawnPosition(1), this.Map);				
                from.FixedParticles(0x376A, 9, 32, 0x13AF, EffectLayer.Waist);
                from.PlaySound(0x1FE);
            }
        }

		public void spawnmobs( Mobile target )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			int mobs = 0;

			foreach ( Mobile m in this.GetMobilesInRange( 10 ) )
			{
				if ( m is MinotaurCaptain || m is Coil || m is Devourer )
					++mobs;
			}

			if ( mobs < 4 )
			{
				int newmobs = 1;

				for ( int i = 0; i < newmobs; ++i )
				{
					BaseCreature Mob;

					switch ( Utility.Random( 6 ) )
					{
						default:
						case 0: case 1:	Mob = new MinotaurCaptain(); break;
						case 2: case 3:	Mob = new Coil(); break;
						case 4:	case 5:	Mob = new Devourer(); break;
					}

					Mob.Team = this.Team;

					bool validLocation = false;
					Point3D loc = this.Location;

					for ( int j = 0; !validLocation && j < 10; ++j )
					{
						int x = X + Utility.Random( 3 ) - 1;
						int y = Y + Utility.Random( 3 ) - 1;
						int z = map.GetAverageZ( x, y );

						if ( validLocation = map.CanFit( x, y, this.Z, 16, false, false ) )
							loc = new Point3D( x, y, Z );
						else if ( validLocation = map.CanFit( x, y, z, 16, false, false ) )
							loc = new Point3D( x, y, z );
					}

					Mob.MoveToWorld( loc, map );
					Mob.Combatant = target;
				}
			}
		}

		public void DoSpecialAbility( Mobile target )
		{

			if ( 0.75 >= Utility.RandomDouble() ) // 25% chance to more daemons
				spawnmobs( target );

		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			DoSpecialAbility( attacker );
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			DoSpecialAbility( defender );
		}




                public override bool AutoDispel{ get{ return true; } }
	        public override bool BardImmune{ get{ return true; } }
                public override bool AlwaysMurderer { get { return true; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }
                
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } } 
                public override Poison HitPoison { get { return Poison.Deadly; } }

        public override WeaponAbility GetWeaponAbility() 
        {
            int ability = Utility.Random(3);
            if (ability == 1)
                return WeaponAbility.Dismount;
            else if (ability == 2)
                return WeaponAbility.MortalStrike;
            else
                return WeaponAbility.WhirlwindAttack;
        }


		public mmobQueen( Serial serial ) : base( serial )
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