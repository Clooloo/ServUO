using System;
using Server.Items;
namespace Server.Mobiles
{
	[CorpseName( "a dark elf corpse" )]
	public class Vampy : BaseCreature
	{

		[Constructable]
		public Vampy() : base(AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.2, 0.4)
		{
			Name = "Ashive";
			Title = "the dark elf";
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
			
			Fame = 4500;
			Karma = -4500;
			
			VirtualArmor = 45;

            // hair, facial hair			
            HairItemID = Race.Elf.RandomHair(Female);
            HairHue = Race.Elf.RandomHairHue();
			
			FancyShirt shirt = new FancyShirt();
			shirt.Hue = 1175;
			shirt.Name = "ashive's shirt";
			AddItem( shirt );

			Skirt skirt = new Skirt();
			skirt.Hue = 1175;
			skirt.Name = "ashive's skirt";
			AddItem( skirt );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Hue = 1175;
			gloves.Name = "ashive's gloves";
			gloves.Movable = false;
			AddItem( gloves );

			Sandals shoe = new Sandals();
			shoe.Hue = 1260;
			shoe.Name = "ashive's sandals";
			AddItem( shoe );

			PackItem( new EvilHead());
			
		}
		
		public Vampy( Serial serial ) : base( serial )
		{
			
		}
		public override bool AlwaysMurderer{get{return true;}}
		public override void OnDoubleClick( Mobile from )
		{
			
			Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;
			
				Item p = from.FindItemOnLayer( Layer.Backpack );
				if ( p != null )
			{
			Item d = from.Backpack.FindItemByType( typeof(DarkDeed) );
			if ( d == null )
			{
			
				if( mobile != null )
				{
					if( from.Karma == 0 )
					{
						this.Say( "Hmm, you have yet to choose your way in the world, child? Ah, come to the dark side, and bring me the elven lord's head! You shall be rewarded greatly." );
					}
					else if( from.Karma > 0 )
					{
						this.Say( "Holy scum!! What are you doing, invading my prepetual darkness? Ah, I see. You wish to become part of this darkness, no? I will allow you unto my humble abode, but first, you must bring me the head of good, the elven lord!! Bring it to me, and I shall reward you greatly." );
					}
					else if( from.Karma < 0 )
					{
						this.Say( "Yes, come coser child of the dark. Do you wish to please both yourself and I? then bring me back the head of that elven lord scum!! don't worry dear, there will be a godly reward in it for you, my pretty." );
					}
				}
			}
			else
			{
				this.Say( "Go away, I have no need for you.");
			}
			}
			
		}
		
		
		
		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			Item c = from.FindItemOnLayer( Layer.Backpack );
				if ( c != null )
			{
				
			
			Item a = from.Backpack.FindItemByType( typeof(DarkDeed) );
			if ( a == null )
			{
			
			
			if( from != null )
			{
			
			if( from.Karma < 0 )
			{
				if( dropped is LordsHead )
				{
					if( dropped.Amount == 1 )
					{
						from.AddToBackpack( new DarkBow() );

						
						this.Say( "YES!! FINALLY!! My thanks for your service to your queen. Here is your reward!" );
						
						dropped.Delete();
					}
				}
				else
				{
					this.Say( "That is not the elf's head! Begone untill you finish your deed!" );
				}
				
			}
			else if( from.Karma > 0 )
			{
				
				if( dropped is LordsHead )
				{
					if( dropped.Amount==1 )
					{
				from.AddToBackpack( new DarkBow());
				from.AddToBackpack( new DarkDeed());

				this.Say( "You have pleased your queen. I thank you for your service, and thus I give you a certificate of Darkness. Hold it with reverence, dear child!" );
				from.SendMessage( "You are now a follower of the dark! Pray you meet no light upon your way!" );
						dropped.Delete();
					}
				}
				else
				{
					this.Say( "That is not the elf's head! Begone untill you finish your deed!" );

				}

			}

			}
						else
			{
			this.Say( "You pittiful mortal? Do you not think I can tell a fake head?" );
			}
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
