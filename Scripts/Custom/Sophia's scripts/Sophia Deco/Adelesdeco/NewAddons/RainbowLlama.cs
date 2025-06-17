//Amherst Mod
using System;
using System.Collections;
using Server.Mobiles;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a llama corpse" )]
	[TypeAlias( "Server.Mobiles.RainbowLlama" )]
	public class RainbowLlama : BaseMount
	{
		[Constructable]
		public RainbowLlama() : this( "a ridable llama" )
		{
		}

		[Constructable]
		public RainbowLlama( string name ) : base( name, 0xDC, 0x3EA6, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0x3F3;

			SetStr( 121, 149 );
			SetDex( 156, 175 );
			SetInt( 116, 130 );

			SetHits( 515, 627 );
			SetMana( 1000 );

			SetDamage( 33, 45 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 55 );
			SetResistance( ResistanceType.Fire, 35, 40 );
			SetResistance( ResistanceType.Cold, 35, 40 );
			SetResistance( ResistanceType.Poison, 35, 40 );
			SetResistance( ResistanceType.Energy, 35, 40 );

			SetSkill( SkillName.MagicResist, 115.1, 120.0 );
			SetSkill( SkillName.Tactics, 109.2, 119.0 );
			SetSkill( SkillName.Wrestling, 109.2, 119.0 );

			Fame = 300;
			Karma = 0;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 89.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 12; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public RainbowLlama( Serial serial ) : base( serial )
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
		
		public override bool OnDragDrop( Mobile from, Item dropped )
		{          		
         	Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;

			if ( mobile != null)
			{
				if( dropped is Apple )
         			{
         				dropped.Delete(); 
         				this.Hue = 0x494;
						mobile.SendMessage ( "Your llama enjoys what you've given it" );
					}
				else if( dropped is Lime )
         			{
         				dropped.Delete(); 
         				this.Hue = 0x483;
						mobile.SendMessage ( "Your llama enjoys what you've given it" );
					}
				else if( dropped is Lemon )
         			{
         				dropped.Delete(); 
         				this.Hue = 0x35;
						mobile.SendMessage ( "Your llama enjoys what you've given it" );
					}
				else if( dropped is Grapes )
         			{
         				dropped.Delete(); 
         				this.Hue = 0x490;
						mobile.SendMessage ( "Your llama enjoys what you've given it" );
					}
				else if( dropped is Dates )
         			{
         				dropped.Delete(); 
         				this.Hue = 0x486;
						mobile.SendMessage ( "Your llama enjoys what you've given it" );
					}
				else if( dropped is Pear )
         			{
         				dropped.Delete(); 
         				this.Hue = 0x48F;
						mobile.SendMessage ( "Your llama enjoys what you've given it" );
					}
				else if( dropped is Squash )
         			{
         				dropped.Delete(); 
         				this.Hue = 0x491;
						mobile.SendMessage ( "Your llama enjoys what you've given it" );
					}
				else if( dropped is Cantaloupe )
         			{
         				dropped.Delete(); 
         				this.Hue = 0x499;
						mobile.SendMessage ( "Your llama enjoys what you've given it" );
					}
				else if( dropped is Peach )
         			{
         				dropped.Delete(); 
         				this.Hue = 0x2E;
						mobile.SendMessage ( "Your llama enjoys what you've given it" );
					}
				else if( dropped is Coconut || dropped is SplitCoconut )
         			{
         				dropped.Delete(); 
         				this.Hue = 0x47E;
						mobile.SendMessage ( "Your llama enjoys what you've given it" );
					}
				else if( dropped is Banana || dropped is Bananas )
         			{
         				dropped.Delete(); 
         				this.Hue = 0x38;
						mobile.SendMessage ( "Your llama enjoys what you've given it" );
					}
				else if( dropped is Carrot )
         			{
         				dropped.Delete(); 
         				this.Hue = 0x496;
						mobile.SendMessage ( "Your llama enjoys what you've given it" );
					}
				else if( dropped is Watermelon )
         			{
         				dropped.Delete(); 
         				this.Hue = 0x48E;
						mobile.SendMessage ( "Your llama enjoys what you've given it" );
					}
				else if( dropped is Gold )
         			{
         				dropped.Delete(); 
         				this.Hue = 0x0;
						mobile.SendMessage ( "Your llama enjoys what you've given it" );
					}


         	else
					mobile.SendMessage ( "Your llama doesn't want that item" );
			}
			return false;
		}
	}
}