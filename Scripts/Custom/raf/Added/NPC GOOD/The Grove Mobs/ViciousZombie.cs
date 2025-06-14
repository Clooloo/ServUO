using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a rotting corpse" )]
	public class HighZombie : BaseCreature
	{
		[Constructable]
		public HighZombie() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.3, 0.5 )
		{
			Name = "-Vicious Zombie-";
			Body = 0x303;
            Hue = 1915;
			BaseSoundID = 471;

			SetStr( 1546, 1770 );
			SetDex( 231, 250 );
			SetInt( 126, 140 );

			SetHits( 3128, 12542 );

			SetDamage( 20, 35 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 90, 100 );
			SetResistance( ResistanceType.Cold, 90, 100 );
			SetResistance( ResistanceType.Poison, 90, 100 );

			SetSkill( SkillName.MagicResist, 115.1, 160.0 );
			SetSkill( SkillName.Tactics, 135.1, 150.0 );
			SetSkill( SkillName.Wrestling, 100.1, 120.0 );

			Fame = 16000;
			Karma = -16000;

			VirtualArmor = 60;
			
			switch ( Utility.Random( 10 ))
			{
				case 0: PackItem( new LeftArm() ); break;
				case 1: PackItem( new RightArm() ); break;
				case 2: PackItem( new Torso() ); break;
				case 3: PackItem( new Bone() ); break;
				case 4: PackItem( new RibCage() ); break;
				case 5: PackItem( new RibCage() ); break;
				case 6: PackItem( new BonePile() ); break;
				case 7: PackItem( new BonePile() ); break;
				case 8: PackItem( new BonePile() ); break;
				case 9: PackItem( new MasterCoin() ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich );
            AddLoot(LootPack.FilthyRich, 2);
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }

		public HighZombie( Serial serial ) : base( serial )
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