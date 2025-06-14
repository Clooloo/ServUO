using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a corpse" )]
	public class TrainingboBob : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 117.5; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public TrainingboBob() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0, 0 )
		{
			Name = " - Training WereWolf - ";
			Body = 719;
			BaseSoundID = 0xE5;
			Hue = 0;
			CantWalk = true;

			SetStr( 50, 50 );
			SetDex( 350, 350 );
			SetInt( 5571, 5592 );

			SetHits( 30000000, 30000000 );

			SetDamage( 0, 0 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Fire, 0 );
			SetDamageType( ResistanceType.Cold, 0 );
			SetDamageType( ResistanceType.Poison, 0 );
			SetDamageType( ResistanceType.Energy, 0 );

			SetResistance( ResistanceType.Physical, 70 );
			SetResistance( ResistanceType.Fire, 70 );
			SetResistance( ResistanceType.Cold, 70 );
			SetResistance( ResistanceType.Poison, 70 );
			SetResistance( ResistanceType.Energy, 70 );

			SetSkill( SkillName.MagicResist, 120.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.Wrestling, 100.0 );

			Fame = 0;
			Karma = 0;

			VirtualArmor = 350;
			ControlSlots = 2;

		}

		public override void GenerateLoot()
		{
		}

		public override bool AutoDispel{ get{ return true; } }
		public override bool BardImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override void OnThink()
		{
			if ( Hits != HitsMax )
			{
				Hits = HitsMax;
			}
		}

		public TrainingboBob( Serial serial ) : base( serial )
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

namespace Server.Mobiles
{
	public class NNinja : BaseCreature
	{
		public override bool ClickTitle{ get{ return false; } }
        public override bool CanStealth { get { return true; } }

        private DateTime m_NextWeaponChange;

		[Constructable]
		public NNinja() : base( AIType.AI_Ninja, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			SpeechHue = Utility.RandomDyedHue();
			Hue = Utility.RandomSkinHue();
			Name = " Shadow Ninja ";

			Body = ( this.Female = Utility.RandomBool() ) ? 0x191 : 0x190;

			SetHits( 2251, 4350 );

			SetStr( 526, 625 );
			SetDex( 581, 595 );
			SetInt( 2151, 2165 );

			SetDamage( 15, 25 );

			SetDamageType( ResistanceType.Physical, 65 );
			SetDamageType( ResistanceType.Fire, 15 );
			SetDamageType( ResistanceType.Poison, 15 );
			SetDamageType( ResistanceType.Energy, 5 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 55, 65 );
			SetResistance( ResistanceType.Cold, 55, 65 );
			SetResistance( ResistanceType.Poison, 55, 65 );
			SetResistance( ResistanceType.Energy, 55, 65 );

			SetSkill( SkillName.Anatomy, 105.0, 110.0 );
			SetSkill( SkillName.MagicResist, 100.0, 120.0 );
			SetSkill( SkillName.Tactics, 100.0, 120.0 );
			SetSkill( SkillName.Wrestling, 100.0, 120.0 );
			SetSkill( SkillName.Fencing, 100.0, 120.0 );
			SetSkill( SkillName.Macing, 100.0, 120.0 );
			SetSkill( SkillName.Swords, 100.0, 120.0 );

			SetSkill( SkillName.Ninjitsu, 120.0, 125.0 );
            SetSkill( SkillName.Hiding, 80.0);
            SetSkill( SkillName.Stealth, 90.0 );

			Fame = 8500;
			Karma = -8500;

            LeatherNinjaBelt belt = new LeatherNinjaBelt();
            belt.UsesRemaining = 100;
            belt.Poison = Poison.Greater;
            belt.PoisonCharges = 100;
            belt.Movable = false;
            AddItem(belt);

            int amount = Skills[SkillName.Ninjitsu].Value >= 100 ? 2 : 1;

            for (int i = 0; i < amount; i++)
            {
                Fukiya f = new Fukiya();
                f.UsesRemaining = 100;
                f.Poison = amount == 1 ? Poison.Regular : Poison.Greater;
                f.PoisonCharges = 100;
                f.Movable = false;
                PackItem(f);
            }

			AddItem( new NinjaTabi() );
			AddItem( new LeatherNinjaJacket());
			AddItem( new LeatherNinjaHood());
			AddItem( new LeatherNinjaPants());
			AddItem( new LeatherNinjaMitts());
			
			if( Utility.RandomDouble() < 0.33 )
				PackItem( new SmokeBomb() );

            if (Utility.RandomBool())
                PackItem(new Tessen());
            else
                PackItem(new Wakizashi());

            if (Utility.RandomBool())
                PackItem(new Nunchaku());
            else
                PackItem(new Daisho());

            if (Utility.RandomBool())
                PackItem(new Sai());
            else
                PackItem(new Tekagi());

            if (Utility.RandomBool())
                PackItem(new Kama());
            else
                PackItem(new Katana());

			Utility.AssignRandomHair( this );
            ChangeWeapon();
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );
			c.DropItem( new ImbuingDeed() );
		}

