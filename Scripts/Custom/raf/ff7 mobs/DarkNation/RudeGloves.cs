//Customized By Mrs Death
using System;
using Server;

namespace Server.Items

{
              
              public class RudeGloves : BlackStaff
              {
              public override int AosMinDamage{ get{ return 20; } }
              public override int AosMaxDamage{ get{ return 24; } }
              
                      [Constructable]
                      public RudeGloves() 
                      {
                                        Weight = 5;
                                        Name = "[FF7] Rude's Bare Hands [TURKS]";
                                        Hue = 2666;
					ItemID = 10130;
              
                                        WeaponAttributes.HitDispel = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitFireball = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitHarm = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitLeechHits = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitLeechMana = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitLeechStam = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitLightning = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitLowerAttack = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitLowerDefend = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitMagicArrow = Utility.Random( 1, 10 );
              
                                        Attributes.AttackChance = Utility.Random( 1, 20 );
                                        Attributes.DefendChance = Utility.Random( 1, 20 );
                                       Attributes.ReflectPhysical = Utility.Random( 1, 20 );
              
                                    }
              
                      public RudeGloves( Serial serial ) : base( serial )  
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
