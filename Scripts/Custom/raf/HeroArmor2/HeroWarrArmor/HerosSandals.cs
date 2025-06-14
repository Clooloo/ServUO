using System;
namespace Server.Items
{
    public class HerosSandals2 : Sandals
    {
		public override int ArtifactRarity{ get{ return 55; } } 
		
		public int BoundToSoul = 0;// Start binding value as zero.

        [Constructable]
        public HerosSandals2()
        {
			this.Name = "Hero Warrior's Sandals";
			this.Hue = 1955;
			
			this.LootType = LootType.Blessed;
			this.Attributes.Luck = 300;
			this.Attributes.LowerManaCost = 5;
			this.Attributes.AttackChance = 5;
			this.Attributes.DefendChance = 5;
			this.Attributes.RegenMana = 5;
			
			SkillBonuses.SetValues(0, SkillName.Anatomy, 40.0);
			SkillBonuses.SetValues(1, SkillName.Tactics, 40.0);
			SkillBonuses.SetValues(2, SkillName.Bushido, 45.0);
			SkillBonuses.SetValues(3, SkillName.Parry, 35.0);
			SkillBonuses.SetValues(4, SkillName.Focus, 55.0);
        }

			public override bool OnDragLift( Mobile from ) 
		    { 
			    if(BoundToSoul == 0) //Check to see if bound to a serial.
			    { 
      			    BoundToSoul = from.Serial; //Bind to a serial on first time lifted.
                    this.Name = from.Name.ToString() + "'s Hero Warrior Sandals";//Change item name and add who it is bound to. "Player's Hero Warrior Sandals"
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
        public HerosSandals2(Serial serial)
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