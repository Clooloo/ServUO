//Customized By Mrs Death
using System;
using Server;


namespace Server.Items
{
              public class CidArms: DragonArms
{
              
              [Constructable]
              public CidArms()
{

                          Weight = 10;
                          Name = "-[FF7] Cid's Arms-";
                          Hue = 1264;
              
              //Attributes.AttackChance = 10;
              //Attributes.BonusDex = 10;
              //Attributes.BonusHits = 15;
              //Attributes.BonusInt = 10;
              //Attributes.BonusMana = 15;
                          Attributes.BonusStam = Utility.Random(0, 20);
                          Attributes.DefendChance = Utility.Random(0, 20);
                          Attributes.ReflectPhysical = Utility.Random(0, 20);
                          Attributes.SpellDamage = Utility.Random(0, 20);
                          Attributes.WeaponDamage = Utility.Random(0, 20);
                          Attributes.WeaponSpeed = Utility.Random(0, 20);
              ColdBonus = Utility.Random( 10, 20 );
              EnergyBonus = Utility.Random( 10, 20 );
              FireBonus = Utility.Random( 10, 20 );
              PhysicalBonus = Utility.Random( 10, 20 );
              PoisonBonus = Utility.Random( 10, 20 );
              StrBonus = 10;
                  }
              public CidArms( Serial serial ) : base( serial )
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
