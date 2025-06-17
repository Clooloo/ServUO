using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    //[FlipableAttribute(0x2B08, 0x2B09)]
    public class BreastplateOfBaal : PlateChest
    {
  
        public override int BasePhysicalResistance { get { return 10; } }

        public override int BaseFireResistance { get { return 9; } }
        public override int BaseColdResistance { get { return 10; } }
        public override int BasePoisonResistance { get { return 10; } }
        public override int BaseEnergyResistance { get { return 10; } }

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        public override int AosStrReq { get { return 65; } }
        public override int OldStrReq { get { return 65; } }

        public override int OldDexBonus { get { return -6; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 11; } }

      

        [Constructable]
        public BreastplateOfBaal()
            
        {
            Name = "Breastplate of Baal";
             Attributes.WeaponSpeed = 10;
                Attributes.WeaponDamage = 5;
                Attributes.AttackChance = 5;
            Weight = 6.0;
            Hue = 2176;
             Movable = false;

        }
        public override void GetProperties(ObjectPropertyList list)
            {
 
            base.GetProperties(list);
            
            list.Add("Demon skin [Apocalypse] [6 pieces based set]");
            }
 
        
  
        public BreastplateOfBaal(Serial serial)
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