//Customized By Mrs Death
using System;
using Server;


namespace Server.Items
{
              public class CidLegs: DragonLegs
{
              
              [Constructable]
              public CidLegs()
{

                          Weight = 10;
                          Name = "-[FF7] Cid's Legs-";
                          Hue = 1264;
              
              //Attributes.AttackChance = 10;
                          Attributes.BonusDex = Utility.Random(0, 20);
              //Attributes.BonusHits = 15;
                          Attributes.BonusInt = Utility.Random(0, 20);
                          Attributes.BonusMana = Utility.Random(0, 20);
                          Attributes.BonusStam = Utility.Random(0, 20);
              //Attributes.DefendChance = 10;
              //Attributes.ReflectPhysical = 25;
                          Attributes.SpellDamage = Utility.Random(0, 20);
              //Attributes.WeaponDamage = 20;
                          Attributes.WeaponSpeed = Utility.Random(0, 40);
              ColdBonus = Utility.Random( 10, 20 );
              EnergyBonus = Utility.Random( 10, 20 );
              FireBonus = Utility.Random( 10, 20 );
              PhysicalBonus = Utility.Random( 10, 20 );
              PoisonBonus = Utility.Random( 10, 20 );
              StrBonus = 10;
                  }
              public CidLegs( Serial serial ) : base( serial )
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
