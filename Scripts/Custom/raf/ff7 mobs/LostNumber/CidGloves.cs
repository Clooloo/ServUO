//Customized By Mrs Death
using System;
using Server;


namespace Server.Items
{
              public class CidGloves: DragonGloves
{
              
              [Constructable]
              public CidGloves()
{

                          Weight = 10;
                          Name = "-[FF7] Cid's Gloves-";
                          Hue = 1264;

                          Attributes.AttackChance = Utility.Random(0, 20);
                          Attributes.BonusDex = Utility.Random(0, 20);
                          Attributes.BonusHits = Utility.Random(0, 20);
              //Attributes.BonusInt = 10;
              //Attributes.BonusMana = 15;
              //Attributes.BonusStam = 15;
                          Attributes.DefendChance = Utility.Random(0, 20);
                          Attributes.ReflectPhysical = Utility.Random(0, 20);
                          Attributes.SpellDamage = Utility.Random(0, 20);
          //    Attributes.WeaponDamage = 20;
          //Attributes.WeaponSpeed = 10;
              ColdBonus = Utility.Random( 10, 20 );
              EnergyBonus = Utility.Random( 10, 20 );
              FireBonus = Utility.Random( 10, 20 );
              PhysicalBonus = Utility.Random( 10, 20 );
              PoisonBonus = Utility.Random( 10, 20 );
              StrBonus = 10;
                  }
              public CidGloves( Serial serial ) : base( serial )
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
