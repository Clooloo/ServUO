using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    [FlipableAttribute( 0x2D28, 0x2D34 )]  // ornate axe flipable
	public class VenomBlade : BaseAxe
	{
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.Disarm; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.CrushingBlow; } }

		public override int AosStrengthReq{ get{ return 35; } }
		public override int AosMinDamage{ get{ return 19; } }  //the min/max damage have been changed from the base weapon
		public override int AosMaxDamage{ get{ return 23; } }
		public override int AosSpeed{ get{ return 18; } }  // the speed has also been changed
		public override float MlSpeed{ get{ return 3.00f; } }

		public override int OldStrengthReq{ get{ return 40; } }
		public override int OldMinDamage{ get{ return 6; } }
		public override int OldMaxDamage{ get{ return 38; } }
		public override int OldSpeed{ get{ return 30; } }

		public override int InitMinHits{ get{ return 225; } }
		public override int InitMaxHits{ get{ return 225; } }

		[Constructable]
		public VenomBlade() : base( 0x2D28 ) //this is the base OrnateAxe item
		{
            Hue = 0x4F6;
			Weight = 4.0;
            Name = "Venom Axe";

			WeaponAttributes.HitLeechStam = 52;                                   
			WeaponAttributes.HitLightning = 51;
			WeaponAttributes.HitLowerAttack = 56;
			Attributes.AttackChance = 20;
			Attributes.BonusDex = 25;
			Attributes.Luck = 250;
			Attributes.SpellChanneling = 1;
			Attributes.WeaponDamage = 65;
			Attributes.WeaponSpeed = 35;
			Layer = Layer.OneHanded;  // note this is a one-handed axe weapon, you might not want that on your server
		}

        public void OnHit(Mobile attacker, Mobile defender, double damageBonus)
        {
                        Poison = Poison.Deadly;
                if (Utility.RandomDouble() >= 0.8) // 20% chance to poison
                {
                    if (Utility.RandomDouble() >= 0.5) // 50% chance for deadly
                    {

                        defender.ApplyPoison(attacker, Poison);
                        attacker.SendMessage(" Venom Strikes! ");
                    }
                    else// 50% chance for Lethal
                    {
                        Poison = Poison.Lethal;
                        defender.ApplyPoison(attacker, Poison);
                        attacker.SendMessage(" Venom Strikes Lethally! ");
                    }
                }
                else
                {
                    //attacker.SendMessage(" No Venom Applied ");  //Leave this line in if you want to see hits with no poison application
                }
            base.OnHit(attacker, defender, damageBonus); //returns hit after poison
        }


		public VenomBlade( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}