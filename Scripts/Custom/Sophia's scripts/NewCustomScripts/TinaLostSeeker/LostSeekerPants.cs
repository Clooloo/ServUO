using System;
using Server;

namespace Server.Items
{
	public class LostSeekerPants : PlateChest
	{
		public override int ArtifactRarity{ get{ return 68; } }
	
	
		[Constructable]
		public LostSeekerPants()
		{
			Weight = 1.1; 
            		Name = "Lost Seeker Pants"; 
            		Hue = 1366;
                        ItemID = 9799;
                        Layer = Layer.Pants;

                        MeditationAllowance =                    ArmorMeditationAllowance.All;
                        

			
			
		
			
			Attributes.DefendChance = 10;
			
			Attributes.LowerManaCost = 15;
			Attributes.LowerRegCost = 10;
			Attributes.Luck = 50;
			
			
			Attributes.RegenHits = 2;
			Attributes.RegenMana = 2;
			Attributes.RegenStam = 2;
            Attributes.BonusStam = 20;
            Attributes.CastRecovery = 4;
			
			Attributes.WeaponDamage = 10;
            ArmorAttributes.MageArmor = 1;
			
            ArmorAttributes.SelfRepair = 40;

			
              StrRequirement = 15;



		}
                        public override bool OnEquip( Mobile from )
                {
	                from.FixedParticles( 0x374A, 10, 30, 5013, 1153, 2, EffectLayer.Waist );
                        from.FixedParticles( 0x374A, 10, 15, 5021, EffectLayer.Waist );
                        from.PlaySound( 0x51A );
	                from.PlaySound( 0xFA );
                        from.PlaySound( 0xF5 );
                        return base.OnEquip(from);
		}

                        public LostSeekerPants(Serial serial)
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

