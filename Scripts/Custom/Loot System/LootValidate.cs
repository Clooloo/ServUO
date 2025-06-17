using System;
using System.Collections;
using Server.Items;
using Server.Misc;

namespace Server.Mobiles
{
	public class ArtifactValidate
	{
		private static int multip = 1;
		private static float percent = 1;

		public static void ArtiChance(Mobile m, BaseCreature bc)
		{
			int karma = Math.Abs( bc.Karma );
			int fame = bc.Fame;
			int hits = bc.HitsMax;
			int stam = bc.StamMax;
			int mana = bc.ManaMax;

			float artichance = multip*( 15*(hits+stam+mana) / 5500);
            			
			if( artichance > 30 )  
			artichance = 30;
			artichance -= 0;
			if( artichance < 0 )
			artichance = 0;              
			percent = artichance/100;
			//m.SendMessage( "You have a {0}% chance of receiving a special Item from this creature.", percent*100);

		}
		public static void GiveArtifact(BaseCreature bc)
		{

//Begin Artifact Randomness
			if ( percent > Utility.RandomDouble() ) // 0.3 = 30% = chance to drop

			bc.PackItem(ArtifactList.RandomArtifact());
			
		}
		public static void MultiP(int size)
		{
			multip = size;
		}
	}
}
