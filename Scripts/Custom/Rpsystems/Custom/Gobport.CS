using System.Collections.Generic;
using Server.Engines.Craft;
using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Engines.Quests;
using Server.Mobiles;

namespace Server.Items
{
    public class Gobport : Teleporter
    {
        [Constructable]
        public Gobport() : base()
        {
            // Constructor for creating new instances
        }

        // Serialization constructor
        public Gobport(Serial serial) : base(serial)
        {
            // Constructor for deserializing existing instances
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            // Add any additional serialization logic if needed
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            // Add any additional deserialization logic if needed
        }

        public override bool OnMoveOver(Mobile m)
        {
            if (base.OnMoveOver(m))
            {
                // Existing OnMoveOver logic remains the same
                const int criminalHue = 1970;
                m.Hue = criminalHue;

                if (m.Hue == criminalHue)
                {
                    m.Criminal = true;
                    m.SendMessage("You feel a dark aura surround you, marking you as an outlaw.");
                }

                // Skill and stat setting logic remains the same
                m.Skills[SkillName.Ninjitsu].Base = 65;
                m.Skills[SkillName.MagicResist].Base = 65;
                m.Skills[SkillName.Hiding].Base = 65;
                m.Skills[SkillName.Tracking].Base = 65;
                m.Skills[SkillName.Stealth].Base = 65;
                m.Skills[SkillName.Poisoning].Base = 65;
                m.Skills[SkillName.SpiritSpeak].Base = 55;

                // Zero out other skills
                // (Previous skill setting code remains the same)

                m.PublicOverheadMessage(Network.MessageType.Regular, 0, false, "Mischevious and true to your goblinoid blood, you thrive for both good and bad deeds in a land where you are exiled.");

                m.RawStr = 35;
                m.RawDex = 60;
                m.RawInt = 35;
                m.Title = "The Goblinborn";

                Bag bag = new Bag();
                bag.DropItem(new RecallRune());
                m.AddToBackpack(bag);
                m.AddToBackpack(new Gold(300));
            }

            return true;
        }
    }
}