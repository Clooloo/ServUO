//Customized By Mrs Death
using System;
using Server;


namespace Server.Items
{
              public class CidChest: DragonChest
{
              
              [Constructable]
              public CidChest()
{

                          Weight = 10;
                          Name = "-[FF7] Cid's Chest-";
                          Hue = 1264;

                          Attributes.AttackChance = Utility.Random(0, 20);
                          Attributes.BonusDex = Utility.Random(0, 20);
                          Attributes.BonusHits = Utility.Random(0, 20);
                          Attributes.BonusInt = Utility.Random(0, 20);
                          Attributes.BonusMana = Utility.Random(0, 20);
                          Attributes.BonusStam = Utility.Random(0, 20);
          //    Attributes.DefendChance = 10;
          //    Attributes.ReflectPhysical = 25;
          //    Attributes.SpellDamage = 25;
          //    Attributes.WeaponDamage = 20;
          //Attributes.WeaponSpeed = 10;
              ColdBonus = Utility.Random( 10, 20 );
              EnergyBonus = Utility.Random( 10, 20 );
              FireBonus = Utility.Random( 10, 20 );
              PhysicalBonus = Utility.Random( 10, 20 );
              PoisonBonus = Utility.Random( 10, 20 );
              StrBonus = 10;
                  }
              public CidChest( Serial serial ) : base( serial )
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
