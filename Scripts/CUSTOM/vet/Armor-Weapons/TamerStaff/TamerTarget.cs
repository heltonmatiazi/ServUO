using System;
using Server.Network;
using Server.Items;
using System.Collections;
using Server.Targeting;
using Server.Mobiles;


namespace Server.Targeting
{
   public class TamerTarget : Target
      {
         private bool m_SetSkillTime = true;
         private BaseTamer m_Item;

         public TamerTarget( BaseTamer item ) :  base ( 6, false, TargetFlags.None )
         {
            m_Item = item;
         }

         private static Hashtable m_BeingTamed = new Hashtable();

         protected override void OnTargetFinish( Mobile from )
         {
            if ( m_SetSkillTime )
                from.NextSkillTime = Core.TickCount;
         }

         protected override void OnTargetCancel (Mobile from, TargetCancelType Canceled )
         {
            m_Item.Movable = true;
         }

         protected override void OnTarget( Mobile from, object target )
         {

            if( target == from )
                      from.SendLocalizedMessage( 1005576 );

            if ( target is Mobile )
            {
               if ( target is BaseCreature )
               {
                  BaseCreature creature = (BaseCreature)target;

                  if ( !creature.Tamable )
                  {
                     from.SendLocalizedMessage( 502469 ); // That being can not be tamed.
                     m_Item.Movable = true;
                  }
                  else if ( creature.Controlled )
                  {
                     from.SendLocalizedMessage( 502467 ); // That animal looks tame already.
                     m_Item.Movable = true;
                  }
                  else if ( from.Female ? !creature.AllowFemaleTamer : !creature.AllowMaleTamer )
                  {
                     from.SendLocalizedMessage( 502801 ); // You can't tame that!
                     m_Item.Movable = true;
                  }
                  else if ( from.Followers + creature.ControlSlots > from.FollowersMax )
                  {
                     from.SendLocalizedMessage( 1049611 ); // You have too many followers to tame that creature.
                     m_Item.Movable = true;
                  }
                  else if ( from.Skills[SkillName.AnimalTaming].Value >= 110.0 )
                  {
                     if ( m_BeingTamed.Contains( target ) )
                     {
                        from.SendLocalizedMessage( 502802 ); // Someone else is already taming this.
                        m_Item.Movable = true;
                     }

                     else
                     {
                        m_BeingTamed[target] = from;

                        // Face the creature
                        from.Direction = from.GetDirectionTo( creature );

                        //from.NextSkillTime = DateTime.MaxValue;
                        from.NextSkillTime = Core.TickCount + 6000;

                        from.LocalOverheadMessage( MessageType.Emote, 0x59, 1010597 ); // You start to tame the creature.
                        from.NonlocalOverheadMessage( MessageType.Emote, 0x59, 1010598 ); // *begins taming a creature.*

                        new InternalTimer( m_Item, from, creature, Utility.Random( 3, 2 ) ).Start();

                        m_SetSkillTime = false;
                        m_Item.Movable = false;
                     }

                  }
                  else
                  {
                     from.SendLocalizedMessage( 502806 ); // You have no chance of taming this creature.
                     m_Item.Movable = true;
                  }
               }
               else
               {
                  from.SendLocalizedMessage( 502469 ); // That being can not be tamed.
                  m_Item.Movable = true;
               }
            }
            else
            {
               from.SendLocalizedMessage( 502801 ); // You can't tame that!
               m_Item.Movable = true;
            }

         }
         private class InternalTimer : Timer
         {
            private BaseTamer m_Item;
            private Mobile m_Tamer;
            private BaseCreature m_Creature;
            private int m_MaxCount;
            private int m_Count;



            public InternalTimer( BaseTamer item, Mobile tamer, BaseCreature creature, int count ) : base( TimeSpan.FromSeconds( 3.0 ), TimeSpan.FromSeconds( 3.0 ), count )
            {

               m_Tamer = tamer;
               m_Creature = creature;
               m_MaxCount = count;
               m_Item = item;

            }

            protected override void OnTick()
            {
               m_Count++;

               if ( !m_Tamer.InRange( m_Creature, 6 ) )
               {
                  m_BeingTamed.Remove( m_Creature );
                  m_Tamer.NextSkillTime = Core.TickCount;
                  m_Tamer.SendLocalizedMessage( 502795 ); // You are too far away to continue taming.
                  m_Item.Movable = true;
                  Stop();
               }
               else if ( !m_Tamer.CheckAlive() )
               {
                  m_BeingTamed.Remove( m_Creature );
                  m_Tamer.NextSkillTime = Core.TickCount;
                  m_Tamer.SendLocalizedMessage( 502796 ); // You are dead, and cannot continue taming.
                  m_Item.Movable = true;
                  Stop();
               }
               else if ( !m_Tamer.CanSee( m_Creature ) )
               {
                  m_BeingTamed.Remove( m_Creature );
                  m_Tamer.NextSkillTime = Core.TickCount;
                  m_Tamer.SendLocalizedMessage( 502800 ); // You can't see that.
                  m_Item.Movable = true;
                  Stop();
               }
               else if ( !m_Creature.Tamable )
               {
                  m_BeingTamed.Remove( m_Creature );
                  m_Tamer.NextSkillTime = Core.TickCount;
                  m_Tamer.SendLocalizedMessage( 502469 ); // That being can not be tamed.
                  m_Item.Movable = true;
               Stop();
               }
               else if ( m_Creature.Controlled )
               {
                  m_BeingTamed.Remove( m_Creature );
                  m_Tamer.NextSkillTime = Core.TickCount;
                  m_Tamer.SendLocalizedMessage( 502804 ); // That animal looks tame already.
                  m_Item.Movable = true;
                  Stop();
               }
               else if ( m_Count < m_MaxCount )
               {
                  m_Tamer.RevealingAction();
                  m_Tamer.PublicOverheadMessage( MessageType.Regular, 0x3B2, Utility.Random( 502790, 4 ) );
                  m_Tamer.Direction = m_Tamer.GetDirectionTo( m_Creature );

               }
               else
               {
                  m_Tamer.RevealingAction();
                  m_Tamer.NextSkillTime = Core.TickCount;
                  m_BeingTamed.Remove( m_Creature );
                  m_Item.DoTamerTarget( m_Tamer, m_Creature );
                  m_Item.Movable = true;

                  if ( m_Tamer.Skills[SkillName.AnimalTaming].Value >= 110.0 )
                  {
                     if ( m_Tamer.Skills[SkillName.AnimalTaming].Value >= 110.0 )
                        m_Tamer.SendLocalizedMessage( 502797 ); // That wasn't even challenging.
                     else
                        m_Creature.PrivateOverheadMessage( MessageType.Regular, 0x3B2, 502799, m_Tamer.NetState ); // It seems to accept you as master.

                     m_Creature.SetControlMaster( m_Tamer );

                  }

                  else
                  {
                     m_Tamer.SendLocalizedMessage( 502798 ); // You fail to tame the creature.
                  }
               }
            }
         }
   }
}
