//Customized By Mrs Death
using System;
using Server;

namespace Server.Items
{
              public class VincentHelm: PlateHelm
{
              
              [Constructable]
              public VincentHelm()
{

                          Weight = 5;
                          Name = "[FF7] Vincent's Helm";
                          Hue = 1157;
              
              Attributes.BonusDex = 20;
              Attributes.BonusHits = 10;
              Attributes.BonusInt = 20;
              Attributes.BonusMana = 10;
              Attributes.BonusStam = 10;
              Attributes.LowerManaCost = 5;
              Attributes.LowerRegCost = 15;
              Attributes.ReflectPhysical = 10;
              ColdBonus = 18;
              EnergyBonus = 18;
              FireBonus = 18;
              PhysicalBonus = 18;
              PoisonBonus = 18;
              StrBonus = 20;
                  }
              public VincentHelm( Serial serial ) : base( serial )
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