		public override bool BardImmune{ get{ return true; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Gems, 2 );
		}
		
		public override bool AlwaysMurderer{ get{ return true; } }

        private void ChangeWeapon()
        {
            if (Backpack == null)
                return;

            Item item = FindItemOnLayer(Layer.OneHanded);

            if (item == null)
                item = FindItemOnLayer(Layer.TwoHanded);

            System.Collections.Generic.List<BaseWeapon> weapons = new System.Collections.Generic.List<BaseWeapon>();

            foreach (Item i in Backpack.Items)
            {
                if (i is BaseWeapon && i != item)
                    weapons.Add((BaseWeapon)i);
            }

            if (weapons.Count > 0)
            {
                if (item != null)
                    Backpack.DropItem(item);

                AddItem(weapons[Utility.Random(weapons.Count)]);

                m_NextWeaponChange = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(30, 60));
            }
        }

        public override void OnThink()
        {
            base.OnThink();

            if (Combatant != null && m_NextWeaponChange < DateTime.UtcNow)
                ChangeWeapon();
        }

		public NNinja( Serial serial ) : base( serial )
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

            m_NextWeaponChange = DateTime.UtcNow;
		}
	}
}

namespace Server.Items
{

	public class ImbuingDeed : Item
	{

		[Constructable]
		public ImbuingDeed () : this( null )
		{
		}

		[Constructable]
		public ImbuingDeed ( string name ) : base ( 0x14F0 )
		{
			Name = "Random Imbuing Ingredients ";
			Hue = 1158;
		}

		public ImbuingDeed ( Serial serial ) : base ( serial )
		{
		}

      		public override void OnDoubleClick( Mobile from ) 
      		{
			if ( !IsChildOf( from.Backpack ) )
			{
                from.SendLocalizedMessage(1042001);
            }
            else
            {
/////////////////Prize Deed
                switch (Utility.Random(30))       
                {
                    case 0: from.AddToBackpack(new EssenceBalance(10)); break;
                    case 1: from.AddToBackpack(new AbyssalCloth(10)); break;
                    case 2: from.AddToBackpack(new ArcanicRuneStone(10)); break;
                    case 3: from.AddToBackpack(new ChagaMushroom(10)); break;
                    case 4: from.AddToBackpack(new CrystalShards(10)); break;
                    case 5: from.AddToBackpack(new DaemonClaw(10)); break;
                    case 6: from.AddToBackpack(new DelicateScales(10)); break;
                    case 7: from.AddToBackpack(new EssenceAchievement(10)); break;
                    case 8: from.AddToBackpack(new EssenceBalance(10)); break;
                    case 9: from.AddToBackpack(new EssenceControl(10)); break;
                    case 10: from.AddToBackpack(new EssenceDiligence(10)); break;
                    case 11: from.AddToBackpack(new EssenceDirection(10)); break;
                    case 12: from.AddToBackpack(new EssenceFeeling(10)); break;
                    case 13: from.AddToBackpack(new EssenceOrder(10)); break;
                    case 14: from.AddToBackpack(new EssencePassion(10)); break;
                    case 15: from.AddToBackpack(new EssencePersistence(10)); break;
                    case 16: from.AddToBackpack(new EssencePrecision(10)); break;
                    case 17: from.AddToBackpack(new EssenceSingularity(10)); break;
                    case 18: from.AddToBackpack(new FaeryDust(10)); break;
                    case 19: from.AddToBackpack(new FeyWings(10)); break;
                    case 20: from.AddToBackpack(new GoblinBlood(10)); break;
                    case 21: from.AddToBackpack(new PowderedIron(10)); break;
                    case 22: from.AddToBackpack(new RaptorTeeth(10)); break;
                    case 23: from.AddToBackpack(new ReflectiveWolfEye(10)); break;
                    case 24: from.AddToBackpack(new RunedPrism(10)); break;
                   // case 25: from.AddToBackpack(new SeedRenewal(10)); break;
                    case 25: from.AddToBackpack(new SilverSnakeSkin(10)); break;
                    case 26: from.AddToBackpack(new SpiderCarapace(10)); break;
                    case 27: from.AddToBackpack(new UndyingFlesh(10)); break;
                    case 28: from.AddToBackpack(new VialOfVitriol(10)); break;
                    case 29: from.AddToBackpack(new VoidOrb(10)); break;


                        
                }
                this.Delete();
			}

		}

		public override void Serialize ( GenericWriter writer)
		{
			base.Serialize ( writer );

			writer.Write ( (int) 0);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize ( reader );

			int version = reader.ReadInt();
		}
	}
}