using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a Guardian corpse" )]
	public class Ccoldarcher : BaseCreature
	{

        private DateTime m_NextBomb;
        private int m_Thrown;

		[Constructable]
        public Ccoldarcher()
            : base(AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
            Name = " The Guardians ";
	    BaseSoundID = 367;
            Hue = 1911;

            switch (Utility.Random(20))
            {
                case 0: Body = 256; break;
                case 1: Body = 272; break;
                case 2: Body = 76; break;
                case 3: Body = 263; break;
                case 4: Body = 265; break;
                case 5: Body = 267; break;
                case 6: Body = 285; break;
                case 7: Body = 314; break; 
                case 8: Body = 728; break; 
                case 9: Body = 730; break; 
                case 10: Body = 255; break;
                case 11: Body = 741; break; 
                case 12: Body = 740; break; 
                case 13: Body = 241; break;
                case 14: Body = 18; break; 
                case 15: Body = 57; break;
                case 16: Body = 123; break; 
                case 17: Body = 306; break; 
                case 18: Body = 766; break;
                case 19: Body = 280; break;
 


            }


			SetStr( 500, 1000 );
			SetDex( 3500, 3650 );
			SetInt( 3300, 3500 );

			SetHits( 7000, 12000 );

			SetDamage( 25, 30 );

			SetDamageType( ResistanceType.Physical, 10 );
			SetDamageType( ResistanceType.Cold, 50 );
			SetDamageType( ResistanceType.Poison, 40 );

			SetResistance( ResistanceType.Physical,75, 85 );
			SetResistance( ResistanceType.Fire, 40, 55 );
			SetResistance( ResistanceType.Cold, 85, 88 );
			SetResistance( ResistanceType.Poison, 80, 90 );
			SetResistance( ResistanceType.Energy, 50, 55 );

                        this.SetSkill(SkillName.MagicResist, 140.0);
                        this.SetSkill(SkillName.Tactics, 130);
			this.SetSkill(SkillName.Magery, 130.0);
			this.SetSkill(SkillName.EvalInt, 130.0);
			this.SetSkill(SkillName.Mysticism, 120);
			this.SetSkill(SkillName.Focus, 120);
			this.SetSkill(SkillName.Meditation, 120);
			this.SetSkill(SkillName.Wrestling, 150);
			this.SetSkill(SkillName.Necromancy, 120);
			this.SetSkill(SkillName.SpiritSpeak, 120);

			Fame = 16000;
			Karma = -16000;

			VirtualArmor = 60;


            HHatchet th = new TTHatchet();
            th.Movable = false;
            AddItem( th );
  
                        PackItem(new RandomTalisman());
                        PackItem (new RAD());
                        PackItem( new MasterCoin( 2 ) );
                        PackItem (new VoidOrb(5));
                        PackItem (new MagicalResidue(5));
                        
                        PackItem (new DelicateScales(5));
                       AddLoot( LootPack.FilthyRich, 2 );


		}

        	
		public override void OnDeath(Container c)
		{
			base.OnDeath(c);
                     c.DropItem( new MasterCoin( 30 ) );
                     

            if (0.06 > Utility.RandomDouble()) // 
            {           
                c.DropItem(new MagicClothDeed());             
            }
            if (0.30 > Utility.RandomDouble()) // 30% chance to drop
            {           
                c.DropItem(new MagicClothDeed());             

		}
}
                public override bool AlwaysMurderer { get { return true; } }
                	
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }
                public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.BleedAttack;
        }


        public override void OnActionCombat()
        {
            Mobile combatant = this.Combatant as Mobile;

            if (combatant == null || combatant.Deleted || combatant.Map != this.Map || !this.InRange(combatant, 12) || !this.CanBeHarmful(combatant) || !this.InLOS(combatant))
                return;

            if (DateTime.UtcNow >= this.m_NextBomb)
            {
                this.ThrowBomb(combatant);

                this.m_Thrown++;

                if (0.85 >= Utility.RandomDouble() && (this.m_Thrown % 2) == 1) // 75% chance to quickly throw another bomb
                    this.m_NextBomb = DateTime.UtcNow + TimeSpan.FromSeconds(3.0);
                else
                    this.m_NextBomb = DateTime.UtcNow + TimeSpan.FromSeconds(2.0 + (5.0 * Utility.RandomDouble())); // 5-15 seconds
            }
        }

        public void ThrowBomb(Mobile m)
        {
            this.DoHarmful(m);

            this.MovingParticles(m, 0x913, 4, 0, false, true, 1152, 0, 9502, 6014, 0x11D, EffectLayer.Waist, 0);

            new InternalTimer(m, this).Start();
        }

       private class InternalTimer : Timer
        {
            private readonly Mobile m_Mobile;
            private readonly Mobile m_From;
            public InternalTimer(Mobile m, Mobile from)
                : base(TimeSpan.FromSeconds(1.0))
            {
                this.m_Mobile = m;
                this.m_From = from;
                this.Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                this.m_Mobile.PlaySound(0x11D);
                AOS.Damage(this.m_Mobile, this.m_From, Utility.RandomMinMax(110, 170), 0, 100, 0, 0, 0);
            }
        }


        public Ccoldarcher(Serial serial): base(serial)
            
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