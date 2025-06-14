using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a King Kong corpse" )]
	public class Kingkong : BaseCreature
	{
		[Constructable]
		public Kingkong() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.6 )
		{
            Name = " King Kong ";
			Body = 1308;
			BaseSoundID = 0x9E;
                        Hue = 2759;
   
			SetStr( 1500, 2000 );
			SetDex( 1000, 2000 );
			SetInt( 5300, 5350 );

			SetHits( 55000, 70000 );

			SetDamage( 30, 65 );

			SetResistance( ResistanceType.Physical,65, 85 );
			SetResistance( ResistanceType.Fire, 60, 80 );
			SetResistance( ResistanceType.Cold, 60, 85 );
			SetResistance( ResistanceType.Poison, 60, 65 );
			SetResistance( ResistanceType.Energy, 60, 80 );

            SetSkill( SkillName.Poisoning, 175.5);
			SetSkill( SkillName.MagicResist, 145.0 );
			SetSkill( SkillName.Tactics, 135.5 );
			SetSkill( SkillName.Wrestling, 150.0 );
			SetSkill( SkillName.Meditation, 200.0 );

			Fame = 16000;
			Karma = -16000;

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

          //  if (0.04 > Utility.RandomDouble()) // 
         //   {           
          //      c.DropItem(new HeroWeapondeed());             
         //   }

            if (0.10 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Robedeed());             
            }

        //    if (0.05 > Utility.RandomDouble()) // 
       //     {           
       //         c.DropItem(new EverlastingBandage());             
       //     }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicClothDeed());             

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
				if ( m is Miasma || m is Grobu || m is KhaldunSummoner )
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
						case 0: case 1:	Mob = new Miasma(); break;
						case 2: case 3:	Mob = new Grobu(); break;
						case 4:	case 5:	Mob = new KhaldunSummoner(); break;
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


                public override bool AlwaysMurderer { get { return true; } }
                public override bool AutoDispel{ get{ return true; } }
	        public override bool BardImmune{ get{ return true; } }        	
                	
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } } 
                public override Poison HitPoison { get { return Poison.Deadly; } }


		public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.MortalStrike;
        }

 private DateTime _NextBanana;
        private int _Thrown;

        public override void OnActionCombat()
        {
            Mobile combatant = Combatant as Mobile;

            if (DateTime.UtcNow < _NextBanana || combatant == null || combatant.Deleted || combatant.Map != Map || !InRange(combatant, 12) || !CanBeHarmful(combatant) || !InLOS(combatant))
                return;

            ThrowBanana(combatant);

            _Thrown++;

            if (0.75 >= Utility.RandomDouble() && (_Thrown % 2) == 1) // 75% chance to quickly throw another bomb
                _NextBanana = DateTime.UtcNow + TimeSpan.FromSeconds(3.0);
            else
                _NextBanana = DateTime.UtcNow + TimeSpan.FromSeconds(5.0 + (10.0 * Utility.RandomDouble())); // 5-15 seconds
        }

        public void ThrowBanana(Mobile m)
        {
            DoHarmful(m);

            this.MovingParticles(m, Utility.RandomList(0x171f, 0x1720, 0x1721, 0x1722), 10, 0, false, true, 0, 0, 9502, 6014, 0x11D, EffectLayer.Waist, 0);

            Timer.DelayCall(TimeSpan.FromSeconds(1), () =>
            {
                m.PlaySound(0x11D);
                AOS.Damage(m, this, Utility.RandomMinMax(150, 200), 100, 0, 0, 0, 0);
            });
        }


        public Kingkong(Serial serial): base(serial)
            
		{
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
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