using System;

namespace Server.Items
{
    public class HerosAlchemyCrook2 : ShepherdsCrook
    {
		public override int ArtifactRarity{ get{ return 55; } } 
		public override int AosMinDamage{ get{ return 22; } }
		public override int AosMaxDamage{ get{ return 25; } }        
		
		public int BoundToSoul = 0;// Start binding value as zero.

        [Constructable]
        public HerosAlchemyCrook2()
        {
			this.Name = "Hero's Chemist Crook";
			this.Hue = 2411;
			
			this.Attributes.Luck = 100;
			this.WeaponAttributes.MageWeapon = 35;
			this.Attributes.SpellChanneling = 1;
			this.Attributes.BalancedWeapon = 1;
			this.Attributes.CastRecovery = 2;
			this.Attributes.CastSpeed = 2;
			this.Attributes.EnhancePotions = 75;
			
			SkillBonuses.SetValues(0, SkillName.Alchemy, 25.0);
			SkillBonuses.SetValues(1, SkillName.Bushido, 15.0);
			SkillBonuses.SetValues(3, SkillName.Mysticism, 25.0);
			SkillBonuses.SetValues(4, SkillName.Focus, 25.0);			
        }
		
			public override bool OnDragLift( Mobile from ) 
		    { 
			    if(BoundToSoul == 0) //Check to see if bound to a serial.
			    { 
      			    BoundToSoul = from.Serial; //Bind to a serial on first time lifted.
                    this.Name = from.Name.ToString() + "'s Hero Chemist Crook";//Change item name and add who it is bound to. "Player's Hero Magi Chest"
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
        public override bool OnDroppedOnto(Mobile from, Item target)
        {
            from.SendLocalizedMessage(1076254); // That item cannot be dropped.
            return false;
        }
        public HerosAlchemyCrook2(Serial serial)
            : base(serial)
        {
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // ver
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
