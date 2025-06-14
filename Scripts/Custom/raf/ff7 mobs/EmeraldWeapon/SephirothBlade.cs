//Customized By Mrs Death
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class SephirothBlade : NoDachi
  {
		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 27; } }
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		public override int DefHitSound{ get{ return 0x23B; } }
		public override int DefMissSound{ get{ return 0x23A; } }		
		public override bool IsArtifact { get { return true; } }

		private Mobile m_Owner;		
		

      [Constructable]
		public SephirothBlade()
		{
          Name = "Sephiroth's Shame";
          Hue = 1175;
      WeaponAttributes.HitFireball = 100;
      WeaponAttributes.HitLeechHits = 75;
      WeaponAttributes.HitLeechMana = 75;
      WeaponAttributes.HitLeechStam = 75;
      WeaponAttributes.HitLightning = 100;
      WeaponAttributes.HitLowerAttack = 25;
      WeaponAttributes.HitLowerDefend = 25;
      WeaponAttributes.HitPoisonArea = 100;
      Attributes.AttackChance = 10;
      Attributes.BonusDex = 25;
	  MaxRange = 2;
      Attributes.BonusHits = 25;
      Attributes.SpellDamage = 125;
      Attributes.WeaponDamage = 150;
      Attributes.WeaponSpeed = 30;
     Slayer = SlayerName.Exorcism;
		}
        public override void OnDoubleClick(Mobile from)
        {
            if (this.IsChildOf(from.Backpack))
            {
                // set owner if not already set -- this is only done the first time.
                if (m_Owner == null)
                {
                    m_Owner = from;
                    this.Name = m_Owner.Name.ToString() + "'s Sephiroth Blade";
                    from.SendMessage("You feel the sword grow fond of you.");
                }
                else
                {
                    if (m_Owner != from)
                    {
                        from.SendMessage("Sorry but this sword does not belong to you.");
                        return;
                    }
                }
            }
            else
            {
                from.SendMessage(1173, "This sword must be in your pack to use.");
            }
        }

        public override bool OnDragLift(Mobile from)
        {
            // set owner if not already set -- this is only done the first time.
            if (m_Owner == null)
            {
                m_Owner = from;
                this.Name = m_Owner.Name.ToString() + "'s Sephiroth Blade";
                from.SendMessage("You feel the sword grow fond of you.");
                return base.OnDragLift(from);
            }
            else
            {
                if (m_Owner != from)
                {
                    from.SendMessage("Sorry but this sword does not belong to you.");
                    return false;
                }

                return base.OnDragLift(from);
            }
        }		

		public virtual void OnHit( Mobile attacker, Mobile defender )
		{
			attacker.MovingEffect( defender, 5369, 3, 3, false, false );
			defender.FixedParticles( 8383, 10, 30, 5052, EffectLayer.LeftFoot );
			base.OnHit( attacker, defender );
		}		

		
		
		public SephirothBlade( Serial serial ) : base( serial )
		{
		}
 		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

            writer.Write(m_Owner); // Version 1
		}		
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    m_Owner = reader.ReadMobile();
                    break;
            }
		}		
    }
}