//	Originally by Methril UODarwinism.com
//		Last Modified:
//
//	Version: 1.0
//
using System;

namespace Server.Items
{
    public class SlightlySingedEnigmaChest : LeatherChest
    {
		public override int ArtifactRarity{ get{ return 13; } } 
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		
		public override int ArmorBase { get { return 20; } }
		public override int BasePhysicalResistance { get { return 12; } }
        public override int BaseFireResistance { get { return 14; } }
        public override int BaseColdResistance { get { return 13; } }
        public override int BasePoisonResistance { get { return 13; } }
        public override int BaseEnergyResistance { get { return 13; } }
		
        public override int AosStrReq { get { return 0; } }
        public override int OldStrReq { get { return 0; } }

        [Constructable]
        public SlightlySingedEnigmaChest()
        {
			this.Name = "Slightly Singed Chest of Enigma";
			this.Hue = 2411;
			
			this.Attributes.CastRecovery = 1;
			this.Attributes.CastSpeed = 1;
			this.Attributes.Luck = 150;
			this.Attributes.DefendChance = 5;
            this.Attributes.BonusHits = 10;
			this.AbsorptionAttributes.EaterFire = 5;
			this.AbsorptionAttributes.EaterCold = 5;
			this.AbsorptionAttributes.EaterKinetic = 5;
			this.Attributes.LowerRegCost = 15;
			this.Attributes.EnhancePotions = 50;
			this.Attributes.SpellDamage = 15;
			
			SkillBonuses.SetValues(0, SkillName.Alchemy, 30.0);
			SkillBonuses.SetValues(1, SkillName.Bushido, 15.0);
			SkillBonuses.SetValues(2, SkillName.Magery, 15.0);
        }
		
		public override void GetProperties(ObjectPropertyList list)
            {
 
            base.GetProperties(list);
            
            list.Add("I don't think leather is gonna cut it");
            }

