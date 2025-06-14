using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an ettin lord corpse" )]
	public class EttinLord : BaseCreature
	{
		[Constructable]
		public EttinLord() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an ettin lord";
			Body = 18;
			BaseSoundID = 367;
                        Hue = Utility.Random(1, 100);


			SetStr( 636, 705 );
			SetDex( 286, 385 );
			SetInt( 131, 155 );

			SetHits( 1182, 1299 );

			SetDamage( 29, 31 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 65, 70 );
			SetResistance( ResistanceType.Fire, 55, 65 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 55, 55 );
			SetResistance( ResistanceType.Energy, 55, 65 );

			SetSkill( SkillName.MagicResist, 40.1, 55.0 );
			SetSkill( SkillName.Tactics, 100.0, 120.0 );
			SetSkill( SkillName.Wrestling, 100.0, 120.0 );
                        SetSkill( SkillName.Anatomy, 100.0, 120.0 );

			Fame = 23000;
			Karma = -3000;

			VirtualArmor = 50;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Potions );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 4; } }

		public EttinLord( Serial serial ) : base( serial )
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