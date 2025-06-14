using System;
using Server;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{

	public class PetDeedsDeed : Item
	{

		[Constructable]
		public PetDeedsDeed () : this( null )
		{
		}

		[Constructable]
		public PetDeedsDeed ( string name ) : base ( 0x14F0 )
		{
			Name = "Random Hero Artifact Prize Ticket";
			Hue = 268;
		}

		public PetDeedsDeed ( Serial serial ) : base ( serial )
		{
		}
		
		 private static Type[] m_ArtifactRarity11 = new Type[]
            {
				typeof( PetColdlResistanceBonusPotion ),
				typeof( PetControlSlotsBonusPotion ),
				typeof( PetDamageMaxBonusPotion ),
				typeof( PetDamageMinBonusPotion ),
				typeof( PetEnergyResistanceBonusPotion ),
				typeof( PetFireResistanceBonusPotion ),
				typeof( PetHitsPointBonusPotion ),
				typeof( PetManaPointBonusPotion ),
				typeof( PetPhysicalResistanceBonusPotion ),
				typeof( PetPoisonResistanceBonusPotion ),
				typeof( PetStamPointBonusPotion )
            };
		
			

      		public override void OnDoubleClick( Mobile from ) 
      		{
			if ( !IsChildOf( from.Backpack ) )
			{
                from.SendLocalizedMessage(1042001);
            }
            else
            {
				double chance = Utility.RandomDouble();
				  if (chance < 1.0) // 300% chance for drop
            {
                from.AddToBackpack(Loot.Construct(m_ArtifactRarity11[Utility.Random(m_ArtifactRarity11.Length)]));
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