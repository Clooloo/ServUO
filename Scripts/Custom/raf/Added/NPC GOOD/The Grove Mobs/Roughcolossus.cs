using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a colossus corpse" )]
	public class RoughColossus : BaseCreature
	{

		[Constructable]
		public RoughColossus() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			// TODO: Gas attack
			Name = " Rough colossus ";
			Hue = 2959;
			Body = 0x33D;
			BaseSoundID = 268;

			SetStr( 1500, 2000 );
			SetDex( 500, 800 );
			SetInt( 80, 90 );

			SetHits( 10000, 25000 );

			SetDamage( 20, 50 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Fire, 25 );
			SetDamageType( ResistanceType.Cold, 25 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 75, 85 );
			SetResistance( ResistanceType.Fire, 70, 75 );
			SetResistance( ResistanceType.Cold, 70, 75 );
			SetResistance( ResistanceType.Poison, 90, 100 );
			SetResistance( ResistanceType.Energy, 70, 75 );

			SetSkill( SkillName.MagicResist, 120, 140.0 );
			SetSkill( SkillName.Tactics, 120, 160.0 );
			SetSkill( SkillName.Wrestling, 100, 120.0 );

			Fame = 12000;
			Karma = -12000;

			VirtualArmor = 60;
			
			
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 1 );
			AddLoot( LootPack.Gems, 2 );
                        
		}
		
		public override void OnDeath( Container c )
		{
			base.OnDeath( c );
			
			ValoriteGranite granite = new ValoriteGranite();
   			granite.Amount = 2;
   			c.DropItem(granite);

		}

		public override bool AutoDispel{ get{ return true; } }
		public override bool BleedImmune{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 4; } }

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            base.OnDamage(amount, from, willKill);
			
           // eats pet or summons
           // if (from is BaseCreature)
           // {
            //    BaseCreature creature = (BaseCreature)from;
				
         //       if (creature.Controlled || creature.Summoned)
           //     {
           //         this.Heal(creature.Hits);					
            //        creature.Kill();				
					
            //        Effects.PlaySound(this.Location, this.Map, 0x574);
             //   }
           // }
			
            // teleports player near
            if (from is PlayerMobile && !this.InRange(from.Location, 1))
            {
                this.Combatant = from;
				
                from.MoveToWorld(this.GetSpawnPosition(1), this.Map);				
                from.FixedParticles(0x376A, 9, 32, 0x13AF, EffectLayer.Waist);
                from.PlaySound(0x1FE);
            }
        }


		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( from is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)from;

				if ( bc.Controlled || bc.BardTarget == this )
					damage = 0; // Immune to pets and provoked creatures
			}
			else if ( from != null )
			{
				int hitback = damage;
				AOS.Damage( from, this, hitback, 15, 0, 0, 0, 0 );
			}
		}

		public override void CheckReflect( Mobile caster, ref bool reflect )
		{
			reflect = true; // Every spell is reflected back to the caster
		}
		public override void AlterMeleeDamageTo( Mobile to, ref int damage )
		{
			if ( 0.5 >= Utility.RandomDouble() )
			{
				double positionChance = Utility.RandomDouble();
				BaseArmor armor;

				if ( positionChance < 0.07 )
					armor = to.NeckArmor as BaseArmor;
				else if ( positionChance < 0.14 )
					armor = to.HandArmor as BaseArmor;
				else if ( positionChance < 0.28 )
					armor = to.ArmsArmor as BaseArmor;
				else if ( positionChance < 0.43 )
					armor = to.HeadArmor as BaseArmor;
				else if ( positionChance < 0.65 )
					armor = to.LegsArmor as BaseArmor;
				else
					armor = to.ChestArmor as BaseArmor;

				if ( armor != null )
				{
					int ruin = Utility.RandomMinMax( 1, 4 );
					armor.HitPoints -= ruin;
				}
			}
		}
		public RoughColossus( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}