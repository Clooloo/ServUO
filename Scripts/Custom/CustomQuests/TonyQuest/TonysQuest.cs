/*
 created by:
     /\            888                   888     .d8888b.   .d8888b.  
____/_ \____       888                   888    d88P  Y88b d88P  Y88b 
\  ___\ \  /       888                   888    888    888 888    888 
 \/ /  \/ /    .d88888  8888b.   8888b.  888888 Y88b. d888 Y88b. d888 
 / /\__/_/\   d88" 888     "88b     "88b 888     "Y888P888  "Y888P888 
/__\ \_____\  888  888 .d888888 .d888888 888           888        888 
    \  /      Y88b 888 888  888 888  888 Y88b.  Y88b  d88P Y88b  d88P 
     \/        "Y88888 "Y888888 "Y888888  "Y888  "Y8888P"   "Y8888P"  
Tonys Crazy Horse Quest v1.0
Story Background:
	Basically Tony is a horse rider who used to tormented his horse while in training.
	He didn't gave him enough food or water and kept beating him up all the time (too bad tony is immune)...
	One day Tonys horse got crazy, grabbed tonys leash and start running.
	Tony will ask the player to get his training leash back to him in exchange to a magical reward, a pet res crystal (that he probably stole from someone) and some gold.
*/
//Thanx for Sunshine for her ideas
using System;
using System.Collections;
using Server;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Commands;
using System.Collections.Generic; 

namespace Server.Mobiles
{
	#region Tony
	[CorpseName( "Tony's Corpse" )]
	public class Tony : Mobile
	{
		private static ArrayList alFinished = new ArrayList();
		public static ArrayList Finished{ get{ return alFinished; } set{ alFinished = value; } }

		[Constructable]
		public Tony()
		{
			alFinished = new ArrayList();
			Name = "Tony";
			Title = "The Horse Rider";
			Body = 400;
			CantWalk = true;
			Hue = 33784;
			AddItem( new Boots() );
			AddItem( new Shirt( 1436 ) );
			AddItem( new ShortPants( 1436 ) );
			AddItem( new Whip() );
			AddItem( new ShortHair( 1741 ) );
		}

