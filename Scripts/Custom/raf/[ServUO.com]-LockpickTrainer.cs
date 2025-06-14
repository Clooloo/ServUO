using System;
using System.Collections;
using Server.Multis;
using Server.Mobiles;
using Server.Network;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.Items
{
    public class LockpickTrainer : LockableContainer
    {
        private const string m_LockPickStr1 = "Lockpick Trainer, Double click to set for your skill level.";

        [Constructable]
        public LockpickTrainer(): base(0x9AA)
        {
            Locked = true;
            LockLevel = 10;
            RequiredSkill = 10;
            Weight = 4.0;
            EngravedText = m_LockPickStr1;
        }
		
		public override void AddNameProperties(ObjectPropertyList list)
        {
            base.AddNameProperties(list);
            list.Add(m_LockPickStr1);
        }

        public override void OnSingleClick(Mobile from)
        {
            base.OnSingleClick(from);
            this.LabelTo(from, m_LockPickStr1);
        }
		
		public override void Open(Mobile from)
		{
          // EM 2019.01.11 If the EngravedText equals the Constant String then this is dynamic else do nothing
          // EM 2019.01.14 Eased up on the content of the Engraved text to "" or not ""
            if (this.EngravedText != "") // It may need a check for null ...
            {
               double lockpicking = from.Skills[SkillName.Lockpicking].Value;
               int level = (int)(lockpicking + 15.0); // EM 2019.01.11 Keep it small to slow the process down
               if (level > 135) level = 135;
               this.RequiredSkill = (int)lockpicking;
               this.LockLevel = this.RequiredSkill;
               this.MaxLockLevel = level;
               if (this.LockLevel == 0) this.LockLevel = -1; // EM 2019.01.11 Not sure this is needed.
               from.SendMessage("This chest has been set for " + lockpicking + " lockpicking skill!");
            }
		}
		
		public override void LockPick(Mobile from)
        {
            this.Locked = true;
            from.SendMessage("The container magically relocks it self.");
        }
        public LockpickTrainer(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
