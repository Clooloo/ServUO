using System;
using Server;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
	public class CthulhuArmoRarms : Cthulhuarms
	{
		public override int ArtifactRarity{ get{ return 1000; } }

		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }
		public override bool CanBeWornByGargoyles{ get{ return true; } }

		[Constructable]
		public CthulhuArmoRarms()
		{
			Weight = 20.0; 
            		Name = " Ancient Warrior Arms  "; 
            		Hue = 1921;

			Attributes.CastRecovery = 2;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = Utility.RandomMinMax(5, 10);
			Attributes.BonusHits = Utility.RandomMinMax(3, 5);
			Attributes.SpellDamage = Utility.RandomMinMax(35, 50);
                        // NegativeAttributes.Antique = 1;
                      
                      this.Attributes.WeaponSpeed = 5;

			
			
			StrRequirement = 130;
            PhysicalBonus = Utility.RandomMinMax(8, 15);
            ColdBonus = Utility.RandomMinMax(8, 15);
            FireBonus = Utility.RandomMinMax(10, 15);
            PoisonBonus = Utility.RandomMinMax(10, 15);
            EnergyBonus = Utility.RandomMinMax(5, 15);

            Attributes.BonusStr = Utility.RandomMinMax(10, 15);
            Attributes.Luck = Utility.RandomMinMax(300, 500);
            Attributes.LowerManaCost = Utility.RandomMinMax(5, 10);
            Attributes.LowerRegCost = 25;

            switch( Utility.Random(7) )
            {
                case 0: 
                    this.SkillBonuses.SetValues(0, SkillName.EvalInt, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Magery, 10);
                    break;
                case 1: 
                    this.SkillBonuses.SetValues(0, SkillName.Necromancy, 10);
                    this.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 10);
                    break;
                case 2: 
                    this.SkillBonuses.SetValues(0, SkillName.Mysticism, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Focus, 10);
                    break;
                case 3: 
                    this.SkillBonuses.SetValues(0, SkillName.Spellweaving, 20);
                    break;
				case 4: 
                    this.SkillBonuses.SetValues(0, SkillName.Bushido, 30);
                    break;
				case 5: 
                    this.SkillBonuses.SetValues(0, SkillName.Tactics, 30);
                    break;
				case 6: 
                    this.SkillBonuses.SetValues(0, SkillName.Parry, 30);
                    break;	

                 }

		}

		public CthulhuArmoRarms( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize( GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

				public override bool OnEquip( Mobile from )
		{
			return Validate( from ) && base.OnEquip( from );
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( Validate( Parent as Mobile ) )
				base.OnSingleClick( from );
		}

		public bool Validate( Mobile m )
		{
			if ( m == null || !m.Player )
				return true;
			{
				m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
				m.PlaySound( 0x208 );
				m.SendMessage( "A bruise is a lesson. And each lesson makes us better." );

			}
			
			return true;
		}
	}
}

namespace Server.Items
{
    [FlipableAttribute(0x2B0A, 0x2B0B)]
    public class Cthulhuarms : BaseArmor
    {
		public override bool IsArtifact { get { return true; } }
        [Constructable]
        public Cthulhuarms()
            : base(0x2B0A)
        {

            this.Weight = 3.0;
            this.SetHue = 0;
            this.Hue = 0x226;
			
			
            this.SetPhysicalBonus = 5;
            this.SetFireBonus = 5;
            this.SetColdBonus = 5;
            this.SetPoisonBonus = 5;
            this.SetEnergyBonus = 5;
        }

        public Cthulhuarms(Serial serial)
            : base(serial)
        {
        }


        public override int BasePhysicalResistance
        {
            get
            {
                return 8;
            }
        }
        public override int BaseFireResistance
        {
            get
            {
                return 11;
            }
        }
        public override int BaseColdResistance
        {
            get
            {
                return 6;
            }
        }
        public override int BasePoisonResistance
        {
            get
            {
                return 8;
            }
        }
        public override int BaseEnergyResistance
        {
            get
            {
                return 7;
            }
        }
        public override int InitMinHits
        {
            get
            {
                return 255;
            }
        }
        public override int InitMaxHits
        {
            get
            {
                return 255;
            }
        }
        public override int AosStrReq
        {
            get
            {
                return 60;
            }
        }
        public override ArmorMaterialType MaterialType
        {
            get
            {
                return ArmorMaterialType.Plate;
            }
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
			
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
			
            int version = reader.ReadInt();
        }
    }
} 

