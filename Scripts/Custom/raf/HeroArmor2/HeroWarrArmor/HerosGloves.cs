using System;
namespace Server.Items
{
    public class HerosGloves2 : BoneGloves
    {
		public override int ArtifactRarity{ get{ return 55; } } 
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		
		public override int ArmorBase { get { return 20; } }
		public override int BasePhysicalResistance { get { return 15; } }
        public override int BaseFireResistance { get { return 15; } }
        public override int BaseColdResistance { get { return 10; } }
        public override int BasePoisonResistance { get { return 15; } }
        public override int BaseEnergyResistance { get { return 15; } }
		
        public override int AosStrReq { get { return 0; } }
        public override int OldStrReq { get { return 0; } }
		
		public int BoundToSoul = 0;// Start binding value as zero.

        [Constructable]
        public HerosGloves2()
        {
			this.Name = "Hero Warrior's Bone Gloves";
			this.Hue = 1955;
			
			this.LootType = LootType.Blessed;
			this.ArmorAttributes.MageArmor = 1;
			this.Attributes.CastRecovery = 1;
			this.Attributes.Luck = 300;
			this.Attributes.LowerManaCost = 6;
			this.Attributes.DefendChance = 5;
			this.Attributes.AttackChance = 5;
            this.Attributes.BonusHits = 10;
            this.Attributes.BonusStr = 10;			
			this.AbsorptionAttributes.EaterCold = 30;
			this.AbsorptionAttributes.ResonanceCold = 20;
			this.Attributes.LowerRegCost = 15;
			this.Attributes.WeaponDamage = 15;
			

			SkillBonuses.SetValues(0, SkillName.Throwing, 30);
            SkillBonuses.SetValues(1, SkillName.Macing, 25);
			SkillBonuses.SetValues(2, SkillName.Fencing, 25);
			SkillBonuses.SetValues(3, SkillName.Swords, 25);
            SkillBonuses.SetValues(4, SkillName.Archery, 30);
        }

			public override bool OnDragLift( Mobile from ) 
		    { 
			    if(BoundToSoul == 0) //Check to see if bound to a serial.
			    { 
      			    BoundToSoul = from.Serial; //Bind to a serial on first time lifted.
                    this.Name = from.Name.ToString() + "'s Hero Warrior Gloves";//Change item name and add who it is bound to. "Player's Hero Warrior Gloves"
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
            if ( from.Skills[SkillName.Tactics].Base < 155.0 )
			{
				from.SendMessage( "You are not skilled enough to equip that." );
                return false;
			}
            else
            {
                return base.CanEquip( from );
            }
        }     
        public HerosGloves2(Serial serial)
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
