using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.VeteranRewards;

namespace Server.Items
{
   [FlipableAttribute( 0x2683, 0x2684 )]
    public class HoodedRobe : BaseOuterTorso, IDyable, IRewardItem
   {
      public override int BasePhysicalResistance{ get{ return 3; } }

      private bool m_IsRewardItem;
      [CommandProperty(AccessLevel.GameMaster)]
      public bool IsRewardItem
      {
          get { return m_IsRewardItem; }
          set { m_IsRewardItem = value; InvalidateProperties(); }
      }

      [Constructable]
      public HoodedRobe() : base( 0x2683 )
      {
         Weight = 5.0;
         LootType=LootType.Blessed;
         Name = "Shroud";
         Layer = Layer.OuterTorso;
      }

      public override void OnDoubleClick( Mobile m )
      {
         if( Parent != m )
         {
            m.SendMessage( "You must be wearing the robe to use it!" );
         }
         else
         {
            if ( ItemID == 0x2683 || ItemID == 0x2684 )
            {
               m.SendMessage( "You lower the hood." );
               m.PlaySound( 0x57 );
               ItemID = 0x1F03;
               m.NameMod = null;
               /*if ( ((PlayerMobile)m).CityTitle != null)
               {
                    ((PlayerMobile)m).ShowCityTitle = true;
               }*/
               m.RemoveItem(this);
               if (!m.EquipItem(this))
               {
                   bool dropped = false;
                   if (null != m.Backpack)
                   {
                       m.Backpack.DropItem(this);
                       dropped = true;
                   }

                   if (!dropped)
                   {
                       if (m.BankBox != null)
                       {
                           m.BankBox.DropItem(this);
                       }
                   }
               }
               m.EquipItem(this);
               if( m.Kills >= 5)
               {
               m.Criminal = true;
                }
                if( m.GuildTitle != null)
               {
                  m.DisplayGuildTitle = true;
                }
            }
            else if ( ItemID == 0x1F03 || ItemID == 0x1F04 )
            {
               m.SendMessage( "You pull the hood over your head." );
               m.PlaySound( 0x57 );
               ItemID = 0x2683;
               m.NameMod = "shrouded figure";
               m.DisplayGuildTitle = false;
               m.Criminal = false;
               /*if ( ((PlayerMobile)m).ShowCityTitle == true)
               {
                    ((PlayerMobile)m).ShowCityTitle = false;
               }*/
               m.RemoveItem(this);
               m.EquipItem(this);

            }
         }
      }

       public override bool OnEquip( Mobile from )
      {
          if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
          {
              from.SendMessage("This does not belong to you!!");
              return false;
          }
         if ( ItemID == 0x2683 )
         {
         from.NameMod = "shrouded figure";
         from.DisplayGuildTitle = false;
         from.Criminal = false;
         }
         return base.OnEquip(from);
      }

      public override void OnRemoved( Object o )
      {
      if( o is Mobile )
      {
          ((Mobile)o).NameMod = null;
      }
      if( o is Mobile && ((Mobile)o).Kills >= 5)
               {
               ((Mobile)o).Criminal = true;
                }
      if( o is Mobile && ((Mobile)o).GuildTitle != null )
               {
          ((Mobile)o).DisplayGuildTitle = true;
                }

      base.OnRemoved( o );
      }

      public HoodedRobe( Serial serial ) : base( serial )
      {

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
