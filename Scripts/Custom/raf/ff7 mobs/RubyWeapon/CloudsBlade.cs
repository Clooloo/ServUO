//Customized By Mrs Death
using System;
using Server;

namespace Server.Items

{
              
              public class CloudsBlade : NoDachi
              {
              public override int AosMinDamage{ get{ return 15; } }
              public override int AosMaxDamage{ get{ return 20; } }
              
                      [Constructable]
                      public CloudsBlade() 
                      {
                                        Weight = 7;
                                        Name = "[FF7] Cloud's Ultima Weapon";
                                        Hue = 1173;
              
                                        WeaponAttributes.HitColdArea = 80;
                                        WeaponAttributes.HitEnergyArea = 80;
                                        WeaponAttributes.HitFireArea = 80;
                                        WeaponAttributes.HitLeechHits = 80;
                                        WeaponAttributes.HitLeechMana = 80;
                                        WeaponAttributes.HitLeechStam = 80;
                                        WeaponAttributes.HitPhysicalArea = 80;
                                        WeaponAttributes.HitPoisonArea = 80;
              
                                        Attributes.AttackChance = 25;
                                        Attributes.DefendChance = 25;
                                        Attributes.ReflectPhysical = 15;
                                        Attributes.SpellDamage = 15;
                                        Attributes.WeaponDamage = 70;
                                        Attributes.WeaponSpeed = 35;
              
                                    }
        //                    public override void GetDamageTypes( Mobile weilder, out int phys, out int fire, out int cold, out int pois, out int nrgy )
        //{
        //    phys = 0;
        //    cold = 0;
        //    fire = 0;
        //    pois = 0;
        //    nrgy = 100;
        //}
		

                      public CloudsBlade( Serial serial ) : base( serial )  
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
