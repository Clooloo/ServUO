using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Aramagool's Corpse" )]
	public class Aramagool : Titan
	{
		[Constructable]
		public Aramagool()
		{
			Name = "Aramagool";
			Body = 76;
			BaseSoundID = 609;


			SetStr( 1500 );
			SetDex( 1300 );
			SetInt( 2200 );

			SetHits( 34000 );

			SetDamage( 25, 45 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 75 );

			SetResistance( ResistanceType.Physical, 100 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 65 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 70 );

			SetSkill( SkillName.MagicResist, 200.0 );
			SetSkill( SkillName.Tactics, 130.0 );
			SetSkill( SkillName.Wrestling, 130.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 50;

			PackItem( new AncientTitanHelm() );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
		}

                public override bool AutoDispel{ get{ return true; } }
	        public override bool BardImmune{ get{ return true; } }
                public override bool AlwaysMurderer { get { return true; } }
                
				public override bool AllureImmune{get{return true;}}

		public Aramagool( Serial serial ) : base( serial )
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