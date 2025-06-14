//Customized By Mrs Death

using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Mobiles

              {
              [CorpseName( " corpse of Ruby Weapon" )]
              public class RubyWeapon : BaseCreature
              {

                                 [Constructable]
                                    public RubyWeapon() : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
                            {
                                               Name = "Ruby Weapon";
					        
                                               Hue = 33;
								Paralyzed = false;
                                               Body = 777; // Uncomment these lines and input values
                                               BaseSoundID = 362; // To use your own custom body and sound.
                                               SetStr( 5000 );
                                               SetDex( 4000 );
                                               SetInt( 3000 );
                                               SetHits( 200000 );
                                               SetDamage( 50, 90 );
                                               SetDamageType( ResistanceType.Cold, 120 );
                                               SetDamageType( ResistanceType.Fire, 120 );
                                               SetDamageType( ResistanceType.Energy, 120 );
                                               SetDamageType( ResistanceType.Poison, 120 );

                                               SetResistance( ResistanceType.Physical, 70 );
                                               SetResistance( ResistanceType.Cold, 80 );
                                               SetResistance( ResistanceType.Fire, 80 );
                                               SetResistance( ResistanceType.Energy, 80 );
                                               SetResistance( ResistanceType.Poison, 80 );

			SetSkill( SkillName.EvalInt, 320.1, 330.0 );
			SetSkill( SkillName.Magery, 290.1, 300.0 );
			SetSkill( SkillName.Meditation, 200.1, 301.0 );
			SetSkill( SkillName.Poisoning, 200.1, 301.0 );
			SetSkill( SkillName.MagicResist, 575.2, 600.0 );
			SetSkill( SkillName.Tactics, 390.1, 400.0 );
			SetSkill( SkillName.Wrestling, 375.1, 400.0 );
			SetSkill( SkillName.Swords, 375.1, 400.0 );
			SetSkill( SkillName.Anatomy, 375.1, 400.0 );
			SetSkill( SkillName.Parry, 250.1, 300.0 );


                                               Fame = 40000;
                                               Karma = -45000;
                                               VirtualArmor = 70;
		PackGold( 11120, 11130 );

}
public override void GenerateLoot()
		{		
			switch ( Utility.Random( 100 ))
			{
				
				case 0: PackItem( new CloudsHelm() ); break;
				case 1: PackItem( new CloudsChest() ); break;
				case 2: PackItem( new CloudsArms() ); break;
				case 3: PackItem( new CloudsGloves() ); break;
				case 4: PackItem( new CloudsLegs() ); break;
				case 5: PackItem( new CloudsBlade() ); break;
				case 6: PackItem( new CloudsShoes() ); break;
				case 7: PackItem( new CloudsMask() ); break;
				

							
		 }

                            }
				 public override bool CanRummageCorpses { get { return true; } }
				 public override Poison PoisonImmune { get { return Poison.Lethal; } }
                                 
				
                                 public override bool IsScaryToPets{ get{ return true; } }
				 public override bool AutoDispel{ get{ return true; } }
                                 public override bool BardImmune{ get{ return true; } }
                                 public override bool Unprovokable{ get{ return true; } }
                                 public override Poison HitPoison{ get{ return Poison. Lethal ; } }
                                 public override bool AlwaysMurderer{ get{ return true; } }
				



		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( from is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)from;

				if ( bc.Controlled || bc.BardTarget == this )
					damage = 0; // Immune to pets and provoked creatures
			}
		}



public RubyWeapon( Serial serial ) : base( serial )
                      {
                      }

public override void Serialize( GenericWriter writer )
                      {
                                        base.Serialize( writer );
                                        writer.Write( (int) 0 );
                      }

        public override void Deserialize( GenericReader reader )
                      {
                                        base.Deserialize( reader );
                                        int version = reader.ReadInt();

				}

			}
		}

