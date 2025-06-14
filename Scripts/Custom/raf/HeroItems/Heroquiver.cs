using System;

namespace Server.Items
{
    public class Heroquiver : BaseQuiver
	{
		public override bool IsArtifact { get { return true; } }
        [Constructable]
        public Heroquiver()
            : base(0x2B02)
        {
            this.LootType = LootType.Blessed;
            this.Name = (" Hero's Legendary Quiver ");
            this.Weight = 8.0;
	    Hue = 2499;
            this.WeightReduction = 30;

            this.Attributes.DefendChance = 20;
            this.Attributes.AttackChance = 20;

           switch (Utility.Random(13))
            {
                case 0: this.LowerAmmoCost = 70; break; 
                case 1: this.LowerAmmoCost = 72; break; 
                case 2: this.LowerAmmoCost = 74; break; 
                case 3: this.LowerAmmoCost = 76; break; 
                case 4: this.LowerAmmoCost = 78; break; 
                case 5: this.LowerAmmoCost = 80; break; 
                case 6: this.LowerAmmoCost = 82; break; 
                case 7: this.LowerAmmoCost = 84; break;
                case 8: this.LowerAmmoCost = 88; break;
                case 9: this.LowerAmmoCost = 90; break;
                case 10: this.LowerAmmoCost = 94; break;
                case 11: this.LowerAmmoCost = 96; break;
                case 12: this.LowerAmmoCost = 100; break;
            }

            switch (Utility.Random(4))
            {
                case 0: Attributes.BonusStam = 5; break; 
                case 1: Attributes.BonusStam = 10; break;
                case 2: Attributes.BonusStam = 15; break;
                case 3: Attributes.BonusStam = 20; break;
            }

            switch (Utility.Random(4))
            {
                case 0: Attributes.BonusHits = 5; break; 
                case 1: Attributes.BonusHits = 10; break;
                case 2: Attributes.BonusHits = 15; break;
                case 3: Attributes.BonusHits = 20; break;
            }

            switch( Utility.Random(8) )
            {
                case 0: 
                    this.SkillBonuses.SetValues(0, SkillName.EvalInt, 15);
                    this.SkillBonuses.SetValues(1, SkillName.Magery, 15);
                    break;
                case 1: 
                    this.SkillBonuses.SetValues(0, SkillName.Necromancy, 10);
                    this.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 20);
                    break;
                case 2: 
                    this.SkillBonuses.SetValues(0, SkillName.Swords, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Tactics, 10);
                    break;
                case 3: 
                    this.SkillBonuses.SetValues(0, SkillName.Discordance, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Musicianship, 20);
                    break;
                case 4: 
                    this.SkillBonuses.SetValues(0, SkillName.Fencing, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Tactics, 10);
                    break;
                case 5: 
                    this.SkillBonuses.SetValues(0, SkillName.Anatomy, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Healing, 10);
                    break;
                case 6: 
                    this.SkillBonuses.SetValues(0, SkillName.Archery, 20);
                    this.SkillBonuses.SetValues(1, SkillName.Tactics, 20);
                    break;
                case 7: 
                    this.SkillBonuses.SetValues(0, SkillName.Macing, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Tactics, 10);
                    break;
            }
            
        }

        public Heroquiver(Serial serial)
            : base(serial)
        {
        }

		public override bool CanAlter
		{
			get
			{
				return false;
			}
		}

        public override int LabelNumber
        {
            get
            {
                return 1075201;
            }
        }// Quiver of Infinity
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(2); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();

            if (version < 1 && this.DamageIncrease == 0)
                this.DamageIncrease = 10;

            if (version < 2 && this.Attributes.WeaponDamage == 10)
                this.Attributes.WeaponDamage = 0;
        }
    }
}