using System;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Spells;

namespace Server.Items
{
	public class WolfRobe : BaseOuterTorso
	{
                public override int ArtifactRarity{ get{ return 13; } }
		[Constructable]
		public WolfRobe() : base( 0x2684 )
		{	
			Hue = 1109;	
			Name = "Dam Wolf";
			Attributes.WeaponSpeed = 10;
		}

		public WolfRobe( Serial serial ) : base( serial )
		{
		}

        public override bool OnEquip(Mobile from)
        {
            if (!from.CanBeginAction(typeof(Server.Spells.Seventh.PolymorphSpell)))
            {
                from.SendLocalizedMessage(1061628); // You can't do that while polymorphed.
                return false;
            }
            else if (TransformationSpellHelper.UnderTransformation(from))
            {
                from.SendMessage("You cannot equip that in your current form.");
                return false;
            }
            else if (DisguiseTimers.IsDisguised(from))
            {
                from.SendLocalizedMessage(1061631); // You can't do that while disguised.
                return false;
            }

            from.SendMessage("You feel the speed of a Werewolf taking over your body!");
            from.SolidHueOverride = 1109;

            //if( !from.Mounted )	// Only transform if not mounted.. //* make them get off the dam mount lol
            {
                from.BodyMod = 719;
                from.FixedParticles(0x375A, 10, 15, 5010, EffectLayer.Waist);
                from.FixedParticles(0x376A, 1, 14, 0x13B5, EffectLayer.Waist);
                from.PlaySound(from.Body.IsFemale ? 0x338 : 0x44A);
            }

            //else
            {
                //from.SendMessage( 1154, "The transformation was incomplete! The WereWolf is too huge to ride mounts!!" );
            }
            return true;
        }

        public override void OnRemoved(object parent)
        {
            if (parent is Mobile)
            {
                Mobile from = (Mobile)parent;

                from.SolidHueOverride = -1;

                from.BodyMod = 0;

                from.FixedParticles(0x375A, 10, 15, 5010, EffectLayer.Waist);
                from.SendMessage("You feel your body returning to its original form.");
            }

            base.OnRemoved(parent);
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int ) 0 );
		}

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
            		public override void OnDoubleClick( Mobile from )
		{
            Item y = from.Backpack.FindItemByType(typeof(WolfRobe));
			if ( y !=null )
			{

                if (this.ItemID == 9860) this.ItemID = 7939;
                else if (this.ItemID == 7939) this.ItemID = 9860;

			}
			else
			{ 
                               	from.SendMessage( "You must have the item in your pack to take down the hood." ); 
                        }
		}
	}
}