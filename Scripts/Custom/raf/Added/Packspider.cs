using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.ContextMenus;

namespace Server.Mobiles
{
	[CorpseName( "a Pack Spider corpse" )]
	public class Packspider : BaseMount
	{
		[Constructable]
		public Packspider() : this( "a Pack spider" )
		{
		}

		public override bool SubdueBeforeTame{ get{ return true; } } // Must be beaten into submission

		[Constructable]
		public Packspider( string name ) : base( name, 152, 0x3ECA, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Lord SpiderMan ";
			Hue = 2444;
                        BaseSoundID = 0x24D;

			SetStr( 900, 2000 );
			SetDex( 500, 600 );
			SetInt( 2000, 3000 );

			SetHits( 2600, 3000 );

			SetDamage( 25, 45 );

                        SetDamageType(ResistanceType.Physical, 20);
                        SetDamageType(ResistanceType.Fire, 20);
                        SetDamageType(ResistanceType.Cold, 20);
                        SetDamageType(ResistanceType.Poison, 40);
                        SetDamageType(ResistanceType.Energy, 20);

			SetResistance( ResistanceType.Physical, 70, 80 );
			SetResistance( ResistanceType.Fire, 65, 78 );
			SetResistance( ResistanceType.Cold, 65, 78 );
			SetResistance( ResistanceType.Poison, 90, 100 );
			SetResistance( ResistanceType.Energy, 70, 75 );

                        SetSkill( SkillName.Anatomy, 100.1, 125.0 );
			SetSkill( SkillName.MagicResist, 140.1, 160.0 );
			SetSkill( SkillName.Tactics, 120.1, 150.0 );
			SetSkill( SkillName.Wrestling, 110.1, 140.0 );
                        SetSkill( SkillName.Poisoning, 120.1, 140.0);
		        SetSkill( SkillName.Meditation, 100.0, 120.0 );

			Fame = 17000;
			Karma = -17000;

			Tamable = true;
			ControlSlots = 5;
			MinTameSkill = 105.1;

			Container pack = Backpack;

			if ( pack != null )
				pack.Delete();

			pack = new StrongBackpack();
			pack.Movable = false;

			AddItem( pack );
		}

		public override int GetAngerSound()
		{
			return 0x21D;
		}

		public override int GetIdleSound()
		{
			return 0x21D;
		}

		public override int GetAttackSound()
		{
			return 0x162;
		}

		public override int GetHurtSound()
		{
			return 0x163;
		}

		public override int GetDeathSound()
		{
			return 0x21D;
		}

                public override bool AutoDispel{ get{ return true; } }
	        public override bool BardImmune{ get{ return true; } }
                public override bool AlwaysMurderer { get { return true; } }
                public override Poison HitPoison { get { return Poison.Deadly; } }  
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }       


        public override WeaponAbility GetWeaponAbility() 
        {
            int ability = Utility.Random(3);
            if (ability == 1)
                return WeaponAbility.MortalStrike;
            else if (ability == 2)
                return WeaponAbility.ParalyzingBlow;
            else
                return WeaponAbility.WhirlwindAttack;
        }


		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		// TODO: Speed boost when hit by magic.

		public Packspider( Serial serial ) : base( serial )
		{
		}

		#region Pack Animal Methods
		public override bool OnBeforeDeath()
		{
			if ( !base.OnBeforeDeath() )
				return false;

			PackAnimal.CombineBackpacks( this );

			return true;
		}

		public override DeathMoveResult GetInventoryMoveResultFor( Item item )
		{
			return DeathMoveResult.MoveToCorpse;
		}

		public override bool IsSnoop( Mobile from )
		{
			if ( PackAnimal.CheckAccess( this, from ) )
				return false;

			return base.IsSnoop( from );
		}

		public override bool OnDragDrop( Mobile from, Item item )
		{
			if ( CheckFeed( from, item ) )
				return true;

			if ( PackAnimal.CheckAccess( this, from ) )
			{
				AddToBackpack( item );
				return true;
			}

			return base.OnDragDrop( from, item );
		}

		public override bool CheckNonlocalDrop( Mobile from, Item item, Item target )
		{
			return PackAnimal.CheckAccess( this, from );
		}

		public override bool CheckNonlocalLift( Mobile from, Item item )
		{
			return PackAnimal.CheckAccess( this, from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );

			PackAnimal.GetContextMenuEntries( this, from, list );
		}
		#endregion

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}