using System;
using Server;
using Server.Items;
using System.Collections;


namespace Server.Mobiles
{

	[CorpseName( "a noobish corpse" )]
	public class NoobDexer : BaseCreature
	{

	private static bool m_Talked;

        string[] kfcsay = new string[]
        { 
		 "OMG!",
		 "LMAO... you suck!",
		 "u noob",
		 "i rox u sux",
		 "go back to trammie!",
	}; 

		[Constructable]
		public NoobDexer () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "A Noob Dexer";
			Body = 400;
			SpeechHue = 2124;
			Hue = 33784;
			VirtualArmor = 50;
			Kills = 10;

			SetStr( 125 );
			SetDex( 130 );
			SetInt( 25 );



			SetSkill( SkillName.Fencing, 120.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.MagicResist, 120.0 );
			SetSkill( SkillName.Anatomy, 100.0 );

			Fame = 0;
			Karma = -10000;
			
			new Horse().Rider = this;

			PackItem( new Gold( 200 , 800 ) );


			Item apron = new HalfApron( 1165 );
			apron.Movable = false;
			AddItem( apron );

			Item hair = new ShortHair( 2124 );
			hair.Movable = false;
			AddItem( hair );

			Item shoes = new Sandals( 1165 );
			shoes.Movable = false;
			AddItem( shoes );

			Item mask = new SavageMask( 2124 );
			mask.Movable = false;
			AddItem( mask );

			Item robe = new Robe( 1108 );
			robe.Movable = false;
			AddItem( robe );
			
			Item gloves = new LeatherGloves();
			gloves.Movable = false;
			gloves.Hue = 2124;
			AddItem( gloves );

			Item gorget = new LeatherGorget();
			gorget.Movable = false;
			gorget.Hue = 2124;
			AddItem( gorget );


			TribalSpear weapon = new TribalSpear();
			weapon.Movable = false;
			AddItem( weapon );
			
		}

		

		public override void OnMovement( Mobile m, Point3D oldLocation ) 
               {                                                    
         	if( m_Talked == false ) 
               { 
            	if ( m.InRange( this, 3 ) ) 
               {                
               	m_Talked = true; 
               	SayRandom( kfcsay, this ); 
               	this.Move( GetDirectionTo( m.Location ) ); 
               	SpamTimer t = new SpamTimer(); 
               	t.Start(); 
               } 
	       }
	       }		

		


		

		public NoobDexer( Serial serial ) : base( serial )
		{
		}

     		private class SpamTimer : Timer 
      		{ 
         	public SpamTimer() : base( TimeSpan.FromSeconds( 5 ) ) 
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
