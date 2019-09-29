using System;
using Server.Network;
using Server.Items;
using System.Collections;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Items
{
   [FlipableAttribute( 0xE81, 0xE82 )]
   public class BaseTamer : BaseStaff
   {
      public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
      public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Disarm; } }

      public override int AosStrengthReq{ get{ return 20; } }
      public override int AosMinDamage{ get{ return 13; } }
      public override int AosMaxDamage{ get{ return 15; } }
      public override int AosSpeed{ get{ return 40; } }

      public override int OldStrengthReq{ get{ return 10; } }
      public override int OldMinDamage{ get{ return 3; } }
      public override int OldMaxDamage{ get{ return 12; } }
      public override int OldSpeed{ get{ return 30; } }

      //private int m_Charges;

      [Constructable]
      public BaseTamer(  /*int minCharges, int maxCharges*/ ) :  base( 0xE81 )
      {
         Name = "Staff of Taming";
         Weight = 6.0;
         //Charges = Utility.RandomMinMax( minCharges, maxCharges );
      }

      private static Hashtable m_BeingTamed = new Hashtable();

      /*public void ConsumeCharge( Mobile from )
      {
         --Charges;

         if ( Charges == 0 )
            from.SendLocalizedMessage( 1019073 ); // This item is out of charges.
      }*/

      public BaseTamer( Serial serial ) : base( serial )
      {
      }

      /*[CommandProperty( AccessLevel.GameMaster )]
      public int Charges
      {
         get
         {
            return m_Charges;
         }
         set
         {
            m_Charges = value;
         }
      }*/
      public override void OnDoubleClick( Mobile from )
      {
         if ( from.Skills[SkillName.AnimalTaming].Value >= 110.0 )
              {
            if ( Parent == from )
            {
               //if ( m_Charges > 0 )
                  OnTameUse ( from );

               //else
                          //from.SendLocalizedMessage( 1019073 ); // This item is out of charges.
            }
            else
            {
               from.SendLocalizedMessage( 502641 ); // You must equip this item to use it.
            }

              }
         else if ( from.Skills[SkillName.AnimalTaming].Value < 110.0 )
         {
            from.Say ( "110 Animal Taming is Required before using this Item" );
         }
      }

      public override void Serialize( GenericWriter writer )
      {
         base.Serialize( writer );

         writer.Write( (int) 0 ); // version

         //writer.Write( (int) m_Charges );
      }

      public override void Deserialize( GenericReader reader )
      {
         base.Deserialize( reader );

         int version = reader.ReadInt();

        // switch ( version )
         //{
            //case 0:
            //{
               //m_Charges = (int)reader.ReadInt();

               //break;
            //}
         //}
      }

      public override void OnSingleClick( Mobile from )
      {
         ArrayList attrs = new ArrayList();

         //if ( !Identified )
            //attrs.Add( new EquipInfoAttribute( 1038000 ) ); // Unidentified
         //else
         //{

            //attrs.Add( new EquipInfoAttribute( 1017349 + (int)m_Charges, m_Charges ) );
         //}

         EquipmentInfo eqInfo = new EquipmentInfo( 1017041, Crafter, false, (EquipInfoAttribute[])attrs.ToArray( typeof( EquipInfoAttribute ) ) );

         from.Send( new DisplayEquipmentInfo( this, eqInfo ) );
         this.LabelTo( from, this.Name );
      }

      public virtual void OnTameUse( Mobile from )
      {
         //from.SendLocalizedMessage( 1010018 ); // What do you want to use this item on?

         from.Target = new TamerTarget( this );
         this.Movable = false;
         from.Hidden = false;

         from.SendLocalizedMessage( 502789 ); // Tame which animal?

         //return TimeSpan.FromHours( 6.0 );
      }

      public virtual void DoTamerTarget( Mobile from, object o )
      {
         if ( Deleted /*|| Charges <= 0*/ || Parent != from || o is StaticTarget || o is LandTarget )
            return;

         //if ( OnTamerTarget( from, o ) )
            //ConsumeCharge( from );
      }

      public virtual bool OnTamerTarget( Mobile from, object o )
      {
         return true;
      }

   }
}