namespace Server.Items
{
	public class CthulhuArmorpants : CthulhuLegs
	{
		public override int ArtifactRarity{ get{ return 1000; } }

		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }
	public override bool CanBeWornByGargoyles{ get{ return true; } }
		
		[Constructable]
		public CthulhuArmorpants()
		{
			Weight = 20.0; 
            		Name = " Ancient Warrior Legs  "; 
            		Hue = 1921;


			Attributes.CastRecovery = 2;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = Utility.RandomMinMax(5, 10);
			Attributes.BonusHits = Utility.RandomMinMax(3, 5);
			Attributes.SpellDamage = Utility.RandomMinMax(35, 50);
                        // NegativeAttributes.Antique = 1;
                      
                      this.Attributes.WeaponSpeed = 5;

			
			
			StrRequirement = 130;
            PhysicalBonus = Utility.RandomMinMax(8, 15);
            ColdBonus = Utility.RandomMinMax(8, 15);
            FireBonus = Utility.RandomMinMax(10, 15);
            PoisonBonus = Utility.RandomMinMax(10, 15);
            EnergyBonus = Utility.RandomMinMax(5, 15);

            Attributes.BonusStr = Utility.RandomMinMax(10, 15);
            Attributes.Luck = Utility.RandomMinMax(300, 500);
            Attributes.LowerManaCost = Utility.RandomMinMax(5, 10);
            Attributes.LowerRegCost = 25;

            switch( Utility.Random(7) )
            {
                case 0: 
                    this.SkillBonuses.SetValues(0, SkillName.EvalInt, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Magery, 10);
                    break;
                case 1: 
                    this.SkillBonuses.SetValues(0, SkillName.Necromancy, 10);
                    this.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 10);
                    break;
                case 2: 
                    this.SkillBonuses.SetValues(0, SkillName.Mysticism, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Focus, 10);
                    break;
                case 3: 
                    this.SkillBonuses.SetValues(0, SkillName.Spellweaving, 20);
                    break;
				case 4: 
                    this.SkillBonuses.SetValues(0, SkillName.Bushido, 30);
                    break;
				case 5: 
                    this.SkillBonuses.SetValues(0, SkillName.Tactics, 30);
                    break;
				case 6: 
                    this.SkillBonuses.SetValues(0, SkillName.Parry, 30);
                    break;	

                 }

		}

		public CthulhuArmorpants( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize( GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

				public override bool OnEquip( Mobile from )
		{
			return Validate( from ) && base.OnEquip( from );
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( Validate( Parent as Mobile ) )
				base.OnSingleClick( from );
		}

		public bool Validate( Mobile m )
		{
			if ( m == null || !m.Player )
				return true;
			{
				m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
				m.PlaySound( 0x208 );
				m.SendMessage( "A bruise is a lesson. And each lesson makes us better." );

			}
			
			return true;
		}
	}
}

namespace Server.Items
{
    [FlipableAttribute(0x2B06, 0x2B07)]
    public class CthulhuLegs : BaseArmor
    {
		public override bool IsArtifact { get { return true; } }
        [Constructable]
        public CthulhuLegs()
            : base(0x2B06)
        {

            this.Weight = 9.0;
            this.SetHue = 0;
            this.Hue = 0x226;
					
            this.SetPhysicalBonus = 5;
            this.SetFireBonus = 5;
            this.SetColdBonus = 5;
            this.SetPoisonBonus = 5;
            this.SetEnergyBonus = 5;
        }

