namespace Server.Items
{
    public class GargishNewbieArms : BaseArmor
    {
        [Constructable]
        public GargishNewbieArms()
            : this(0)
        {
        }

        [Constructable]
        public GargishNewbieArms(int hue)
            : base(0x302)
        {
            Layer = Layer.Arms;
            Weight = 2.0;
            Hue = hue;
            LootType = LootType.Blessed;
	    Attributes.LowerRegCost = 20;
	    WeaponAttributes.SelfRepair = 5;
	    ArmorAttributes.LowerStatReq = 100;
	    PhysicalBonus = 3;
	    FireBonus = 1;
	    ColdBonus = 2;
	    PoisonBonus = 2;
	    EnergyBonus = 2;
		}

        public GargishNewbieArms(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 5;
        public override int BaseFireResistance => 6;
        public override int BaseColdResistance => 7;
        public override int BasePoisonResistance => 6;
        public override int BaseEnergyResistance => 6;

        public override int InitMinHits => 30;
        public override int InitMaxHits => 50;

        public override int StrReq => 25;

        public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
        public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
        public override CraftResource DefaultResource => CraftResource.RegularLeather;

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
