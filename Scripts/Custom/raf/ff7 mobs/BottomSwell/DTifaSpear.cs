//Customized By Mrs Death
using System;
using Server;

namespace Server.Items

{
              
              public class DTifaSpear : Spear
              {
              public override int AosMinDamage{ get{ return 20; } }
              public override int AosMaxDamage{ get{ return 25; } }
              public override int DefMaxRange{ get{ return 3; } }

                      [Constructable]
                      public DTifaSpear() 
                      {
                                        Weight = 5;
                                        Name = "[FF7] Tifa's Leather Glove";
                                        Hue = 1000;
              
                                        WeaponAttributes.HitDispel = Utility.Random( 1, 75 );
                                        WeaponAttributes.HitFireball = Utility.Random( 1, 75 );
                                        WeaponAttributes.HitHarm = Utility.Random( 1, 75 );
                                        WeaponAttributes.HitLightning = Utility.Random( 1, 75 );
                                        WeaponAttributes.HitLowerAttack = Utility.Random( 1, 75 );
                                        WeaponAttributes.HitLowerDefend = Utility.Random( 1, 75 );
                                        WeaponAttributes.HitMagicArrow = Utility.Random( 1, 75 );
                                       
              
                                        Attributes.AttackChance = 15;
                                        Attributes.DefendChance = 15;
                                       Attributes.ReflectPhysical = 15;
                                        Attributes.WeaponDamage = Utility.Random( 1, 75 );
                                        Attributes.WeaponSpeed = Utility.Random( 1, 75 );
              
                                    }
              
                      public DTifaSpear( Serial serial ) : base( serial )  
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