        public CthulhuLegs(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance
        {
            get
            {
                return 8;
            }
        }
        public override int BaseFireResistance
        {
            get
            {
                return 7;
            }
        }
        public override int BaseColdResistance
        {
            get
            {
                return 10;
            }
        }
        public override int BasePoisonResistance
        {
            get
            {
                return 7;
            }
        }
        public override int BaseEnergyResistance
        {
            get
            {
                return 8;
            }
        }
        public override int InitMinHits
        {
            get
            {
                return 255;
            }
        }
        public override int InitMaxHits
        {
            get
            {
                return 255;
            }
        }
        public override int AosStrReq
        {
            get
            {
                return 70;
            }
        }
        public override ArmorMaterialType MaterialType
        {
            get
            {
                return ArmorMaterialType.Plate;
            }
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
			
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
			
            int version = reader.ReadInt();
        }
    }
} 

namespace Server.Items
{
	public class CthulhuArmoRchest : Cthulhuchest
	{
		public override int ArtifactRarity{ get{ return 1000; } }

		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }
		public override bool CanBeWornByGargoyles{ get{ return true; } }

		[Constructable]
		public CthulhuArmoRchest()
		{
			Weight = 20.0; 
            		Name = " Ancient Warrior Chest  "; 
            		Hue = 1921;

			Attributes.CastRecovery = 2;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = Utility.RandomMinMax(5, 10);
			Attributes.BonusHits = Utility.RandomMinMax(3, 5);
			Attributes.SpellDamage = Utility.RandomMinMax(35, 50);
                        // NegativeAttributes.Antique = 1;
                      
                      this.Attributes.WeaponSpeed = 5;

			
			
			StrRequirement = 130;
            PhysicalBonus = Utility.RandomMinMax(8, 15);
            ColdBonus = Utility.RandomMinMax(8, 15);
            FireBonus = Utility.RandomMinMax(10, 15);
            PoisonBonus = Utility.RandomMinMax(10, 15);
            EnergyBonus = Utility.RandomMinMax(5, 15);

            Attributes.BonusStr = Utility.RandomMinMax(10, 15);
            Attributes.Luck = Utility.RandomMinMax(300, 500);
            Attributes.LowerManaCost = Utility.RandomMinMax(5, 10);
            Attributes.LowerRegCost = 25;

            switch( Utility.Random(7) )
            {
                case 0: 
                    this.SkillBonuses.SetValues(0, SkillName.EvalInt, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Magery, 10);
                    break;
                case 1: 
                    this.SkillBonuses.SetValues(0, SkillName.Necromancy, 10);
                    this.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 10);
                    break;
                case 2: 
                    this.SkillBonuses.SetValues(0, SkillName.Mysticism, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Focus, 10);
                    break;
                case 3: 
                    this.SkillBonuses.SetValues(0, SkillName.Spellweaving, 20);
                    break;
				case 4: 
                    this.SkillBonuses.SetValues(0, SkillName.Bushido, 30);
                    break;
				case 5: 
                    this.SkillBonuses.SetValues(0, SkillName.Tactics, 30);
                    break;
				case 6: 
                    this.SkillBonuses.SetValues(0, SkillName.Parry, 30);
                    break;	

                 }

		}

		public CthulhuArmoRchest( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize( GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	
				public override bool OnEquip( Mobile from )
		{
			return Validate( from ) && base.OnEquip( from );
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( Validate( Parent as Mobile ) )
				base.OnSingleClick( from );
		}

		public bool Validate( Mobile m )
		{
			if ( m == null || !m.Player )
				return true;
			{
				m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
				m.PlaySound( 0x208 );
				m.SendMessage( "A bruise is a lesson. And each lesson makes us better." );

			}
			
			return true;
		}
	}
}

namespace Server.Items
{
	public class CthulhuFemaleArmoRchest : Cthulhuchest
	{
		public override int ArtifactRarity{ get{ return 1000; } }

		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }
		public override bool CanBeWornByGargoyles{ get{ return true; } }

