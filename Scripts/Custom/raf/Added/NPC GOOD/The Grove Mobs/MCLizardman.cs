using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a mc lizardman corpse" )]
	public class MCLizardman : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Lizardman; } }

		[Constructable]
		public MCLizardman() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Master Lizardman";
			Body = Utility.RandomList( 35, 36 );
			BaseSoundID = 417;
            Hue = 1917;

			SetStr( 226, 350 );
			SetDex( 86, 155 );
			SetInt( 36, 200 );

			SetHits( 1800, 2200 );

			SetDamage( 14, 16 );

			SetDamageType( ResistanceType.Physical, 65 );

			SetResistance( ResistanceType.Physical, 25, 30 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Cold, 5, 10 );
			SetResistance( ResistanceType.Poison, 10, 20 );

			SetSkill( SkillName.MagicResist, 55.1, 60.0 );
			SetSkill( SkillName.Tactics, 55.1, 80.0 );
			SetSkill( SkillName.Wrestling, 50.1, 70.0 );

			Fame = 1500;
			Karma = -1500;

			VirtualArmor = 28;

                        PackGold(600, 1100);
                        PackItem(new MasterCoin( 5 ) );
        }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			// TODO: weapon
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 12; } }
		public override HideType HideType{ get{ return HideType.Spined; } }
        public override bool AlwaysMurderer { get { return true; } }

		public MCLizardman( Serial serial ) : base( serial )
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