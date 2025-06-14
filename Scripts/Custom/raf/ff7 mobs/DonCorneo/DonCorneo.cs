//Customized By Mrs Death
using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( " corpse of Don Corneo" )]
	public class DonCorneo : BaseCreature
	{
		public override bool ClickTitle{ get{ return false; } }
		
		[Constructable]
		public DonCorneo() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{

			Hue = Utility.RandomSkinHue();

				Body = 400;
				Name = "Don Corneo";
			

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

	    PlateChest Weapon = new PlateChest();
            Weapon.Hue = 1933;
            Weapon.Movable = false;
            AddItem(Weapon);

            PlateChest chest = new PlateChest();
            chest.Hue = 1933;
            chest.Movable = false;
            AddItem(chest);

            PlateArms arms = new PlateArms();
            arms.Hue = 1933;
            arms.Movable = false;
            AddItem(arms);

            PlateGloves gloves = new PlateGloves();
            gloves.Hue = 1933;
            gloves.Movable = false;
            AddItem(gloves);

            PlateGorget gorget = new PlateGorget();
            gorget.Hue = 1933;
            gorget.Movable = false;
            AddItem(gorget);

            PlateHelm helm = new PlateHelm();
            helm.Hue = 1933;
            helm.Movable = false;
            AddItem(helm);

            PlateLegs legs = new PlateLegs();
            legs.Hue = 1933;
            legs.Movable = false;
            AddItem(legs);

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
                case 0: PackItem(new VincentChest()); break;
                case 1: PackItem(new VincentLegs()); break;
                case 2: PackItem(new VincentArms()); break;
                case 3: PackItem(new VincentGloves()); break;
                case 4: PackItem(new VincentGorget()); break;
		case 5: PackItem(new VincentHelm()); break;
		case 6: PackItem(new VincentBow()); break;
            }

            return base.OnBeforeDeath();
        }
        public DonCorneo(Serial serial)
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