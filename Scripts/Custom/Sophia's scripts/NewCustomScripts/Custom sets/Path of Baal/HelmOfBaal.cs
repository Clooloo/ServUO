using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
    //[FlipableAttribute(0x2B10, 0x2B11)]
    public class HelmOfBaal : PlateHelm
    {
        public override int BasePhysicalResistance { get { return 10; } }
        public override int BaseFireResistance { get { return 10; } }
        public override int BaseColdResistance { get { return 9; } }
        public override int BasePoisonResistance { get { return 11; } }
        public override int BaseEnergyResistance { get { return 10; } }

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        public override int AosStrReq { get { return 25; } }
        public override int OldStrReq { get { return 25; } }

        public override int ArmorBase { get { return 30; } }

        

        [Constructable]
        public HelmOfBaal()
            
        {
            Name = "Helm of Baal";
            Attributes.WeaponSpeed = 10;
                Attributes.WeaponDamage = 5;
                Attributes.AttackChance = 5;
            Weight = 3.0;
            Hue = 2176;
            Movable = false;

        }
        //////////////
        /////////////
        
        /////////////
        /////////////
        public override void GetProperties(ObjectPropertyList list)
            {
 
            base.GetProperties(list);
            
            list.Add("Demon skin [Apocalypse] [6 pieces based set]");
            }
 
       
        public HelmOfBaal(Serial serial)
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