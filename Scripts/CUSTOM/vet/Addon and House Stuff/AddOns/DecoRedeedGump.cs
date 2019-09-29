using Server.Network;
using Server.Items;

namespace Server.Gumps
{
    public class DecoRedeedGump : Gump
    {
        private IAddon m_Addon;

        public DecoRedeedGump(IAddon addon) : base(150, 50)
        {
            m_Addon = addon;

            AddBackground(0, 0, 220, 170, 0x13BE);
            AddBackground(10, 10, 200, 150, 0xBB8);
			if (addon is Banner)
				AddHtmlLocalized( 20, 30, 180, 60, 1018318, false, false ); // Do you wish to re-deed this banner?
			else if (addon is FlamingHead)
				AddHtmlLocalized( 20, 30, 180, 60, 1018329, false, false ); // Do you wish to re-deed this skull?
			else
				AddHtmlLocalized( 20, 30, 180, 60, 1062839, false, false ); // Do you wish to re-deed this decoration?
            AddHtmlLocalized(55, 100, 160, 25, 1011011, false, false); // CONTINUE
            AddButton(20, 100, 0xFA5, 0xFA7, 1, GumpButtonType.Reply, 0);
            AddHtmlLocalized(55, 125, 160, 25, 1011012, false, false); // CANCEL
            AddButton(20, 125, 0xFA5, 0xFA7, 0, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Item item = m_Addon as Item;
            if (item == null || item.Deleted)
                return;

            if (info.ButtonID == 1)
            {
                if (sender.Mobile.InRange(item.GetWorldLocation(), 3))
                {
					sender.Mobile.AddToBackpack( m_Addon.Deed );
                    item.Delete();
                }
                else
                {
					sender.Mobile.SendLocalizedMessage( 500295 ); // You are too far away to do that.
                }
            }
        }
    }
}
