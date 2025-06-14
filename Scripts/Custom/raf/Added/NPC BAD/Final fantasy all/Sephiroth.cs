//C:\Users\ruste\OneDrive\Desktop\UOHQOSIUpdate-master\UOHQOSIUpdate-master\Scripts\Custom\Added\NPC BAD\Final fantasy all\Sephiroth.cs
using System; 
using System.Collections; 
using Server.Items; 
using Server.ContextMenus; 
using Server.Misc; 
using Server.Network; 

namespace Server.Mobiles 
{ 
	public class Sephiroth : BaseCreature 
	{ 
		[Constructable] 
		public Sephiroth() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{  
			Name = "Sephiroth";
			Body = Utility.RandomList( 400 );
			HairItemID = 12237;
			HairHue = 1150; 
			Hue = 33770; 

			PlateChest chest = new PlateChest(); 
			chest.Hue = 1175; 
			AddItem( chest ); 
			PlateArms arms = new PlateArms(); 
			arms.Hue = 1175; 
			AddItem( arms ); 
			PlateGloves gloves = new PlateGloves(); 
			gloves.Hue = 1175; 
			AddItem( gloves ); 
			PlateGorget gorget = new PlateGorget(); 
			gorget.Hue = 1175; 
			AddItem( gorget ); 
			PlateLegs legs = new PlateLegs(); 
			legs.Hue = 1175; 
			AddItem( legs ); 
          		Robe robe = new Robe();
            		robe.Hue = 1175;
            		robe.Name = "Sephiroth's Robe";
            		robe.Movable = true;
            		AddItem(robe);  
			AddItem( new SephirothBlade() );	

            SetStr(900, 1150);
            SetDex(325, 375);
            SetInt(6661, 6675);

            SetHits(64500, 65000);

            SetDamage(263, 275);

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 69 );
			SetResistance( ResistanceType.Fire, 75 );
			SetResistance( ResistanceType.Cold, 65 );
			SetResistance( ResistanceType.Poison, 65 );
			SetResistance( ResistanceType.Energy, 74 );

            SetSkill(SkillName.Swords, 500.0, 573.0);
            SetSkill(SkillName.Chivalry, 100.0, 120.0);
            SetSkill(SkillName.Focus, 400.0, 420.0);
            SetSkill(SkillName.Tactics, 300.0, 320.0);
            SetSkill(SkillName.Wrestling, 533.0, 533.0);
            SetSkill(SkillName.Anatomy, 220.0, 240.0);

			Fame = 50000;
			Karma = -50000;
			VirtualArmor = 70;
			
			switch ( Utility.Random( 1 ))
			         {
				
				case 0: this.PackItem( new SephirothBrace() ); break;
               // case 1: this.PackItem( new XMLShield() ); break;
                       			
		 }
     
                                 switch ( Utility.Random( 50 ))
			         {
					case 0: this.PackItem( new ChampionPowerScroll() ); break;
				
}

		}


		public override bool AlwaysMurderer{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 6; } }

		public Sephiroth( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); // version 
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt(); 
		} 
	} 
}