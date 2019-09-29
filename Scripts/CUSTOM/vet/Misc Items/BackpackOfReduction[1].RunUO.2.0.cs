/*
BackpackOfReduction.cs
snicker7 v1.3 [RunUO 2.0]
06/19/06

Description:
The backpack of reduction is a container
that accurately reduces its total weight
by a percentage without actually changing
the weight of the items inside or the
maximum weight that the container can carry.

Properties:
int ReduxPercent - This is a value from 0
	to 100 which corresponds to the
	percentage amount of weight reduction
	desired. 100% would mean the container
	would always weigh 0 stones.
	
Constructors:
BackpackOfReduction()
	defaults to 100% reduction
BackpackOfReduction(int redux)
	reduction rate as specified by the
	redux param

This code is public domain, however, I do
ask that you simply give credit where it
is due if you use it, for the sake of your
own conscience.
*/
using System;
using Server;
using Server.Engines.VeteranRewards;

namespace Server.Items
{
    public class BackpackOfReduction : Bag, IRewardItem
        {

            private bool m_IsRewardItem;
            [CommandProperty(AccessLevel.GameMaster)]
            public bool IsRewardItem
            {
                get { return m_IsRewardItem; }
                set { m_IsRewardItem = value; InvalidateProperties(); }
            }

		private double m_Redux;		
		[CommandProperty(AccessLevel.GameMaster)]
		public int ReduxPercent{get{return (int)(m_Redux*100);}set{
			if(value<0)
				value=0;
			if(value>100)
				value=100;
			m_Redux=((double)value)/100;
			if ( Parent is Item ){
				( Parent as Item ).UpdateTotals();
				( Parent as Item ).InvalidateProperties();
			}
			else if ( Parent is Mobile )
				( Parent as Mobile ).UpdateTotals();
			else
				UpdateTotals();
			InvalidateProperties();
		}}
		public override string DefaultName { get { return "Bag of Holding"; } }
		[Constructable]
		public BackpackOfReduction() : this(100)
                {
                Hue = 0x315;
                }
		[Constructable]
		public BackpackOfReduction(int redux) : base()
                {
                        
			ReduxPercent=redux;
		}
        public override void OnDoubleClick(Mobile from)
        {
            if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
            {
                from.SendMessage("This does not belong to you!!");
                return;
            }
            base.OnDoubleClick(from);
        }
        
        public override bool OnDragDrop(Mobile from, Item dropped)
        {
            if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
            {
                from.SendMessage("This does not belong to you!!");
                return false;
            }
            return OnDragDropInto(from, dropped, new Point3D(20, 100, 0));
        }

        public override bool OnDragDropInto(Mobile from, Item item, Point3D p)
        {
            if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
            {
                from.SendMessage("This does not belong to you!!");
                return false;
            }
            return true;
        }
		public BackpackOfReduction(Serial serial) : base(serial) {}
		public override void Serialize( GenericWriter writer ) {
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.Write((double)m_Redux);
            writer.Write((bool)m_IsRewardItem);
		}
		public override void Deserialize( GenericReader reader ) {
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Redux = reader.ReadDouble();
            m_IsRewardItem = reader.ReadBool();
		}
		public override void UpdateTotal(Item sender, TotalType type, int delta){
			base.UpdateTotal(sender,type,delta);
			if(type==TotalType.Weight){
				if ( Parent is Item )
					( Parent as Item ).UpdateTotal( sender, type, (int)(delta*m_Redux)*-1 );
				else if ( Parent is Mobile )
					( Parent as Mobile ).UpdateTotal( sender, type, (int)(delta*m_Redux)*-1 );
			}
		}
		public override int GetTotal(TotalType type){
			if(type==TotalType.Weight)
				return (int)(base.GetTotal(type)*(1.0-m_Redux));
			return base.GetTotal(type);
		}
	}
}
