/*
GlassSword.cs for RunUO 2.0 by Alari (alarihyena@gmail.com)
This code released under the GNU GPL v3.
11:15 PM Monday, April 02, 2007

A glass sword (featured in U5, U6, U7, U7p2, and U9)

Shatters on impact, one use only, will kill anything it hits.
(Well, anything with less than 10,000 HP, not counting bonuses.)

Not responsible for character death due to inability to hit target.
(Ie: newbie vs dragon does not equal win ;)
*/

using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x26CE, 0x26CF )]
	public class GlassSword1 : BaseSword
	{
//  no abilities
//		public override WeaponAbility PrimaryAbility
//			{
//				get{ return WeaponAbility.ArmorIgnore; }
//			}
//		public override WeaponAbility SecondaryAbility
//			{
//				get{ return WeaponAbility.ConcussionBlow; }
//			}

		public override int AosStrengthReq{ get{ return 10; } }
		public override int AosMinDamage{ get{ return 10000; } }
		public override int AosMaxDamage{ get{ return 10000; } }
		public override int AosSpeed{ get{ return 30; } }
		public override float MlSpeed{ get{ return 2.00f; } }

		public override int OldStrengthReq{ get{ return 10; } }
		public override int OldMinDamage{ get{ return 10000; } }
		public override int OldMaxDamage{ get{ return 10000; } }
		public override int OldSpeed{ get{ return 30; } }

		public override int DefHitSound{ get{ return 0x38E; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		[Constructable]
		public GlassSword1() : base( 0x26CE ) // paladin sword
		{
			Name = "glass sword";
			Weight = 5.0;
			Hue = 91;
		}

		public override void OnHit( Mobile attacker, IDamageable defender, double damageBonus )
		{
			base.OnHit( attacker, defender, damageBonus );

			attacker.SendMessage( "The sword shatters!" );
			Delete();  // or Consume(); ??
		}


		public GlassSword1( Serial serial ) : base( serial )
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