		public virtual bool IsInvulnerable{ get{ return true; } }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list) 
		{ 
			base.GetContextMenuEntries( from, list ); 
			list.Add( new TonyEntry( from, this ) ); 
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{          		
			if ( from == null )
				return false;

			if( dropped is Whip )
			{
				if ( alFinished.Contains( from ) )
				{
					from.SendMessage(32, "You can do the quest only once");
					return false;
				}
				alFinished.Add( from );
				from.AddToBackpack( new Gold( 5000 ) );
				from.AddToBackpack( new TonysResCrystal( ) );
				if (dropped.Amount > 1)
					dropped.Amount--;
				else
					dropped.Delete();
				from.SendMessage( "Thank you kind neighbour!" );
				from.SendGump( new TonyFinishGump());
			}
			else
				PrivateOverheadMessage( MessageType.Regular, 1153, false, "I have no use of this!", from.NetState );
			return false;
		}
		
		public static void Initialize() 
		{
            CommandSystem.Register("TonyGump", AccessLevel.GameMaster, new CommandEventHandler(TonyGump_OnCommand));
            CommandSystem.Register("RemoveFromTonysList", AccessLevel.Seer, new CommandEventHandler(RemoveFromTonysList_OnCommand));
		} 

		private static void TonyGump_OnCommand( CommandEventArgs e ) 
		{
			e.Mobile.SendGump( new TonyGump( e.Mobile ) ); 
		}
		private static void RemoveFromTonysList_OnCommand ( CommandEventArgs e )
		{
			e.Mobile.Target = new RemoveFromTonysListTarget(); 
		}

		public Tony( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );

			writer.WriteMobileList( alFinished, true );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			alFinished = reader.ReadMobileList();
		}
	}
	#endregion

	#region Context Menu
	public class TonyEntry : ContextMenuEntry
	{
		private Mobile mFrom;
		private Mobile mTony;
			
		public TonyEntry( Mobile from, Mobile tony ) : base( 6146, 3 )
		{
			mFrom = from;
			mTony = tony;
		}

		public override void OnClick()
		{
			if( !( mFrom is PlayerMobile ) )
				return;
			if ( !( mFrom.HasGump( typeof( TonyGump ) ) ) )
			{
				mFrom.SendGump( new TonyGump( mFrom ));
			}
		}
	}
	#endregion

	#region Tonys gump
	public class TonyGump : Gump 
	{
		public TonyGump( Mobile owner ) : base( 50,50 ) 
		{ 
			AddPage(0);
			AddBackground(50, 50, 400, 415, 9250);
			AddImageTiled(411, 62, 44, 389, 203);
			AddImage(93, 83, 9005);
			AddLabel(155, 83, 52, @"The Quest of The Training Whip");
			AddHtml( 93, 149, 315, 249, "<BODY>" +
				"<BASEFONT COLOR=YELLOW>*Tony looks up with a grin*<BR><BR>" +
				"Say, hey, hey you! Come over here.<BR>" + 
				"I'm wanting to head off to join the tournament later, but I need to train my horse first.<BR><BR>" + 
				"The games mean a lot to me, but my last horse ran away with my whip.<BR>" +
				"Find me my horse, it's called Tonys Crazy Horse.<BR><BR>" +
				"Once you kill him open his backpack and you should see my whip there.<BR>" +
				"Be ware, this horse can kill almost every veteran player with one hit.<BR><BR>" +
				"Stay clear of his kicking legs and crashing head.<BR>" +
				"I'll give you my blessed Resurrection Crystal and 5000 gold coins if you give me my whip back.<BR><BR>" +
				"So think about it, a lot of gold for your work!</BODY>", (bool)true, (bool)true);
			AddImageTiled(44, 61, 17, 391, 9263);
			AddImage(10, 52, 10421);
			AddImageTiled(63, 63, 375, 15, 10304);
			AddImageTiled(63, 434, 375, 15, 10304);
			AddImage(-7, 344, 10402);
			AddImage(108, 99, 2103);
			AddImage(162, 105, 96);
			AddButton(224, 405, 247, 248, 0, GumpButtonType.Reply, 0);
			AddImageTiled(411, 61, 30, 390, 10460);
			AddImageTiled(61, 61, 30, 390, 10460);
			AddImage(423, 33, 10441);
			AddImage(37, 47, 10420);
			AddImage(31, 187, 10411);
		} 
	}
	#endregion

	#region Tonys finish gump
	public class TonyFinishGump : Gump
	{
		public TonyFinishGump() : base( 200, 200 )
		{
			AddPage(0);
			AddBackground(0, 0, 353, 118, 9270);
			AddAlphaRegion( 2, 2, 349, 114 );
			AddLabel(118, 15, 1149, "Quest Complete");
			AddLabel(48, 39, 255, "Oh wonderful. Thank you so much!.");
			AddLabel(48, 55, 255, "Please, take this as a sign of my gratitude.");
			AddLabel(48, 71, 255, "Thank you again!");
		}
	}
	#endregion

	#region Remove from tonys list
	public class RemoveFromTonysListTarget : Target 
	{ 
		public RemoveFromTonysListTarget() : base( 15, false, TargetFlags.None ) 
		{ 
		}

		protected override void OnTarget( Mobile from, object target ) 
		{ 
			if ( !( target is PlayerMobile ) )
				return;
			
			if ( Tony.Finished.Contains( (Mobile)target ) )
			{
				Tony.Finished.Remove( (Mobile)target );
				from.SendMessage(88, "You removed the player from Tonys list and he can do the quest again.");
			}
			else
				from.SendMessage(32, "This player is not in Tonys list. ");
		} 
	} 
	#endregion

	#region Tonys crazy horse
	[CorpseName( "Tonys crazy horse corpse" )]
	public class TonysCrazyHorse : BaseCreature
	{
		[Constructable]
		public TonysCrazyHorse() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Tonys Crazy Horse";
			Body = 226;
			BaseSoundID = 168;

			SetStr( 360, 400 );
			SetDex( 460, 580 );
			SetInt( 260, 340 );

			SetHits( 1000, 1200 );
			SetMana( 200 );

			SetDamage( 270, 290 );

			SetDamageType( ResistanceType.Physical, 100 );
			SetDamageType( ResistanceType.Fire, 100 );
			SetDamageType( ResistanceType.Cold, 100 );
			SetDamageType( ResistanceType.Poison, 100 );
			SetDamageType( ResistanceType.Energy, 100 );
			
			SetResistance( ResistanceType.Physical, 100 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Cold, 100 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 100 );

			SetSkill( SkillName.MagicResist, 100.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0 );

			Fame = 30000;
			Karma = -30000;

			VirtualArmor = 100;

			PackItem( new Whip() );
		}

		public override bool BardImmune{ get{ return true; } }
		public override bool AutoDispel{ get{ return true; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

		public TonysCrazyHorse( Serial serial ) : base( serial )
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
	#endregion

	#region Pet res crystal
	[Flipable( 0x1374, 0x1375 )]
	public class TonysResCrystal : AddonComponent
	{
		private DateTime dtNextUse;

		[CommandProperty(AccessLevel.GameMaster)]
		public DateTime NextUse { get { return dtNextUse; } set { dtNextUse = value; InvalidateProperties(); } }

		[Constructable]
		public TonysResCrystal() : base ( 7961 )
		{
			Name="Tonys Resurrection Crystal";
			Hue = 33;
			Movable= true;
			LootType = LootType.Blessed;
		}

		public TonysResCrystal( Serial serial ) : base( serial )
		{
		}
			
		public override void OnDoubleClick( Mobile from )
		{
			if ( !(IsChildOf(from.Backpack)) )
				from.SendMessage(32, "This must be in your backpack to use");
			else if (dtNextUse > DateTime.Now)
				from.SendMessage(32, "You can't use this untill the energy recharges.");
			else
				from.Target = new TonysResCrystalTarget( this ); 
		}

		private class TonysResCrystalTarget : Target
		{
			private TonysResCrystal rc;

			public TonysResCrystalTarget( Item i ) : base( 3, false, TargetFlags.None )
			{
				rc=(TonysResCrystal)i;
			}
			
			protected override void OnTarget( Mobile from, object targ )
			{
				if ( rc.Deleted || !(targ is BaseCreature) )
					return;
				BaseCreature bc = (BaseCreature)targ;
				if ( bc.IsDeadPet && bc.ControlMaster != null && bc.ControlMaster is PlayerMobile )
				{
					int iChance = Utility.Random(100);
					if ( iChance == Utility.Random(100) ) //1% to delete it
					{
						rc.Delete();
						from.SendMessage(32, "The Crystal shatters as the magic within explodes, leaving nothing but ashes behind.");
					}
					else if ( iChance < 50 ) //50% to res the pet
					{
						from.PlaySound( 0x214 );
						from.FixedEffect( 0x376A, 10, 16 );
						bc.ControlMaster.SendGump( new PetResurrectGump( from, bc ) );
						from.SendMessage(88, "The Gods have smiled upon you and your pet lives.");
					}
					else if ( iChance < 75 ) //25% to do nothing
						from.SendMessage(32, "I am sorry your pet could not be resurrected.");
					else if ( iChance < 90 ) //15% to take 50% hp from the player max hp.
					{
						if ( from.Hits < (int)(from.HitsMax/2) )
						{
							from.Kill();
							from.SendMessage(32, "You were not able to control the energy force and sufferd a blow, if you were more healthy you would've survived.");
						}
						else
						{
							from.Hits = (int)(from.HitsMax/2);
							from.SendMessage(32, "You were not able to control the energy force and sufferd a blow.");
						}
						Effects.PlaySound( from.Location, from.Map, 0x207 );
						Effects.SendLocationEffect( from.Location, from.Map, 0x36BD, 20 );
					}
					else 
					{
						Effects.PlaySound( from.Location, from.Map, 0x207 );
						Effects.SendLocationEffect( from.Location, from.Map, 0x36BD, 20 );
						from.SendMessage(32, "The power was to great, you could not hope to control it and you were killed.");
						from.Kill();
					}
					rc.NextUse = DateTime.Now + TimeSpan.FromMinutes( Utility.Random( 15, 15 ) );
				}
				else
					from.SendMessage("You can only res pets that you own");
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
			writer.Write( (DateTime) dtNextUse );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			dtNextUse = reader.ReadDateTime();
		} 
	}
	#endregion
}