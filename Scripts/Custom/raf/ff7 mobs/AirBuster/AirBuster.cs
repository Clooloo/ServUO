// Customized By Mrs Death

using System;
using Server.Items;

namespace Server.Mobiles

              {
              [CorpseName( " corpse of Air Buster" )]
              public class AirBuster : ChaosDaemon
              {
                                 [Constructable]
                                    public AirBuster() : base()
                            {
                                               Name = "Air Buster";
                                               Hue = 1159;
                                               Body = 0x2F4;
                                               BaseSoundID = 679;
                                               SetStr( 500 );
                                               SetDex( 225 );
                                               SetInt( 200 );
                                               SetHits( 10000 );
                                               SetDamage( 13, 20 );
                                               SetDamageType( ResistanceType.Physical, 39 );
                                               SetDamageType( ResistanceType.Cold, 29 );
                                               //SetDamageType( ResistanceType.Fire, 29 );
                                               //SetDamageType( ResistanceType.Energy, 199 );
                                               //SetDamageType( ResistanceType.Poison, 199 );

                                               SetResistance( ResistanceType.Physical, 70 );
                                               SetResistance( ResistanceType.Cold, 20 );
                                               SetResistance( ResistanceType.Fire, 30 );
                                               SetResistance( ResistanceType.Energy, 40 );
                                               SetResistance( ResistanceType.Poison, 30 );
                                               Fame = 12000;
                                               Karma = -1000;
                                               VirtualArmor = 20;

                                               PackGold( 1000 );

			AerisChest Chest = new AerisChest();
			Chest.Movable = false;
			AddItem(Chest);

			AerisSkirt Legs = new AerisSkirt();
			Legs.Movable = false;
			AddItem(Legs);
			
			AerisCirclet Circlet = new AerisCirclet();
			Circlet.Movable = false;
			AddItem(Circlet);
			
			AerisSandals Sandals = new AerisSandals();
			Sandals.Movable = false;
			AddItem(Sandals);
			
			AerisSickle Weapon = new AerisSickle();
			Weapon.Movable = false;
			AddItem(Weapon);

					       }
				public override void GenerateLoot()
		{		
                                 switch ( Utility.Random( 40 ))
			         {
				case 0: PackItem( new AerisSickle() ); break;
				case 1: PackItem( new AerisSkirt() ); break;
				case 2: PackItem( new AerisChest() ); break;
				case 3: PackItem( new AerisSandals() ); break;
				case 4: PackItem( new AerisCirclet() ); break;

                                                }}

                                 
				              
                                 public override bool IsScaryToPets{ get{ return true; } }
				                 public override bool AutoDispel{ get{ return true; } }
                                 public override bool BardImmune{ get{ return true; } }
                                 public override bool Unprovokable{ get{ return true; } }
                                 public override Poison HitPoison{ get{ return Poison. Lesser ; } }
                                 public override bool AlwaysMurderer{ get{ return true; } }

public AirBuster( Serial serial ) : base( serial )
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
