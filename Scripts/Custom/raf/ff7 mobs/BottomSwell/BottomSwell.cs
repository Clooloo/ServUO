//Customized By Mrs Death
using System;
using Server.Items;

namespace Server.Mobiles
              {

              [CorpseName( " corpse of Bottom Swell " )]
              public class BottomSwell : BaseCreature
              {

		  public override WeaponAbility GetWeaponAbility()
		  {
			return Utility.RandomBool() ? WeaponAbility.ArmorIgnore : WeaponAbility.ParalyzingBlow;
		  }

                                 	[Constructable]
                                    public BottomSwell() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8 )
                            {
                                               Name = "Bottom Swell";
                                               Hue = 1162;
                                               Body = 401;
					BaseSoundID = 0x3E9;

                                               SetStr( 619 );
                                               SetDex( 619 );
                                               SetInt( 619 );
                                               SetHits( 250000 );
                                               SetDamage( 20, 30 );
                                               SetDamageType( ResistanceType.Physical, 619 );
                                               SetDamageType( ResistanceType.Cold, 619 );
                                               SetDamageType( ResistanceType.Fire, 619 );
                                               SetDamageType( ResistanceType.Energy, 619 );
                                               SetDamageType( ResistanceType.Poison, 619 );

                                               SetResistance( ResistanceType.Physical, 619 );
                                               SetResistance( ResistanceType.Cold, 619 );
                                               SetResistance( ResistanceType.Fire, 619 );
                                               SetResistance( ResistanceType.Energy, 619 );
                                               SetResistance( ResistanceType.Poison, 619 );

                                               SetSkill(SkillName.EvalInt, 619);
                                               SetSkill(SkillName.Tactics, 619);
                                               SetSkill(SkillName.MagicResist, 619);
                                               SetSkill(SkillName.Wrestling, 619);
					       SetSkill(SkillName.Parry, 619);
					       SetSkill(SkillName.Fencing, 619);
                                               SetSkill(SkillName.Meditation, 619);
                                               SetSkill(SkillName.Focus, 619);
                                               SetSkill(SkillName.Magery, 619);
                                               SetSkill(SkillName.Anatomy, 619);
			
                                               Fame = -1000;
                                               Karma = -1000;
                                               Tamable = false;
                                               VirtualArmor = 87;


	    		FTifaChest Chest = new FTifaChest();
			Chest.Movable = false;
			AddItem(Chest);

			TifaSkirt Legs = new TifaSkirt();
			Legs.Movable = false;
			AddItem(Legs);

			DTifaSpear Weapon = new DTifaSpear();
			Weapon.Movable = false;
			AddItem(Weapon);
			
			TifaLight Shield = new TifaLight();
			Shield.Movable = false;
			AddItem(Shield);
                                            }
            
                                            public override void GenerateLoot()
                                            {
            	                               switch ( Utility.Random( 80 ))
			{
		case 0: PackItem( new TifaChest() ); break;
		case 1: PackItem( new TifaLegs() ); break;
		case 2: PackItem( new FTifaChest() ); break;
		case 3: PackItem( new TifaSkirt() ); break;
		case 4: PackItem( new TifaSpear() ); break;
                                            }}    

                                 public override bool AutoDispel{ get{ return true; } }
                                 public override bool Unprovokable{ get{ return true; } }
                                 public override Poison HitPoison{ get{ return Poison. Lethal ; } }
                                 public override bool AlwaysMurderer{ get{ return true; } }
					   

			    public BottomSwell( Serial serial ) : base( serial )
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
