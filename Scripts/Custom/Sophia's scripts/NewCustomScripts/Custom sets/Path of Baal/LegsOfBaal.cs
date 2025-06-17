using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    //[FlipableAttribute(0x2B06, 0x2B07)]
    public class LegsOfBaal : PlateLegs
    {
        public override int BasePhysicalResistance { get { return 10; } }
        public override int BaseFireResistance { get { return 9; } }
        public override int BaseColdResistance { get { return 10; } }
        public override int BasePoisonResistance { get { return 9; } }
        public override int BaseEnergyResistance { get { return 10; } }

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        public override int AosStrReq { get { return 70; } }
        public override int OldStrReq { get { return 70; } }

        public override int OldDexBonus { get { return -4; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 7; } }

        

        [Constructable]
        public LegsOfBaal()
           
        {
            Name = "Legs of Baal";
             Attributes.WeaponSpeed = 10;
                Attributes.WeaponDamage = 5;
                Attributes.AttackChance = 5;
            Hue = 2176;
             Movable = false;
        }
        public override void GetProperties(ObjectPropertyList list)
            {
 
            base.GetProperties(list);
            
            list.Add("Demon skin [Apocalypse] [6 pieces based set]");
            }
 
        
   
        public LegsOfBaal(Serial serial)
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