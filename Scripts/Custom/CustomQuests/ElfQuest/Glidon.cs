using System;
using Server.Items;
namespace Server.Mobiles
{
	[CorpseName( "a holy king corpse" )]
	public class ElfLord : BaseCreature
	{

		[Constructable]
		public ElfLord() : base(AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.2, 0.4)
		{
			Name = "Gliroin";
			Title = "the high elf";
            Body = 605;
            Hue = Race.Elf.RandomSkinHue();
			SetStr( 555, 920 );
			SetDex( 350, 445 );
			SetInt( 476, 1000 );
			
			SetHits( 451, 999 );
			
			SetDamage( 15, 25 );
			
			SetDamageType( ResistanceType.Physical, 70, 100 );
			SetDamageType( ResistanceType.Poison, 30, 100 );
			
			SetResistance( ResistanceType.Physical, 20, 90 );
			SetResistance( ResistanceType.Fire, 20, 95 );
			SetResistance( ResistanceType.Cold, 20, 95 );
			SetResistance( ResistanceType.Poison, 20, 100 );
			SetResistance( ResistanceType.Energy, 20, 90 );
			
			SetSkill( SkillName.MagicResist, 70.0 );
			SetSkill( SkillName.Tactics, 90.0 );
			SetSkill( SkillName.Wrestling, 90.0 );
			
			Fame = -10000;
			Karma = 900000;
			
			VirtualArmor = 45;

            // hair, facial hair			
            HairItemID = Race.Elf.RandomHair(Female);
            HairHue = Race.Elf.RandomHairHue();
			
			PackItem( new LordsHead() );
			
			FancyShirt shirt = new FancyShirt();
			shirt.Hue = 2127;
			shirt.Name = "Gliroin's shirt";
			AddItem( shirt );

			LeatherLegs skirt = new LeatherLegs();
			skirt.Hue = 2127;
			skirt.Name = "Gliroin's pants";
			AddItem( skirt );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Hue = 2127;
			gloves.Name = "Gliroin's gloves";
			gloves.Movable = false;
			AddItem( gloves );

			Sandals shoe = new Sandals();
			shoe.Hue = 2127;
			shoe.Name = "Glirion's sandals";
			AddItem( shoe );
			
		}
		
		public ElfLord( Serial serial ) : base( serial )
		{
			
		}
		
		public override void OnDoubleClick( Mobile from )
		{
			Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;
				Item c = from.FindItemOnLayer( Layer.Backpack );
				if ( c != null )
			{
			Item d = from.Backpack.FindItemByType( typeof(LightDeed) );
			if ( d == null )
			{
			if( mobile != null )
			{
				if( from.Karma == 0 )
				{
				this.Say( "You look like a strong lad, could you do me a favor? My foe, Ashive,has been pestering me. Would you get her head for me?" );
				}
				else if( from.Karma > 0 )
				{
				this.Say( "Ah, my friend, have you come to aid me? If that is so, would you grace me by retreiving the head of my hated foe, Ashive?" );
				}
				else if( from.Karma < 0 )
				{
					this.Say( "One of evil? But... ah, you wish to come to my side? If that is so, retreive the head of your mistress, Ashive." );
				}
			}

		}
						else
			{
			this.Say( "You have already helped me. I thank you for your persistance" );
			}
				}
		}
		
		
		
		public override bool OnDragDrop( Mobile from, Item dropped )
		{
				Item p = from.FindItemOnLayer( Layer.Backpack );
				if ( p != null )
			{
			Item a = from.Backpack.FindItemByType( typeof(LightDeed) );
			if ( a == null )
			{
				
			if( from != null )
			{
			
			if( from.Karma < 0 )
			{
				if( dropped is EvilHead )
				{
					if( dropped.Amount == 1 )
					{
						from.AddToBackpack( new LightBow() );
						from.AddToBackpack( new LightDeed() );

						
						this.Say( "You have served me well. I reward you with this." );
						
						dropped.Delete();
					}
				}
				else
				{
					this.Say( "You must be mistaken, that is not her head." );
				}
				
			}
			else if( from.Karma > 0 )
			{
				
				if( dropped is EvilHead )
				{
					if( dropped.Amount==1 )
					{
				from.AddToBackpack( new LightBow());
				from.AddToBackpack( new LightDeed());

				this.Say( "Ah, my faithful servant, you have returned? Good job, take this as a reward." );
				from.SendMessage( "You are now a holy servant! You can repel any evil now!" );
						dropped.Delete();
					}
				}
				else
				{
					this.Say( "You must be mistaken, that is not her head." );

				}

			}

		}
		}
						else
			{
			this.Say( "Where did you get that? It is an obvious fake, but I admire your curage" );
			}
				}
return false;
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
