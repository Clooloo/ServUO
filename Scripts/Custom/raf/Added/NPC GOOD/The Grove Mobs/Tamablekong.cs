using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a King Kong corpse" )]
	public class tamablekong : BaseCreature
	{
		[Constructable]
		public tamablekong() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.6 )
		{
            Name = "Tamable Kong ";
			Body = 1308;
			BaseSoundID = 0x9E;
                        Hue = 2545;

			SetStr( 1000, 1300 );
			SetDex( 500, 600 );
			SetInt( 1300, 1350 );

			SetHits( 2000, 3000 );

			SetDamage( 30, 38 );

                        SetDamageType(ResistanceType.Physical, 100);

			SetResistance( ResistanceType.Physical,65, 75 );
			SetResistance( ResistanceType.Fire, 50, 70 );
			SetResistance( ResistanceType.Cold, 50, 75 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, 50, 70 );

                        SetSkill( SkillName.Anatomy, 100.1, 125.0 );
			SetSkill( SkillName.MagicResist, 75.1, 105.0 );
			SetSkill( SkillName.Tactics, 100.1, 125.0 );
			SetSkill( SkillName.Wrestling, 120.1, 130.0 );

			Fame = 11000;
			Karma = -11000;

			VirtualArmor = 50;
        
                        Tamable = true;
                        ControlSlots = 4;
                        MinTameSkill = 112.1;
        

            PackItem(new RandomTalisman());
            PackGold(100, 200);
          //  PackWeapon(1, 2);
          //  PackWeapon(1, 2);
          //  PackArmor(1, 2);
			
			switch ( Utility.Random( 4 ))
			{
				case 0: PackItem( new Taint() ); break;
				case 1: PackItem( new RightArm() ); break;
				case 2: PackItem( new Torso() ); break;
				case 3: PackItem( new Bone() ); break;
			}
		}
        	
              //  public override bool AlwaysMurderer { get { return true; } }
                public override bool BardImmune{ get{ return true; } }
		public override bool CanAngerOnTame { get { return true; } }
                public override bool BleedImmune{ get{ return true; } }
		public override WeaponAbility GetWeaponAbility()

        {
            return WeaponAbility.ConcussionBlow;
        }        

 private DateTime _NextBanana;
        private int _Thrown;

        public override void OnActionCombat()
        {
            Mobile combatant = Combatant as Mobile;

            if (DateTime.UtcNow < _NextBanana || combatant == null || combatant.Deleted || combatant.Map != Map || !InRange(combatant, 12) || !CanBeHarmful(combatant) || !InLOS(combatant))
                return;

            ThrowBanana(combatant);

            _Thrown++;

            if (0.75 >= Utility.RandomDouble() && (_Thrown % 2) == 1) // 75% chance to quickly throw another bomb
                _NextBanana = DateTime.UtcNow + TimeSpan.FromSeconds(3.0);
            else
                _NextBanana = DateTime.UtcNow + TimeSpan.FromSeconds(5.0 + (10.0 * Utility.RandomDouble())); // 5-15 seconds
        }

        public void ThrowBanana(Mobile m)
        {
            DoHarmful(m);

            this.MovingParticles(m, Utility.RandomList(0x171f, 0x1720, 0x1721, 0x1722), 10, 0, false, true, 0, 0, 9502, 6014, 0x11D, EffectLayer.Waist, 0);

            Timer.DelayCall(TimeSpan.FromSeconds(1), () =>
            {
                m.PlaySound(0x11D);
                AOS.Damage(m, this, Utility.RandomMinMax(120, 130), 100, 0, 0, 0, 0);
            });
        }


        public tamablekong(Serial serial): base(serial)
            
		{
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
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