using System;
using System.Collections;
using System.Collections.Generic;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;
using Server;
using Server.Items;
using Server.Gumps;

namespace Server.Mobiles
{
     	public class Feron : BaseGuildmaster
	    {
		public override NpcGuild NpcGuild{ get{ return NpcGuild.BlacksmithsGuild; } }

		public override bool ClickTitle{ get{ return true; } }

		[Constructable]
		public Feron() : base( "blacksmith" )
		{
			Name = "Feron";
			Title = "the worried smithy";
			Female = true;			

			SetSkill( SkillName.ArmsLore, 65.0, 88.0 );
			SetSkill( SkillName.Blacksmith, 90.0, 100.0 );
			SetSkill( SkillName.Macing, 36.0, 68.0 );
			SetSkill( SkillName.Parry, 36.0, 68.0 );
		}

		public override VendorShoeType ShoeType
		{
			get{ return VendorShoeType.ThighBoots; }
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			Item item = ( Utility.RandomBool() ? null : new Server.Items.RingmailChest() );

			if ( item != null && !EquipItem( item ) )
			{
				item.Delete();
				item = null;
			}

			if ( item == null )
				AddItem( new Server.Items.FullApron() );

			AddItem( new Server.Items.SmithHammer() );
		}

		
		public Feron( Serial serial ) : base( serial )
		{
		}
            public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
	        { 
	                base.GetContextMenuEntries( from, list );
                      list.Add( new FeronEntry( from, this ) ); 
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
		
		public class FeronEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public FeronEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
			{
				m_Mobile = from;
				m_Giver = giver;
			}

			public override void OnClick()
			{
				

                          if( !( m_Mobile is PlayerMobile ) )
					return;
				
				PlayerMobile mobile = (PlayerMobile) m_Mobile;

				{
					if ( ! mobile.HasGump( typeof( FeronGump ) ) )
					{
						mobile.SendGump( new FeronGump( mobile ));
						
					} 
				}
			}
		}
		
		public override bool OnDragDrop( Mobile from, Item dropped )
		{          		
         	        Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;

			if ( mobile != null)
			{
				if( dropped is OrderList )
         		{
         			

					dropped.Delete(); 
				mobile.SendMessage( "Feron has given you your reward" );
				mobile.AddToBackpack( new Gold( 1000 ) );

         		switch (Utility.Random( 11 )) 
		{
         			case 0: mobile.AddToBackpack( new RunicHammer( CraftResource.DullCopper, Core.AOS ? 50 : 50 ) ); break;
         			case 1: mobile.AddToBackpack( new RunicHammer( CraftResource.ShadowIron, Core.AOS ? 50 : 50 ) ); break;
				case 2: mobile.AddToBackpack( new RunicHammer( CraftResource.Copper, Core.AOS ? 50 : 50 ) ); break;
				case 3: mobile.AddToBackpack( new RunicHammer( CraftResource.Bronze, Core.AOS ? 50 : 50 ) ); break;
				case 4: mobile.AddToBackpack( new RunicHammer( CraftResource.Gold, Core.AOS ? 40 : 40 ) ); break;
				case 5: mobile.AddToBackpack( new RunicHammer( CraftResource.Agapite, Core.AOS ? 30 : 30 ) ); break;
				case 6: mobile.AddToBackpack( new RunicHammer( CraftResource.Verite, Core.AOS ? 20 : 20 ) ); break;
				case 7: mobile.AddToBackpack( new RunicHammer( CraftResource.Valorite, Core.AOS ? 10 : 10 ) ); break;
				case 8:mobile.AddToBackpack( new RunicSewingKit( CraftResource.SpinedLeather, Core.AOS ? 50 : 50 ) );; break;
				case 9:mobile.AddToBackpack( new RunicSewingKit( CraftResource.HornedLeather, Core.AOS ? 30 : 30 ) );; break;
				case 10:mobile.AddToBackpack( new RunicSewingKit( CraftResource.BarbedLeather, Core.AOS ? 10 : 10 ) );; break;
         			
		}
         			
				

					return true;
         		}
				
         		else
         		{
					SayTo( from, "I have no need for that, please get my order list" );
     			}
			}
			return false;

		
		}

	}
}