		[Constructable]
		public CthulhuFemaleArmoRchest()
		{
			Weight = 20.0; 
            		Name = " Ancient Female Warrior Chest  "; 
					ItemID = 7174;
            		Hue = 1921;

			Attributes.CastRecovery = 2;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = Utility.RandomMinMax(5, 10);
			Attributes.BonusHits = Utility.RandomMinMax(3, 5);
			Attributes.SpellDamage = Utility.RandomMinMax(35, 50);
                        // NegativeAttributes.Antique = 1;
                      
                      this.Attributes.WeaponSpeed = 5;

			
			
			StrRequirement = 130;
            PhysicalBonus = Utility.RandomMinMax(8, 15);
            ColdBonus = Utility.RandomMinMax(8, 15);
            FireBonus = Utility.RandomMinMax(10, 15);
            PoisonBonus = Utility.RandomMinMax(10, 15);
            EnergyBonus = Utility.RandomMinMax(5, 15);

            Attributes.BonusStr = Utility.RandomMinMax(10, 15);
            Attributes.Luck = Utility.RandomMinMax(300, 500);
            Attributes.LowerManaCost = Utility.RandomMinMax(5, 10);
            Attributes.LowerRegCost = 25;

            switch( Utility.Random(7) )
            {
                case 0: 
                    this.SkillBonuses.SetValues(0, SkillName.EvalInt, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Magery, 10);
                    break;
                case 1: 
                    this.SkillBonuses.SetValues(0, SkillName.Necromancy, 10);
                    this.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 10);
                    break;
                case 2: 
                    this.SkillBonuses.SetValues(0, SkillName.Mysticism, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Focus, 10);
                    break;
                case 3: 
                    this.SkillBonuses.SetValues(0, SkillName.Spellweaving, 20);
                    break;
				case 4: 
                    this.SkillBonuses.SetValues(0, SkillName.Bushido, 30);
                    break;
				case 5: 
                    this.SkillBonuses.SetValues(0, SkillName.Tactics, 30);
                    break;
				case 6: 
                    this.SkillBonuses.SetValues(0, SkillName.Parry, 30);
                    break;	

                 }

		}

		public CthulhuFemaleArmoRchest( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize( GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	
				public override bool OnEquip( Mobile from )
		{
			return Validate( from ) && base.OnEquip( from );
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( Validate( Parent as Mobile ) )
				base.OnSingleClick( from );
		}

		public bool Validate( Mobile m )
		{
			if ( m == null || !m.Player )
				return true;
			{
				m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
				m.PlaySound( 0x208 );
				m.SendMessage( "A bruise is a lesson. And each lesson makes us better." );

			}
			
			return true;
		}
	}
}

namespace Server.Items
{
    [FlipableAttribute(0x2B08, 0x2B09)]
    public class Cthulhuchest : BaseArmor
    {
		public override bool IsArtifact { get { return true; } }
        [Constructable]
        public Cthulhuchest()
            : base(0x2B08)
        {

            this.Weight = 7.0;
            this.SetHue = 0;
            this.Hue = 0x226;
			
            this.SetPhysicalBonus = 5;
            this.SetFireBonus = 5;
            this.SetColdBonus = 5;
            this.SetPoisonBonus = 5;
            this.SetEnergyBonus = 5;
        }

