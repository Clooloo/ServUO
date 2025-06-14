//Customized By Mrs Death
using System;
using Server;

namespace Server.Items
{
    public class BarretBow : Bow
    {
        public override int ArtifactRarity { get { return 23; } }
	public override int AosMinDamage{ get{ return 30; } }
	public override int OldMinDamage{ get{ return 30; } }
	public override int AosMaxDamage{ get{ return 30; } }
	public override int OldMaxDamage{ get{ return 30; } }
        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        [Constructable]
        public BarretBow()
        {
            Weight = 5.0;
            Name = "[FF7] Barret's Missing Score";
            Speed = Utility.Random( 36, 50 );


            Hue = 1164;
            Slayer = SlayerName.ElementalBan;
            Attributes.BonusStr = Utility.Random( 1, 20 );
            Attributes.BonusInt = Utility.Random( 1, 20 );
            Attributes.BonusDex = Utility.Random( 1, 20 );
            Attributes.BonusHits = Utility.Random( 1, 15 );
            Attributes.BonusStam = Utility.Random( 1, 20 );
            Attributes.BonusMana = Utility.Random( 1, 20 );
            WeaponAttributes.HitLeechHits = Utility.Random( 1, 75 );
            WeaponAttributes.HitLeechStam = Utility.Random( 1, 75 );
            WeaponAttributes.HitLeechMana = Utility.Random( 1, 75 );
            Attributes.AttackChance = Utility.Random( 1, 35 );
            Attributes.DefendChance = Utility.Random( 1, 35 );
            Attributes.WeaponDamage = Utility.Random( 1, 75 );
            Attributes.WeaponSpeed = Utility.Random( 1, 75 );
            Attributes.ReflectPhysical = Utility.Random( 1, 35 );
            Attributes.SpellDamage = Utility.Random( 1, 75 );
            WeaponAttributes.ResistPhysicalBonus = 20;
            WeaponAttributes.ResistColdBonus = 20;
            WeaponAttributes.ResistFireBonus = 20;
            WeaponAttributes.ResistEnergyBonus = 20;
            WeaponAttributes.ResistPoisonBonus = 20;
            WeaponAttributes.HitLowerAttack = Utility.Random( 1, 75 );
            WeaponAttributes.HitLowerDefend = Utility.Random( 1, 75 );
            WeaponAttributes.HitHarm = Utility.Random( 1, 75 );
            WeaponAttributes.HitFireball = Utility.Random( 1, 75 );
            WeaponAttributes.HitLightning = Utility.Random( 1, 75 );
            WeaponAttributes.HitDispel = Utility.Random( 1, 75 );
        }

        public BarretBow(Serial serial) : base(serial)
            
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