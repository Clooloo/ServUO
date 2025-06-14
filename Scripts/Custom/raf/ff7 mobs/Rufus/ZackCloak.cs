//Customized By Mrs Death
using System;
using Server;


namespace Server.Items
{
              public class ZackCloak: Cloak
{
              
              [Constructable]
              public ZackCloak()  
{

                          Weight = 5;
                          Name = "[FF7] Zack's Cloak";
                          Hue = 598;
              
              Attributes.AttackChance = 7;
              Attributes.BonusDex = 8;
              Attributes.BonusHits = 4;
              Attributes.BonusInt = 8;
              Attributes.BonusMana = 4;
              Attributes.BonusStam = 4;
              Attributes.DefendChance = 7;
              Attributes.LowerRegCost = 25;
              Attributes.ReflectPhysical = 10;
              Attributes.BonusStr = 8;
                  }
              public ZackCloak( Serial serial ) : base( serial )
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
