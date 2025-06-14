using System;

namespace Server.Items
{
    [FlipableAttribute( 0x1450, 0x1455 )]
	public class ArchaicInquisResolution :  BaseArmor 
	{
		public int BoundToSoul = 0;// Start binding value as zero.
		public override bool IsArtifact { get { return true; } }
        [Constructable]
        public ArchaicInquisResolution(): base(0x1450)
        {
            Hue = 0x4F2;
			Name = "Archaic Resolutions";
			ItemID = 0x2B0C;			
            Attributes.CastRecovery = 3;
			Attributes.CastSpeed = 2;
            Attributes.LowerManaCost = 12;
			Attributes.BonusHits = 15;
			Attributes.BonusInt = 15;
			AbsorptionAttributes.EaterCold = 30;
			AbsorptionAttributes.CastingFocus = 6;
			AbsorptionAttributes.ResonanceCold = 20;
			
            switch( Utility.Random(2) )
            {
                case 0: 
                    this.SkillBonuses.SetValues(0, SkillName.EvalInt, 25);
                    this.SkillBonuses.SetValues(1, SkillName.Magery, 20);
					this.Attributes.SpellDamage = 75;
                    this.ArmorAttributes.MageArmor = 1;					
                    break;
                case 1: 
                    this.SkillBonuses.SetValues(0, SkillName.Anatomy, 35);
                    this.SkillBonuses.SetValues(1, SkillName.Tactics, 20);
					this.Attributes.WeaponDamage = 75;
					this.Attributes.RegenMana = 4;
                    break;
            }			
        }

			public override bool OnDragLift( Mobile from ) 
		    { 
			    if(BoundToSoul == 0) //Check to see if bound to a serial.
			    { 
      			    BoundToSoul = from.Serial; //Bind to a serial on first time lifted.
                    this.Name = from.Name.ToString() + "'s Archaic Resolutions";//Change item name and add who it is bound to. "Player's Archaic Resolutions"
      			    from.Emote( "*" + from.Name + " knows these can never be traded*" ); 
				    base.OnDragLift( from ); 
				    return true;//Allow it to bind to the first player to lift it after creation.
							//Will show in [props as ParentEntity and RootParentEntitty as [m] Serial, "Player Name"
      		    } 
           	    else if(BoundToSoul == from.Serial) //Check to see if gloves are bound to who is lifting it.
      		    {
				    base.OnDragLift( from );
				    return true; //Allow player who had bound to gloves to lift.
      		    } 
      		    else 
      		    { 
      			    from.SendMessage( "The armor refuses your soul" ); 
				    return false; //Disallow any one else from lifting the gloves.
			    } 
		    }        
		public ArchaicInquisResolution(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber
        {
            get
            {
                return 1060206;
            }
        }// The Inquisitor's Resolution
        public override int ArtifactRarity
        {
            get
            {
                return 420;
            }
        }
        public override int BasePhysicalResistance
        {
            get
            {
                return 18;
            }
        }		
        public override int BaseColdResistance
        {
            get
            {
                return 22;
            }
        }
        public override int BaseFireResistance
        {
            get
            {
                return 25;
            }
        }		
        public override int BaseEnergyResistance
        {
            get
            {
                return 17;
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
            public override ArmorMaterialType MaterialType
            {
                get
                {
                return ArmorMaterialType.Bone;
                }
            }          
		public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (version < 1)
            {
                this.ColdBonus = 0;
                this.EnergyBonus = 0;
            }
        }
    }
}