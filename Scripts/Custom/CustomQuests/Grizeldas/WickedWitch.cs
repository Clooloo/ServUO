//Created By: Otim Pyre 6-29-06
using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Spells;
using Server.Spells.Seventh;
using Server.Spells.Fifth;

namespace Server.Mobiles
{
	
	[CorpseName( "The Corpse of Grizelda" )]
	public class  WickedWitch: BaseCreature
	{
		public Item Immovable( Item item )
		{
			item.Movable = false;
			return item;
		}
		
		[Constructable]
		public WickedWitch() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Grizelda";
                        Title = "The Witch";
			Female = true;
			Body = 0x191;
			Hue = Utility.RandomMinMax(0x8596, 0x8599);

	                WizardsHat hat = new WizardsHat();
                        hat.Movable = false;
                        hat.Hue = 1;
                        AddItem(hat);

                        Robe robe = new Robe();
                        robe.Movable = false;
                        robe.Hue = 1;
                        AddItem(robe);

                        GoldBracelet bracelet = new GoldBracelet();
                        bracelet.Movable = false;
                        bracelet.Hue = 0x35;
                        AddItem(bracelet);

                        ThighBoots boots = new ThighBoots();
                        boots.Movable = false;
                        boots.Hue = 0x497;
                        AddItem(boots);

			HairItemID = 0x203C;

			Item staff = new StaffOfPower();
			staff.Movable = false;
			AddItem( staff );
	
			SetStr( 100, 150 );
			SetDex( 50 );
			SetInt( 250 );

			SetHits( 500 );

			SetDamage( 15, 35 ); 

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30 );
			SetResistance( ResistanceType.Fire, 30 );
			SetResistance( ResistanceType.Cold, 30 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.MagicResist, 100, 120 );
			SetSkill( SkillName.Magery, 200 ); 
			SetSkill( SkillName.Meditation, 200 );
			SetSkill( SkillName.EvalInt, 200 );
			SetSkill( SkillName.Wrestling, 120 );
			
			Fame = 1500;
			Karma = -1500;
			VirtualArmor = 30;

	
	} 

		// this is the Generic loot that is added on death
		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			
		}

        public override bool OnBeforeDeath()
        {
            this.Say("Whoa is me!' What a world! What a world!");

            this.AddItem(new Gold(2000));
            switch (Utility.Random(50))//This is the random rares list
            {
                case 0: PackItem(new RobeOfTheEclipse()); break;
                case 1: PackItem(new RobeOfTheEquinox()); break;
                case 2: PackItem(new HatOfTheMagi()); break;
                case 3: PackItem(new AlchemistsBauble()); break;
                case 4: PackItem(new Cauldron()); break;
                case 5: PackItem(new TarotCardsArtifact()); break;
                case 6: PackItem(new StaffOfPower()); break;
            }

            return base.OnBeforeDeath();

        } 
		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool BardImmune{ get{ return true; } }
		public override bool Unprovokable{ get{ return true; } }
		public override bool Uncalmable{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override bool AlwaysMurderer{ get{ return true; } } 
		
		 public void Polymorph( Mobile m )
		{
			if ( !m.CanBeginAction( typeof( PolymorphSpell ) ) || !m.CanBeginAction( typeof( IncognitoSpell ) ) || m.IsBodyMod )
				return;

			IMount mount = m.Mount;

			if ( mount != null )
				mount.Rider = null;

			if ( m.Mounted )
				return;

			if ( m.BeginAction( typeof( PolymorphSpell ) ) )
			{
				Item disarm = m.FindItemOnLayer( Layer.OneHanded );

				if ( disarm != null && disarm.Movable )
					m.AddToBackpack( disarm );

				disarm = m.FindItemOnLayer( Layer.TwoHanded );

				if ( disarm != null && disarm.Movable )
					m.AddToBackpack( disarm );

				m.BodyMod = 81;
				m.HueMod = 0;

				new ExpirePolymorphTimer( m ).Start();
			}
		}

		private class ExpirePolymorphTimer : Timer
		{
			private Mobile m_Owner;

			public ExpirePolymorphTimer( Mobile owner ) : base( TimeSpan.FromMinutes( 3.0 ) )
			{
				m_Owner = owner;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if ( !m_Owner.CanBeginAction( typeof( PolymorphSpell ) ) )
				{
					m_Owner.BodyMod = 0;
					m_Owner.HueMod = -1;
					m_Owner.EndAction( typeof( PolymorphSpell ) );
				}
			}
		}
		
		public void DoSpecialAbility( Mobile target )
		{
			if ( 0.45 >= Utility.RandomDouble() ) // 45% chance to polymorph attacker into a gianttoad
				Polymorph( target );

		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			DoSpecialAbility( attacker );
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			DoSpecialAbility( defender );
		}

		public override int GetAngerSound()
		{
			return 601;
		}

		public override int GetIdleSound()
		{
			return 600;
		}

		public override int GetAttackSound()
		{
			return 595;
		}

		public override int GetHurtSound()
		{
			return 1203;
		}

		public override int GetDeathSound()
		{
			return 1340;
		}

		
		public WickedWitch( Serial serial ) : base( serial ) 
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
