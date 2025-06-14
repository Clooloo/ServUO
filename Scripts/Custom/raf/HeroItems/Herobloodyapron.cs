using System;
using Server.Network;
using Server.Items;
using System.Collections;

namespace Server.Items
{
	public class HerobloodyApron : HalfApron
	{
        public override int InitMinHits { get { return 100; } }
        public override int InitMaxHits { get { return 100; } }

		[Constructable]
		public HerobloodyApron() : base()
		{
			Weight = 1.0;
			Name = "Blood of Hero";
			Hue = 2155;
                        this.Attributes.RegenHits = 10;
                        this.Attributes.WeaponDamage = 20;
                        this.Attributes.SpellDamage = 25;
                         Weight = 40.0;
             

            switch (Utility.Random(3))
            {
                case 0: Attributes.BonusHits = 10; break; 
                case 1: Attributes.BonusHits = 15; break;
                case 2: Attributes.BonusHits = 20; break;

            }            

            switch (Utility.Random(3))
            {
                case 0: Attributes.BonusInt = 10; break; 
                case 1: Attributes.BonusInt = 15; break;
                case 2: Attributes.BonusInt = 20; break;


		}

            switch( Utility.Random(14) )
            {
                case 0: 
                    this.SkillBonuses.SetValues(0, SkillName.EvalInt, 20);
                    this.SkillBonuses.SetValues(1, SkillName.Magery, 20);
                    break;
                case 1: 
                    this.SkillBonuses.SetValues(0, SkillName.Provocation, 20);
                    this.SkillBonuses.SetValues(1, SkillName.Musicianship, 20);
                    break;
                case 2: 
                    this.SkillBonuses.SetValues(0, SkillName.Swords, 20);
                    this.SkillBonuses.SetValues(1, SkillName.Tactics, 20);
                    break;
                case 3: 
                    this.SkillBonuses.SetValues(0, SkillName.Discordance, 20);
                    this.SkillBonuses.SetValues(1, SkillName.Musicianship, 20);
                    break;
                case 4: 
                    this.SkillBonuses.SetValues(0, SkillName.Fencing, 20);
                    this.SkillBonuses.SetValues(1, SkillName.Tactics, 20);
                    break;
                case 5: 
                    this.SkillBonuses.SetValues(0, SkillName.Chivalry, 20);
                    this.SkillBonuses.SetValues(1, SkillName.MagicResist, 20);
                    break;
                case 6: 
                    this.SkillBonuses.SetValues(0, SkillName.Anatomy, 20);
                    this.SkillBonuses.SetValues(1, SkillName.Healing, 20);
                    break;
                case 7: 
                    this.SkillBonuses.SetValues(0, SkillName.Ninjitsu, 20);
                    this.SkillBonuses.SetValues(1, SkillName.Stealth, 20);
                    break;
                case 8: 
                    this.SkillBonuses.SetValues(0, SkillName.Bushido, 20);
                    this.SkillBonuses.SetValues(1, SkillName.Parry, 20);
                    break;
                case 9: 
                    this.SkillBonuses.SetValues(0, SkillName.Archery, 20);
                    this.SkillBonuses.SetValues(1, SkillName.Tactics, 20);
                    break;
                case 10: 
                    this.SkillBonuses.SetValues(0, SkillName.Macing, 20);
                    this.SkillBonuses.SetValues(1, SkillName.Tactics, 20);
                    break;
                case 11: 
                    this.SkillBonuses.SetValues(0, SkillName.Necromancy, 20);
                    this.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 20);
                    break;
                case 12: 
                    this.SkillBonuses.SetValues(0, SkillName.Stealth, 20);
                    this.SkillBonuses.SetValues(1, SkillName.Stealing, 20);
                    break;
                case 13: 
                    this.SkillBonuses.SetValues(0, SkillName.Peacemaking, 20);
                    this.SkillBonuses.SetValues(1, SkillName.Musicianship, 20);
                    break;

            }



		}

        public HerobloodyApron(Serial serial)
            : base(serial)
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
            Item y = from.Backpack.FindItemByType(typeof(HeroGlasses));
			if ( y !=null )
			{

                if (this.ItemID == 5435) this.ItemID = 10128;
                else if (this.ItemID == 10128) this.ItemID = 5435;

			}
			else
			{ 
                               	from.SendMessage( "You must have the item in your pack to take down the apron it." ); 
                        }
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
		
		public override bool OnEquip( Mobile from )
		{

			from.SendMessage( "Fear cuts deeper than swords." );
				
			BeginBleed( from );
	
			return base.OnEquip( from );
		}

		public override void OnRemoved( object parent )
		{
			if ( parent is Mobile )
			{
				Mobile from = ( Mobile ) parent;
				
				EndBleed ( from );

                from.SendMessage("A bruise is a lesson.");
			}

			base.OnRemoved( parent );
		}

		private static Hashtable m_Table = new Hashtable();

		public static bool IsBleeding( Mobile m )
		{
			return m_Table.Contains( m );
		}
		
		public static void BeginBleed( Mobile m  )
		{
			Timer t = (Timer)m_Table[m];

			if ( t != null )
				t.Stop();

			t = new InternalTimer( m );
			m_Table[m] = t;

			t.Start();
		}

		public static void DoBleed( Mobile m )
		{
			Blood blood = new Blood();
			blood.ItemID = Utility.Random( 0x122A, 5 );
			blood.MoveToWorld( m.Location, m.Map );
		}

		public static void EndBleed( Mobile m )
		{
			Timer t = (Timer)m_Table[m];

			if ( t == null )
				return;

			t.Stop();
			m_Table.Remove( m );
		}

		private class InternalTimer : Timer
		{
			private Mobile m_From;
			private int m_Count;

			public InternalTimer( Mobile from ) : base( TimeSpan.FromSeconds( 2.0 ), TimeSpan.FromSeconds( 2.0 ) )
			{
				m_From = from;
				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				DoBleed( m_From );
			}

		}
	}
}