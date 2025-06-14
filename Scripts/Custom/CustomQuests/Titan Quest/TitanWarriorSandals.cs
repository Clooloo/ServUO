using System;
using Server;

namespace Server.Items
{

        public class TitanWarriorSandals : Sandals
        {
                public override int InitMinHits { get { return 100; } }
                public override int InitMaxHits { get { return 100; } }
                public override int BasePhysicalResistance{ get{ return 7; } }
                public override int BaseFireResistance{ get{ return 7; } }
                public override int BaseColdResistance{ get{ return 7; } }
                public override int BasePoisonResistance{ get{ return 7; } }
                public override int BaseEnergyResistance{ get{ return 7; } }
                
                [Constructable]
                public TitanWarriorSandals()
                {
                        Name = "Titan Warrior Sandals";
                        Hue = Utility.RandomList( 1161, 1150, 1266 );
                        Attributes.BonusStr = 10;
                        Attributes.BonusDex = 10;
                        Attributes.BonusInt = 10;
                        this.Attributes.WeaponDamage = 20;
                        this.Attributes.SpellDamage = 30;                        

            switch( Utility.Random(15) )
            {
                case 0: 
                    this.SkillBonuses.SetValues(0, SkillName.EvalInt, 5);
                    this.SkillBonuses.SetValues(1, SkillName.Magery, 5);
                    break;
                case 1: 
                    this.SkillBonuses.SetValues(0, SkillName.AnimalLore, 5);
                    this.SkillBonuses.SetValues(1, SkillName.AnimalTaming, 5);
                    break;
                case 2: 
                    this.SkillBonuses.SetValues(0, SkillName.Swords, 5);
                    this.SkillBonuses.SetValues(1, SkillName.Tactics, 5);
                    break;
                case 3: 
                    this.SkillBonuses.SetValues(0, SkillName.Discordance, 5);
                    this.SkillBonuses.SetValues(1, SkillName.Musicianship, 5);
                    break;
                case 4: 
                    this.SkillBonuses.SetValues(0, SkillName.Fencing, 5);
                    this.SkillBonuses.SetValues(1, SkillName.Tactics, 5);
                    break;
                case 5: 
                    this.SkillBonuses.SetValues(0, SkillName.Chivalry, 5);
                    this.SkillBonuses.SetValues(1, SkillName.MagicResist, 5);
                    break;
                case 6: 
                    this.SkillBonuses.SetValues(0, SkillName.Anatomy, 5);
                    this.SkillBonuses.SetValues(1, SkillName.Healing, 5);
                    break;
                case 7: 
                    this.SkillBonuses.SetValues(0, SkillName.Ninjitsu, 5);
                    this.SkillBonuses.SetValues(1, SkillName.Stealth, 5);
                    break;
                case 8: 
                    this.SkillBonuses.SetValues(0, SkillName.Bushido, 5);
                    this.SkillBonuses.SetValues(1, SkillName.Parry, 5);
                    break;
                case 9: 
                    this.SkillBonuses.SetValues(0, SkillName.Archery, 5);
                    this.SkillBonuses.SetValues(1, SkillName.Tactics, 5);
                    break;
                case 10: 
                    this.SkillBonuses.SetValues(0, SkillName.Macing, 5);
                    this.SkillBonuses.SetValues(1, SkillName.Tactics, 5);
                    break;
                case 11: 
                    this.SkillBonuses.SetValues(0, SkillName.Necromancy, 5);
                    this.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 5);
                    break;
                case 12: 
                    this.SkillBonuses.SetValues(0, SkillName.Stealth, 5);
                    this.SkillBonuses.SetValues(1, SkillName.Stealing, 5);
                    break;
                case 13: 
                    this.SkillBonuses.SetValues(0, SkillName.Peacemaking, 5);
                    this.SkillBonuses.SetValues(1, SkillName.Musicianship, 5);
                    break;
                case 14:
                    this.SkillBonuses.SetValues(0, SkillName.Provocation, 5);
                    this.SkillBonuses.SetValues(1, SkillName.Musicianship, 5);
                    break;
            }
                }



                public TitanWarriorSandals( Serial Serial ) : base ( Serial )
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
                        