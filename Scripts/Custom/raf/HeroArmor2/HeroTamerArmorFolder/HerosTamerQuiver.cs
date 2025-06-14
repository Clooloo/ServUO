using System;
namespace Server.Items
{
    public class HerosTamerQuiver2 : BaseQuiver
    {
		public override int ArtifactRarity{ get{ return 55; } } 
		
		public int BoundToSoul = 0;// Start binding value as zero.

        [Constructable]
        public HerosTamerQuiver2()
        {
			this.Name = "Hero Tamer's Quiver";
			this.Hue = 2411;

			this.LootType = LootType.Blessed;
			this.Attributes.Luck = 300;
			this.Attributes.LowerManaCost = 5;
            this.Attributes.BonusHits = 15;
            this.Attributes.BonusStr = 15;	
		    this.Attributes.BonusInt = 15;
            this.Attributes.BonusDex = 15;			
			this.Attributes.LowerAmmoCost = 100;
			this.WeightReduction = 50;
			

			SkillBonuses.SetValues(0, SkillName.Discordance, 25);
            SkillBonuses.SetValues(1, SkillName.Musicianship, 25);
			SkillBonuses.SetValues(2, SkillName.Focus, 30);
			SkillBonuses.SetValues(3, SkillName.AnimalTaming, 20);
            SkillBonuses.SetValues(4, SkillName.AnimalLore, 20);
			
        }
		
			public override bool OnDragLift( Mobile from ) 
		    { 
			    if(BoundToSoul == 0) //Check to see if bound to a serial.
			    { 
      			    BoundToSoul = from.Serial; //Bind to a serial on first time lifted.
                    this.Name = from.Name.ToString() + "'s Elite Tamer Quiver";//Change item name and add who it is bound to. "Player's Elite Warrior Quiver"
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
        public HerosTamerQuiver2(Serial serial)
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