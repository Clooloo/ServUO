/*----------------*/
/*--- Scripted ---*/
/*--- By: JBob ---*/
/*----------------*/
using System;
using Server;
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
	[FlipableAttribute( 0xdf1, 0xdf0 )]
	public class HeroMagiStaff : BaseStaff
	{
        private int mEvolutionPoints;// Weapon can be set evolve to X% at line 102
        [CommandProperty(AccessLevel.GameMaster)]
        public int EvolutionPoints { get { return mEvolutionPoints; } set { mEvolutionPoints = value; } }

		public int BoundToSoul = 0;// Start binding value as zero.

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.WhirlwindAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }
		
		public override int AosMinDamage{ get{ return 22; } }
		public override int AosMaxDamage{ get{ return 25; } }
		public override int AosSpeed{ get{ return 39; } }
		public override float MlSpeed{ get{ return 2.75f; } }//Added This to fix not being able to attack stuff when the evolution stuff was added.

		public override int InitMinHits{ get{ return 999; } }
		public override int InitMaxHits{ get{ return 999; } }

		[Constructable]
		public HeroMagiStaff() : base( 0xdf0 )
		{
			Weight = 7.0;
			Name = "Hero's Magi Staff";
			Resource = CraftResource.None;//Resource None so the weapon's name shows correct once Bound.
			
			BoundToSoul = 0; 
			// Create item with value at zero. Will show in [props as ParentEntity and RootParentEntitty as null.
			
            Attributes.Luck = 100;
			LootType = LootType.Blessed;
            WeaponAttributes.SelfRepair = 10;
            SkillBonuses.SetValues(0, SkillName.EvalInt, 20);
            Attributes.SpellDamage = 1;
			Attributes.CastSpeed = 2;
			Attributes.CastRecovery = 3;
			WeaponAttributes.MageWeapon = 50;
            Attributes.WeaponDamage = 50;
            Attributes.SpellChanneling = 1;
            AbsorptionAttributes.CastingFocus = 6;
			Attributes.BalancedWeapon = 1;
		}
		
		public override bool OnDragLift( Mobile from ) 
		{ 
			if(BoundToSoul == 0) //Check to see if bound to a serial.
			{ 
      			BoundToSoul = from.Serial; //Bind to a serial on first time lifted.
                this.Name = "Hero " + from.Name.ToString() + "'s Magi Staff";//Change item name and add who it is bound to. "Player's WeaponName"
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
			else if (BoundToSoul >= 0)//Once the weapon is bound it will show the Evolution Points.
			{// \n puts the stuff after it on a new line
				list.Add( "<BASEFONT COLOR=#669966>"/*Green*/ + "[Soulbound]\n" + "Hero Points: " + mEvolutionPoints.ToString() + "<BASEFONT COLOR=#FFFFFF>"/*Back to White*/ );
			}
        }
		/*When weapon hits this gives a chance to gain Evolution Points*/
        public override void OnHit(Mobile attacker, IDamageable defender, double damageBonus)
        {
            if (Utility.Random(2) == 1)
            {
                ApplyGain();
            }
            base.OnHit(attacker, defender,damageBonus);
        }

        public void ApplyGain()
        {
            int expr;
            if (mEvolutionPoints < 10001)//5001 restricts evolving to 50% and 10001 is 100%
            {
                mEvolutionPoints++;

                if ((mEvolutionPoints / 100) > 0)
                {
                    expr = mEvolutionPoints / 100;

                    this.WeaponAttributes.HitLeechHits = expr;
                    this.WeaponAttributes.HitLeechMana = expr;
                }

                if ((mEvolutionPoints / 200) > 0)
                {
                    expr = mEvolutionPoints / 100;

                    this.WeaponAttributes.HitLightning = expr;
                    this.WeaponAttributes.HitFireball = expr;
                    this.Attributes.SpellDamage = expr + 75;
                }

                if ((25 + (mEvolutionPoints / 200)) > 0) this.Attributes.WeaponSpeed = (0 + (mEvolutionPoints / 200));

                if ((mEvolutionPoints / 1000) > 0)
                {
                    expr = mEvolutionPoints / 1000;

                    this.Attributes.RegenMana = expr;
                    this.Attributes.RegenHits = expr;
                }
                InvalidateProperties();

            }
        }
		
        public override bool CanEquip( Mobile from )
        {
            if ( from.Skills[SkillName.Magery].Base < 125.0 )
			{
				from.SendMessage( "You are not skilled enough to equip that." );
                return false;
			}
            else
            {
                return base.CanEquip( from );
            }
        }			
		public HeroMagiStaff( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.Write( (int) mEvolutionPoints );//Serialize(Save) how many points the weapon has.
         	writer.Write( (int) BoundToSoul );//Serialize who it is bound to.
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			mEvolutionPoints = reader.ReadInt();//Read on startup how many points the weapon has.
         	BoundToSoul = reader.ReadInt();//Read on startup who it is bound to.
		}
	}
}
