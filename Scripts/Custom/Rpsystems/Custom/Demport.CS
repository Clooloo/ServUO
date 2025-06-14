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
    public class Demport : Teleporter
    {
        [Constructable]
        public Demport() : base()
        {
            // Constructor for creating new instances
        }

        // Serialization constructor
        public Demport(Serial serial) : base(serial)
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
                const int criminalHue = 1157;
                m.Hue = criminalHue;

                if (m.Hue == criminalHue)
                {
                    m.Criminal = true;
                    m.SendMessage("You feel a dark aura surround you, marking you as an outlaw.");
                }

                // Set specific skills to 65 or non-zero
                m.Skills[SkillName.Mysticism].Base = 65;
                m.Skills[SkillName.Focus].Base = 65;
                m.Skills[SkillName.Necromancy].Base = 65;
                m.Skills[SkillName.MagicResist].Base = 65;
                m.Skills[SkillName.Hiding].Base = 65;
                m.Skills[SkillName.Tracking].Base = 65;
                m.Skills[SkillName.SpiritSpeak].Base = 65;

                // Zero out other skills
                // (Previous skill setting code remains the same)

                m.PublicOverheadMessage(Network.MessageType.Regular, 0, false, "There is destructive power through your veins, everything involving a blast or control over a battlefield is far from unknown to you.");

                m.RawStr = 50;
                m.RawDex = 30;
                m.RawInt = 55;
                m.Title = "The Demonborn";

                Bag bag = new Bag();
                bag.DropItem(new RecallRune());
                m.AddToBackpack(bag);
                m.AddToBackpack(new Gold(600));
            }

            return true;
        }
    }
}