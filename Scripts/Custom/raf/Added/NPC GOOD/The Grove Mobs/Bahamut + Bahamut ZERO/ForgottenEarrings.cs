using System; 
using Server; 

namespace Server.Items
{ 
	public class ForgottenEarrings : SilverEarrings
	{
		[Constructable]
		public ForgottenEarrings()
		{
			Name = "Forgotten";
			Hue = 0xB;

			Attributes.BonusDex = 3;
			Attributes.BonusStr = 3;
			Attributes.BonusInt = 3;

			Resistances.Physical = 2;
			Resistances.Fire = 2;
			Resistances.Cold = 2;
			Resistances.Poison = 2;
			Resistances.Energy = 2;

			Attributes.CastSpeed = 1;
			Attributes.CastRecovery = 1;
		}

		public ForgottenEarrings( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
} 