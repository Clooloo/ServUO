using System;
using Server.Misc;

namespace Server.Items
{
	[FlipableAttribute( 0x1515, 0x1530 )] 
	public class CloakofSirKen : Cloak 
	{ 
		private SkillMod m_SkillMod0; 
		private SkillMod m_SkillMod1; 
		private SkillMod m_SkillMod2;
		private SkillMod m_SkillMod3; 
		private SkillMod m_SkillMod4; 		
		private StatMod m_StatMod0;
		private StatMod m_StatMod1;		
		
		[Constructable] 
		public CloakofSirKen() : base( 0x309 ) 
		{ 
			Name = "The Cloak of Sir Kenshin";
			
			Attributes.WeaponDamage = 100;
			Attributes.SpellDamage = 25;
            Attributes.LowerManaCost = 8;
       		Attributes.AttackChance = 15;
			
			DefineMods();
		} 

		private void DefineMods()
		{
			m_SkillMod0 = new DefaultSkillMod( SkillName.Macing, true, 20 ); 
			m_SkillMod1 = new DefaultSkillMod( SkillName.Fencing, true, 20 ); 
			m_SkillMod2 = new DefaultSkillMod( SkillName.Throwing, true, 20 );
			m_SkillMod3 = new DefaultSkillMod( SkillName.Tactics, true, 20 ); 
			m_SkillMod4 = new DefaultSkillMod( SkillName.Anatomy, true, 20 );			
			m_StatMod0 = new StatMod( StatType.Str, "CloakofSirKen", 25, TimeSpan.Zero );
			m_StatMod1 = new StatMod( StatType.Dex, "CloakofSirKen", 25, TimeSpan.Zero );
		}

		private void SetMods( Mobile wearer )
		{			
			wearer.AddSkillMod( m_SkillMod0 ); 
			wearer.AddSkillMod( m_SkillMod1 ); 
			wearer.AddSkillMod( m_SkillMod2 );
			wearer.AddSkillMod( m_SkillMod3 );
			wearer.AddSkillMod( m_SkillMod4 ); 			
		}

		public override bool OnEquip( Mobile from ) 
		{ 
			SetMods( from );
			return true;  
		} 

		public override bool Dye( Mobile from, DyeTub sender )
		{
			from.SendLocalizedMessage( 1042083 ); // You can not dye that.
			return false;
		}

		public override void OnRemoved( object parent ) 
		{ 
			if ( parent is Mobile ) 
			{ 
				Mobile m = (Mobile)parent;
				m.RemoveStatMod( "CloakofSirKen" ); 

				if ( m.Hits > m.HitsMax )
					m.Hits = m.HitsMax; 

				if ( m_SkillMod0 != null ) 
					m_SkillMod0.Remove(); 

				if ( m_SkillMod1 != null ) 
					m_SkillMod1.Remove(); 

				if ( m_SkillMod2 != null ) 
					m_SkillMod2.Remove();

				if ( m_SkillMod3 != null ) 
					m_SkillMod3.Remove(); 

				if ( m_SkillMod4 != null ) 
					m_SkillMod4.Remove(); 				
			} 
		} 

		public override void OnSingleClick( Mobile from ) 
		{ 
			this.LabelTo( from, Name ); 
		} 

		public CloakofSirKen( Serial serial ) : base( serial ) 
		{ 
			DefineMods();
			
			if ( Parent != null && this.Parent is Mobile ) 
				SetMods( (Mobile)Parent );
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 
			writer.Write( (int) 0 ); 
		} 

		public override void Deserialize(GenericReader reader) 
		{ 
			base.Deserialize( reader ); 
			int version = reader.ReadInt(); 
		} 
	} 
} 