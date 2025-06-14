//Customized By Mrs Death
using System;
using System.Collections;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using System.Collections.Generic;
using Server.Engines.CannedEvil;

namespace Server.Mobiles
{
    [CorpseName( "Holy Sh*t" )]
    public class RainbowBigBoss : BaseCreature
    {

		public static Type[] ArtifactRarity12 { get { return m_ArtifactRarity12; } }
		public static Type[] ArtifactRarity1000 { get { return m_ArtifactRarity1000; } }
		private static Type[] m_ArtifactRarity12 = new Type[]
			{
				//typeof( DecoCraftTool )
			};

		private static Type[] m_ArtifactRarity1000 = new Type[]
			{
				typeof( Robeoftherainbow ),
				typeof( RelicFragment ),
                typeof( RainbowTile2 ),
            //    typeof( CinctureDeed )
				
			};

		public static Item CreateRandomArtifact()
		{
			if ( !Core.AOS )
				return null;

			int count = ( m_ArtifactRarity12.Length * 5 ) + ( m_ArtifactRarity1000.Length * 4 );
			int random = Utility.Random( count );
			Type type;

			if ( random < ( m_ArtifactRarity12.Length * 5 ) )
			{
				type = m_ArtifactRarity12[random / 5];
			}
			else
			{
				random -= m_ArtifactRarity12.Length * 5;
				type = m_ArtifactRarity1000[random / 4];
			}

			return Loot.Construct( type );
		}

		public static Mobile FindRandomPlayer( BaseCreature creature )
		{
			List<DamageStore> rights = creature.GetLootingRights(); 

			for ( int i = rights.Count - 1; i >= 0; --i )
			{
				DamageStore ds = rights[i];

				if ( !ds.m_HasRight )
					rights.RemoveAt( i );
			}

			if ( rights.Count > 0 )
				return rights[Utility.Random( rights.Count )].m_Mobile;

			return null;
		}

		public static void DistributeArtifact( BaseCreature creature )
		{
			DistributeArtifact( creature, CreateRandomArtifact() );
		}

		public static void DistributeArtifact( BaseCreature creature, Item artifact )
		{
			DistributeArtifact( FindRandomPlayer( creature ), artifact );
		}

		public static void DistributeArtifact( Mobile to )
		{
			DistributeArtifact( to, CreateRandomArtifact() );
		}

		public static void DistributeArtifact( Mobile to, Item artifact )
		{
			if ( to == null || artifact == null )
				return;

			Container pack = to.Backpack;

			if ( pack == null || !pack.TryDropItem( to, artifact, false ) )
				to.BankBox.DropItem( artifact );

			to.SendLocalizedMessage( 1062317 ); // For your valor in combating the fallen beast, a special artifact has been bestowed on you.
		}

		public static int GetArtifactChance( Mobile boss )
		{
			if ( !Core.AOS )
				return 0;

			int luck = LootPack.GetLuckChanceForKiller( boss );
			int chance;

            if (boss is RainbowBigBoss)
				chance = 1500 + (luck / 5);
			else
				chance = 750 + (luck / 10);

			return chance;
		}

		public static bool CheckArtifactChance( Mobile boss )
		{
			return GetArtifactChance( boss ) > Utility.Random( 1000 );
		}

		public override WeaponAbility GetWeaponAbility()
		{
			switch ( Utility.Random( 3 ) )
			{
				default:
				case 0: return WeaponAbility.DoubleStrike;
				case 1: return WeaponAbility.WhirlwindAttack;
				case 2: return WeaponAbility.CrushingBlow;
			}
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

            if (!Summoned && !NoKillAwards && RainbowBigBoss.CheckArtifactChance(this))
                RainbowBigBoss.DistributeArtifact(this);
		}




        private Timer m_Timer;

        public override bool IsScaredOfScaryThings { get { return false; } }
        public override bool IsScaryToPets { get { return false; } }

        [Constructable]
        public RainbowBigBoss() : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "RainbowBigBoss";
            Hue = 1616;
	    Body = 12;
            BaseSoundID = 362;

            SetStr(1500);//Adjust this to fit your shard.
            SetDex(1000);//Adjust this to fit your shard.
            SetInt(1000);//Adjust this to fit your shard.

            SetHits(20000);//Adjust this to fit your shard.

            SetDamage(18, 29);//Adjust this to fit your shard.

            SetDamageType(ResistanceType.Energy, 100);//Adjust this to fit your shard.

