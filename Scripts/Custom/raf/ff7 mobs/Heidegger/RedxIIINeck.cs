//Customized By Mrs Death
using System;
using Server;
using Server.Items;

namespace Server.Items
{

              public class RedxIIINeck: LeatherGorget
{
              
              [Constructable]
              public RedxIIINeck()
{

                          Weight = 4;
                          Name = "[FF7] Red-xIII's NeckFur";
                          Hue = 338;
              
              Attributes.AttackChance = 10;
	      Attributes.BonusStam = 15;
              Attributes.CastSpeed = 5;
              Attributes.EnhancePotions = 10;
              Attributes.Luck = 450;
              Attributes.NightSight = 1;
              Attributes.ReflectPhysical = 10;
              Attributes.RegenHits = 1;
              Attributes.RegenMana = 1;
              Attributes.RegenStam = 1;
              Attributes.SpellDamage = 15;
              Attributes.WeaponDamage = 10;
	      Attributes.WeaponSpeed = 5;
	      Attributes.BonusStr = 15;
		Attributes.BonusDex = 15;
		Attributes.BonusInt = 15;
                  }
              public RedxIIINeck( Serial serial ) : base( serial )
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
