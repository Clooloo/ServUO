using System;
using Server.Items;

namespace Server.Items
{
	public class HeroGorget : PlateGorget
	{
	
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		public override bool CanBeWornByGargoyles{ get{ return true; } }

		[Constructable]
		public HeroGorget() : base()
		{
          
		  this.Name = ("Hero Gorget");
            this.Weight = 20;

            this.SetHue = 1150;
            this.SetPhysicalBonus = 28;
            this.SetFireBonus = 28;
            this.SetColdBonus = 28;
            this.SetPoisonBonus = 28;
            this.SetEnergyBonus = 28;
			
			this.Attributes.RegenHits = 10;
            this.Attributes.DefendChance = 20;
            switch( Utility.Random(15) )
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
				case 14: 
                    this.SkillBonuses.SetValues(0, SkillName.AnimalTaming, 10);
                    this.SkillBonuses.SetValues(1, SkillName.AnimalLore, 10);
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

		public HeroGorget( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) 0 ); // version
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();
		}
	}
}