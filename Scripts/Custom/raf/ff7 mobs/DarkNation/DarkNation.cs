//Customized By Mrs Death

using System;
using Server.Items;

namespace Server.Mobiles

              {
              [CorpseName( " corpse of Dark Nation" )]
              public class DarkNation : Daemon
              {
                                 [Constructable]
                                    public DarkNation() : base()
                            {
                                               Name = "Dark Nation";
                                               Hue = 1175;
                                               Body = 23; // Uncomment these lines and input values
                                               //BaseSoundID = 357; // To use your own custom body and sound.
                                               SetStr( 500 );
                                               SetDex( 3000 );
                                               SetInt( 1500 );
                                               SetHits( 20000 );
                                               SetDamage( 25, 30 );
                                               SetDamageType( ResistanceType.Physical, 25 );
                                               SetDamageType( ResistanceType.Cold, 25 );
                                               SetDamageType( ResistanceType.Fire, 300 );
                                               SetDamageType( ResistanceType.Energy, 25 );
                                               SetDamageType( ResistanceType.Poison, 25 );

                                               SetResistance( ResistanceType.Physical, 70 );
                                               SetResistance( ResistanceType.Cold, 70 );
                                               SetResistance( ResistanceType.Fire, 70 );
                                               SetResistance( ResistanceType.Energy, 70 );
                                               SetResistance( ResistanceType.Poison, 70 );
                                               Fame = 30000;
                                               Karma = - 25000;
                                               VirtualArmor = 70;
     
                                                 switch ( Utility.Random( 50 ))
			         {
				
				case 0: PackItem( new RudeGloves() ); break;
                       		{	
			
			
		 }}

                            }
                                
                                 public override bool AutoDispel{ get{ return true; } }
                                 public override bool BardImmune{ get{ return true; } }
                                 public override bool Unprovokable{ get{ return true; } }
                                 public override Poison HitPoison{ get{ return Poison. Lethal ; } }

public DarkNation( Serial serial ) : base( serial )
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
