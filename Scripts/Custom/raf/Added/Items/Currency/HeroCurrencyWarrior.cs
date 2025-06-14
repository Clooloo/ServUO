
using System;
using Server;

namespace Server.Items
{
	public class HeroCurrencyWarrior : Item
	{
		public int BoundToSoul = 0;// Start binding value as zero.
		public override double DefaultWeight
		{
			get { return 0.001; }
		}

		[Constructable]
		public HeroCurrencyWarrior() : this( 1 )
		{
		}

		[Constructable]
		public HeroCurrencyWarrior( int amount ) : base( 0x3196 )
		{
            Name = "Hero Currency Warrior";
            Hue = 1631; 
			Stackable = true;
            LootType = LootType.Blessed;
			Amount = amount;
		}
		public override bool OnDragLift( Mobile from ) 
		{ 
			if(BoundToSoul == 0) //Check to see if bound to a serial.
			{ 
      			BoundToSoul = from.Serial; //Bind to a serial on first time lifted.
                this.Name = "Hero " + from.Name.ToString() + "'s Warrior Currency";//Change item name and add who it is bound to.
      			from.Emote( "*" + from.Name + " somehow knows this currency belongs to him alone*" ); 
				base.OnDragLift( from ); 
				return true;//Allow it to bind to the first player to lift it after creation.
							//Will show in [props as ParentEntity and RootParentEntitty as [m] Serial, "Player Name"
      		} 
           	else if(BoundToSoul == from.Serial) //Check to see if currency is bound to who is lifting it.
      		{
				base.OnDragLift( from );
				return true; //Allow player who had bound to currency to lift it.
      		} 
      		else 
      		{ 
      			from.SendMessage( "The currency refuses your soul" ); 
				return false; //Disallow any one else from lifting the currency.
			} 
		}
		
		public override void AddNameProperty(ObjectPropertyList list)
        {
			base.AddNameProperty( list );
			if(BoundToSoul == 0) //Check to see if bound to a serial.
			{ 
				list.Add( "<BASEFONT COLOR=#669966>"/*Green*/ + "[Un-Bound]" + "<BASEFONT COLOR=#FFFFFF>"/*Back to White*/ );
      		}
		}		

		public HeroCurrencyWarrior( Serial serial ) : base( serial )
		{
		}

        public override int GetDropSound()
        {
            if (Amount <= 1)
                return 0x2E4;
            else if (Amount <= 5)
                return 0x2E5;
            else
                return 0x2E6;
        }
        public override bool OnDroppedOnto(Mobile from, Item target)
        {
            from.SendLocalizedMessage(1076254); // That item cannot be dropped.
            return false;
        }
        public override bool OnDroppedInto(Mobile from, Container target, Point3D p)
        {
            if (target == from.Backpack)
                return base.OnDroppedInto(from, target, p);

            from.SendLocalizedMessage(1076254); // That item cannot be dropped.
            return false;
        }
		public override bool OnDroppedToWorld(Mobile from, Point3D point)
        {
            from.SendLocalizedMessage(1076254); // That item cannot be dropped.
            return false;
        }
        public override bool AllowSecureTrade(Mobile from, Mobile to, Mobile newOwner, bool accepted)
        {
            from.SendLocalizedMessage(1076256); // That item cannot be traded.
            return false;
        }          

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
         	writer.Write( (int) BoundToSoul );//Serialize who it is bound to.
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
         	BoundToSoul = reader.ReadInt();//Read on startup who it is bound to.
		}
	}
}
