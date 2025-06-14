using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a Rough Tiger corpse" )]
	public class RoughTiger : BaseCreature
	{
		[Constructable]
		public RoughTiger() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.6 )
		{
            Name = " Rough Tiger ";
			Body = 1416;
			BaseSoundID = 0xA3;
            Hue = 1584;

			SetStr( 1200, 1500 );
			SetDex( 500, 800 );
			SetInt( 1300, 1350 );

			SetHits( 18000, 20000 );

			SetDamage( 25, 35 );

			SetResistance( ResistanceType.Physical,75, 85 );
			SetResistance( ResistanceType.Fire, 70, 80 );
			SetResistance( ResistanceType.Cold, 60, 75 );
			SetResistance( ResistanceType.Poison, 70, 80 );
			SetResistance( ResistanceType.Energy, 70, 80 );

            SetSkill( SkillName.Poisoning, 175.5);
			SetSkill( SkillName.MagicResist, 145.0 );
			SetSkill( SkillName.Tactics, 135.5 );
			SetSkill( SkillName.Wrestling, 120.0 );

			Fame = 16000;
			Karma = -16000;

			VirtualArmor = 60;
                       
                        PackItem( new MasterCoin(1));
                        AddLoot( LootPack.SuperBoss, 2 );
	
		}

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);


             if (0.001 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Heroquiver());             
            }

       //     if (0.002 > Utility.RandomDouble()) // 
       //     {           
       //         c.DropItem(new EverlastingBandage());             
     //       }

            if (0.05 > Utility.RandomDouble()) // 50% chance to drop
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
        	
                	
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }
		public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.BleedAttack;
        }

        public RoughTiger(Serial serial): base(serial)
            
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