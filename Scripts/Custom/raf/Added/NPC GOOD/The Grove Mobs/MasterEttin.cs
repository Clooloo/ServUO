using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an ettins corpse" )]
	public class MasterEttin : BaseCreature
	{
		[Constructable]
		public MasterEttin() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Master ettin";
			Body = 18;
			BaseSoundID = 367;
            Hue = 2758;

			SetStr( 1036, 1365 );
			SetDex( 560, 750 );
			SetInt( 3301, 3505 );

			SetHits( 21000, 46990 );

			SetDamage( 35, 55 );

			SetDamageType( ResistanceType.Physical, 50 );
                        SetDamageType(ResistanceType.Cold, 50);

			SetResistance( ResistanceType.Physical, 75, 80 );
			SetResistance( ResistanceType.Fire, 75, 80 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 75, 80 );
			SetResistance( ResistanceType.Energy, 75, 85 );

			SetSkill( SkillName.MagicResist, 140.1, 155.0 );
			SetSkill( SkillName.Tactics, 150.1, 170.0 );
			SetSkill( SkillName.Wrestling, 140.1, 150.0 );

			Fame = 13000;
			Karma = -13000;

			VirtualArmor = 38;
 
                        
                        PackItem( new MasterCoin( 25 ) );
                        AddLoot( LootPack.SuperBoss, 5 );
	
		}


		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

           // if (0.006 > Utility.RandomDouble()) // 
           // {           
           //     c.DropItem(new Herobow2());             
           // }

       //     if (0.005 > Utility.RandomDouble()) //
      //      {           
      //          c.DropItem(new EverlastingBandage());             
      //      }

            if (0.005 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new HerobloodyApron());             
            }

            if (0.004 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new HerohoodedRobe());             
            }

            if (0.005 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Heroquiver());             
            }

          

        //    if (0.01 > Utility.RandomDouble()) // 
       //     {           
        //        c.DropItem(new EverlastingBandage());             
        //    }

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

                 
                
		public override bool CanRummageCorpses{ get{ return false; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 4; } }
                public override bool AlwaysMurderer { get { return true; } }

		public MasterEttin( Serial serial ) : base( serial )
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