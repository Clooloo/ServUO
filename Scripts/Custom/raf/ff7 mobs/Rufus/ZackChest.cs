//Customized By Mrs Death
using System;
using Server;


namespace Server.Items
{
              public class ZackChest: ChainChest
{
              
              [Constructable]
              public ZackChest()
{

                          Weight = 5;
                          Name = "[FF7] Zack's Chest";
                          Hue = 598;
              ItemID = 11124;
              Attributes.AttackChance = 7;
              Attributes.BonusDex = 8;
              Attributes.BonusHits = 4;
              Attributes.BonusInt = 8;
              Attributes.BonusMana = 4;
              Attributes.BonusStam = 4;
              Attributes.DefendChance = 7;
              Attributes.LowerRegCost = 25;
              Attributes.ReflectPhysical = 10;
              StrBonus = 8;
                  }
              public ZackChest( Serial serial ) : base( serial )
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
