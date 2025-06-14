//Customized By Mrs Death
using System;
using Server;

namespace Server.Items
{
    [FlipableAttribute( 0x1452, 0x1457 )]
	public class SephirothSkirt : BaseArmor
	{
		public int BoundToSoul = 0;// Start binding value as zero.
        public override int ArtifactRarity{ get{ return 69; } }
		public override bool CanBeWornByGargoyles{ get{ return true; } }

		[Constructable]
		public SephirothSkirt() : base( 0x1452 )
		{
			Layer = Layer.OuterLegs;
            LootType = LootType.Blessed;
            Name = "Sephiroth's Skirt ";
			Hue = 1175;
            ItemID = 0x1516;
            SkillBonuses.SetValues(0, SkillName.EvalInt, 30);
			SkillBonuses.SetValues(1, SkillName.Tactics, 30);
			Attributes.BonusDex = 25;
			Attributes.BonusStr = 25;
			Attributes.BonusHits = 25;
            Attributes.SpellDamage = 50;
            Attributes.WeaponDamage = 50;
		}
		    public override void GetProperties(ObjectPropertyList list)
            {
 
            base.GetProperties(list);
            
            list.Add("+3 LMC Over Cap");
            }        
			public override bool OnDragLift( Mobile from ) 
		    { 
			    if(BoundToSoul == 0) //Check to see if bound to a serial.
			    { 
      			    BoundToSoul = from.Serial; //Bind to a serial on first time lifted.
                    this.Name = from.Name.ToString() + "'s Hero Skirt";//Change item name and add who it is bound to. "Player's Hero Skirt"
      			    from.Emote( "*" + from.Name + " knows this can never be traded*" ); 
				    base.OnDragLift( from ); 
				    return true;//Allow it to bind to the first player to lift it after creation.
							//Will show in [props as ParentEntity and RootParentEntitty as [m] Serial, "Player Name"
      		    } 
           	    else if(BoundToSoul == from.Serial) //Check to see if clothing is bound to who is lifting it.
      		    {
				    base.OnDragLift( from );
				    return true; //Allow player who had bound to clothing to lift it.
      		    } 
      		    else 
      		    { 
      			    from.SendMessage( "The clothing refuses your soul" ); 
				    return false; //Disallow any one else from lifting the clothing.
			    } 
		    }    
            public override ArmorMaterialType MaterialType
            {
                get
                {
                return ArmorMaterialType.Bone;
                }
            }  
		public SephirothSkirt( Serial serial ) : base( serial )
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
