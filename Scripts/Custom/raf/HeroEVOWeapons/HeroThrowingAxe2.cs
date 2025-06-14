namespace Server.Items
{
	public class HeroAxeThrow2 : HHatchet
	{

      		public override int AosMinDamage{ get{ return 22; } } 
      		public override int AosMaxDamage{ get{ return 25; } } 
      		public override int AosSpeed{ get{ return 35; } } 

                public override int ArtifactRarity{ get{ return 55; } }   
        public int BoundToSoul = 0;// Start binding value as zero.
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public HeroAxeThrow2()
		{
			Name = " - Hero's Throwing Axe - ";
			Hue = 1152;
                        Weight = 10.0;
			
			DurabilityLevel = WeaponDurabilityLevel.Indestructible;
         		Quality = ItemQuality.Exceptional;
                LootType = LootType.Blessed;

                WeaponAttributes.HitLightning = 100;
                WeaponAttributes.HitFireball = 100;				
                WeaponAttributes.HitHarm = 100;
			  	WeaponAttributes.HitLeechMana = 80;
                WeaponAttributes.HitLeechStam = 50;
				WeaponAttributes.HitLeechHits = 100;
                AosElementDamages.Chaos = 100;
				Attributes.RegenMana = 10;
				Attributes.RegenHits = 10;
				Attributes.WeaponDamage = 100;
				Attributes.WeaponSpeed = 30;
				Attributes.SpellChanneling = 1;
				Attributes.BalancedWeapon = 1;
                WeaponAttributes.SelfRepair = 10;
			    SkillBonuses.SetValues(0, SkillName.Throwing, 15);				
				}

		public override bool OnDragLift( Mobile from ) 
		{ 
			if(BoundToSoul == 0) //Check to see if bound to a serial.
			{ 
      			BoundToSoul = from.Serial; //Bind to a serial on first time lifted.
                this.Name = "Hero " + from.Name.ToString() + "'s Throwing Axe";//Change item name and add who it is bound to. "Player's WeaponName"
      			from.Emote( "*" + from.Name + " somehow knows this weapon belongs to him alone*" ); 
				base.OnDragLift( from ); 
				return true;//Allow it to bind to the first player to lift it after creation.
							//Will show in [props as ParentEntity and RootParentEntitty as [m] Serial, "Player Name"
      		} 
           	else if(BoundToSoul == from.Serial) //Check to see if weapon is bound to who is lifting it.
      		{
				base.OnDragLift( from );
				return true; //Allow player who had bound to weapon to lift it.
      		} 
      		else 
      		{ 
      			from.SendMessage( "The weapon refuses your soul" ); 
				return false; //Disallow any one else from lifting the weapon.
			} 
		}
		
		public override void AddNameProperty(ObjectPropertyList list)
        {
			base.AddNameProperty( list );
			if(BoundToSoul == 0) //Check to see if bound to a serial.
			{ 
				list.Add( "<BASEFONT COLOR=#669966>"/*Green*/ + "[Un-Bound]" + "<BASEFONT COLOR=#FFFFFF>"/*Back to White*/ );
      		}
		}

        public override bool CanEquip( Mobile from )
        {
            if ( from.Skills[SkillName.Throwing].Base < 125.0 )
			{
				from.SendMessage( "You are not skilled enough to equip that." );
                return false;
			}
            else
            {
                return base.CanEquip( from );
            }
        }	
        public override int MinThrowRange
        {
            get
            {
                return 1;
            }
        }// MaxRange 11				
        public HeroAxeThrow2( Serial serial ) : base( serial )
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
