//Customized By Mrs Death
using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	public class Rufus : BaseCreature
	{
		public override bool ClickTitle{ get{ return false; } }

		[Constructable]
		public Rufus() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{

			Hue = Utility.RandomSkinHue();

				Body = 400;
				Name = "Rufus";
			

			SetStr( 306, 450 );
			SetDex( 201, 215 );
			SetInt( 351, 485 );

            		SetHits(2500, 5000);
			SetDamage( 15, 25 );

			SetSkill( SkillName.MagicResist, 85.0, 97.5 );
			SetSkill( SkillName.Swords, 99.0, 117.5 );
			SetSkill( SkillName.Tactics, 95.0, 107.5 );
			SetSkill( SkillName.Wrestling, 95.0, 107.5 );

			Fame = 1000;
			Karma = -1000;

            Doublet chest = new Doublet();
            chest.Hue = 1150;
            chest.Movable = false;
            AddItem(chest);

            LeatherNinjaPants legs = new LeatherNinjaPants();
            legs.Hue = 1150;
            legs.Movable = false;
            AddItem(legs);

            Cloak cloak = new Cloak();
            cloak.Hue = 1150;
            cloak.Movable = false;
            AddItem(cloak);


            new Nightmare().Rider = this;
			

			Utility.AssignRandomHair( this );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 2 );
		}

		public override bool AlwaysMurderer{ get{ return true; } }

                public override bool OnBeforeDeath()
        {
            IMount mount = this.Mount;
            if (mount != null)
            {
                mount.Rider = null;

                if (mount is Mobile) ((Mobile)mount).Delete();
            }
                      switch (Utility.Random(50))
            {
                case 0: PackItem(new ZackChest()); break;
                case 1: PackItem(new ZackPants()); break;
                case 2: PackItem(new ZackCloak()); break;
                case 3: PackItem(new ZackBoots()); break;
                case 4: PackItem(new ZackBlade()); break;
            }

            return base.OnBeforeDeath();
        }
        public Rufus(Serial serial)
            : base(serial)
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