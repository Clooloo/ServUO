using System;
namespace Server.Items
{
    public class HerosTamerHelm2 : BoneHelm
    {
		public override int ArtifactRarity{ get{ return 55; } } 
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
        public override SetItem SetID{ get{ return SetItem.Virtuoso; } }
		public override int Pieces{ get{ return 5; } }
        public override bool BardMasteryBonus { get { return true; } }		
		
		public override int ArmorBase { get { return 20; } }
		public override int BasePhysicalResistance { get { return 22; } }
        public override int BaseFireResistance { get { return 22; } }
        public override int BaseColdResistance { get { return 15; } }
        public override int BasePoisonResistance { get { return 15; } }
        public override int BaseEnergyResistance { get { return 15; } }
		
        public override int AosStrReq { get { return 0; } }
        public override int OldStrReq { get { return 0; } }
		
		public int BoundToSoul = 0;// Start binding value as zero.

        [Constructable]
        public HerosTamerHelm2()
        {
			this.Name = "Hero Tamer's Bone Mask";
			this.Hue = 1954;
			
			this.LootType = LootType.Blessed;
			this.ArmorAttributes.MageArmor = 1;
			this.Attributes.CastRecovery = 3;
			this.Attributes.CastSpeed = 3;
			this.Attributes.Luck = 300;
            this.Attributes.WeaponDamage = 25;
            this.Attributes.SpellDamage = 10;
			this.Attributes.LowerManaCost = 8;
			this.Attributes.RegenMana = 4;
            this.Attributes.BonusHits = 15;
            this.Attributes.BonusStr = 15;	
		    this.Attributes.BonusInt = 15;
            this.Attributes.BonusDex = 15;			
            this.AbsorptionAttributes.EaterEnergy = 30;
			this.AbsorptionAttributes.CastingFocus = 4;
			this.Attributes.LowerRegCost = 15;
			
			SkillBonuses.SetValues(0, SkillName.Focus, 30);
			SkillBonuses.SetValues(1, SkillName.Musicianship, 20);
            SkillBonuses.SetValues(2, SkillName.Discordance, 20);         
        }

			public override bool OnDragLift( Mobile from ) 
		    { 
			    if(BoundToSoul == 0) //Check to see if bound to a serial.
			    { 
      			    BoundToSoul = from.Serial; //Bind to a serial on first time lifted.
                    this.Name = from.Name.ToString() + "'s Hero Beast Master Mask";//Change item name and add who it is bound to. "Player's Hero Warrior Mask"
      			    from.Emote( "*" + from.Name + " knows this can never be traded*" ); 
				    base.OnDragLift( from ); 
				    return true;//Allow it to bind to the first player to lift it after creation.
							//Will show in [props as ParentEntity and RootParentEntitty as [m] Serial, "Player Name"
      		    } 
           	    else if(BoundToSoul == from.Serial) //Check to see if armor is bound to who is lifting it.
      		    {
				    base.OnDragLift( from );
				    return true; //Allow player who had bound to armor to lift it.
      		    } 
      		    else 
      		    { 
      			    from.SendMessage( "The armor refuses your soul" ); 
				    return false; //Disallow any one else from lifting the armor.
			    } 
		    }	
        public override bool CanEquip( Mobile from )
        {
            if ( from.Skills[SkillName.AnimalTaming].Base < 135.0 )
			{
				from.SendMessage( "You are not skilled enough to equip that." );
                return false;
			}
            else
            {
                return base.CanEquip( from );
            }
        }     
        public HerosTamerHelm2(Serial serial)
            : base(serial)
        {
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
         	writer.Write( (int) BoundToSoul );//Serialize who it is bound to.
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
         	BoundToSoul = reader.ReadInt();//Read on startup who it is bound to.
		}
	}
}