        public Cthulhuchest(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance
        {
            get
            {
                return 10;
            }
        }
        public override int BaseFireResistance
        {
            get
            {
                return 7;
            }
        }
        public override int BaseColdResistance
        {
            get
            {
                return 8;
            }
        }
        public override int BasePoisonResistance
        {
            get
            {
                return 7;
            }
        }
        public override int BaseEnergyResistance
        {
            get
            {
                return 8;
            }
        }
        public override int InitMinHits
        {
            get
            {
                return 255;
            }
        }
        public override int InitMaxHits
        {
            get
            {
                return 255;
            }
        }
        public override int AosStrReq
        {
            get
            {
                return 65;
            }
        }
        public override ArmorMaterialType MaterialType
        {
            get
            {
                return ArmorMaterialType.Plate;
            }
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
			
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
			
            int version = reader.ReadInt();
        }
    }
} 

namespace Server.Items
{
	public class CthulhuArmorGlove : Cthulhugloves
	{
		public override int ArtifactRarity{ get{ return 1000; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		public override bool CanBeWornByGargoyles{ get{ return true; } }

		[Constructable]
		public CthulhuArmorGlove()
		{
			Weight = 20.0; 
            		Name = " Ancient Warrior Gauntlets  "; 
            		Hue = 1921;


			Attributes.CastRecovery = 2;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = Utility.RandomMinMax(5, 10);
			Attributes.BonusHits = Utility.RandomMinMax(3, 5);
			Attributes.SpellDamage = Utility.RandomMinMax(35, 50);
                        // NegativeAttributes.Antique = 1;
                      
                      this.Attributes.WeaponSpeed = 5;

			
			
			StrRequirement = 130;
            PhysicalBonus = Utility.RandomMinMax(8, 15);
            ColdBonus = Utility.RandomMinMax(8, 15);
            FireBonus = Utility.RandomMinMax(10, 15);
            PoisonBonus = Utility.RandomMinMax(10, 15);
            EnergyBonus = Utility.RandomMinMax(5, 15);

            Attributes.BonusStr = Utility.RandomMinMax(10, 15);
            Attributes.Luck = Utility.RandomMinMax(300, 500);
            Attributes.LowerManaCost = Utility.RandomMinMax(5, 10);
            Attributes.LowerRegCost = 25;

            switch( Utility.Random(7) )
            {
                case 0: 
                    this.SkillBonuses.SetValues(0, SkillName.EvalInt, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Magery, 10);
                    break;
                case 1: 
                    this.SkillBonuses.SetValues(0, SkillName.Necromancy, 10);
                    this.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 10);
                    break;
                case 2: 
                    this.SkillBonuses.SetValues(0, SkillName.Mysticism, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Focus, 10);
                    break;
                case 3: 
                    this.SkillBonuses.SetValues(0, SkillName.Spellweaving, 20);
                    break;

				case 4: 
                    this.SkillBonuses.SetValues(0, SkillName.Bushido, 30);
                    break;
				case 5: 
                    this.SkillBonuses.SetValues(0, SkillName.Tactics, 30);
                    break;
				case 6: 
                    this.SkillBonuses.SetValues(0, SkillName.Parry, 30);
                    break;	
				
                 }

		}

		public CthulhuArmorGlove( Serial serial ) : base( serial )
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

		public override bool OnEquip( Mobile from )
		{
			return Validate( from ) && base.OnEquip( from );
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( Validate( Parent as Mobile ) )
				base.OnSingleClick( from );
		}

		public bool Validate( Mobile m )
		{
			if ( m == null || !m.Player )
				return true;
			{
				m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
				m.PlaySound( 0x208 );
				m.SendMessage( "A bruise is a lesson. And each lesson makes us better." );

			}
			
			return true;
		}
	}
}

namespace Server.Items
{
    [FlipableAttribute(0x2B0C, 0x2B0D)]
    public class Cthulhugloves : BaseArmor
    {
		public override bool IsArtifact { get { return true; } }
        [Constructable]
        public Cthulhugloves()
            : base(0x2B0C)
        {

            this.Weight = 4.0;
            this.SetHue = 0;
            this.Hue = 0x226;
			
            this.SetPhysicalBonus = 5;
            this.SetFireBonus = 5;
            this.SetColdBonus = 5;
            this.SetPoisonBonus = 5;
            this.SetEnergyBonus = 5;
        }

        public Cthulhugloves(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance
        {
            get
            {
                return 6;
            }
        }
        public override int BaseFireResistance
        {
            get
            {
                return 6;
            }
        }
        public override int BaseColdResistance
        {
            get
            {
                return 8;
            }
        }
        public override int BasePoisonResistance
        {
            get
            {
                return 9;
            }
        }
        public override int BaseEnergyResistance
        {
            get
            {
                return 6;
            }
        }
        public override int InitMinHits
        {
            get
            {
                return 255;
            }
        }
        public override int InitMaxHits
        {
            get
            {
                return 255;
            }
        }
        public override int AosStrReq
        {
            get
            {
                return 50;
            }
        }
        public override ArmorMaterialType MaterialType
        {
            get
            {
                return ArmorMaterialType.Plate;
            }
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
			
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
			
            int version = reader.ReadInt();
        }
    }
}

namespace Server.Items
{

	public class CthulhuArmorDeed : Item
	{


