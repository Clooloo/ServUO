using System;
namespace Server.Items
{
    public class HerosAlchemyQuiver : BaseQuiver
    {
		public override int ArtifactRarity{ get{ return 55; } } 
		
		public int BoundToSoul = 0;// Start binding value as zero.

        [Constructable]
        public HerosAlchemyQuiver()
        {
			this.Name = "Hero Chemist's Quiver";
			this.Hue = 1954;

			this.LootType = LootType.Blessed;
			this.Attributes.Luck = 300;
            this.Attributes.BonusHits = 15;
            this.Attributes.BonusStr = 15;	
		    this.Attributes.BonusInt = 15;
			this.Attributes.LowerManaCost = 8;
            this.Attributes.BonusDex = 15;			
			this.Attributes.LowerAmmoCost = 100;
			this.Attributes.EnhancePotions = 50;
			this.WeightReduction = 50;
			
			SkillBonuses.SetValues(0, SkillName.Alchemy, 30.0);
			SkillBonuses.SetValues(1, SkillName.Bushido, 20.0);
			SkillBonuses.SetValues(3, SkillName.Mysticism, 25.0);
			SkillBonuses.SetValues(4, SkillName.Focus, 25.0);			
			
        }
		
			public override bool OnDragLift( Mobile from ) 
		    { 
			    if(BoundToSoul == 0) //Check to see if bound to a serial.
			    { 
      			    BoundToSoul = from.Serial; //Bind to a serial on first time lifted.
                    this.Name = from.Name.ToString() + "'s Elite Chemist Quiver";//Change item name and add who it is bound to. "Player's Elite Warrior Quiver"
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
            if ( from.Skills[SkillName.Alchemy].Base < 135.0 )
			{
				from.SendMessage( "You are not skilled enough to equip that." );
                return false;
			}
            else
            {
                return base.CanEquip( from );
            }
        }     
        public HerosAlchemyQuiver(Serial serial)
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
