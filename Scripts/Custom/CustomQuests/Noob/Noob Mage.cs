using System;
using Server;
using Server.Items;
using System.Collections;


namespace Server.Mobiles
{

	[CorpseName( "a noobish corpse" )]
	public class NoobMage : BaseCreature
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
		public NoobMage () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "A Noob Mage";
			Body = 400;
			SpeechHue = 2128;
			Hue = 33784;
			VirtualArmor = 50;
			Kills = 10;

			SetStr( 125 );
			SetDex( 25 );
			SetInt( 130 );



			SetSkill( SkillName.Wrestling, 150.0 );
			SetSkill( SkillName.Magery, 120.0 );
			SetSkill( SkillName.MagicResist, 100.0 );
			SetSkill( SkillName.EvalInt, 100.0 );

			Fame = 0;
			Karma = -10000;
			
			new Horse().Rider = this;

			PackItem( new Gold( 200 , 800 ) );


			Item apron = new HalfApron( 1167 );
			apron.Movable = false;
			AddItem( apron );

			Item hair = new ShortHair( 2128 );
			hair.Movable = false;
			AddItem( hair );

			Item shoes = new Sandals( 1167 );
			shoes.Movable = false;
			AddItem( shoes );

			Item mask = new OrcishKinMask();
			mask.Movable = false;
			AddItem( mask );

			Item robe = new Robe( 1108 );
			robe.Movable = false;
			AddItem( robe );
			
			Item gloves = new LeatherGloves();
			gloves.Movable = false;
			gloves.Hue = 2128;
			AddItem( gloves );

			Item gorget = new LeatherGorget();
			gorget.Movable = false;
			gorget.Hue = 2128;
			AddItem( gorget );
			
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

		


		

		public NoobMage( Serial serial ) : base( serial )
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
