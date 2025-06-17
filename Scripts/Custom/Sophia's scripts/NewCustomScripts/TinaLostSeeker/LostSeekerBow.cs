using System;
using Server;

namespace Server.Items
{
	public class LostSeekerBow : CompositeBow
	{
	 	public override int ArtifactRarity{ get{ return 68; } }
		public override int AosMinDamage{ get{ return 20; } }
		public override int AosMaxDamage{ get{ return 25; } }
		public override int AosSpeed{ get{ return 40; } }
        public override int DefMaxRange{ get{return 20; } }
		
        
		

        public override int DefHitSound{ get{ return 0x224; } }
		public override int DefMissSound{ get{ return 0x223; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MovingShot; } }
		
				
		[Constructable]
	 	public LostSeekerBow()
	 	{
	 	 	Name = "Lost Seeker Bow";
	 	 	Hue = 1366;
            ItemID = 10149;

	 	 	Attributes.SpellChanneling = 1;
	 	 	Attributes.BonusDex = 5;
	 	      Attributes.WeaponDamage = 10;
	 	 	Attributes.WeaponSpeed = 10;
            
            
            WeaponAttributes.HitFireball = 20;
            WeaponAttributes.HitLeechMana = 5;
	 	 	
            
	 	 WeaponAttributes.SelfRepair = 10;
            WeaponAttributes.UseBestSkill = 1;
            StrRequirement = 20;
	 	 	
	 	}

        public LostSeekerBow(Serial serial)
            : base(serial)
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
