using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Factions;

namespace Server.Mobiles
{
	[CorpseName( "an ogre lords corpse" )]
	public class OgreLorda : BaseCreature
	{
		public override Faction FactionAllegiance { get { return Minax.Instance; } }
		public override Ethics.Ethic EthicAllegiance { get { return Ethics.Ethic.Evil; } }

		[Constructable]
		public OgreLorda () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an ogre lord";
			Body = 83;
			BaseSoundID = 427;
                        Hue = Utility.Random(1, 100);


			SetStr( 767, 945 );
			SetDex( 266, 275 );
			SetInt( 46, 70 );

			SetHits( 1476, 1552 );

			SetDamage( 25, 31 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 65, 65 );
			SetResistance( ResistanceType.Fire, 50, 70 );
			SetResistance( ResistanceType.Cold, 50, 70 );
			SetResistance( ResistanceType.Poison, 50, 70 );
			SetResistance( ResistanceType.Energy, 50, 70 );

			SetSkill( SkillName.MagicResist, 125.1, 140.0 );
			SetSkill( SkillName.Tactics, 110.1, 120.0 );
			SetSkill( SkillName.Wrestling, 115.1, 120.0 );
                        SetSkill( SkillName.Anatomy, 120.0, 120.0 );


			Fame = 25000;
			Karma = -15000;

			VirtualArmor = 50;

			PackItem( new Club() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 2 );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 2; } }

		public OgreLorda( Serial serial ) : base( serial )
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