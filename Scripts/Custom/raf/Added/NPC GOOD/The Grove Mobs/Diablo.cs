using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a Diablo corpse" )]
	public class Diablo2 : BaseCreature
	{
		[Constructable]
		public Diablo2 () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.6 )
		{
		//	AuraMessage = "Get OUT!"; // TODO Cliloc support: 1008111
		//	AuraType = ResistanceType.Cold;
		//	MinAuraDelay = 5;
		//	MaxAuraDelay = 10;
		//	MinAuraDamage = 35;
		//	MaxAuraDamage = 45;
		//	AuraRange = 10;

			Name = "Lord Diablo";
			Body = 1433;
			BaseSoundID = 604;
                        Hue = 0;

			SetStr( 1500, 1700 );
			SetDex( 2400, 2995 );
			SetInt( 4501, 5925 );

			SetHits( 52000, 72000 );

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
       //         c.DropItem(new HeroWeapondeed());             
       //     }

            if (0.10 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Robedeed());             
            }

         //   if (0.05 > Utility.RandomDouble()) // 
          //  {           
        //        c.DropItem(new EverlastingBandage());             
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
				if ( m is MasterMikael || m is IceFiend || m is SirPatrick )
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
						case 0: case 1:	Mob = new MasterMikael(); break;
						case 2: case 3:	Mob = new IceFiend(); break;
						case 4:	case 5:	Mob = new SirPatrick(); break;
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

		public Diablo2( Serial serial ) : base( serial )
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