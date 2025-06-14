using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a Ocean Serpent corpse" )]
	public class OceanSerpent : BaseCreature
	{
	

		[Constructable]
		public OceanSerpent () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an Ocean Serpant";
			Body = 0x15;
			BaseSoundID = 219;
			Hue = 1152;

			SetStr( 426, 555 );
			SetDex( 90, 95 );
			SetInt( 45, 65 );

			SetHits( 1500, 2500 );

			SetDamage( 15, 22 );

			SetDamageType( ResistanceType.Physical, 90 );
			SetDamageType( ResistanceType.Poison, 10 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Fire, 40, 60 );
			SetResistance( ResistanceType.Cold, 58, 65 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, 20, 32 );

			SetSkill( SkillName.EvalInt, 100.0, 120.0 );
			SetSkill( SkillName.Magery, 100.0, 120.0 );
			SetSkill( SkillName.MagicResist, 85.0, 100.0 );
			SetSkill( SkillName.Tactics, 120.0, 120.0 );
			SetSkill( SkillName.Wrestling, 120.0, 120.0 );
			SetSkill( SkillName.Meditation, 100.0, 120.0 );
			

			Fame = 4500;
			Karma = -4500;

			VirtualArmor = 50;
			CanSwim = true;

			PackItem( new BlackPearl( 3 ) );
			PackItem( new MasterCoin( 5 ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 4 );
			
		}

		public override bool BleedImmune{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override bool AlwaysMurderer{ get{ return true; } }

		public OceanSerpent( Serial serial ) : base( serial )
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