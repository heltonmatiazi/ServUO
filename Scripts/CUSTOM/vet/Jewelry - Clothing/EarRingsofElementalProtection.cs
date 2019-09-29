using System;
using Server.Mobiles;
using Server.Network;
using Server.Engines.VeteranRewards;
using Server.Accounting;

namespace Server.Items
{
    public class EarringsOfTheElemements : BaseEarrings, IRewardItem //replace NAME with the name that you want to call your item, make sure to capitalize it. ie: FireRing, not firering, also replace BaseItem with the item your copying.
	{
        private bool m_IsRewardItem;
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }      
		[Constructable]
		public EarringsOfTheElemements() : base( 0x1087 ) //same name above goes here
		{
			Name = "Earrings Of Elememental Protection"; //this is where you put the name the players will see. ie: the blazing fire ring. did you notice I didn't capitalize it, not needed in this name as it auto caps for you.
                        //this.Identified = true;
                        Resistances.Fire = 30;
                        Resistances.Cold = 30;
                        Resistances.Poison = 30;
                        Resistances.Energy = 30;
		}

		public EarringsOfTheElemements( Serial serial ) : base( serial ) //same name as above.
		{
		}
        
        public override bool OnEquip(Mobile from)
        {
            if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
            {
                from.SendMessage("This does not belong to you!!");
                return false;
            }
            if (from is PlayerMobile)
            {
                Account acct = from.Account as Account;
                acct.SetTag("VoidEffect","yes");
                //((PlayerMobile)from).VoidEffect = true; //Depending on what effect you want this item to protect, pick one of the following and replace EFFECT with it: PDarkEffect, PFireEffect, PIceEffect, PToxicEffect, PElectEffect, PWaterEffect, PMistEffect, PExplosionEffect, PShineyEffect and PFireFlyEffect 
            }

            return base.OnEquip(from);
        }
        
        public override void OnRemoved(object parent)
        {
            base.OnRemoved(parent);

            if (parent is PlayerMobile)
            {
                PlayerMobile m = (PlayerMobile)parent;
                Account acc = m.Account as Account;
                acc.SetTag("VoidEffect","no");
                //((PlayerMobile)parent).VoidEffect = false; //Put the same effect you place in above here as well.
            }
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
            writer.Write((bool)m_IsRewardItem);
                        //writer.Write( m_Owner );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
            m_IsRewardItem = reader.ReadBool();
                        //m_Owner = reader.ReadMobile();
		}
	}
}
