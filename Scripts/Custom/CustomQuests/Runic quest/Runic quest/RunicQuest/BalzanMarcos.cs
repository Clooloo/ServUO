using System; 
using System.Collections; 
using Server.Misc; 
using Server.Items; 
using Server.Mobiles; 

namespace Server.Mobiles 
{ 
	[CorpseName( "the corpse of balzan marcos" )]
	public class BalzanMarcos : BaseCreature
	{

	private static bool m_Talked;

        string[] kfcsay = new string[]
      { 
		 "You will need to kill me to get the order list",
		 "You shall never get the order list",
		 "You will die",
		 
      }; 
	 
	    public override WeaponAbility GetWeaponAbility()
        {
            switch (Utility.Random(3))
            {
                default:
                case 0: return WeaponAbility.DoubleStrike;
                case 1: return WeaponAbility.WhirlwindAttack;
                case 2: return WeaponAbility.CrushingBlow;
            }
        }
	 
		[Constructable] 
		public BalzanMarcos() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
			SetStr( 1500, 2060 );
			SetDex( 1250, 1350 );
			SetInt( 2000, 3200 );
			SetHits(700000);

			SetDamage( 80, 130 );

			SetDamageType( ResistanceType.Physical, 100 );
 			
			Name = "Balzan Marcos";
			Title = "the evil theif Monster";
			BodyValue = 713; 

			SpeechHue = Utility.RandomDyedHue(); 

			Hue = Utility.RandomSkinHue(); 

						
			RingmailChest chest = new RingmailChest(); 
			chest.Hue = 0x966; 
			AddItem( chest ); 
			RingmailArms arms = new RingmailArms(); 
			arms.Hue = 0x966; 
			AddItem( arms ); 
			RingmailGloves gloves = new RingmailGloves(); 
			gloves.Hue = 0x966; 
			AddItem( gloves ); 
			PlateGorget gorget = new PlateGorget(); 
			gorget.Hue = 0x966; 
			AddItem( gorget ); 
			RingmailLegs legs = new RingmailLegs(); 
			legs.Hue = 0x966; 
			AddItem( legs ); 
			
			
			
			PackGold( 420, 690 );
			if (Utility.RandomDouble() < .1 ) // generates random less than 1
        		PackItem( new OrderList() );


            SetDamageType(ResistanceType.Physical, 125);
            SetDamageType(ResistanceType.Fire, 125);
            SetDamageType(ResistanceType.Cold, 125);
            SetDamageType(ResistanceType.Poison, 125);
            SetDamageType(ResistanceType.Energy, 125);
 
            SetResistance(ResistanceType.Physical, 75);
            SetResistance(ResistanceType.Fire, 75);
            SetResistance(ResistanceType.Cold, 75);
            SetResistance(ResistanceType.Poison, 75);
            SetResistance(ResistanceType.Energy, 75);
 
            SetSkill(SkillName.Necromancy, 120, 120.0);
            SetSkill(SkillName.SpiritSpeak, 120.0, 120.0);
 
            SetSkill(SkillName.DetectHidden, 80.0);
            SetSkill(SkillName.EvalInt, 125.0);
            SetSkill(SkillName.Magery, 125.0);
            SetSkill(SkillName.Meditation, 125.0);
            SetSkill(SkillName.MagicResist, 150.0);
            SetSkill(SkillName.Tactics, 125.0);
            SetSkill(SkillName.Wrestling, 125.0);
 
            Fame = 10000;
            Karma = -12000;
 
            VirtualArmor = 64;

		} 

		        public override bool BardImmune { get { return !Core.SE; } }
        public override bool Unprovokable { get { return Core.SE; } }
        public override bool AreaPeaceImmune { get { return Core.SE; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
		
		public override void OnMovement( Mobile m, Point3D oldLocation ) 
               			{                                                    
         		if( m_Talked == false ) 
         		{ 
            			if ( m.InRange( this, 4 ) ) 
            			{                
               				m_Talked = true; 
               				SayRandom( kfcsay, this ); 
               				this.Move( GetDirectionTo( m.Location ) ); 
                  				// Start timer to prevent spam 
               				SpamTimer t = new SpamTimer(); 
               				t.Start(); 
            			} 
		 			}
	  			}		

		public BalzanMarcos( Serial serial ) : base( serial )
		{
		}

		private class SpamTimer : Timer 
      		{ 
         		public SpamTimer() : base( TimeSpan.FromSeconds( 3 ) ) 
         		{ 
			Priority = TimerPriority.OneSecond;
         		} 

         	protected override void OnTick() 
         	{ 
            		m_Talked = false; 
         	} 
	  	}

	  	private static void SayRandom( string[] say, Mobile m )
	  	{
		 	m.Say( say[Utility.Random( say.Length )] );
	  	}

		public override bool AlwaysMurderer{ get{ return true; } }
		
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