            SetResistance(ResistanceType.Physical, 50);//Adjust this to fit your shard.
            SetResistance(ResistanceType.Fire, 50);//Adjust this to fit your shard.
            SetResistance(ResistanceType.Poison, 50);//Adjust this to fit your shard.
            SetResistance(ResistanceType.Energy, 50);//Adjust this to fit your shard.
            SetResistance(ResistanceType.Cold, 40);//Adjust this to fit your shard.

            SetSkill(SkillName.EvalInt, 100);//Adjust this to fit your shard.
            SetSkill(SkillName.Tactics, 100);//Adjust this to fit your shard.
            SetSkill(SkillName.MagicResist, 100);//Adjust this to fit your shard.
            SetSkill(SkillName.Wrestling, 100);//Adjust this to fit your shard.
            SetSkill(SkillName.Meditation, 100);//Adjust this to fit your shard.
            SetSkill(SkillName.Focus, 100);//Adjust this to fit your shard.
            SetSkill(SkillName.Magery, 112);//Adjust this to fit your shard.

            Fame = 2500;//Adjust this to fit your shard.
            Karma = -2500;//Adjust this to fit your shard.

            VirtualArmor = 50;//Adjust this to fit your shard.

            PackGold(10000);//You can change the gold to your shard here...
            PackItem( new MasterCoin( 10 ) );
            
            //m_Timer = new TeleportTimer(this);
            //m_Timer.Start();
        }

        public override bool CanRummageCorpses { get { return false; } }
        public override bool BardImmune { get { return false; } }
        public override bool Unprovokable { get { return false; } }
        public override bool Uncalmable { get { return false; } }
        public override Poison PoisonImmune { get { return Poison.Lesser; } }
        public override bool AlwaysMurderer { get { return true; } }

            
        private class TeleportTimer : Timer
        {
            private Mobile m_Owner;

            private static int[] m_Offsets = new int[]
			{
				-1, -1,
				-1,  0,
				-1,  1,
				0, -1,
				0,  1,
				1, -1,
				1,  0,
				1,  1
			};

            public TeleportTimer(Mobile owner) : base(TimeSpan.FromSeconds(5.0), TimeSpan.FromSeconds(5.0))
            {
                m_Owner = owner;
            }

            protected override void OnTick()
            {
                if (m_Owner.Deleted)
                {
                    Stop();
                    return;
                }

                Map map = m_Owner.Map;

                if (map == null)
                    return;

                if (0.25 < Utility.RandomDouble())
                    return;

                Mobile toTeleport = null;

                foreach (Mobile m in m_Owner.GetMobilesInRange(16))
                {
                    if (m != m_Owner && m.Player && m_Owner.CanBeHarmful(m) && m_Owner.CanSee(m))
                    {
                        toTeleport = m;
                        break;
                    }
                }

                if (toTeleport != null)
                {
                    int offset = Utility.Random(8) * 2;

                    Point3D to = m_Owner.Location;

                    for (int i = 0; i < m_Offsets.Length; i += 2)
                    {
                        int x = m_Owner.X + m_Offsets[(offset + i) % m_Offsets.Length];
                        int y = m_Owner.Y + m_Offsets[(offset + i + 1) % m_Offsets.Length];

                        if (map.CanSpawnMobile(x, y, m_Owner.Z))
                        {
                            to = new Point3D(x, y, m_Owner.Z);
                            break;
                        }
                        else
                        {
                            int z = map.GetAverageZ(x, y);

                            if (map.CanSpawnMobile(x, y, z))
                            {
                                to = new Point3D(x, y, z);
                                break;
                            }
                        }
                    }

                    Mobile m = toTeleport;

                    Point3D from = m.Location;

                    m.Location = to;

                    Server.Spells.SpellHelper.Turn(m_Owner, toTeleport);
                    Server.Spells.SpellHelper.Turn(toTeleport, m_Owner);

                    m.ProcessDelta();

                    Effects.SendLocationParticles(EffectItem.Create(from, m.Map, EffectItem.DefaultDuration), 0x3709, 1, 30, 9904, 1108);
                    Effects.SendLocationParticles(EffectItem.Create(to, m.Map, EffectItem.DefaultDuration), 0x3709, 1, 30, 9904, 1108);

                    m.PlaySound(0x1FE);

                    m_Owner.Combatant = toTeleport;
                    m_Owner.PrivateOverheadMessage(MessageType.Regular, 1153, false, "AHHHHH!!!! Help me!!!", m_Owner.NetState);
                }
            }
        }


        public RainbowBigBoss(Serial serial) : base(serial)
        {
        }
        


        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }
        private BaseCreature bc;
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        
        }
    }
}
