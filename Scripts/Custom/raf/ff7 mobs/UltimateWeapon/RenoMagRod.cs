//Customized By Mrs Death
using System;
using Server;

namespace Server.Items

{
              
              public class RenoMagRod : Club
              {
              public override int AosMinDamage{ get{ return 20; } }
              public override int AosMaxDamage{ get{ return 24; } }
              
                      [Constructable]
                      public RenoMagRod() 
                      {
                                        Weight = 5;
                                        Name = "[FF7] Reno's Electro-Mag Rod [TURKS]";
                                        Hue = 1000;
              
                                        WeaponAttributes.HitDispel = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitFireball = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitHarm = Utility.Random( 1, 10 );
					WeaponAttributes.HitEnergyArea = 80;
                                        WeaponAttributes.HitLeechHits = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitLeechMana = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitLeechStam = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitLightning = Utility.Random( 75, 80 );
                                        WeaponAttributes.HitLowerAttack = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitLowerDefend = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitMagicArrow = Utility.Random( 1, 10 );
              
                                        Attributes.AttackChance = Utility.Random( 1, 20 );
                                        Attributes.DefendChance = Utility.Random( 1, 20 );
                                        Attributes.ReflectPhysical = Utility.Random( 1, 20 );
              
                                    }
					
        //                    public override void GetDamageTypes( Mobile weilder, out int phys, out int fire, out int cold, out int pois, out int nrgy )
        //{
        //    phys = 0;
        //    cold = 0;
        //    fire = 0;
        //    pois = 0;
        //    nrgy = 100;
        //}


                      public RenoMagRod( Serial serial ) : base( serial )  
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
