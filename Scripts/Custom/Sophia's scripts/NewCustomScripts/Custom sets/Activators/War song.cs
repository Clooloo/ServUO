using System;
using System.Collections;
using Server;
using Server.Prompts;
using Server.Mobiles;
using Server.Network;
using Server.Gumps;
using Server.Items;
using Server.Engines.VeteranRewards;
 
namespace Server.Items
{
    public class WarSong : Item
    {

        [Constructable]
        public WarSong() : base( 0x2AAA )
        {
            Movable = true;
            Hue = 1387;
            Weight = 25.0;
            Name = "War Song Set";
        }
        public override void GetProperties(ObjectPropertyList list)
            {
 
            base.GetProperties(list);
            
            list.Add("Feel the power of the music.");
            }
       
        public override void OnDoubleClick( Mobile from )
        {
            //if (from.Race == Race.Human)
            //{  
                Item EquipArmor1 = from.FindItemOnLayer(Layer.Pants);
                Item EquipArmor2 = from.FindItemOnLayer(Layer.Gloves);
                Item EquipArmor3 = from.FindItemOnLayer(Layer.InnerTorso);
                Item EquipArmor4 = from.FindItemOnLayer(Layer.Arms);   
                //Item EquipArmor5 = from.FindItemOnLayer(Layer.Neck);
                Item EquipArmor5 = from.FindItemOnLayer(Layer.Helm);
                //Item EquipArmor7 = from.FindItemOnLayer(Layer.Cloak);//Layer.Cloak
               
 
                if (EquipArmor1 is BardLegs || EquipArmor2 is BardGloves || EquipArmor3 is BardChest ||
                    EquipArmor4 is BardArms || EquipArmor5 is BardHelm)
                {
                	
                    //from.LocalOverheadMessage(MessageType.Emote, 0x59, true, "You remove the armor! ");
                    EquipArmor1.Delete();
                    EquipArmor2.Delete();
                    EquipArmor3.Delete();
                    EquipArmor4.Delete();
                    EquipArmor5.Delete();
                    //EquipArmor6.Delete();
                    //EquipArmor7.Delete();
                    from.Skills.Discordance.Base -= 10;
                    from.Skills.Peacemaking.Base -= 10;
                    from.Skills.Musicianship.Base -= 10;
                    from.RawInt -= 30;
                    return;
                }
                else if (EquipArmor1 is LegsOfBaal || EquipArmor1 is WorkerLegs || EquipArmor1 is NaturalLegs || EquipArmor1 is RigorLegs)
                {
                from.LocalOverheadMessage(MessageType.Emote, 0x59, true, "Please remove the current armor set first.");
                return;
                }
                else if ( !IsChildOf( from.Backpack ) )
      {
      from.SendLocalizedMessage(1042001);
      return;
      }
                
               
                if (EquipArmor1 != null)              
                    from.AddToBackpack(EquipArmor1);
               
                if (EquipArmor2 != null)
                    from.AddToBackpack(EquipArmor2);
               
                if (EquipArmor3 != null)
                    from.AddToBackpack(EquipArmor3);
               
                if (EquipArmor4 != null)
                    from.AddToBackpack(EquipArmor4);

                 if (EquipArmor5 != null)
                    from.AddToBackpack(EquipArmor5);

                 /*if (EquipArmor6 != null)
                    from.AddToBackpack(EquipArmor6);

                if (EquipArmor7 != null)
                    from.AddToBackpack(EquipArmor7);*/
       

                //from.LocalOverheadMessage(MessageType.Emote, 0x59, true, "You feel the power of Baal on your hands! ");
                
                
                
                from.EquipItem(new BardLegs());
                from.EquipItem(new BardGloves());
                from.EquipItem(new BardChest());
                from.EquipItem(new BardArms());
                //from.EquipItem(new GorgetOfBaal());
                from.EquipItem(new BardHelm());
                //from.EquipItem(new Baalcloak());
                //from.RawStr += 30;
                from.RawInt += 30;
                from.Skills.Discordance.Base += 10;
                from.Skills.Peacemaking.Base += 10;
                from.Skills.Musicianship.Base += 10;
                
                
 
            
        }
   

     
        
        public WarSong( Serial serial ) : base( serial )
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