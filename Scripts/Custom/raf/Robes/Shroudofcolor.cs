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
	public class Shroudofcolor : HoodedShroudOfShadows
	{
		[Constructable]
		public Shroudofcolor()
		{
			 
			Name = "Shroud of Color";
            Hue = 0;
		}
		
		public override bool OnEquip(Mobile m) 
	      { 

    		m.NameMod = m.Name+"'s Shroud of Color";
			m.DisplayGuildTitle = false;	
			m.SendMessage( "The cloak will transform it's colour when you click on it!" );
            m.PlaySound( 484 );
			return base.OnEquip(m);
		}
        public override void OnDoubleClick(Mobile from)
        {
        Hue = Utility.Random( 3000 );
        }
		
		public override void OnRemoved( object parent) 
	      { 
		if (parent is Mobile) 
	        { 
	         Mobile m = (Mobile)parent; 
		   m.NameMod = null;
                   m.BodyMod = 0;
           m.HueMod = -1;
               Attributes.BonusStr = 0;
		   m.SendMessage( "Your back to your old self." );
                   m.PlaySound( 484 );		   
		   m.DisplayGuildTitle = true;
		  }

	         base.OnRemoved(parent); 
      	}

        public Shroudofcolor(Serial serial): base(serial)
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
}