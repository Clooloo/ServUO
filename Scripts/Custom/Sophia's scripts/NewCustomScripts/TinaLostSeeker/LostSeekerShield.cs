using System;
using Server;

namespace Server.Items
{
	public class LostSeekerShield : MetalKiteShield
	{
		public override int ArtifactRarity{ get{ return 50; } }

		
		

		[Constructable]
		public LostSeekerShield()
		{
			Weight = 3.0; 
            		Name = "Lost Seeker Shield"; 
            		Hue = 1366;
                    ItemID = 7028;

			
			  Attributes.BonusDex = 1;
			  
			  
			  Attributes.ReflectPhysical = 10;
              
			  Attributes.RegenMana = 6;
			  Attributes.SpellChanneling = 1;
			  ArmorAttributes.SelfRepair = 25;
              Attributes.SpellDamage = 10;
               ArmorAttributes.DurabilityBonus = 10;

			   
			   EnergyBonus = 10;
			   
			   PhysicalBonus = 10;
			   
			

		}
                                public override bool OnEquip( Mobile from )
                          {
	               from.FixedParticles( 0x375A, 1, 17, 9919, 33, 7, EffectLayer.Waist );
	               from.FixedParticles( 0x3728, 1, 13, 9502, 33, 7, (EffectLayer)255 );
                               from.PlaySound( 1383 );
	               return base.OnEquip(from);
		}

                                public LostSeekerShield(Serial serial)
                                    : base(serial)
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