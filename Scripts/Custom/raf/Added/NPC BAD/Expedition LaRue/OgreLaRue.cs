using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an ogre corpse" )]
	public class OgreLaRue : BaseCreature
	{
		[Constructable]
		public OgreLaRue () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.5 )
		{
			Name = "an Ogre of LaRue";
			Body = 1;
			BaseSoundID = 427;
            Hue = 1910;

			SetStr( 366, 495 );
			SetDex( 246, 265 );
			SetInt( 46, 70 );

			SetHits( 1000, 1117 );
			SetMana( 0 );

			SetDamage( 15, 21 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50, 55 );
			SetResistance( ResistanceType.Fire, 55, 55 );
			SetResistance( ResistanceType.Cold, 55, 55 );
			SetResistance( ResistanceType.Poison, 55, 55 );
			SetResistance( ResistanceType.Energy, 55 );

			SetSkill( SkillName.MagicResist, 55.1, 70.0 );
			SetSkill( SkillName.Tactics, 110.1, 150.0 );
			SetSkill( SkillName.Wrestling, 115.1, 115.0 );
            SetSkill( SkillName.Anatomy, 110.2, 115.0 );

			Fame = 21000;
			Karma = -3000;

			VirtualArmor = 40;

			PackItem( new Club() );
			PackItem( new MasterCoin(5) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Potions );
		}
        public override bool AlwaysMurderer{ get{ return true; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 3; } }

		public OgreLaRue( Serial serial ) : base( serial )
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