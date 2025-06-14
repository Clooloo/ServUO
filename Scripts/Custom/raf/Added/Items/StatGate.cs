//ssusing System;
using Server.Gumps;

namespace Server.Items
{
	public class StatGate : Item
	{
		[Constructable]
		public StatGate() : base( 0xF6C )
		{
			Movable = false;
			Name = "Fix your stats cap here";
		}

		public StatGate( Serial serial ) : base( serial )
		{
		}

		public override bool OnMoveOver( Mobile m )
		{
			if (m.Map.CanFit( m.Location, 16, false, false ) )
			{
				m.StrCap = 450;
				m.StrMaxCap=1500;
                m.DexCap = 450;
				m.DexMaxCap=1500;
				m.IntCap = 450;
				m.IntMaxCap=1500;
				return true;
			}
                        else
                        {
                        	return false;
                        }
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
