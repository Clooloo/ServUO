using System;
using Server;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{

	public class Herodeed : Item
	{

		[Constructable]
		public Herodeed () : this( null )
		{
		}

		[Constructable]
		public Herodeed ( string name ) : base ( 0x14F0 )
		{
			Name = "Random Hero Artifact Prize Ticket";
			Hue = 1923;
		}

		public Herodeed ( Serial serial ) : base ( serial )
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
/////////////////Prize Herodeed
                switch (Utility.Random(11))       
                {
                    case 0: from.AddToBackpack(new HerobloodyApron()); break;
                    case 1: from.AddToBackpack(new Herotalisman()); break;
                    case 2: from.AddToBackpack(new HeroGlasses()); break;
                    case 3: from.AddToBackpack(new HerohoodedRobe()); break;
                    case 4: from.AddToBackpack(new Heroquiver()); break;
                  //  case 5: from.AddToBackpack(new HeroWeapondeed()); break;
                    case 6: from.AddToBackpack(new Herospellbook()); break;
                    case 7: from.AddToBackpack(new Herotalisman()); break;
                    case 8: from.AddToBackpack(new Herospellbook()); break;
					case 9: from.AddToBackpack(new HeroShield()); break;
					case 10: from.AddToBackpack(new HeroGorget()); break;
                        
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