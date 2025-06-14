using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a mad cow's corpse" )]
	public class FrenziedBull : BaseCreature
	{
		[Constructable]
		public FrenziedBull() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a frenzied bull";
			Body = Utility.RandomList( 0xE8, 0xE9 );
			BaseSoundID = 0x64;

			Hue = 1153;

			SetStr( 205, 245 );
			SetDex( 215, 238 );
			SetInt( 1000, 1500 );

			SetHits( 800, 1000 );

			SetDamage( 25, 45 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35, 40 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.EvalInt, 100.2, 118.0 );
			SetSkill( SkillName.Magery, 105.1, 116.0 );
			SetSkill( SkillName.Meditation, 27.5, 50.0 );
			SetSkill( SkillName.MagicResist, 98.5, 112.0 );
			SetSkill( SkillName.Tactics, 65.0, 87.5 );
			SetSkill( SkillName.Wrestling, 20.3, 80.0 );
			SetSkill( SkillName.Necromancy, 112.0, 119.9);

			Fame = 10000;
			Karma = -10000;

			VirtualArmor = 50;
		}

		public override int Meat{ get{ return 10; } }
		public override void GenerateLoot()
		{
			if ( Utility.Random(5) ==0 )
			PackItem( new PrizedLeather() );
			
		}

		public override bool AlwaysMurderer{ get{ return true; } }

		public FrenziedBull(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}