using System;
using Server.Network;
using Server.Items;
using Server.Engines.VeteranRewards;

namespace Server.Items
{
    public class Charm : Item, IRewardItem
	{
		private static bool isactive = false;

        private bool m_IsRewardItem;
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }

		[Constructable]
		public Charm() : base( 0xE73 )
		{
			Weight = 1.0;
			Name = "Magical Charm";
		}
		
		public override bool OnDroppedInto( Mobile from, Container target, Point3D p )
		{
            if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
            {
                from.SendMessage("This does not belong to you!!");
                return false;
            }
            else
            {
                string modName = from.Serial.ToString();
                if (target == from.Backpack || target.IsChildOf(from.Backpack))
                {
                    from.AddStatMod(new StatMod(StatType.Str, modName + "CharmStr", 10, TimeSpan.Zero));
                    from.AddStatMod(new StatMod(StatType.Int, modName + "CharmInt", 10, TimeSpan.Zero));
                    from.AddStatMod(new StatMod(StatType.Dex, modName + "CharmDex", 10, TimeSpan.Zero));
                    isactive = true;
                }
            }
			return base.OnDroppedInto(from,target,p);
		}
		
		public override void OnItemLifted( Mobile from, Item item )
		{
                        string modName = from.Serial.ToString();
			if( item.IsChildOf( from.Backpack) )
			{
                     from.RemoveStatMod( modName + "CharmStr" );
                     from.RemoveStatMod( modName + "CharmInt" );
                     from.RemoveStatMod( modName + "CharmDex" );
				isactive = false;
			}
			base.OnItemLifted(from,item);
		}
		
		public Charm( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
            writer.Write((bool)m_IsRewardItem);
			writer.Write( (bool) isactive );
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			
			switch( version )
			{
				case 0:
					{
                        m_IsRewardItem = reader.ReadBool();
						isactive = reader.ReadBool();
						break;
					}
			}
		}
	}
}
