//Customized By Mrs Death
using System;
using Server;


namespace Server.Items
{
              public class CidHelm: DragonHelm
{
              
              [Constructable]
              public CidHelm()
{

                          Weight = 10;
                          Name = "-[FF7] Cid's Helm-";
                          Hue = 1264;

                          Attributes.AttackChance = Utility.Random(0, 20);
              //Attributes.BonusDex = 10;
             // Attributes.BonusHits = 15;
              //Attributes.BonusInt = 10;
                          Attributes.BonusMana = Utility.Random(0, 20);
                          Attributes.BonusStam = Utility.Random(0, 20);
                          Attributes.DefendChance = Utility.Random(0, 20);
             // Attributes.ReflectPhysical = 25;
              //Attributes.SpellDamage = 25;
                          Attributes.WeaponDamage = Utility.Random(0, 20);
                          Attributes.WeaponSpeed = Utility.Random(0, 20);
              ColdBonus = Utility.Random( 10, 20 );
              EnergyBonus = Utility.Random( 10, 20 );
              FireBonus = Utility.Random( 10, 20 );
              PhysicalBonus = Utility.Random( 10, 20 );
              PoisonBonus = Utility.Random( 10, 20 );
              StrBonus = 10;
                  }
              public CidHelm( Serial serial ) : base( serial )
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
