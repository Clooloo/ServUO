using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( " Heart beat corpse " )]
	public class HeartBeat2 : BaseCreature
	{
		[Constructable]
		public HeartBeat2 () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
		//	AuraMessage = "Get OUT !!"; // TODO Cliloc support: 1008111
		//	AuraType = ResistanceType.Cold;
		//	MinAuraDelay = 5;
		//	MaxAuraDelay = 15;
		//	MinAuraDamage = 15;
		//	MaxAuraDamage = 25;
		//	AuraRange = 2;

			Name = " Heart beat";
			Body = 1427;
			BaseSoundID = 278;
                        Hue = 0;

			SetStr( 1500, 1700 );
			SetDex( 1400, 1995 );
			SetInt( 2501, 2925 );

			SetHits( 55000, 60000 );

			SetDamage( 40, 50 );

			SetSkill( SkillName.EvalInt, 100, 120.0 );
			SetSkill( SkillName.Magery, 100, 120.0 );
			SetSkill( SkillName.MagicResist, 75.1, 105.0 );
			SetSkill( SkillName.Tactics, 100, 120.0 );
			SetSkill( SkillName.Wrestling, 160, 180.0 );

			SetResistance( ResistanceType.Physical,70, 85 );
			SetResistance( ResistanceType.Fire, 60, 80 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Poison, 70, 80 );
			SetResistance( ResistanceType.Energy, 70, 80 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 60;


                       
                        PackItem( new MasterCoin( 45 ) );
                        AddLoot( LootPack.SuperBoss, 10 );
	
		}


		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

        //    if (0.05 > Utility.RandomDouble()) // 
         //   {           
         //       c.DropItem(new Herobow2());             
         //   }

            if (0.05 > Utility.RandomDouble()) //
            {           
                c.DropItem(new Herotalisman());             
            }

            if (0.05 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new HerobloodyApron());             
            }

            if (0.04 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new HerohoodedRobe());             
            }

            if (0.05 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Heroquiver());             
            }

         //   if (0.04 > Utility.RandomDouble()) // 
          //  {           
         //       c.DropItem(new EverlastingBandage());             
         //   }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicClothDeed());       


		}
      }


        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            base.OnDamage(amount, from, willKill);
			
            // eats pet or summons
        //    if (from is BaseCreature)
         //   {
         //       BaseCreature creature = (BaseCreature)from;
				
         //       if (creature.Controlled || creature.Summoned)
          //      {
          //          this.Heal(creature.Hits);					
          //          creature.Kill();				
					
          //          Effects.PlaySound(this.Location, this.Map, 0x574);
          //      }
          //  }
			
            // teleports player near
            if (from is PlayerMobile && !this.InRange(from.Location, 1))
            {
                this.Combatant = from;
				
                from.MoveToWorld(this.GetSpawnPosition(1), this.Map);				
                from.FixedParticles(0x376A, 9, 32, 0x13AF, EffectLayer.Waist);
                from.PlaySound(0x1FE);
            }
        }

                public override bool AutoDispel{ get{ return true; } }
	        public override bool BardImmune{ get{ return true; } }
                public override bool AlwaysMurderer { get { return true; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }
		public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.BleedAttack;
        }

		public HeartBeat2( Serial serial ) : base( serial )
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