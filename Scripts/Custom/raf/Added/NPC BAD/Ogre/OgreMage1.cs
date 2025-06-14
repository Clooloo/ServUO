using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Factions;

namespace Server.Mobiles
{
	[CorpseName( "an ogre mage's corpse" )]
	public class OgreMage1 : BaseCreature
	{
		public override Faction FactionAllegiance { get { return Minax.Instance; } }
		public override Ethics.Ethic EthicAllegiance { get { return Ethics.Ethic.Evil; } }

		[Constructable]
		public OgreMage1 () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an ogre mage";
			Body = 83;
			BaseSoundID = 427;
			Hue = Utility.Random(1, 100);


			SetStr( 467, 589 );
			SetDex( 66, 75 );
			SetInt( 846, 879 );

			SetHits( 776, 952 );
			

			SetDamage( 20, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.MagicResist, 125.1, 140.0 );
			SetSkill( SkillName.Tactics, 60.1, 70.0 );
			SetSkill( SkillName.Wrestling, 70.1, 80.0 );
			SetSkill( SkillName.Magery, 100.0, 110.0 );

			Fame = 19000;
			Karma = -16000;

			VirtualArmor = 40;

			PackReg( 180 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Greater; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 7; } }

		public OgreMage1( Serial serial ) : base( serial )
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