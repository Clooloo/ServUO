//Customized By Mrs Death
using System;
using Server;
using Server.Items;

namespace Server.Items
{
              public class CloudsShoes: SamuraiTabi
{            
              [Constructable]
              public CloudsShoes()
{

                          Weight = 7;
                          Name = "[FF7] Cloud's Shoes";
                          Hue = 1173;
              
              Attributes.BonusDex = 15;
              Attributes.BonusHits = 15;
              Attributes.BonusInt = 15;
              Attributes.DefendChance = 35;
              Attributes.LowerManaCost = 20;
              Attributes.Luck = 50;
              Attributes.NightSight = 1;
              Attributes.ReflectPhysical = 10;
              Attributes.RegenHits = 25;
              Attributes.WeaponDamage = 35;
              Attributes.BonusStr = 25;
                  }
              public CloudsShoes( Serial serial ) : base( serial )
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
