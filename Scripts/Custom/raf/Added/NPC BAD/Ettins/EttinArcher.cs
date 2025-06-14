using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an ettin archer corpse" )]
	public class EttinArcher : BaseCreature
	{
		[Constructable]
		public EttinArcher() : base( AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an ettin archer";
			Body = 18;
			BaseSoundID = 367;
                        Hue = Utility.Random(1, 100);

			SetStr( 336, 405 );
			SetDex( 86, 85 );
			SetInt( 31, 55 );

			SetHits( 682, 899 );

			SetDamage( 15, 19 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 50 );
			SetResistance( ResistanceType.Fire, 45, 55 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 45, 55 );
			SetResistance( ResistanceType.Energy, 45, 55 );

			SetSkill( SkillName.MagicResist, 40.1, 55.0 );
			SetSkill( SkillName.Tactics, 80.1, 90.0 );
			SetSkill( SkillName.Anatomy, 100.1, 110.0 );
                        SetSkill( SkillName.Archery, 90.1, 100.0 );

			Fame = 16000;
			Karma = -3000;

			VirtualArmor = 38;

                        AddItem( new Bow() );
			PackItem( new Arrow( Utility.Random( 50, 120 ) ) );
			PackGold( 575, 725 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Potions );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 3; } }
		public override int Meat{ get{ return 4; } }

		public EttinArcher  (Serial serial)  : base ( serial )
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