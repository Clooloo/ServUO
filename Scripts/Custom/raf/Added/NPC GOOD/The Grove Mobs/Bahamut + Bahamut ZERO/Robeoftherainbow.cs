/*
 * Created by jacquesc1. 
 * Date: 05/08/2009
 */
using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class Robeoftherainbow : Robe
	{
        public ColourChangeTimer changeTimer;

		[Constructable]
		public Robeoftherainbow()
		{
			 
			Name = "Rainbow Robe";
            Hue = 0;
		}
		
		public override bool OnEquip(Mobile m) 
	    { 

        	changeTimer = new ColourChangeTimer( this );
        	changeTimer.Start();
			m.NameMod = m.Name + "'s Rainbow Robe";
			m.DisplayGuildTitle = false;	
			m.SendMessage( "The cloak will transform it's colour!" );
            m.PlaySound( 484 );
			return base.OnEquip(m);
		}

		public override void OnRemoved( object parent) 
	    { 

        	if ( changeTimer != null )
       		{
       			changeTimer.Stop();
       		}	

			if (parent is Mobile) 
	        { 
	        	Mobile m = (Mobile)parent; 
		   		m.NameMod = null;
                m.BodyMod = 0;
		   		m.SendMessage( "You're back to your boring old self." );
                m.PlaySound( 484 );		   
		   		m.DisplayGuildTitle = true;
		  	}

	        base.OnRemoved(parent); 
      	}

        public Robeoftherainbow(Serial serial): base(serial)
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
	
	public class ColourChangeTimer : Timer
	{
		private Robeoftherainbow m_Robie;	 

        public ColourChangeTimer( Robeoftherainbow rob )
			: base( TimeSpan.FromSeconds( 30.0 ), TimeSpan.FromSeconds( 30.0 ) )
		{
			Priority = TimerPriority.FiftyMS;
			
			m_Robie = rob;
		}

		protected override void OnTick() //every 30 seconds executes code in {}
		{
			m_Robie.Hue = Utility.Random( 3000 );
		}
	}
}
