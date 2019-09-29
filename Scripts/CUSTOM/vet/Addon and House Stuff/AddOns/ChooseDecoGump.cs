using Server.Items;
using Server.Network;

namespace Server.Gumps
{
	public class ChooseDecoGump : Gump
	{
		private IAddonTargetDeed m_Deed;
		private int m_Pages;
		private int m_Start;
		private int m_End;
		private string m_Type;

		public ChooseDecoGump( IAddonTargetDeed deed, int page, int start, int end, string type ) : base( 150, 50 )
		{
			Closable = false;

			m_Deed = deed;
			m_Start = start;
			m_End = end;
			m_Type = type;
			int length = (end - start) / 2;
			m_Pages = (int)System.Math.Ceiling((double)length / 8);

			AddBackground( 0, 0, 500, 230, 2600 );

			AddLabel( 45, 15, 1152, "Choose a " + type + ":" );

			for (int j = 0; j < 8; j++)
			{
				if (page * 8 + j > length)
					break;

				AddButton( 30 + 60 * j, 50, 2117, 2118, start + 2 * j + page * 16, GumpButtonType.Reply, 0 );
				AddItem( 15 + 60 * j, 70, start + 2 * j + page * 16 );
			}

			if (8 + page * 8 < length )
				AddButton( 430, 200, 2224, 2224, page + 1, GumpButtonType.Reply, 0 );
			if (page > 0)
				AddButton( 50, 200, 2223, 2223, page - 1, GumpButtonType.Reply, 0 );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if (info.ButtonID < m_Pages)
			{
				sender.Mobile.CloseGump( typeof( ChooseDecoGump ) );
				sender.Mobile.SendGump( new ChooseDecoGump( m_Deed, info.ButtonID, m_Start, m_End, m_Type ) );
			}
			else if (info.ButtonID >= m_Start && info.ButtonID <= m_End)
				sender.Mobile.SendGump( new DecoFacingGump( m_Deed, info.ButtonID ) );
		}
	}
}
