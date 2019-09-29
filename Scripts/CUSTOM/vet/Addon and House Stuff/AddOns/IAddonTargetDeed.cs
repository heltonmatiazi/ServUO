namespace Server.Items
{
	public interface IAddonTargetDeed
	{
		int TargetLocalized { get; }

		void Placement_OnTarget( Mobile from, object targeted, object state );
	}
}
