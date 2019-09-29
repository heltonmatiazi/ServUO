/*
**	Tasslehoff's Ring of many places Version 1.0			© 3-15-2004
**
**	(Special RunUO Subscriber version - DO NOT Re-Distribute)
**
**				Credits:
**
**	Scripted by: KillerBeeZ for the Pandora shard @ www.CTlinx.org/uo
**	you may use this script as long as you leave this header in tact
**
**				Description:
**
**	A Ring that when worn and doubleclicked will take players to one
**	of 31 places in Trammel (replace Trammel with Trammel if you desire)
**	(9 Shrines, 15 Towns, and 7 Dungeons)
**
**	The ring has one use then it is deleted
**
**	I didn't label them so your going to have to figure out which is which,
**	although the Shrines are 1st, then the Dungeons I believe.
**
**	!IF you use a custom map, please change the locations!
**
**				Instructions
**
**	In Game
**	[add TasslehoffsRing
**
**	In Script
**	AddItem( new TasslehoffsRing() );
**
**				Notes
**
**	I will offer support for this script as long as you are running a
**	clean copy of RunUO b36. I will try to help you with any custom scripts
**	but I cannot spend much time supporting other peoples scripts.
**	Support Email: KillerBeeZ@CTlinx.org
*/

using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Gumps;
using Server.Misc;
using Server.Engines.VeteranRewards;

namespace Server.Items
{
    public class TasslehoffsRing : BaseRing, IRewardItem
	{

		public override int ArtifactRarity{ get{ return 1337; } }
        private bool m_IsRewardItem;

        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }
		[Constructable]
		public TasslehoffsRing() : base( 0x108a )
		{
			Weight = 0.1;
			Name = "Tasslehoff's Ring of many places";
			Hue = 2;
                        //Identified = true;
			LootType = LootType.Blessed;
			SkillBonuses.SetValues( 0, SkillName.Hiding, 10.0 );
			SkillBonuses.SetValues( 1, SkillName.Stealth, 10.0 );

			switch ( Utility.Random( 5 ))
			{
			case 0:
			Attributes.Luck = 10;
			break;

			case 1:
			Attributes.Luck = 25;
			break;

			case 2:
			Attributes.Luck = 50;
			break;

			case 3:
			Attributes.Luck = 75;
			break;

			case 4:
			Attributes.Luck = 100;
			break;
			}
		}
        public override bool OnEquip(Mobile from)
        {
            if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
            {
                from.SendMessage("This does not belong to you!!");
                return false;
            }
            
            return base.OnEquip(from);
        }
		public TasslehoffsRing( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( Parent != from )
			{
			from.SendMessage( 22, "You must equip this item to use it." );
			}
			else
			{
				switch ( Utility.Random( 31 ))
				{
				case 0:
				from.Location = ( new Point3D( 1456, 854, 0 ));
				from.Map = Map.Felucca;
				break;

				case 1:
				from.Location = ( new Point3D( 1856, 872, -1));
				from.Map = Map.Felucca;
				break;

				case 2:
				from.Location = ( new Point3D( 4217, 564, 36));
				from.Map = Map.Felucca;
				break;

				case 3:
				from.Location = ( new Point3D( 1730, 3528, 3));
				from.Map = Map.Felucca;
				break;

				case 4:
				from.Location = ( new Point3D( 4276, 3699, 0));
				from.Map = Map.Felucca;
				break;

				case 5:
				from.Location = ( new Point3D( 1301, 639, 16));
				from.Map = Map.Felucca;
				break;

				case 6:
				from.Location = ( new Point3D( 3355, 299, 9));
				from.Map = Map.Felucca;
				break;

				case 7:
				from.Location = ( new Point3D( 1589, 2485, 5));
				from.Map = Map.Felucca;
				break;

				case 8:
				from.Location = ( new Point3D( 2496, 3932, 0));
				from.Map = Map.Felucca;
				break;

				case 9:
				from.Location = ( new Point3D( 2043, 238, 10));
				from.Map = Map.Felucca;
				break;

				case 10:
				from.Location = ( new Point3D( 514, 1561, 0));
				from.Map = Map.Felucca;
				break;

				case 11:
				from.Location = ( new Point3D( 4721, 3822, 0));
				from.Map = Map.Felucca;
				break;

				case 12:
				from.Location = ( new Point3D( 1176, 2637, 0));
				from.Map = Map.Felucca;
				break;

				case 13:
				from.Location = ( new Point3D( 1298, 1080, 0));
				from.Map = Map.Felucca;
				break;

				case 14:
				from.Location = ( new Point3D( 4111, 432, 5));
				from.Map = Map.Felucca;
				break;

				case 15:
				from.Location = ( new Point3D( 2499, 919, 0));
				from.Map = Map.Felucca;
				break;

				case 16:
				from.Location = ( new Point3D( 1323, 1624, 55));
				from.Map = Map.Felucca;
				break;

				case 17:
				from.Location = ( new Point3D( 2285, 1209, 0));
				from.Map = Map.Felucca;
				break;

				case 18:
				from.Location = ( new Point3D( 1398, 3742, -21));
				from.Map = Map.Felucca;
				break;

				case 19:
				from.Location = ( new Point3D( 3792, 2248, 20));
				from.Map = Map.Felucca;
				break;

				case 20:
				from.Location = ( new Point3D( 2539, 501, 30));
				from.Map = Map.Felucca;
				break;

				case 21:
				from.Location = ( new Point3D( 4442, 1122, 5));
				from.Map = Map.Felucca;
				break;

				case 22:
				from.Location = ( new Point3D( 3728, 1360, 5));
				from.Map = Map.Felucca;
				break;

				case 23:
				from.Location = ( new Point3D( 535, 992, 0));
				from.Map = Map.Felucca;
				break;

				case 24:
				from.Location = ( new Point3D( 1362, 896, 0));
				from.Map = Map.Felucca;
				break;

				case 25:
				from.Location = ( new Point3D( 2882, 788, 0));
				from.Map = Map.Felucca;
				break;

				case 26:
				from.Location = ( new Point3D( 1927, 2779, 0));
				from.Map = Map.Felucca;
				break;

				case 27:
				from.Location = ( new Point3D( 639, 2236, -3));
				from.Map = Map.Felucca;
				break;

				case 28:
				from.Location = ( new Point3D( 3011, 3526, 15));
				from.Map = Map.Felucca;
				break;

				case 29:
				from.Location = ( new Point3D( 3650, 2653, 0));
				from.Map = Map.Felucca;
				break;

				case 30:
				from.Location = ( new Point3D( 5769, 3176, 0));
				from.Map = Map.Felucca;
				break;
				}

			//this.Delete();

			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
            writer.Write((bool)m_IsRewardItem);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
            m_IsRewardItem = reader.ReadBool();
		}
	}
}