		[Constructable]
		public CthulhuArmorDeed () : this( null )
		{
		}

		[Constructable]
		public CthulhuArmorDeed ( string name ) : base ( 0x14F0 )
		{
			Name = "Random WarMage Armor Deed ";
			Hue = 1921;
		}

		public CthulhuArmorDeed ( Serial serial ) : base ( serial )
		{
		}

      		public override void OnDoubleClick( Mobile from ) 
      		{
			if ( !IsChildOf( from.Backpack ) )
			{
                from.SendLocalizedMessage(1042001);
            }
            else
            {
/////////////////Prize CthulhuArmorDeed
                switch (Utility.Random(7))       
                {
                    case 0: from.AddToBackpack(new CthulhuArmoRarms()); break;      
                    case 1: from.AddToBackpack(new CthulhuArmoRchest()); break;
                    case 2: from.AddToBackpack(new CthulhuArmorGlove()); break;
                    case 3: from.AddToBackpack(new CthulhuArmorpants()); break;     
                    case 4: from.AddToBackpack(new CthulhuArmorCloak()); break;
                    case 5: from.AddToBackpack(new CthulhuArmorHelm()); break; 
					case 6: from.AddToBackpack(new CthulhuFemaleArmoRchest()); break;		

                }
                this.Delete();
			}

		}

		public override void Serialize ( GenericWriter writer)
		{
			base.Serialize ( writer );

			writer.Write ( (int) 0);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize ( reader );

			int version = reader.ReadInt();
		}
	}

}


namespace Server.Items
{
	public class CthulhuArmorCloak : Cthucloak
	{
		public override int ArtifactRarity{ get{ return 1000; } }

		public override int InitMinHits{ get{ return 100; } }
		public override int InitMaxHits{ get{ return 100; } }
		public override bool CanBeWornByGargoyles{ get{ return true; } }

		[Constructable]
		public CthulhuArmorCloak()
		{
			Weight = 20.0; 
            		Name = " Ancient Warrior Cloak  "; 
            		Hue = 1921;

			Attributes.CastRecovery = 2;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = Utility.RandomMinMax(5, 10);
			Attributes.BonusHits = Utility.RandomMinMax(3, 5);
			Attributes.SpellDamage = Utility.RandomMinMax(35, 50);
                        // NegativeAttributes.Antique = 1;
                      
                      this.Attributes.WeaponSpeed = 5;
			
			StrRequirement = 130;

            Attributes.BonusStr = Utility.RandomMinMax(10, 15);
            Attributes.Luck = Utility.RandomMinMax(300, 500);
            Attributes.LowerManaCost = Utility.RandomMinMax(5, 10);
            Attributes.LowerRegCost = 25;

            switch( Utility.Random(7) )
            {
                case 0: 
                    this.SkillBonuses.SetValues(0, SkillName.EvalInt, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Magery, 10);
                    break;
                case 1: 
                    this.SkillBonuses.SetValues(0, SkillName.Necromancy, 10);
                    this.SkillBonuses.SetValues(1, SkillName.SpiritSpeak, 10);
                    break;
                case 2: 
                    this.SkillBonuses.SetValues(0, SkillName.Mysticism, 10);
                    this.SkillBonuses.SetValues(1, SkillName.Focus, 10);
                    break;
                case 3: 
                    this.SkillBonuses.SetValues(0, SkillName.Spellweaving, 20);
                    break;
				case 4: 
                    this.SkillBonuses.SetValues(0, SkillName.Bushido, 30);
                    break;
				case 5: 
                    this.SkillBonuses.SetValues(0, SkillName.Tactics, 30);
                    break;
				case 6: 
                    this.SkillBonuses.SetValues(0, SkillName.Parry, 30);
                    break;	

                 }

		}

		public CthulhuArmorCloak( Serial serial ) : base( serial )
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

		public override bool OnEquip( Mobile from )
		{
			return Validate( from ) && base.OnEquip( from );
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( Validate( Parent as Mobile ) )
				base.OnSingleClick( from );
		}

