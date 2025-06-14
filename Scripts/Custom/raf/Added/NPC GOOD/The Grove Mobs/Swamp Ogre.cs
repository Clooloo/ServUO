using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a Swamp Ogre corpse" )]
	public class SwampOgre : BaseCreature
	{

		[Constructable]
		public SwampOgre () : base( AIType.AI_Berserk, FightMode.Closest, 10, 1, 0.3, 0.5 )
		{
			Hue = 2210;
			Name = "a Swamp Ogre";
			Body = Core.AOS ? 1 : 1;
			BaseSoundID = 427;

			SetStr( 595, 625 );
			SetDex( 81, 118 );
			SetInt( 175, 178 );

			SetHits( 1000, 1750 );
			SetStam( 120, 135 );

			SetDamage( 30, 33 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Poison, 50 );

			SetResistance( ResistanceType.Physical, 40, 55 );
			SetResistance( ResistanceType.Fire, 65, 70 );
			SetResistance( ResistanceType.Cold, 50, 55 );
			SetResistance( ResistanceType.Poison, 50, 51 );
			SetResistance( ResistanceType.Energy, 30, 35 );

			SetSkill( SkillName.Meditation, 0 );
			SetSkill( SkillName.EvalInt, 110.0, 140.0 );
			SetSkill( SkillName.Magery, 110.0, 140.0 );
			SetSkill( SkillName.Poisoning, 110.0, 140.0 );
			SetSkill( SkillName.Anatomy, 110.0, 140.0 );
			SetSkill( SkillName.MagicResist, 110.0, 140.0 );
			SetSkill( SkillName.Tactics, 110.0, 140.0 );
			SetSkill( SkillName.Wrestling, 115.0, 145.0 );

			Fame = 22000;
			Karma = -15000;

			VirtualArmor = 35;


		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 8 );
			AddLoot( LootPack.Gems, 8 );
			PackItem( new MasterCoin( 3 ) );
		}

		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 19; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.MortalStrike;
		}

		public SwampOgre( Serial serial ) : base( serial )
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

			SetDamage( 24, 33 );

		
		}
	}
}
