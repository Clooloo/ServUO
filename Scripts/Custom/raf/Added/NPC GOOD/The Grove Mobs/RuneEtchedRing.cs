using System; 
using Server; 

namespace Server.Items
{ 
	public class RuneEtchedRing : GoldRing
	{
		[Constructable]
		public RuneEtchedRing()
		{
			Name = "Rune Etched Ring";
			Hue = 1174;

			Resistances.Fire = 2;
			Resistances.Cold = 2;
			Resistances.Poison = 2;
			Resistances.Energy = 2;
			Attributes.BonusInt = 5;
            Attributes.SpellDamage = 15;
			Attributes.CastSpeed = 1;
			Attributes.CastRecovery = 3;
		}

		public RuneEtchedRing( Serial serial ) : base( serial )
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