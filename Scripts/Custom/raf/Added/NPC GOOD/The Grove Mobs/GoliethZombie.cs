using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a Toxic corpse" )]
	public class GoliethZombie : BaseCreature
	{
		[Constructable]
		public GoliethZombie() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.6 )
		{
            Name = "-GoliethZombie-";
			Body = 0x318;
			BaseSoundID = 471;
            Hue = 1472;

			SetStr( 900, 1000 );
			SetDex( 500, 650 );
			SetInt( 2300, 2350 );

			SetHits( 36000, 55145 );

			SetDamage( 35, 45 );

			SetDamageType( ResistanceType.Physical, 75 );
            SetDamageType( ResistanceType.Poison, 95);

			SetResistance( ResistanceType.Physical,75, 85 );
			SetResistance( ResistanceType.Fire, 50, 55 );
			SetResistance( ResistanceType.Cold, 85, 88 );
			SetResistance( ResistanceType.Poison, 90, 100 );
			SetResistance( ResistanceType.Energy, 70, 90 );

            SetSkill( SkillName.Poisoning, 175.5);
			SetSkill( SkillName.MagicResist, 145.0 );
			SetSkill( SkillName.Tactics, 135.5 );
			SetSkill( SkillName.Wrestling, 130.0 );

			Fame = 16000;
			Karma = -16000;

			VirtualArmor = 45;
                       
                        
                        PackItem( new MasterCoin( 15 ) );
                        AddLoot( LootPack.SuperBoss, 10 );
	
		}


		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

       //     if (0.005 > Utility.RandomDouble()) // 
        //    {           
        //        c.DropItem(new Herobow2());             
         //   }

            if (0.006 > Utility.RandomDouble()) //
            {           
                c.DropItem(new Herotalisman());             
            }

            if (0.006 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new HerobloodyApron());             
            }

            if (0.006 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new HerohoodedRobe());             
            }

        //    if (0.006 > Utility.RandomDouble()) // 
       //     {           
       //         c.DropItem(new EverlastingBandage());             
       //     }
                    
       
       //     if (0.01 > Utility.RandomDouble()) // 
       //     {           
       //         c.DropItem(new EverlastingBandage());             
       //     }

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


                public override bool AutoDispel{ get{ return true; } }
	        public override bool BardImmune{ get{ return true; } }
       	        public override bool AlwaysMurderer { get { return true; } }
		
                public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }

        public GoliethZombie(Serial serial): base(serial)
            
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