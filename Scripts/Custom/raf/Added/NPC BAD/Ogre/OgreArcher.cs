using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an ogre archer corpse" )]
	public class OgreArcher : BaseCreature
	{
		[Constructable]
		public OgreArcher () : base( AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an ogre archer";
			Body = 1;
			BaseSoundID = 427;
                        Hue = Utility.Random(1, 100);

			SetStr( 466, 595 );
			SetDex( 246, 265 );
			SetInt( 46, 70 );

			SetHits( 1100, 1217 );
			SetMana( 0 );

			SetDamage( 21, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50, 65 );
			SetResistance( ResistanceType.Fire, 55, 55 );
			SetResistance( ResistanceType.Cold, 55, 55 );
			SetResistance( ResistanceType.Poison, 55, 55 );
			SetResistance( ResistanceType.Energy, 55 );

			SetSkill( SkillName.MagicResist, 55.1, 70.0 );
			SetSkill( SkillName.Tactics, 100.1, 110.0 );
			SetSkill( SkillName.Wrestling, 70.1, 80.0 );
                        SetSkill( SkillName.Archery, 99.1, 110.0 );
                        SetSkill( SkillName.Anatomy, 99.2, 110.0 );

			Fame = 23000;
			Karma = -3000;

			VirtualArmor = 50;

			PackItem( new Club() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Potions );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 3; } }
		public override int Meat{ get{ return 2; } }

		public OgreArcher( Serial serial ) : base( serial )
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