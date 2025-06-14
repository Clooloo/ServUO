//Customized By Mrs Death
using System;
using Server;

namespace Server.Items
{
	public class ZackBlade : Broadsword
	{

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public ZackBlade()
		{
			Weight = 5;
                        Name = "[FF7] Zack's Buster Sword";
			Hue = 1000;
			WeaponAttributes.HitEnergyArea = 50;
			WeaponAttributes.HitLightning = 50;
			Attributes.WeaponSpeed = 50;
			Attributes.WeaponDamage = 50;
			WeaponAttributes.ResistEnergyBonus = 10;
			WeaponAttributes.LowerStatReq = 100;
		}

        //public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy )
        //{
        //    fire = 20;
        //    phys = 20;
        //    pois = 20;
        //    cold = 20;
        //    nrgy = 20;
        //}

		public ZackBlade( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}