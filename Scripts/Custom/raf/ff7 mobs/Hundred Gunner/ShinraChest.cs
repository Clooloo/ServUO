//Customized By Mrs Death
using System;
using Server;


namespace Server.Items
{
              public class ShinraChest: LeatherChest
{
              
              [Constructable]
              public ShinraChest()
{

                          Name = "[FF7] Shinra Chest";
                          Hue = 1156;
              		ItemID = 11124;
              Attributes.AttackChance = 25;
              Attributes.BonusDex = 10;
              Attributes.BonusHits = 15;
              Attributes.BonusInt = 10;
              Attributes.BonusMana = 15;
              Attributes.BonusStam = 15;
              Attributes.DefendChance = 25;
              Attributes.LowerManaCost = 10;
              Attributes.LowerRegCost = 20;
              Attributes.ReflectPhysical = 25;
              Attributes.SpellDamage = 25;
              ColdBonus = 14;
              EnergyBonus = 14;
              FireBonus = 14;
              PhysicalBonus = 14;
              PoisonBonus = 14;
              StrBonus = 10;
                  }
              public ShinraChest( Serial serial ) : base( serial )
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