        public SlightlySingedEnigmaChest(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
	
	public class SingedEnigmaArms : LeatherArms
    {
		public override int ArtifactRarity{ get{ return 13; } } 
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		
		public override int ArmorBase { get { return 20; } }
		public override int BasePhysicalResistance { get { return 17; } }
        public override int BaseFireResistance { get { return 19; } }
        public override int BaseColdResistance { get { return 3; } }
        public override int BasePoisonResistance { get { return 18; } }
        public override int BaseEnergyResistance { get { return 18; } }
		
        public override int AosStrReq { get { return 0; } }
        public override int OldStrReq { get { return 0; } }

        [Constructable]
        public SingedEnigmaArms()
        {
			this.Name = "Singed Arms of Enigma";
			this.Hue = 2411;
			
			this.Attributes.CastRecovery = 1;
			this.Attributes.CastSpeed = 1;
			this.Attributes.Luck = 150;
			this.AbsorptionAttributes.EaterFire = 5;
			this.AbsorptionAttributes.EaterCold = 5;
			this.AbsorptionAttributes.EaterKinetic = 5;
			this.Attributes.DefendChance = 5;
            this.Attributes.BonusHits = 10;
			this.Attributes.LowerRegCost = 15;
			this.Attributes.EnhancePotions = 50;
			this.Attributes.SpellDamage = 10;
			
			SkillBonuses.SetValues(0, SkillName.Alchemy, 30.0);
			SkillBonuses.SetValues(1, SkillName.Bushido, 15.0);
			SkillBonuses.SetValues(2, SkillName.Magery, 15.0);
        }
		
		public override void GetProperties(ObjectPropertyList list)
            {
 
            base.GetProperties(list);
            
            list.Add("Found near an ashy corpse");
            }

        public SingedEnigmaArms(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
	
	public class UnblemishedEnigmaLegs : PlateLegs
    {
		public override int ArtifactRarity{ get{ return 13; } } 
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		
		public override int ArmorBase { get { return 20; } }
		public override int BasePhysicalResistance { get { return 20; } }
        public override int BaseFireResistance { get { return 18; } }
        public override int BaseColdResistance { get { return 17; } }
        public override int BasePoisonResistance { get { return 18; } }
        public override int BaseEnergyResistance { get { return 17; } }
		
        public override int AosStrReq { get { return 0; } }
        public override int OldStrReq { get { return 0; } }

        [Constructable]
        public UnblemishedEnigmaLegs()
        {
			this.Name = "Unblemished Plate Legs of Enigma";
			this.Hue = 2411;
			this.ArmorAttributes.MageArmor = 1;
			
			this.Attributes.CastRecovery = 1;
			this.Attributes.CastSpeed = 1;
			this.Attributes.Luck = 150;
			this.AbsorptionAttributes.EaterFire = 4;
			this.AbsorptionAttributes.EaterCold = 4;
			this.AbsorptionAttributes.EaterKinetic = 4;
			this.Attributes.DefendChance = 5;
            this.Attributes.BonusHits = 10;
			this.Attributes.LowerRegCost = 15;
			this.Attributes.EnhancePotions = 50;
			this.Attributes.SpellDamage = 10;
			
			SkillBonuses.SetValues(0, SkillName.Alchemy, 25.0);
			SkillBonuses.SetValues(1, SkillName.Magery, 15.0);
			SkillBonuses.SetValues(2, SkillName.Bushido, 15.0);
        }
		
		public override void GetProperties(ObjectPropertyList list)
            {
 
            base.GetProperties(list);
            
            list.Add("Plate to protect the jewels!");
            }

        public UnblemishedEnigmaLegs(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
	
	public class ThickSkullOfEnigma : BoneHelm
    {
		public override int ArtifactRarity{ get{ return 13; } } 
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		
		public override int ArmorBase { get { return 20; } }
		public override int BasePhysicalResistance { get { return 18; } }
        public override int BaseFireResistance { get { return 18; } }
        public override int BaseColdResistance { get { return 19; } }
        public override int BasePoisonResistance { get { return 16; } }
        public override int BaseEnergyResistance { get { return 20; } }
		
        public override int AosStrReq { get { return 0; } }
        public override int OldStrReq { get { return 0; } }

        [Constructable]
        public ThickSkullOfEnigma()
        {
			this.Name = "Enigma's Thick Skull";
			this.Hue = 2411;
			this.ArmorAttributes.MageArmor = 1;
			
			this.Attributes.CastRecovery = 1;
			this.Attributes.CastSpeed = 1;
			this.Attributes.Luck = 150;
			this.AbsorptionAttributes.EaterFire = 4;
			this.AbsorptionAttributes.EaterCold = 4;
			this.AbsorptionAttributes.EaterKinetic = 4;
			this.Attributes.DefendChance = 5;
            this.Attributes.BonusHits = 10;
			this.Attributes.LowerRegCost = 20;
			this.Attributes.EnhancePotions = 50;
			this.Attributes.SpellDamage = 10;
			
			SkillBonuses.SetValues(0, SkillName.Alchemy, 25.0);
			SkillBonuses.SetValues(1, SkillName.Magery, 15.0);
			SkillBonuses.SetValues(2, SkillName.Bushido, 15.0);			
        }
		
		public override void GetProperties(ObjectPropertyList list)
            {
 
            base.GetProperties(list);
            
            list.Add("Knew it was thick but damn!");
            }

        public ThickSkullOfEnigma(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
	
	public class CharredEnigmaGloves : DragonGloves
    {
		public override int ArtifactRarity{ get{ return 13; } } 
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		
		public override int ArmorBase { get { return 50; } }
		public override int BasePhysicalResistance { get { return 10; } }
        public override int BaseFireResistance { get { return 13; } }
        public override int BaseColdResistance { get { return 3; } }
        public override int BasePoisonResistance { get { return 10; } }
        public override int BaseEnergyResistance { get { return 13; } }
		
        public override int AosStrReq { get { return 0; } }
        public override int OldStrReq { get { return 0; } }

        [Constructable]
        public CharredEnigmaGloves()
        {
			this.Name = "Seriously Charred Gloves of Enigma";
			this.Hue = 2411;
			this.ArmorAttributes.MageArmor = 1;

			this.Attributes.CastRecovery = 1;
			this.Attributes.CastSpeed = 1;
			this.Attributes.Luck = 150;
			this.AbsorptionAttributes.EaterFire = 4;
			this.AbsorptionAttributes.EaterCold = 4;
			this.AbsorptionAttributes.EaterKinetic = 4;
			this.Attributes.DefendChance = 5;
            this.Attributes.BonusHits = 10;
			this.Attributes.LowerRegCost = 15;
			this.Attributes.EnhancePotions = 50;
			this.Attributes.SpellDamage = 10;
			
			SkillBonuses.SetValues(0, SkillName.Alchemy, 25.0);
			SkillBonuses.SetValues(1, SkillName.Magery, 15.0);
			SkillBonuses.SetValues(2, SkillName.Bushido, 15.0);

        }
		
		public override void GetProperties(ObjectPropertyList list)
            {
 
            base.GetProperties(list);
            
            list.Add("Burned Dragon Hide?");
            }

        public CharredEnigmaGloves(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
	
	public class SmokingShroudOfEnigma : Robe
    {
		public override int ArtifactRarity{ get{ return 13; } } 
		
		//public override int ArmorBase { get { return 20; } }
		public override int BasePhysicalResistance { get { return 7; } }
        public override int BaseFireResistance { get { return 7; } }
        public override int BaseColdResistance { get { return 7; } }
        public override int BasePoisonResistance { get { return 7; } }
        public override int BaseEnergyResistance { get { return 7; } }
		
        public override int AosStrReq { get { return 0; } }
        public override int OldStrReq { get { return 0; } }

		[Constructable]
        public SmokingShroudOfEnigma() : base(0x2683)
        {
			this.Name = "Enigma's Tattered, Smoking Shroud";
			this.Hue = 2411;
			this.ItemID = 0x2684;
			
            this.Attributes.Luck = 250;
			this.Attributes.CastSpeed = 1;
			this.Attributes.Luck = 150;
			this.Attributes.DefendChance = 10;
            this.Attributes.BonusHits = 10;
			this.Attributes.EnhancePotions = 50;
			this.Attributes.SpellDamage = 15;
			
			SkillBonuses.SetValues(0, SkillName.Alchemy, 25.0);
            SkillBonuses.SetValues(1, SkillName.Magery, 15.0);
            SkillBonuses.SetValues(2, SkillName.Bushido, 15.0);			
			
        }
		
		public override void GetProperties(ObjectPropertyList list)
            {
 
            base.GetProperties(list);
            
            list.Add("Found near an ashy corpse");
            }
			
        public SmokingShroudOfEnigma(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
    public class EnigmaEcruRing : GoldRing
    {
		public override int ArtifactRarity{ get{ return 13; } } 

        [Constructable]
        public EnigmaEcruRing()
        {
			this.Name = "Enigma's Ecru Ring";
			this.Hue = 2411;
			
			this.Attributes.CastRecovery = 1;
			this.Attributes.CastSpeed = 1;
			this.Attributes.Luck = 150;
			this.AbsorptionAttributes.EaterFire = 4;
			this.AbsorptionAttributes.EaterCold = 4;
			this.AbsorptionAttributes.EaterKinetic = 4;
			this.Attributes.EnhancePotions = 50;
			this.Attributes.SpellDamage = 15;
			
			SkillBonuses.SetValues(0, SkillName.Alchemy, 25.0);
			SkillBonuses.SetValues(1, SkillName.Magery, 15.0);
        }

        public EnigmaEcruRing(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
	}
    public class EnigmaEarrings : GoldEarrings
    {
		public override int ArtifactRarity{ get{ return 13; } } 

        [Constructable]
        public EnigmaEarrings()
        {
			this.Name = "Enigma's Earrings";
			this.Hue = 2411;
			
			this.Attributes.Luck = 100;
			this.Attributes.ReflectPhysical = 25;
			this.Attributes.EnhancePotions = 50;
			this.Attributes.BonusHits = 15;
			
			SkillBonuses.SetValues(0, SkillName.Alchemy, 25.0);
			SkillBonuses.SetValues(1, SkillName.Magery, 15.0);
			SkillBonuses.SetValues(2, SkillName.Bushido, 15.0);
        }

        public EnigmaEarrings(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
	}
    public class EnigmasCrook : ShepherdsCrook
    {
		public override int ArtifactRarity{ get{ return 13; } } 

        [Constructable]
        public EnigmasCrook()
        {
			this.Name = "Enigma's Broken Staff";
			this.Hue = 2411;
			
			this.Attributes.Luck = 100;
			this.WeaponAttributes.MageWeapon = 30;
			this.Attributes.SpellChanneling = 1;
			this.Attributes.BalancedWeapon = 1;
			this.AbsorptionAttributes.EaterFire = 4;
			this.AbsorptionAttributes.EaterCold = 4;
			this.AbsorptionAttributes.EaterKinetic = 4;
			this.Attributes.CastRecovery = 2;
			this.Attributes.CastSpeed = 2;
			this.Attributes.BonusHits = 10;
			this.Attributes.DefendChance = 15;
			this.Attributes.EnhancePotions = 50;
			this.Attributes.BonusHits = 15;
			
			SkillBonuses.SetValues(0, SkillName.Alchemy, 25.0);
			SkillBonuses.SetValues(1, SkillName.Bushido, 15.0);
			SkillBonuses.SetValues(2, SkillName.Parry, 15.0);
        }

        public EnigmasCrook(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
	}	
}