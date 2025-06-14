using System;
using Server;
using System.Collections;


namespace Server.Items
{
	public class Herospellbook : NecromancerSpellbook
	{
		[Constructable]
		public Herospellbook()
		{
                  Name = " Word of Death ";
			Hue = 1891;
			LootType = LootType.Blessed;
			Attributes.BonusInt = Utility.RandomMinMax(5, 10);
                        Attributes.BonusMana = Utility.RandomMinMax(5, 10);
                        Attributes.RegenMana = 10;
			Attributes.SpellDamage = Utility.RandomMinMax(10, 30);
			Attributes.CastSpeed = 2;
                        Attributes.CastRecovery = 3;
                        Attributes.Luck = Utility.RandomMinMax(200, 500);
                        // NegativeAttributes.Antique = 1;
			MaxHitPoints = 0;
			HitPoints = 0;


            switch( Utility.Random(7) )

           {
                case 0:   this.Slayer = SlayerName.ArachnidDoom;
                          break;
                case 1:   this.Slayer = SlayerName.Repond;
                          break;
                case 2:   this.Slayer = SlayerName.Exorcism;
                          break;
                case 3:   this.Slayer = SlayerName.ElementalBan;
                          break;
                case 4:   this.Slayer = SlayerName.Fey;
                          break;
                case 5:   this.Slayer = SlayerName.ReptilianDeath;
                          break;
                case 6:   this.Slayer = SlayerName.Silver;
                          break;
            }

  


            switch( Utility.Random(4) )
            {
                case 0: 
                    this.SkillBonuses.SetValues(0, SkillName.EvalInt, 20);
                    this.SkillBonuses.SetValues(1, SkillName.Magery, 20);
                    break;
                case 1: 
                    this.SkillBonuses.SetValues(0, SkillName.Necromancy, 20);
                    this.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 20);
                    break;
                case 2: 
                    this.SkillBonuses.SetValues(0, SkillName.Mysticism, 20);
                    this.SkillBonuses.SetValues(1, SkillName.Focus, 20);
                    break;
                case 3: 
                    this.SkillBonuses.SetValues(0, SkillName.Spellweaving, 30);
                    break;
             }

            switch (Utility.Random(4))
            {
                case 0: Attributes.BonusHits = 5; break; 
                case 1: Attributes.BonusHits = 10; break;
                case 2: Attributes.BonusHits = 15; break;
                case 3: Attributes.BonusHits = 20; break;
             }


		}

		public Herospellbook( Serial serial ) : base( serial )
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
	}
}