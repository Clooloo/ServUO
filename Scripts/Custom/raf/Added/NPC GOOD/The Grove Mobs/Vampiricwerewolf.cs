using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a Werewolf corpse" )]
	public class VampiricWerewolf : BaseMount
	{
        private DateTime m_NextAbilityTime;

        [Constructable]
		public VampiricWerewolf() : this( "Vampiric Werewolf" )
		{
		}

		public override bool SubdueBeforeTame{ get{ return true; } } // Must be beaten into submission

		[Constructable]
		public VampiricWerewolf( string name ) : base( name, 719, 16076, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
        
			BaseSoundID = 0xE5;

            Hue = 1665;

			SetStr( 1200, 1500 );
			SetDex( 700, 800 );
			SetInt( 2000, 3000 );

			SetHits( 2600, 4400 );

			SetDamage( 30, 40 );

            SetDamageType(ResistanceType.Physical, 25);
            SetDamageType(ResistanceType.Fire, 25);
            SetDamageType(ResistanceType.Cold, 25);
            SetDamageType(ResistanceType.Energy, 25);

			SetResistance( ResistanceType.Physical,65, 70 );
			SetResistance( ResistanceType.Fire, 60, 75 );
			SetResistance( ResistanceType.Cold, 60, 75 );
			SetResistance( ResistanceType.Poison, 65, 70 );
			SetResistance( ResistanceType.Energy, 60, 75 );

            SetSkill( SkillName.Healing, 70.1, 110.0);
            SetSkill( SkillName.Anatomy, 110.1, 125.0 );
			SetSkill( SkillName.MagicResist, 110.1, 120.0 );
			SetSkill( SkillName.Tactics, 130.1, 150.0 );
			SetSkill( SkillName.Wrestling, 115.1, 120.0 );
            SetSkill( SkillName.Poisoning, 80.1, 100.0);
		    SetSkill( SkillName.Meditation, 100.0, 120.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 50;
        
			Tamable = true;
			ControlSlots = 4;
			MinTameSkill = 115;

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
      	 
        public override bool StatLossAfterTame { get { return true; } }
        public override Poison HitPoison { get { return Poison.Greater; } }             
        //  public override bool CanDoHeal { get { return true; } }
        
        // public override bool AlwaysMurderer { get { return true; } }
        public override bool BardImmune{ get{ return true; } }
		public override bool CanAngerOnTame { get { return true; } }
        public override bool BleedImmune{ get{ return true; } }
        public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies; } }
		public override WeaponAbility GetWeaponAbility()

        {
            return WeaponAbility.WhirlwindAttack;
        }        

		public VampiricWerewolf( Serial serial ) : base( serial )
		{
		}
		
        public override void OnThink()
        {
            if (DateTime.UtcNow >= this.m_NextAbilityTime)
            {
                Mobile combatant = this.Combatant as Mobile;
                if (combatant != null && combatant.Map == this.Map && combatant.InRange(this, 10))
                {
                    this.m_NextAbilityTime = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(4, 5));
                    int ability = Utility.Random(4); // Lets do a 50% chance to fire
                    switch ( ability )
                    {
                        case 0:
                            this.DoFocusedLeech(combatant, "Thine essence will fill my withering body with strength!");
                            break;
                        case 1:
                            break;
                        case 2:
                            this.DoFocusedLeech(combatant, "I rebuke thee, worm, and cleanse thy vile spirit of its tainted blood!");
                            break;
                        case 3:
                            break;
                    }
                }
            }
            base.OnThink();
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

        private void DoFocusedLeech(Mobile combatant, string message)
        {
            this.Say(true, message);

            Timer.DelayCall(TimeSpan.FromSeconds(0.5), new TimerStateCallback(DoFocusedLeech_Stage1), combatant);
        }

        private void DoFocusedLeech_Stage1(object state)
        {
            Mobile combatant = (Mobile)state;

            if (this.CanBeHarmful(combatant))
            {
                this.MovingParticles(combatant, 0x36FA, 1, 0, false, false, 1108, 0, 9533, 1, 0, (EffectLayer)255, 0x100);
                this.MovingParticles(combatant, 0x0001, 1, 0, false, true, 1108, 0, 9533, 9534, 0, (EffectLayer)255, 0);
                this.PlaySound(0x1FB);

                Timer.DelayCall(TimeSpan.FromSeconds(1.0), new TimerStateCallback(DoFocusedLeech_Stage2), combatant);
            }
        }

        private void DoFocusedLeech_Stage2(object state)
        {
            Mobile combatant = (Mobile)state;

            if (this.CanBeHarmful(combatant))
            {
                combatant.MovingParticles(this, 0x36F4, 1, 0, false, false, 32, 0, 9535, 1, 0, (EffectLayer)255, 0x100);
                combatant.MovingParticles(this, 0x0001, 1, 0, false, true, 32, 0, 9535, 9536, 0, (EffectLayer)255, 0);

                this.PlaySound(0x209);
                this.DoHarmful(combatant);
                this.Hits += AOS.Damage(combatant, this, Utility.RandomMinMax(30, 60) - (Core.AOS ? 0 : 10), 100, 0, 0, 0, 0);
            }
        }
	}
}
