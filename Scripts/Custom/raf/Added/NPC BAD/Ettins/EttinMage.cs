using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an ettins corpse" )]
	public class EttinMage : BaseCreature
	{
		[Constructable]
		public EttinMage() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an ettin mage";
			Body = 18;
			BaseSoundID = 367;
                        Hue = Utility.Random(1, 100);

			SetStr( 336, 405 );
			SetDex( 106, 185 );
			SetInt( 131, 155 );

			SetHits( 682, 799 );

			SetDamage( 19, 21 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 50 );
			SetResistance( ResistanceType.Fire, 45, 55 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 45, 55 );
			SetResistance( ResistanceType.Energy, 45, 55 );

			SetSkill( SkillName.MagicResist, 40.1, 55.0 );
			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.Wrestling, 50.1, 60.0 );
                        SetSkill( SkillName.EvalInt, 100.1, 110.0 );
			SetSkill( SkillName.Magery, 100.1, 110.0 );

			Fame = 13000;
			Karma = -3000;

			VirtualArmor = 38;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Potions );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 4; } }

		public EttinMage( Serial serial ) : base( serial )
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