		public bool Validate( Mobile m )
		{
			if ( m == null || !m.Player )
				return true;
			{
				m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
				m.PlaySound( 0x208 );
				m.SendMessage( "A bruise is a lesson. And each lesson makes us better." );

			}
			
			return true;
		}
	}
}

namespace Server.Items
{
    [FlipableAttribute(0x2B04, 0x2B05)]
    public class Cthucloak : BaseClothing
    {
		public override bool IsArtifact { get { return true; } }
        [Constructable]
        public Cthucloak()
            : base(0x2B04, Layer.Cloak)
        {
            this.Weight = 10.0;
            this.SetHue = 0;
            this.Hue = 0x226;
			
        }

        public Cthucloak(Serial serial)
            : base(serial)
        {
        }

        public override int InitMinHits
        {
            get
            {
                return 10;
            }
        }
        public override int InitMaxHits
        {
            get
            {
                return 10;
            }
        }
        public override int AosStrReq
        {
            get
            {
                return 10;
            }
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
			
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
			
            int version = reader.ReadInt();
        }
    }
}

namespace Server.Items
{
       [FlipableAttribute(0x236C, 0x236D)]
	public class CthulhuArmorHelm : BaseArmor
	{
		public override int ArtifactRarity{ get{ return 1000; } }
		public override bool CanBeWornByGargoyles{ get{ return true; } }

		[Constructable]
		public CthulhuArmorHelm()
                     : base(0x236C)
		{
			Weight = 20.0; 
            		Name = " Ancient Warrior Helm  "; 
            		Hue = 1921;


			Attributes.CastRecovery = 2;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = Utility.RandomMinMax(5, 10);
			Attributes.BonusHits = Utility.RandomMinMax(3, 5);
			Attributes.SpellDamage = Utility.RandomMinMax(35, 50);
                        // NegativeAttributes.Antique = 1;
                      
                      this.Attributes.WeaponSpeed = 5;

			
			
			StrRequirement = 130;
            PhysicalBonus = Utility.RandomMinMax(5, 15);
            ColdBonus = Utility.RandomMinMax(5, 15);
            FireBonus = Utility.RandomMinMax(5, 15);
            PoisonBonus = Utility.RandomMinMax(5, 15);
            EnergyBonus = Utility.RandomMinMax(5, 15);

            Attributes.BonusStr = Utility.RandomMinMax(10, 15);
            Attributes.Luck = Utility.RandomMinMax(300, 500);
            Attributes.LowerManaCost = Utility.RandomMinMax(5, 10);
            Attributes.LowerRegCost = 25;

            switch( Utility.Random(7) )
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
				case 4: 
                    this.SkillBonuses.SetValues(0, SkillName.Bushido, 30);
                    break;
				case 5: 
                    this.SkillBonuses.SetValues(0, SkillName.Tactics, 30);
                    break;
				case 6: 
                    this.SkillBonuses.SetValues(0, SkillName.Parry, 30);
                    break;	

                 }

		}

		public CthulhuArmorHelm( Serial serial ) : base( serial )
		{
		}

        public override int BasePhysicalResistance
        {
            get
            {
                return 5;
            }
        }
        public override int BaseFireResistance
        {
            get
            {
                return 5;
            }
        }
        public override int BaseColdResistance
        {
            get
            {
                return 5;
            }
        }
        public override int BasePoisonResistance
        {
            get
            {
                return 5;
            }
        }
        public override int BaseEnergyResistance
        {
            get
            {
                return 5;
            }
        }
        public override int InitMinHits
        {
            get
            {
                return 150;
            }
        }
        public override int InitMaxHits
        {
            get
            {
                return 150;
            }
        }
        public override ArmorMaterialType MaterialType
        {
            get
            {
                return ArmorMaterialType.Plate;
            }
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

		public override bool OnEquip( Mobile from )
		{
			return Validate( from ) && base.OnEquip( from );
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( Validate( Parent as Mobile ) )
				base.OnSingleClick( from );
		}

		public bool Validate( Mobile m )
		{
			if ( m == null || !m.Player )
				return true;
			{
				m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
				m.PlaySound( 0x208 );
				m.SendMessage( "A bruise is a lesson. And each lesson makes us better." );

			}
			
			return true;
		}
	}
}