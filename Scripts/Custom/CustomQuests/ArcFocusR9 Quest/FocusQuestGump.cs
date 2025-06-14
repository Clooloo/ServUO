using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{ 
   public class FocusQuestGump : Gump 
   { 
      public static void Initialize() 
      {
          CommandSystem.Register("FocusQuestGump", AccessLevel.GameMaster, new CommandEventHandler(FocusQuestGump_OnCommand)); 
      } 

      private static void FocusQuestGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new FocusQuestGump( e.Mobile ) ); 
      } 

      public FocusQuestGump( Mobile owner ) : base( 50,50 ) 
      { 
//----------------------------------------------------------------------------------------------------

				AddPage( 0 );
			AddImageTiled(  54, 33, 369, 400, 2624 );
			AddAlphaRegion( 54, 33, 369, 400 );

			AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
			
			AddImage( 97, 49, 9005 );
			AddImageTiled( 58, 39, 29, 390, 10460 );
			AddImageTiled( 412, 37, 31, 389, 10460 );
			AddLabel( 140, 60, 0x34, "Rank 9 Arcane Focus" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=WHITE>I've lost my most valuable book!<BR><BR>Retrieve it and I'll rewards you with something very powerful. <BR>" +
"<BASEFONT COLOR=WHITE>Bring me the Book of Forgotten Powers. Pirates took it on my last sea voyage.  Good luck!" +
						     "</BODY>", false, true);
			
//			<BASEFONT COLOR=#7B6D20>			

//			AddLabel( 113, 135, 0x34, "Tsunade puts down her Papers and asks.." );
//			AddLabel( 113, 150, 0x34, "so you are going to help me?" );
//			AddLabel( 113, 165, 0x34, "Remember, I need his heart as proof..." );
//			AddLabel( 113, 180, 0x34, "You can find him in The Fire Dungeon." );
			AddImage( 430, 9, 10441);
			AddImageTiled( 40, 38, 17, 391, 9263 );
			AddImage( 6, 25, 10421 );
			AddImage( 34, 12, 10420 );
			AddImageTiled( 94, 25, 342, 15, 10304 );
			AddImageTiled( 40, 427, 415, 16, 10304 );
			AddImage( -10, 314, 10402 );
			AddImage( 56, 150, 10411 );
			AddImage( 155, 120, 2103 );
			AddImage( 136, 84, 96 );

			AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 ); 

//--------------------------------------------------------------------------------------------------------------
      } 

      public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons 
      { 
         Mobile from = state.Mobile; 

         switch ( info.ButtonID ) 
         { 
            case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
            { 
               //Cancel 
               from.SendMessage( "You hear laughter at your back." );
               break; 
            } 

         }
      }
   }
}