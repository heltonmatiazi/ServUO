using System;
using Server;
using Server.Spells.First;
using Server.Targeting;

namespace Server.Items
{
   public class TamerStaff : BaseTamer
   {
      [Constructable]
      public TamerStaff() : base( /*5, 20*/ )
      {
         Name = " Staff of Taming ";
      }

      public TamerStaff( Serial serial ) : base( serial )
      {
      }

      public override void Serialize( GenericWriter writer )
      {
         base.Serialize( writer );

         writer.Write( (int) 0 ); // version
      }

      public override void Deserialize( GenericReader reader )
      {
         base.Deserialize( reader );

         int version = reader.ReadInt();
      }


   }
}
