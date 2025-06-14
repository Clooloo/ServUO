using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
	
	public class HeroGlasses : ElvenGlasses
	{
        public override int InitMinHits { get { return 200; } }
        public override int InitMaxHits { get { return 200; } }
        public override int BasePhysicalResistance{ get{ return 20; } }
		public override int BaseFireResistance{ get{ return 20; } }
		public override int BaseColdResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 10; } }
		public override bool CanBeWornByGargoyles{ get{ return true; } }

		[Constructable]
		public HeroGlasses()
		{
            ItemID = 12216;
	    Weight = 40.0;
            Name = "Hero's Glasses";
            Hue = 1152;
            
                       this.Attributes.WeaponDamage = 20;
                       this.Attributes.WeaponSpeed = 20;
                       this.WeaponAttributes.HitLowerDefend = 20;
	               this.WeaponAttributes.HitLowerAttack = 20;
                       this.Attributes.BonusStr = 15;
                       this.Attributes.BonusDex = 10;
			Attributes.RegenMana = 5;
			Attributes.SpellDamage = 20;
			Attributes.LowerManaCost = 10;
			Attributes.LowerRegCost = 20;
			MaxHitPoints = 100;
			HitPoints = 100;
                      StrRequirement = 100;


            switch( Utility.Random(14) )
            {
                case 0: 
                    this.SkillBonuses.SetValues(0, SkillName.EvalInt, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Magery, 10);
                    break;
                case 1:
                    this.SkillBonuses.SetValues(0, SkillName.Provocation, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Musicianship, 10);
                    break;
                case 2: 
                    this.SkillBonuses.SetValues(0, SkillName.Swords, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Tactics, 10);
                    break;
                case 3: 
                    this.SkillBonuses.SetValues(0, SkillName.Discordance, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Musicianship, 10);
                    break;
                case 4: 
                    this.SkillBonuses.SetValues(0, SkillName.Fencing, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Tactics, 10);
                    break;
                case 5: 
                    this.SkillBonuses.SetValues(0, SkillName.Chivalry, 10);
                    this.SkillBonuses.SetValues(1, SkillName.MagicResist, 10);
                    break;
                case 6: 
                    this.SkillBonuses.SetValues(0, SkillName.Anatomy, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Healing, 10);
                    break;
                case 7: 
                    this.SkillBonuses.SetValues(0, SkillName.Ninjitsu, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Stealth, 10);
                    break;
                case 8: 
                    this.SkillBonuses.SetValues(0, SkillName.Bushido, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Parry, 10);
                    break;
                case 9: 
                    this.SkillBonuses.SetValues(0, SkillName.Archery, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Tactics, 10);
                    break;
                case 10: 
                    this.SkillBonuses.SetValues(0, SkillName.Macing, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Tactics, 10);
                    break;
                case 11: 
                    this.SkillBonuses.SetValues(0, SkillName.Necromancy, 10);
                    this.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 10);
                    break;
                case 12: 
                    this.SkillBonuses.SetValues(0, SkillName.Stealth, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Stealing, 10);
                    break;
                case 13: 
                    this.SkillBonuses.SetValues(0, SkillName.Peacemaking, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Musicianship, 10);
                    break;
            }

            switch (Utility.Random(4))
            {
                case 0: Attributes.BonusHits = 5; break; 
                case 1: Attributes.BonusHits = 10; break;
                case 2: Attributes.BonusHits = 15; break;
                case 3: Attributes.BonusHits = 20; break;
            }            

            switch (Utility.Random(4))
            {
                case 0: Attributes.BonusStam = 5; break; 
                case 1: Attributes.BonusStam = 10; break;
                case 2: Attributes.BonusStam = 15; break;
                case 3: Attributes.BonusStam = 20; break;

		}
            }
       
        public HeroGlasses(Serial serial): base(serial)
		{
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
		public override void OnDoubleClick( Mobile from )
		{
            Item y = from.Backpack.FindItemByType(typeof(HeroGlasses));
			if ( y !=null )
			{

                if (this.ItemID == 12216) this.ItemID = 5445;
                else if (this.ItemID == 5445) this.ItemID = 12216;

			}
			else
			{ 
                               	from.SendMessage( "You must have the item in your pack to take down the Glasses it." ); 
                        }
		}
	}
}
