using System;
using Server;

namespace Server.Items
{
	public class NecklaceOfGenesis : BaseNecklace
	{
		
		public override int ArtifactRarity{ get{ return 1000; } }
                 
                [Constructable]

		public NecklaceOfGenesis() : base( 0x1085 ) 
		{
			Weight = 1.0; 
            		Name = "Necklace Of Genesis"; 
            		Hue = 2561;

			Attributes.AttackChance = 15;
			Attributes.BonusHits = 50;
			Attributes.DefendChance = 15;
			Attributes.ReflectPhysical = 10;
			Attributes.WeaponDamage = 25;
			Attributes.SpellDamage = 25;
            Attributes.RegenHits = 5;
			Attributes.RegenMana = 5;
			
		}

		public override void OnAdded( object parent )
		{
			base.OnAdded( parent );
			if( parent is Mobile )
			{
				Mobile from = (Mobile)parent;	
				from.Skills.Swords.Base += 20;
				from.Skills.Fencing.Base += 20;
				from.Skills.Throwing.Base += 30;
				from.Skills.Macing.Base += 20;
				from.Skills.Archery.Base += 30;				
                from.Skills.Tactics.Base += 20;
                from.Skills.Magery.Base += 20; 
                from.Skills.EvalInt.Base += 20;
                from.Skills.Necromancy.Base += 20;
                from.Skills.SpiritSpeak.Base += 20;
                from.Skills.MagicResist.Base += 20;  
			}
		}
		public override void OnRemoved( object parent )
		{
			base.OnRemoved( parent );
			if( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.Skills.Swords.Base -= 20;
				from.Skills.Fencing.Base -= 20;
				from.Skills.Throwing.Base -= 30;
				from.Skills.Macing.Base -= 20;
				from.Skills.Archery.Base -= 30;					
                from.Skills.Tactics.Base -= 20;
                from.Skills.Magery.Base -= 20; 
                from.Skills.EvalInt.Base -= 20;
                from.Skills.Necromancy.Base -= 20;
                from.Skills.SpiritSpeak.Base -= 20;
                from.Skills.MagicResist.Base -= 20;
			}
			
		}

		public NecklaceOfGenesis( Serial serial ) : base( serial )
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
