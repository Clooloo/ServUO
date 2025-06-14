using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a skeletal corpse")]
    public class mrbones : BaseCreature
    {
		
		private static bool m_Talked; // flag to prevent spam 

        string[] kfcsay = new string[] // things to say while greeting 
        { 

           //human Greetings
		   "Beware! Beware!",
		   "Turn back while you still can",
		   "The Witches wish to dine with you as supper!",
		   "Enter if you wish to join the army of the Undead"/*,
		   
		   
		   //Farewells
		   "Until we meet again.",
		   "Farwell!",
		   
		   //Compliments
		   "You are a mighty warrior!",
		   "You did well!",
		   "Your beauty shines bright!",
		   
		   //Insults
		   "Cowardly dog!",
		   "You smell like an orc!",
		   "Thou art a windbag!",
		   "You're ugly and your mother dresses you funny!",
		   
		   //Questions
		   "Do you need help?",
		   "Do you yield?",
		   "Is there trouble?",*/

		   //Class Sayings
		   /* "Beware of the unseen.", 
           "Best watch your back.",
           "I smell war on the wind.",          
           "Stop! One step closer and you shall taste of my blade!",
           "I'll come at you like a westward wind!", */
        };
		
        [Constructable]
        public mrbones()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.Name = "Mr. Bones";
            this.Body = Utility.RandomList(50, 56);
            this.BaseSoundID = 0x48D;
			
			this.CantWalk = true;
            this.SetStr(56, 80);
            this.SetDex(56, 75);
            this.SetInt(16, 40);

            this.SetHits(34, 48);

            this.SetDamage(3, 7);

            this.SetDamageType(ResistanceType.Physical, 100);

            this.SetResistance(ResistanceType.Physical, 15, 20);
            this.SetResistance(ResistanceType.Fire, 5, 10);
            this.SetResistance(ResistanceType.Cold, 25, 40);
            this.SetResistance(ResistanceType.Poison, 25, 35);
            this.SetResistance(ResistanceType.Energy, 5, 15);

            this.SetSkill(SkillName.MagicResist, 45.1, 60.0);
            this.SetSkill(SkillName.Tactics, 45.1, 60.0);
            this.SetSkill(SkillName.Wrestling, 45.1, 55.0);

            this.Fame = 450;
            this.Karma = -450;

            this.VirtualArmor = 16;

            switch ( Utility.Random(5))
            {
                case 0:
                    this.PackItem(new BoneArms());
                    break;
                case 1:
                    this.PackItem(new BoneChest());
                    break;
                case 2:
                    this.PackItem(new BoneGloves());
                    break;
                case 3:
                    this.PackItem(new BoneLegs());
                    break;
                case 4:
                    this.PackItem(new BoneHelm());
                    break;
            }
        }

		public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            if (m_Talked == false)
            {
                if (m.InRange(this, 7))
                {
					m.PublicOverheadMessage(Network.MessageType.Emote, m.SpeechHue, true, "* rattles bones *");
					m.PublicOverheadMessage(Network.MessageType.Emote, m.SpeechHue, true, "* laughter *");
                    m_Talked = true;
                    SayRandom(kfcsay, this);

                    this.Move(GetDirectionTo(m.Location));

                    // Start timer to prevent spam 
                    SpamTimer t = new SpamTimer();
                    t.Start();
                }
            }
        }

        private class SpamTimer : Timer
        {

            public SpamTimer()
                : base(TimeSpan.FromSeconds(8))
            {

                Priority = TimerPriority.OneSecond;

            }

            protected override void OnTick()
            {

                m_Talked = false;

            }
        }

        private static void SayRandom(string[] say, Mobile m)
        {

            m.Say(say[Utility.Random(say.Length)]);

        }
		
        public mrbones(Serial serial)
            : base(serial)
        {
        }

        public override bool BleedImmune
        {
            get
            {
                return true;
            }
        }
        public override Poison PoisonImmune
        {
            get
            {
                return Poison.Lesser;
            }
        }

        public override TribeType Tribe { get { return TribeType.Undead; } }

         public override OppositionGroup OppositionGroup
        {
            get
            {
                return OppositionGroup.FeyAndUndead;
            }
        }
        
        public override bool IsEnemy(Mobile m)
        {
            if(Region.IsPartOf("Haven Island"))
            {
                return false;
            }
            
            return base.IsEnemy(m);
        }
        
       public override void GenerateLoot()
        {
            this.AddLoot(LootPack.Poor);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
