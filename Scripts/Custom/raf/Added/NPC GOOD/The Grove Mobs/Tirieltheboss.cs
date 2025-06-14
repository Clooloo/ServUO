using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

using System.Linq;


namespace Server.Mobiles
{
    [CorpseName("a Keeper corpse")]
    public class Topbosst : BaseCreature
    {
               
        public static TimeSpan TalkDelay = TimeSpan.FromSeconds(10.0); //the delay between talks is 10 seconds
        public DateTime m_NextTalk;


       public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            if (DateTime.Now >= m_NextTalk && InRange(m, 4) && InLOS(m)) // check if it's time to talk & mobile in range & in los.
            {
                m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
                switch (Utility.Random(5))
                {
                    case 0: Say("Fxxx You !!!"); //make it say ...
                        PlaySound(1066); //play giggle sound
                        break;
                    case 1: Say("You stupid jerk!");
                        PlaySound(1071); //play huh sound
                        break;
                    case 2: Say("You are an asshole.");
                        PlaySound(1055); //play clear throat sound
                        break; //
                    case 3: Say("I Kill You !!!");
                        PlaySound(1074); //play no!! sound
                        break;
                    case 4: Say("Leave me alone.");
                        PlaySound(1067); //play groan sound
                        break;
                };
            }
        }

        [Constructable]
        public Topbosst() : base( AIType.AI_NecroMage, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            Name = "-Dread Lord Tiriel-";
            Body = 741;
            Hue = 1665;

			SetStr( 1000, 1200 );
			SetDex( 5000, 6995 );
			SetInt( 8501, 9925 );


			SetHits( 60000, 65000 );

			SetDamage( 30, 40 );

                        SetDamageType(ResistanceType.Physical, 5);
                        SetDamageType(ResistanceType.Energy, 50);
                        SetDamageType(ResistanceType.Cold, 50);

			SetSkill( SkillName.EvalInt, 180, 200.0 );
			SetSkill( SkillName.Magery, 150, 180.0 );
			SetSkill( SkillName.MagicResist, 125.1, 135.0 );
			SetSkill( SkillName.Necromancy, 180, 200.0 );
			SetSkill( SkillName.SpiritSpeak, 300, 320.0 );
			SetSkill( SkillName.Tactics, 140, 160.0 );
			SetSkill( SkillName.Wrestling, 190, 230.0 );
			SetSkill( SkillName.Meditation, 800.0 );
			SetSkill( SkillName.Focus, 800.0 );

			SetResistance( ResistanceType.Physical,75, 85 );
			SetResistance( ResistanceType.Fire, 50, 60 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 100, 100 );
			SetResistance( ResistanceType.Energy, 70, 80 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 60;
                        
                        PackItem (new CrystallineBlackrock(10));
                        PackItem (new RelicFragment(10));
                        PackItem (new RAD());
                        AddLoot( LootPack.SuperBoss, 3 );
			AddLoot( LootPack.Meager );
			
		}

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);
                  c.DropItem( new MasterCoin( 40 ) );
                  

            if (0.02 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new Herodeed());             
            }

          //  if (0.02 > Utility.RandomDouble()) // 
         //   {           
          //      c.DropItem(new HeroWeapondeed());             
         //   }

            if (0.03 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new HeroGlasses());             
            }

            if (0.03 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new GladiatorDeed());             
            }

            if (0.02 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new CthulhuArmorDeed());             
            }

        //    if (0.03 > Utility.RandomDouble()) // 
         //   {           
         //       c.DropItem(new EverlastingBandage());             
         //   }

            if (0.50 > Utility.RandomDouble()) // 50% chance to drop
            {           
                c.DropItem(new MagicClothDeed());             

		}

            }	



    //    public void DoSpecialAbility(Mobile target)
     //   {

        //    if (0.30 >= Utility.RandomDouble())
       //     {
       //         new FireExplodeEffect(target, target.Map, 8, effectHandler: ExplosionDamage).Send();
       //         base.OnGotMeleeAttack(target);

       //     }
        
       //     if (0.20 >= Utility.RandomDouble())
       //     {
        //        new EnergyExplodeEffect(target, target.Map, 8, effectHandler: ExplosionDamage).Send();
        //        base.OnDamagedBySpell(target);
         //   }
      //  }

     //   public override void OnDamagedBySpell(Mobile from)
    //    {
    //        base.OnDamagedBySpell(from);

        //    DoSpecialAbility(from);
   //     }

       

   //     public override void OnGotMeleeAttack( Mobile from )
	//	{
	//		base.OnGotMeleeAttack( from );

   //         DoSpecialAbility(from);
   //     }

       

       public override int GetIdleSound()
        {
            return 1589;
        }

        public override int GetAngerSound()
        {
            return 1586;
        }

        public override int GetHurtSound()
        {
            return 1588;
        }

        public override int GetDeathSound()
        {
            return 1587;
        }

	        public override bool BardImmune{ get{ return true; } }
                public override bool AlwaysMurderer { get { return true; } }
                
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } } 
                public override Poison HitPoison { get { return Poison.Deadly; } }

        public override WeaponAbility GetWeaponAbility() 
        {
            int ability = Utility.Random(3);
            if (ability == 1)
                return WeaponAbility.BleedAttack;
            else if (ability == 2)
                return WeaponAbility.MortalStrike;
            else
                return WeaponAbility.WhirlwindAttack;
        }


                public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            base.OnDamage(amount, from, willKill);
			
            // eats pet or summons
           // if (from is BaseCreature)
          //  {
          //      BaseCreature creature = (BaseCreature)from;
				
          //      if (creature.Controlled || creature.Summoned)
          //      {
           //         this.Heal(creature.Hits);					
           //         creature.Kill();				
					
            //        Effects.PlaySound(this.Location, this.Map, 0x574);
            //    }
           // }
}



        public Topbosst( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

}