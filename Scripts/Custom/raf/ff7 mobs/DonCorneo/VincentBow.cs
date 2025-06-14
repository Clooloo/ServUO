//Customized By Mrs Death
using System;
using Server;

namespace Server.Items
{
	public class VincentBow : Bow
	{

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public VincentBow()
		{
			Name = "[FF7] Vincent's Death Penalty";
			Hue = 1157;
			WeaponAttributes.HitDispel = 50;
			WeaponAttributes.HitLightning = 50;
			Attributes.WeaponSpeed = 50;
			Attributes.WeaponDamage = 50;
			Attributes.AttackChance = 50;
			Attributes.DefendChance = 50;
			Attributes.ReflectPhysical = 50;
			WeaponAttributes.ResistEnergyBonus = 10;
			WeaponAttributes.LowerStatReq = 100;
		}

        //public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy )
        //{
        //    fire = 10;
        //    phys = 60;
        //    pois = 10;
        //    cold = 10;
        //    nrgy = 10;
        //}

		public VincentBow( Serial serial ) : base( serial )
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