using System;
using Server;

namespace Server.Items
{
	public class gandalfThunerstorms : CompositeBow
	{

      		public override int AosMinDamage{ get{ return 25; } } 
      		public override int AosMaxDamage{ get{ return 30; } } 
      		public override int AosSpeed{ get{ return 40; } } 

                public override int ArtifactRarity{ get{ return 77; } }   

		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }

		[Constructable]
		public gandalfThunerstorms()
		{
			Name = "Thunerstorms";
			Hue = 1000;
			
			DurabilityLevel = WeaponDurabilityLevel.Indestructible;
         		Quality = ItemQuality.Exceptional;

                                WeaponAttributes.HitLightning = 50;
				WeaponAttributes.HitLeechMana = 20;
				Attributes.BonusMana = 10;
				Attributes.WeaponDamage = 40;
				Attributes.RegenMana = 5;
				Attributes.SpellChanneling = 1;
				Attributes.CastSpeed = 1;
			        MaxHitPoints = 100;
			        HitPoints = 100;
				}



        public gandalfThunerstorms( Serial serial ) : base( serial )
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