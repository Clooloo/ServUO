using System;
using Server;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{

	public class Robedeed : Item
	{

		[Constructable]
		public Robedeed () : this( null )
		{
		}

		[Constructable]
		public Robedeed ( string name ) : base ( 0x14F0 )
		{
			Name = "Random Transform Robe Prize Ticket";
			Hue = 2665;
		}

		public Robedeed ( Serial serial ) : base ( serial )
		{
		}

      		public override void OnDoubleClick( Mobile from ) 
      		{
			if ( !IsChildOf( from.Backpack ) )
			{
                from.SendLocalizedMessage(1042001);
            }
            else
            {
/////////////////Prize Robe
                switch (Utility.Random(10))       
                {
                    case 0: from.AddToBackpack(new HellHoundsRobe()); break;
                    case 1: from.AddToBackpack(new MongbatResearchRobe()); break;
                    case 2: from.AddToBackpack(new HunterClothing()); break;
                    case 3: from.AddToBackpack(new RobeOfFire()); break;
                    case 4: from.AddToBackpack(new RobeOfTheDead()); break;
                    case 5: from.AddToBackpack(new RobeOfTheDragon()); break;
                    case 6: from.AddToBackpack(new RobeOfJabba()); break;
                    case 7: from.AddToBackpack(new RobeOfTheSkull()); break;
                    case 8: from.AddToBackpack(new SpidersHide()); break;
                    case 9: from.AddToBackpack(new EtherealShroud()); break;
                        
                }
                this.Delete();
			}

		}

		public override void Serialize ( GenericWriter writer)
		{
			base.Serialize ( writer );

			writer.Write ( (int) 0);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize ( reader );

			int version = reader.ReadInt();
		}
	}
}