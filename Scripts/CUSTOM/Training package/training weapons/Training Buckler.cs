using System;
using Server;

namespace Server.Items
{ 
	public class TrainingBuckler: Buckler
	{
		public override int LabelNumber{ get{ return 1061097; } } // Training Buckler
		
                public override int InitMinHits{ get{ return 2600; } }
		public override int InitMaxHits{ get{ return 2600; } }

        public override int ArmorBase{get { return 10; } }

      	

		[Constructable]
		public TrainingBuckler()

		{
                        Name = "A Training Buckler";
			Hue = 220;
	                        
		}

		public TrainingBuckler( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
