using System; 
using Server; 
using Server.Gumps; 
using Server.Network; 
using Server.Mobiles;
using Server.Items;

namespace Server.Items 
{    
	public class HeroTrainer : Item 
	{
		private HHStudyTimer m_HHStudyTimer;
		private Mobile m_From;
		private HeroTrainer m_Trainer;

		private int m_HHStudyTime;
		private int m_Ouch;
		private double m_MinSkill;
		private double m_MaxSkill;
		private bool m_Studying;

		[CommandProperty( AccessLevel.GameMaster )]
		public int HHStudyTime{ get{ return m_HHStudyTime; } set{ m_HHStudyTime = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Ouch{ get{ return m_Ouch; } set{ m_Ouch = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public double MinSkill { get{ return m_MinSkill; } set{ m_MinSkill = value; }	}

		[CommandProperty( AccessLevel.GameMaster )]
		public double MaxSkill { get{ return m_MaxSkill; } set{ m_MaxSkill = value; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public bool Studying { get{ return m_Studying; } set{ m_Studying = value; } }

		[Constructable] 
		public HeroTrainer() : base( 0x2259 ) 
		{
			Name = "Schoolbooks for HeroQuest";
			Movable = false;  
         		LootType = LootType.Blessed;
         		Weight = 100;
			HHStudyTime = 2;
			Ouch = 5;
			MinSkill = -10.0;
			MaxSkill = 120.0;
			Studying = false;
                         Hue = 1161;
		}

		[Constructable] 
		public HeroTrainer( int HHStudyTime, int ouch, double minSkill, double maxSkill, bool studying) : base( 0x2259 ) 
		{
			Name = "Schoolbooks for HeroQuest";
			Movable = false;  
         		LootType = LootType.Blessed;
         		Weight = 5;
			HHStudyTime = HHStudyTime;
			Ouch = ouch;
			MinSkill = minSkill;
			MaxSkill = maxSkill;
			Studying = studying;
		}

		public HeroTrainer( Serial serial ) : base( serial ) 
		{ 
		}

		public void UseHeroTrainer( Mobile from )
		{
			if ( !this.Studying )
				from.SendGump( new HeroTrainerGump( from, this ) );
			else
				from.SendMessage( "You must wait until your current studies are completed." );
		}

		public override void OnDoubleClick( Mobile from )
		{  
                UseHeroTrainer ( from );
		}

		public override void Serialize( GenericWriter writer ) 
		{ 
			 base.Serialize( writer ); 
			 writer.Write( (int) 0 ); // version 

			writer.Write( (int) m_HHStudyTime);
			writer.Write( (int) m_Ouch);

			writer.Write( m_MinSkill );
			writer.Write( m_MaxSkill );

			writer.Write( (bool) m_Studying );
		} 

		public override void Deserialize( GenericReader reader ) 
		{
			base.Deserialize( reader ); 
			int version = reader.ReadInt(); 

			m_HHStudyTime = reader.ReadInt();
			m_Ouch = reader.ReadInt();

			m_MinSkill = reader.ReadDouble();
			m_MaxSkill = reader.ReadDouble();

			m_Studying = reader.ReadBool();
		}
	}
}

namespace Server.Items
{
	public class HeroTrainerGump : Gump 
	{ 
		private Mobile m_From;
		private HeroTrainer m_Trainer;

		public HeroTrainerGump( Mobile from, HeroTrainer trainer ) : base( 25,25 ) 
		  {	 
			m_From = from;
			m_Trainer = trainer;
			m_From.CloseGump( typeof( HeroTrainerGump ) );
				
         	AddPage( 0 ); 

			AddBackground( 50, 10, 500, 500, 5054 );
			AddImageTiled( 58, 20, 500, 475, 2624 );
			AddAlphaRegion( 58, 20, 500, 475 );

 			AddLabel( 75, 25, 88, " Hero Trainer    -Need your blood- ");

         	AddButton( 75, 50, 4005, 4007, 1, GumpButtonType.Reply, 0 );
 			AddLabel( 125, 50, 0x486, "Blacksmith" ); 

         	AddButton( 75, 75, 4005, 4007, 2, GumpButtonType.Reply, 0 );
         	AddLabel( 125, 75, 0x486, "Carpentry" ); 

         	AddButton( 75, 100, 4005, 4007, 3, GumpButtonType.Reply, 0 );
         	AddLabel( 125, 100, 0x486, "Tailoring" ); 

         	AddButton( 75, 125, 4005, 4007, 4, GumpButtonType.Reply, 0 );
         	AddLabel( 125, 125, 0x486, "Alchemy" ); 

         	AddButton( 75, 150, 4005, 4007, 5, GumpButtonType.Reply, 0 );
         	AddLabel( 125, 150, 0x486, "Inscription" ); 

         	AddButton( 275, 50, 4005, 4007, 6, GumpButtonType.Reply, 0 );
        	AddLabel( 325, 50, 0x486, "Cooking" ); 

         	AddButton( 275, 75, 4005, 4007, 7, GumpButtonType.Reply, 0 );
         	AddLabel( 325, 75, 0x486, "Fletching" ); 

         	AddButton( 275, 100, 4005, 4007, 8, GumpButtonType.Reply, 0 );
         	AddLabel( 325, 100, 0x486, "Cartography" ); 

         	AddButton( 275, 125, 4005, 4007, 9, GumpButtonType.Reply, 0 );
         	AddLabel( 325, 125, 0x486, "Tinkering" ); 

         	AddButton( 275, 150, 4005, 4007, 10, GumpButtonType.Reply, 0 );
         	AddLabel( 325, 150, 0x486, "Poisoning" ); 

         	AddButton( 275, 175, 4005, 4007, 11, GumpButtonType.Reply, 0 );
         	AddLabel( 325, 175, 0x486, "Animal Taming" ); 

         	AddButton( 275, 200, 4005, 4007, 12, GumpButtonType.Reply, 0 );
         	AddLabel( 325, 200, 0x486, "Discordance" ); 

         	AddButton( 275, 225, 4005, 4007, 13, GumpButtonType.Reply, 0 );
         	AddLabel( 325, 225, 0x486, "Peacemaking" ); 

        // 	AddButton( 75, 175, 4005, 4007, 14, GumpButtonType.Reply, 0 );
       //  	AddLabel( 125, 175, 0x486, "Imbuing" ); 

         	AddButton( 75, 200, 4005, 4007, 15, GumpButtonType.Reply, 0 );
         	AddLabel( 125, 200, 0x486, "Healing" ); 

         	AddButton( 75, 225, 4005, 4007, 16, GumpButtonType.Reply, 0 );
         	AddLabel( 125, 225, 0x486, "Ninjitsu" ); 

         	AddButton( 75, 250, 4005, 4007, 17, GumpButtonType.Reply, 0 );
         	AddLabel( 125, 250, 0x486, "Spellweaving" ); 

         	AddButton( 75, 275, 4005, 4007, 18, GumpButtonType.Reply, 0 );
         	AddLabel( 125, 275, 0x486, "Veterinary" ); 

         	AddButton( 275, 250, 4005, 4007, 19, GumpButtonType.Reply, 0 );
         	AddLabel( 325, 250, 0x486, "Chivalry" ); 

         	AddButton( 275, 275, 4005, 4007, 20, GumpButtonType.Reply, 0 );
         	AddLabel( 325, 275, 0x486, "Hiding" ); 
			
			AddButton( 75, 300, 4005, 4007, 21, GumpButtonType.Reply, 0 );
         	AddLabel( 125, 300, 0x486, "Provocation" ); 
			
			AddButton( 275, 300, 4005, 4007, 22, GumpButtonType.Reply, 0 );
         	AddLabel( 325, 300, 0x486, "Mining" ); 
			
			AddButton( 75, 325, 4005, 4007, 23, GumpButtonType.Reply, 0 );
         	AddLabel( 125, 325, 0x486, "Resisting Spells " ); 
			
			AddButton( 275, 325, 4005, 4007, 24, GumpButtonType.Reply, 0 );
         	AddLabel( 325, 325, 0x486, "Animal Lore" );
			
			//AddButton( 75, 350, 4005, 4007, 25, GumpButtonType.Reply, 0 );
         //	AddLabel( 125, 350, 0x486, "Throwing" ); 
			
			AddButton( 275, 350, 4005, 4007, 26, GumpButtonType.Reply, 0 );
         	AddLabel( 325, 350, 0x486, "Necromancy" );
			
			AddButton( 75, 375, 4005, 4007, 27, GumpButtonType.Reply, 0 );
         	AddLabel( 125, 375, 0x486, "Spirit Speak" ); 
			
			AddButton( 275, 375, 4005, 4007, 28, GumpButtonType.Reply, 0 );
         	AddLabel( 325, 375, 0x486, "Bushido" );
			
			//AddButton( 75, 400, 4005, 4007, 29, GumpButtonType.Reply, 0 );
         //	AddLabel( 125, 400, 0x486, "Mysticism" );
            
            AddButton( 275, 400, 4005, 4007, 30, GumpButtonType.Reply, 0 );
         	AddLabel( 325, 400, 0x486, "Stealing" );
			
			AddButton( 75, 425, 4005, 4007, 31, GumpButtonType.Reply, 0 );
         	AddLabel( 125, 425, 0x486, "Stealth" );



		}

		public override void OnResponse( NetState state, RelayInfo info )
		{ 
			if ( m_Trainer.Deleted )
					return;

			else if ( info.ButtonID == 1 )
			{				
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{	
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Blacksmith.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding blacksmithy");
						else
							m_From.SendMessage( "You turn to the blacksmithy section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Blacksmith, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;
					}
				}
			}
			else if ( info.ButtonID == 2 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )	
				{	
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Carpentry.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding carpentry.");
						else
							m_From.SendMessage( "You turn to the carpentry section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Carpentry, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}
			else if ( info.ButtonID == 3 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )	
				{	
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Tailoring.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding tailoring.");
						else
							m_From.SendMessage( "You turn to the tailoring section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Tailoring, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}
			else if ( info.ButtonID == 4 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )	
				{	
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Alchemy.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding alchemy.");
						else
							m_From.SendMessage( "You turn to the alchemy section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Alchemy, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}
			else if ( info.ButtonID == 5 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )	
				{	
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Inscribe.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding inscription.");
						else
							m_From.SendMessage( "You turn to the inscription section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Inscribe, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}
			else if ( info.ButtonID == 6 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )	
				{	
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Cooking.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding cooking.");
						else
							m_From.SendMessage( "You turn to the cooking section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Cooking, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}
			else if ( info.ButtonID == 7 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )	
				{	
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Fletching.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding fletching.");
						else
							m_From.SendMessage( "You turn to the fletching section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Fletching, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}
			else if ( info.ButtonID == 8 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )	
				{	
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Cartography.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding cartography.");
						else
							m_From.SendMessage( "You turn to the cartography section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Cartography, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}
			else if ( info.ButtonID == 9 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Tinkering.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding tinkering.");
						else
							m_From.SendMessage( "You turn to the tinkering section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Tinkering, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}
			else if ( info.ButtonID == 10 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Poisoning.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding poisoning.");
						else
							m_From.SendMessage( "You turn to the poisoning section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Poisoning, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}

			else if ( info.ButtonID == 11 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.AnimalTaming.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding AnimalTaming.");
						else
							m_From.SendMessage( "You turn to the AnimalTaming section of the books and study for a while." );
							m_From.CheckSkill( SkillName.AnimalTaming, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}

			else if ( info.ButtonID == 12 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Discordance.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding Discordance.");
						else
							m_From.SendMessage( "You turn to the Discordance section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Discordance, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}

			else if ( info.ButtonID == 13 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Peacemaking.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding Peacemaking.");
						else
							m_From.SendMessage( "You turn to the Peacemaking section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Peacemaking, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}

			else if ( info.ButtonID == 14 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Imbuing.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding Imbuing.");
						else
							m_From.SendMessage( "You turn to the Imbuing section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Imbuing, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}

			else if ( info.ButtonID == 15 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Healing.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding Healing.");
						else
							m_From.SendMessage( "You turn to the Healing section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Healing, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}
			else if ( info.ButtonID == 16 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Ninjitsu.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding Ninjitsu.");
						else
							m_From.SendMessage( "You turn to the Ninjitsu section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Ninjitsu, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}

			else if ( info.ButtonID == 17 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Spellweaving.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding Spellweaving.");
						else
							m_From.SendMessage( "You turn to the Spellweaving section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Spellweaving, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}

			else if ( info.ButtonID == 18 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Veterinary.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding Veterinary.");
						else
							m_From.SendMessage( "You turn to the Veterinary section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Veterinary, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}

			else if ( info.ButtonID == 19 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Chivalry.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding Chivalry.");
						else
							m_From.SendMessage( "You turn to the Chivalry section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Chivalry, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}

			else if ( info.ButtonID == 20 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Hiding.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding Hiding.");
						else
							m_From.SendMessage( "You turn to the Hiding section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Hiding, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}
			
			else if ( info.ButtonID == 21 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Provocation.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding Provocation.");
						else
							m_From.SendMessage( "You turn to the Provocation section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Provocation, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}
			
			else if ( info.ButtonID == 22 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Mining.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding Mining.");
						else
							m_From.SendMessage( "You turn to the Mining section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Mining, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}
			
				else if ( info.ButtonID == 23 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.MagicResist.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding MagicResist.");
						else
							m_From.SendMessage( "You turn to the MagicResist section of the books and study for a while." );
							m_From.CheckSkill( SkillName.MagicResist, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}
			
			else if ( info.ButtonID == 24 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.AnimalLore.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding AnimalLore.");
						else
							m_From.SendMessage( "You turn to the AnimalLore section of the books and study for a while." );
							m_From.CheckSkill( SkillName.AnimalLore, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}
			
			else if ( info.ButtonID == 25 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Throwing.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding Throwing.");
						else
							m_From.SendMessage( "You turn to the Throwing section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Throwing, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}
			
			else if ( info.ButtonID == 26 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Necromancy.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding Necromancy.");
						else
							m_From.SendMessage( "You turn to the Necromancy section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Necromancy, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}
			
			else if ( info.ButtonID == 27 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.SpiritSpeak.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding Spirit Speak.");
						else
							m_From.SendMessage( "You turn to the Spirit Speak section of the books and study for a while." );
							m_From.CheckSkill( SkillName.SpiritSpeak, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}
			
			else if ( info.ButtonID == 28 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Bushido.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding bushido.");
						else
							m_From.SendMessage( "You turn to the Bushido section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Bushido, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}
			
			else if ( info.ButtonID == 29 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Mysticism.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding Mysticism.");
						else
							m_From.SendMessage( "You turn to the Mysticism section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Mysticism, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}

           else if ( info.ButtonID == 30 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Stealing.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding Stealing.");
						else
							m_From.SendMessage( "You turn to the Stealing section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Stealing, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}
            
            else if ( info.ButtonID == 31 )
			{
				if ( !m_From.InRange( m_Trainer.GetWorldLocation(), 2 ) )
				{		
					m_From.SendMessage( "Your eyes are not quite up to the challenge, get a little closer." );
				}
				else
				{	
					if ( m_From.Hits <= m_Trainer.Ouch )
					{
						m_From.SendMessage( "You are too weak!");
					}
					else
					{
						new HHStudyTimer( m_From, m_Trainer.HHStudyTime, m_Trainer ).Start();
						if ( m_From.Skills.Stealth.Base >= m_Trainer.MaxSkill )
							m_From.SendMessage( "You have mastered all that these books have to teach regarding Stealth.");
						else
							m_From.SendMessage( "You turn to the Stealth section of the books and study for a while." );
							m_From.CheckSkill( SkillName.Stealth, m_Trainer.MinSkill, m_Trainer.MaxSkill );
							m_From.Hits = (m_From.Hits - m_Trainer.Ouch);
							m_From.Stam = (m_From.Stam - m_Trainer.Ouch);
							m_From.Mana = (m_From.Mana - m_Trainer.Ouch);
							m_Trainer.Studying = true;	
					}
				}
			}

		}
	}

	public class HHStudyTimer : Timer
	{
		private Mobile m_From;
		private HeroTrainer m_Trainer;

		public HHStudyTimer( Mobile from, int HHStudyTime, HeroTrainer HeroTrainer ) : base( TimeSpan.FromSeconds( HHStudyTime ) )
		{
			m_From = from;
			m_Trainer = HeroTrainer;
		}

		protected override void OnTick()
        {
            m_Trainer.Studying = false;	
			m_From.SendGump( new HeroTrainerGump( m_From, m_Trainer ) );
		}
	}
}
