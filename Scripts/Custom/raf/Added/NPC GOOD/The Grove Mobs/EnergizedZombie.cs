using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a rotting corpse" )]
	public class Energizedzombie : BaseCreature
	{
		[Constructable]
		public Energizedzombie() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.3, 0.5 )
		{
			Name = "-Energized Zombie-";
			Body = 154;
			BaseSoundID = 471;
                        Hue = 1472;

			SetStr( 1200, 1500 );
			SetDex( 400, 5000 );
			SetInt( 126, 140 );

			SetHits( 24000, 40000 );

			SetDamage( 25, 40 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical,75, 85 );
			SetResistance( ResistanceType.Fire, 50, 55 );
			SetResistance( ResistanceType.Cold, 85, 88 );
			SetResistance( ResistanceType.Poison, 90, 100 );
			SetResistance( ResistanceType.Energy, 70, 90 );

			SetSkill( SkillName.MagicResist, 115.1, 180.0 );
			SetSkill( SkillName.Tactics, 135.1, 170.0 );
			SetSkill( SkillName.Wrestling, 125.1, 140.0 );

			Fame = 16000;
			Karma = -16000;

			VirtualArmor = 50;


                        
                        PackItem( new MasterCoin( 3 ) );
                        AddLoot( LootPack.SuperBoss, 5 );
	
		}


		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

            if (0.001 > Utility.RandomDouble()) //
            {           
                c.DropItem(new Herotalisman());             
            }

            if (0.001 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new HerobloodyApron());             
            }

            if (0.001 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new HerohoodedRobe());             
            }

           


       //     if (0.01 > Utility.RandomDouble()) // 
      //      {           
      //          c.DropItem(new EverlastingBandage());             
      //      }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicClothDeed());             
            }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicKilt());             
            }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicBoots());             
            }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicRobe());             
            }


		}


                public override bool AlwaysMurderer { get { return true; } }
                
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }

		public Energizedzombie( Serial serial ) : base( serial )
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