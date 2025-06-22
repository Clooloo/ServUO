using System;
using System.Reflection;
using System.IO;
using Server;
using Server.Items;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Engines.BulkOrders;

namespace Server
{
	public class ArtifactList
	{
		static int index;
		static Type type;

		public static Type[] ArtifactTypes = new Type[]
		{
		//Special Loot

			typeof(AG_BathTubSouthAddonDeed),
			typeof(AG_BathTubEastAddonDeed),
			
			typeof( AG_JacuzziEastAddonDeed ),
			typeof( AG_JacuzziSouthAddonDeed ),
			typeof( AG_ShowerEastAddonDeed ),
			typeof( AG_ShowerSouthAddonDeed ),
			typeof( ADVTrainingDummy ),
			typeof( BBQ1EastAddonDeed ),
			typeof( DoorMatRound ),
			typeof( WelcomeMat ),
			//typeof(  ),
			//typeof(  ),
			//typeof(  ),
			//typeof(  ),
			//typeof(  ),
			//typeof(  ),
			//typeof(  ),
			//typeof(  ),
			//typeof(  ),
			//typeof(  ),
			//typeof(  ),
			//typeof(  ),
			//typeof(  ),
			
			
			typeof(Alchemist2BazaarAddonDeed),
			
			typeof(AmethystTreeAddonDeed),
			
			typeof(BananaHoardAddon),
		
			typeof(birdhouseAddonDeed),
			
			typeof(BigScreenTVEastAddonDeed),
			
			typeof(BigScreenTVSouthAddonDeed),
			
			typeof(BoulderRock01AddonDeed),
			
			typeof(BoulderRock02AddonDeed),
			
			typeof(BoulderRock03AddonDeed),
			
			typeof(BoulderRock04AddonDeed),
			
			typeof(BoulderRock05AddonDeed),
			
			typeof(BoulderRock06AddonDeed),
			
			typeof(BoulderRock07AddonDeed),
			
			typeof(BoulderRock08AddonDeed),
			
			typeof(CampSiteAddonDeed),
			
			typeof(CarpenterBazaarAddonDeed),
			
			typeof(CarpetedStairBazaarAddonDeed),
			
			typeof(CherryBlossomTree1aAddonDeed),
			
			typeof(CherryBlossomTree1bAddonDeed),
			
			typeof(CherryBlossomTree1cAddonDeed),
			
			typeof(CherryBlossomTree1dAddonDeed),
			
			typeof(CherryBlossomTree1eAddonDeed),
			
			typeof(CherryBlossomTree2aAddonDeed),
			
			typeof(CherryBlossomTree2bAddonDeed),
			
			typeof(CherryBlossomTree2cAddonDeed),
			
			typeof(CherryBlossomTree2dAddonDeed),
			
			typeof(CherryBlossomTree2eAddonDeed),
			
			typeof(CrystalBazaarAddonDeed),
			
			typeof(CrystalCluster01AddonDeed),
			
			typeof(CrystalCluster02AddonDeed),
			
			typeof(DistilleryBazaarAddonDeed),
			
			typeof(DistilleryEastAddonDeed),
			
			typeof(DistillerySouthAddonDeed),
			
			typeof(DogHouseAddonDeed),
			
			
			
			typeof(DragonTurtleFountainAddonDeed),
			
			typeof(EasterBasketLargeGiftAddonDeed),
			
			typeof(EvilBazaarAddonDeed),
			
			typeof(eviltreeAddonDeed),
			
			
			
			
			
			typeof(FireOnPillarAddonDeed),
			
			typeof(FirePitLargeAddonDeed),
			
			
			
			typeof(ForsythiaBush01AddonDeed),
			
			typeof(ForsythiaBush02AddonDeed),
			
			typeof(FountainBarrelAddonDeed),
			
			typeof(FrostedBathTableAddonDeed),
			
			typeof(FrostedEastTableAddonDeed),
			
			typeof(FrostedLGSquareTableAddonDeed),
			
			typeof(FrostedSmSquareTableAddonDeed),
			
			typeof(FrostedSTableAddonDeed),
			
			typeof(FrostedTailorTableAddonDeed),
			
			typeof(GenericBazaarAddonDeed),
			
			typeof(GlassClothRackAddonDeed),
			
			typeof(goldcarpetAddonDeed),
			
			
			
			typeof(GoreFireplaceAddonDeed),
			
			
			
			
			
			typeof(HalloweenBloodFountainAddonDeed),
			
			typeof(HalloweenCasketTempleAddonDeed),
			
			typeof(HalloweenGhoulPicnicAddonDeed),
			
			typeof(HalloweenGuillotinePatchAddonDeed),
			
			typeof(HalloweenHellPitAddonDeed),
			
			typeof(HalloweenSkullPostAddonDeed),
			
			typeof(HalloweenSpiderForestAddonDeed),
			
			typeof(HalloweenTortureChamberAddonDeed),
			
			typeof(HalloweenTreeBlackAddonDeed),
			
			typeof(HalloweenTreeRedAddonDeed),
			
			typeof(HalloweenWorshipTempleAddonDeed),
			
			typeof(HarvestCartAddonDeed),
			
			typeof(HarvestKillAddonDeed),
			
			typeof(HarvestLampAddonDeed),
			
			typeof(harvesttableAddonDeed),
			
			typeof(HarvestWreathEAddonDeed),
			
			typeof(HarvestWreathSAddonDeed),
			
			typeof(hex_CornerFireplaceAddonDeed),
			
			typeof(hex_FirepEastAddonDeed),
			
			typeof(hex_fireplaceMPAddonDeed),
			
			typeof(hex_FirepSouthAddonDeed),
			
			typeof(hex_SmallFireplaceAddonDeed),
			
			typeof(hex_StoveSouthAddonDeed),
			
			typeof(hex_StoveEastAddonDeed),
			
			typeof(hex_WaterfallPondAddonDeed),
			
			typeof(HeXgraveyAddonDeed),
			
			typeof(JewelerBazaarAddonDeed),
			
			typeof(KCounterCornerAddonDeed),
			
			typeof(KCounterEAddonDeed),
			
			typeof(KCounterSAddonDeed),
			
			typeof(KitchenStoveEAddonDeed),
			
			typeof(KitchenStoveSAddonDeed),
			
			typeof(KOvenSAddonDeed),
			
			typeof(KOvenEAddonDeed),
			
			typeof(KSinkEAddonDeed),
			
			typeof(KSinkSAddonDeed),
			
			typeof(LeatherArmourBazaarAddonDeed),
			
			typeof(LightHouseLightAddonDeed),
			
			typeof(LilacBushTreeAddonDeed),
			
			
			
			
			
			typeof(LongVine02AddonDeed),
			
			
			
			typeof(LongVine04AddonDeed),
			
			
			
			
			
			typeof(MarbleStairBazaarAddonDeed),
			
			
			
			
			
			
			
			
			
			
			
			typeof(minostatueAddonDeed),
			
			typeof(MoonBlossomTreeAddonDeed),
			
			typeof(MorningGlowTreeAddonDeed),
			
			typeof(OrangeBlossomTreeAddonDeed),
			
			typeof(ParrotPerchAddonDeed),
			
			typeof(PianoAddonDeed),
			
			typeof(PillowBazaarAddonDeed),
			
			typeof(PondAddonDeed),
			
			typeof(PottedColumbineAquaAddonDeed),
			
			typeof(PottedColumbineDkOrangeAddonDeed),
			
			typeof(PottedColumbineFushiaAddonDeed),
			
			typeof(PottedColumbineGreenAddonDeed),
			
			typeof(PottedColumbineLilacAddonDeed),
			
			typeof(PottedColumbineOrangeAddonDeed),
			
			typeof(PottedColumbinePeachAddonDeed),
			
			typeof(PottedColumbinePinkAddonDeed),
			
			typeof(PottedColumbinePurpleAddonDeed),
			
			typeof(PottedColumbineRedAddonDeed),
			
			typeof(PottedColumbineTealAddonDeed),
			
			typeof(PottedColumbineWhiteAddonDeed),
			
			typeof(PottedColumbineYellowAddonDeed),
			
			typeof(PottedMumsAquaAddonDeed),
			
			typeof(PottedMumsBlueAddonDeed),
			
			typeof(PottedMumsGreenAddonDeed),
			
			typeof(PottedMumsLimeAddonDeed),
			
			typeof(PottedMumsOrangeAddonDeed),
			
			typeof(PottedMumsPeachAddonDeed),
			
			typeof(PottedMumsPinkAddonDeed),
			
			typeof(PottedMumsPurpleAddonDeed),
			
			typeof(PottedMumsRedAddonDeed),
			
			typeof(PottedMumsTealAddonDeed),
			
			typeof(PottedMumsWhiteAddonDeed),
			
			typeof(PottedMumsYellowAddonDeed),
			
			typeof(PottedTeaRosesAquaAddonDeed),
			
			typeof(PottedTeaRosesBlueAddonDeed),
			
			typeof(PottedTeaRosesGreenAddonDeed),
			
			typeof(PottedTeaRosesLimeAddonDeed),
			
			typeof(PottedTeaRosesOrangeAddonDeed),
			
			typeof(PottedTeaRosesPeachAddonDeed),
			
			typeof(PottedTeaRosesPinkAddonDeed),
			
			typeof(PottedTeaRosesPurpleAddonDeed),
			
			typeof(PottedTeaRosesRedAddonDeed),
			
			typeof(PottedTeaRosesTealAddonDeed),
			
			typeof(PottedTeaRosesWhiteAddonDeed),
			
			typeof(PottedTeaRosesWhiteAddonDeed),
			
			typeof(PottedTeaRosesYellowAddonDeed),
			
			typeof(PotteryWheelAddonDeed),
			
			typeof(Provisioner2BazaarAddonDeed),
			
			typeof(ProvisionerBazaarAddonDeed),
			
			typeof(PumpkinShackAddonDeed),
			
			typeof(PussyWillowTreeAddonDeed),
			
			typeof(PumpkinHugeAddonDeed),
			
			
			
		
			
			typeof(RedMapleTree1bAddonDeed),
			
			typeof(RedMapleTree1cAddonDeed),
			
			typeof(RedMapleTree1dAddonDeed),
			
			typeof(RedMapleTree1eAddonDeed),
			
			typeof(RedMapleTree2aAddonDeed),
			
			typeof(RedMapleTree2bAddonDeed),
			
			typeof(RedMapleTree2cAddonDeed),
			
			typeof(RedMapleTree2dAddonDeed),
			
			typeof(RedMapleTree2eAddonDeed),
			
			typeof(RedMoonGateCelticAddonDeed),
			
			typeof(RedMoonGateSquareAddonDeed),
			
			typeof(RosebudTreeAddonDeed),
			
			typeof(RoseBush01AddonDeed),
			
			typeof(RoseBush02AddonDeed),
			
			
			
			
			
			typeof(ScribeBazaarAddonDeed),
			
			typeof(ShowerLeftAddonDeed),
			
			typeof(ShowerRightAddonDeed),
			
			
			
			
			typeof(SmithBazaarAddonDeed),
			
			
			
			
			typeof(Stable_Small_1AddonDeed),
			
			typeof(StableBazaarAddonDeed),
			
			typeof(SwimmingPoolAddonDeed),
			
			
			
			
			
			typeof(TallTree02AddonDeed),
			
			typeof(TallTree03AddonDeed),
			
			typeof(TallTree04AddonDeed),
			
			typeof(TallTree05AddonDeed),
			
			typeof(TallTree06AddonDeed),
			
			typeof(TallTree07AddonDeed),
			
			typeof(TallTree08AddonDeed),
			
			typeof(tent_brownAddonDeed),
			
			typeof(tent_whiteAddonDeed),
			
			typeof(TigerRugAddonDeed),
			
			typeof(tikibarAddonDeed),
			
			typeof(TreasurePile01AddonDeed),
			
			typeof(TreasurePile02AddonDeed),
			
			typeof(TreasurePile03AddonDeed),
			
			typeof(TreasurePile04AddonDeed),
			
			typeof(TreasurePile05AddonDeed),
			
			typeof(TurkeyStatueAddonDeed),
			
			typeof(ValentineDinnerEAddonDeed),
			
			typeof(ValentineDinnerSAddonDeed),
			
			typeof(ValentinesCupidAddonDeed),
			
			typeof(ValentineSetting1AddonDeed),
			
			typeof(ValentinesRugPinkEAddonDeed),
			
			typeof(ValentinesRugPinkSAddonDeed),
			
			typeof(ValentinesRugRedEAddonDeed),
			
			typeof(ValentinesRugRedSAddonDeed),
			
			typeof(ValentinesSetting2AddonDeed),
			
			typeof(VaseShellBlueAddonDeed),
			
			typeof(VaseShellBrownAddonDeed),
			
			typeof(VaseShellGreenAddonDeed),
			
			typeof(VaseShellPeachAddonDeed),
			
			typeof(VikingBoatAddonDeed),
			
			typeof(VikingBoatSailAddonDeed),
			
			typeof(WasherDryerSAddonDeed),
			
			typeof(waterparkAddonDeed),
			
			typeof(WisteriaTreeAddonDeed),
			
			typeof(WoodBenchBazaarAddonDeed),
			
			typeof(YardPondAddonDeed),
			

		};
		public static Type[] Artifacts{ get{ return ArtifactTypes; } }

		public static Item RandomArtifact()
		{
			index = Utility.Random( ArtifactTypes.Length );
			type = ArtifactTypes[index];
			return Activator.CreateInstance( type )as Item;
		}
	}
}

//typeof(  ),
//typeof(  ),
//typeof(  ),
//typeof(  ),
//typeof(  ),
//typeof(  ),
