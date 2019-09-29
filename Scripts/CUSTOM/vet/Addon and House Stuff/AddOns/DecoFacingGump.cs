using Server.Items;
using Server.Network;
using Server.Targeting;

namespace Server.Gumps
{
	public class DecoFacingGump : Gump
	{
		private IAddonTargetDeed m_Deed;
		private int m_ID;

		public DecoFacingGump( IAddonTargetDeed deed, int id ) : base( 150, 50 )
		{
			m_Deed = deed;
			m_ID = id;
			Closable = false;

			AddBackground( 0, 2, 300, 150, 2600 );
			AddButton( 50, 40, 2151, 2153, m_ID + 1, GumpButtonType.Reply, 0 );
			AddItem( 90, 35, m_ID + 1 );
			AddButton( 150, 40, 2151, 2153, m_ID, GumpButtonType.Reply, 0 );
			AddItem( 180, 35, m_ID );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if (info.ButtonID < m_ID || info.ButtonID > m_ID + 1)
				return;

			sender.Mobile.SendLocalizedMessage( m_Deed.TargetLocalized );
			sender.Mobile.BeginTarget( -1, true, TargetFlags.None, new TargetStateCallback( m_Deed.Placement_OnTarget ), info.ButtonID );
		}
	}
}