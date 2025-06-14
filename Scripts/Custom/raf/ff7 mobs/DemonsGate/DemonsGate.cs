//Customized By Mrs Death

using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Mobiles

              {
              [CorpseName( " corpse of Demon's Gate" )]
              public class DemonsGate : BaseCreature
              {

                                 [Constructable]
                                    public DemonsGate() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.1, 0.2 )
                            {
                                               Name = "Demon's Gate";
                                               Hue = 1174;
								Paralyzed = false;
                                               Body = 123; // Uncomment these lines and input values
                                               //BaseSoundID = 357; // To use your own custom body and sound.
                                               SetStr( 1000, 1500 );
                                               SetDex( 800, 1000 );
                                               SetInt( 800, 1000 );
                                               SetHits( 200000, 250000 );
                                               SetDamage( 25, 30 );
                                               SetDamageType( ResistanceType.Cold, 120 );
                                               SetDamageType( ResistanceType.Fire, 120 );
                                               SetDamageType( ResistanceType.Energy, 120 );
                                               SetDamageType( ResistanceType.Poison, 120 );

                                               SetResistance( ResistanceType.Physical, 70 );
                                               SetResistance( ResistanceType.Cold, 80 );
                                               SetResistance( ResistanceType.Fire, 80 );
                                               SetResistance( ResistanceType.Energy, 80 );
                                               SetResistance( ResistanceType.Poison, 80 );

			SetSkill( SkillName.EvalInt, 120.1, 130.0 );
			SetSkill( SkillName.Magery, 90.1, 100.0 );
			SetSkill( SkillName.Meditation, 100.1, 150.0 );
			SetSkill( SkillName.Poisoning, 100.1, 120.0 );
			SetSkill( SkillName.MagicResist, 100.2, 120.0 );
			SetSkill( SkillName.Tactics, 100.1, 120.0 );
			SetSkill( SkillName.Wrestling, 100.1, 120.0 );
			SetSkill( SkillName.Swords, 100.1, 120.0 );
			SetSkill( SkillName.Anatomy, 100.1, 120.0 );
			SetSkill( SkillName.Parry, 100.1, 120.0 );


                                               Fame = 40000;
                                               Karma = -45000;
                                               VirtualArmor = 70;
		PackGold( 11120, 11130 );

}
public override void GenerateLoot()
		{		
			switch ( Utility.Random( 75 ))
			{
				
				case 0: PackItem( new JenovaShirt() ); break;
				case 1: PackItem( new JenovaSkirt() ); break;
				case 2: PackItem( new JenovaSash() ); break;
				case 3: PackItem( new JenovaRobe() ); break;
				case 4: PackItem( new JenovaBoots() ); break;
				case 5: PackItem( new JenovaCloak() ); break;
				case 6: PackItem( new JenovaApron() ); break;
				

							
		 }

                            }

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



public DemonsGate( Serial serial ) : base( serial )
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

