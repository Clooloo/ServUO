// Created by the Script Creator
using System;
using Server;

namespace Server.Items
              {
                  public class ChristmasItems : BrownBook
                  {
                      [Constructable]
              public ChristmasItems() : base( "ChristmasItems", "Author", 4, true ) // true writable so players can make notes
                      {
                      // NOTE: There are 8 lines per page and
                      // approx 22 to 24 characters per line!
                     //      0----+----1----+----2----+
                      int cnt = 0;
                          string[] lines;
                          lines = new string[]
                          {
              "Misteltoe2010",
              "Snowman",
              "HolidayBell2010",
              "Snowman2010",
              "SnowyTree2010",
              "Stocking",
              "HolidayCandle",
              "GingerbreadHouseAddon",
                          };
                          Pages[cnt++].Lines = lines;
                      //      0----+----1----+----2----+
                          lines = new string[]
                          {
              "LightofTheWinterSolstice2010",
              "PileofGlacialSnow2010",
              "SnowPile2010",
              "FestiveCactus2010",
              "SantasSleighAddon",
              "SantasReindeer",
              "ChristmasVilliageAddon",
              "ClassicflashingtreeAddon",
                          };
                          Pages[cnt++].Lines = lines;
                      //      0----+----1----+----2----+
                          lines = new string[]
                          {
              "FireplaceSet2SAddon",
              "GarlandEWAddon",
              "HolidayGarland",
              "ChristmasYardAddon",
              "FireplaceSet2EAddon",
              "flashingtreeAddon",
              "GarlandNSAddon",
              "LightsEastAddon",
                          };
                          Pages[cnt++].Lines = lines;
                      //      0----+----1----+----2----+
                         lines = new string[]
                          {
              "LightsSouthAddon",
              "ModernflashingtreeAddon",
              "NewHolidayTree",
              "SnowRugAddon",
              "TownCenterChristmasTreeAddon",
              "TownCenterChristmasNGAddon",
              "SnowMediumAddon",
              "SnowSmallAddon",
                         };
                          Pages[cnt++].Lines = lines;
                      }
              
        public ChristmasItems( Serial serial ) : base( serial )
                      {
                      }
              
        public override void Deserialize( GenericReader reader )
                      {
                          base.Deserialize( reader );
              
                          int version = reader.ReadInt();
                      }
              
        public override void Serialize( GenericWriter writer )
                      {
                          base.Serialize( writer );
              
                          writer.Write( (int)0 ); // version
        }
                  }
              }
