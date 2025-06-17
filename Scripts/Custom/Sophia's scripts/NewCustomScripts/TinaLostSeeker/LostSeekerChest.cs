using System;
using Server;

namespace Server.Items
{
	public class LostSeekerChest : PlateChest
	{
		public override int ArtifactRarity{ get{ return 68; } }

		
		

		[Constructable]
		public LostSeekerChest()
		{
			Weight = 3.0; 
            		Name = "Lost Seeker Chest"; 
            		Hue = 1366;
                    ItemID = 9793;
                    Layer = Layer.Shirt;

                   MeditationAllowance =                    ArmorMeditationAllowance.All;
                        



			
			
			Attributes.BonusInt = 5;
            
			Attributes.BonusMana = 10;
			Attributes.CastRecovery = 4;
			Attributes.CastSpeed = 4;
                  Attributes.BonusHits = 10;
		
			Attributes.LowerRegCost = 20;
			Attributes.Luck = 50;
			Attributes.ReflectPhysical = 10;
	
			
			Attributes.WeaponSpeed = 15;
                  ArmorAttributes.MageArmor = 1;
			ArmorAttributes.SelfRepair = 50;

		
			
			FireBonus = 10;
			StrRequirement = 20;

			

		}

        public LostSeekerChest(Serial serial)
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