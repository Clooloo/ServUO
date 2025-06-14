//Customized By Mrs Death

using System;
using Server.Items;

namespace Server.Mobiles

              {
              [CorpseName( " corpse of Lost Number" )]
              public class LostNumber : Daemon
              {
                                 [Constructable]
                                    public LostNumber() : base()
                            {
                                               Name = "-Lost Number-";
                                               Hue = 1152;
                                               Body = 400; // Uncomment these lines and input values
                                               //BaseSoundID = 357; // To use your own custom body and sound.
                                               SetStr( 750 );
                                               SetDex( 700 );
                                               SetInt( 600 );
                                               SetHits( 1000, 2000 );
                                               SetDamage( 15, 20 );
                                               SetDamageType( ResistanceType.Physical, 100 );
                                               SetDamageType( ResistanceType.Cold, 10 );
                                               SetDamageType( ResistanceType.Fire, 10 );
                                               SetDamageType( ResistanceType.Energy, 10 );
                                               SetDamageType( ResistanceType.Poison, 10 );

                                               SetResistance( ResistanceType.Physical, 40 );
                                               SetResistance( ResistanceType.Cold, 40 );
                                               SetResistance( ResistanceType.Fire, 40 );
                                               SetResistance( ResistanceType.Energy, 40 );
                                               SetResistance( ResistanceType.Poison, 40 );
                                               Fame = 300;
                                               Karma = - 250;
                                               VirtualArmor = 40;

					new EtherealSwampDragon().Rider = this;

			Item FancyShirt = new FancyShirt(); 
			FancyShirt.Movable = false;
			FancyShirt.Hue = 1; 
			AddItem( FancyShirt );

			Item LongPants = new LongPants(); 
			LongPants.Movable = false;
			LongPants.Hue = 1; 
			AddItem( LongPants );

			Item Cloak = new Cloak(); 
			Cloak.Movable = false;
			Cloak.Hue = 1; 
			AddItem( Cloak );

			Item Boots = new Boots(); 
			Boots.Movable = false;
			Boots.Hue = 1; 
			AddItem( Boots );
     
                                                 switch ( Utility.Random( 35 ))
			         {
				
				case 1: PackItem( new CidChest() ); break;
				case 2: PackItem( new CidGloves() ); break;
                        	case 3: PackItem( new CidHelm() ); break;
                        	case 4: PackItem( new CidArms() ); break;
                        	case 5: PackItem( new CidLegs() ); break;
                            case 6: PackItem(new MasterCoin(20)); break;
                            case 7: PackItem(new RelicFragment()); break;
                            case 8: PackItem(new ValoriteIngot(500)); break;
                          
                       		{	
			
			
		 }}

                            }
		public override bool CanRummageCorpses{ get{ return true; } }
        public override bool BardImmune{ get{ return true; } }
        public override Poison HitPoison{ get{ return Poison.Lethal; } }
        public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
        public override int TreasureMapLevel{ get{ return 5; } }
        public override bool AlwaysMurderer { get { return true; } }

public LostNumber( Serial serial ) : base( serial )
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
