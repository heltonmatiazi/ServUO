/*OnbeforeDeath Method
Item check = this.FindItemOnLayer( Layer.Ring );

         if ( check is LostRingOfAncientSecrets )
         {
            LostRingOfAncientSecrets checkring = (LostRingOfAncientSecrets) check;

            if ( checkring.SaveLoc != new Point3D( 0, 0, 0 ) && checkring.CanUseNow && !Server.Misc.WeightOverloading.IsOverloaded( this ) )
            {
               this.PublicOverheadMessage( MessageType.Regular, this.SpeechHue, true, "*invokes the Lost Ring of Ancient Secrets*", false );
               this.Blessed = true;
               this.Frozen = true;

               checkring.CanUseNow = false;

               m_LostRingTimer = new LostRingTimer( checkring );
               m_LostRingTimer.Start();

               m_SpawnTimer = new SpawnTimer( checkring, this );
               m_SpawnTimer.Start();

               return false;
            }
         }*/
         //public LostRingTimer m_LostRingTimer;
      //public SpawnTimer m_SpawnTimer;
/*public class LostRingTimer : Timer
      {
         private LostRingOfAncientSecrets m_lostring;
         private Mobile m_mob;

         public LostRingTimer( LostRingOfAncientSecrets checkring ) : base( TimeSpan.FromMinutes( checkring.ReUseTimeMinutes ) )
         {
            m_lostring = checkring;
         }

         protected override void OnTick()
         {
            m_lostring.CanUseNow = true;
            Stop();
         }
      }

      public class SpawnTimer : Timer
      {
         private LostRingOfAncientSecrets m_lostring;
         private Mobile m_mob;
         private int cnt = 0;
         private   int chance = Utility.Random( 1, 100 );

         public SpawnTimer( LostRingOfAncientSecrets checkring, Mobile m ) : base( TimeSpan.Zero, TimeSpan.FromSeconds( 3 ) )
         {
            m_lostring = checkring;
            m_mob = m;
         }

         protected override void OnTick()
         {
            cnt += 1;

            if ( cnt == 3 )
            {
               m_mob.Blessed = false;
               m_mob.Frozen = false;
               m_mob.Kill();
               Stop();
            }

            if ( cnt == 2 && m_mob.Kills >= 5 )
            {
               if ( chance < 45 )
               {
                  m_mob.PublicOverheadMessage( MessageType.Regular, m_mob.SpeechHue, true, "*invocation failed!*", false );
                  return;
               }
            }

            if ( cnt == 2 )
            {
               m_mob.Location = m_lostring.SaveLoc;
               m_mob.Blessed = false;
               m_mob.Frozen = false;
               Stop();
            }
         }
      }*/

using System;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;
using Server.Spells;
using Server.Items;
using Server;

namespace Server.Items
{
	public class LostRingOfAncientSecrets : BaseRing
	{
		// *** Command Property Variablies ***
		public Point3D m_SaveLoc;
		public int m_ReUseTime;
		public bool m_CanUseNow;
        private Map m_Map;
		// ***
        private Mobile      m_Owner;

        [CommandProperty( AccessLevel.GameMaster )]
		public Map LocMap
        { 
            get{ return m_Map; } 
            set{ m_Map = value; }
        }

                [CommandProperty( AccessLevel.GameMaster )]
                public Mobile Owner
                {
                get{ return m_Owner; }
                set{ m_Owner = value; }
                }
		public Point3D defloc = new Point3D( 0, 0, 0 );

		[Constructable]
		public LostRingOfAncientSecrets() : base( 0x108A )
		{
			Weight = 0.1;
			Hue = 1174;
			Name = "Ring of Ancient Secrets";
                        //Identified = true;
			LootType = LootType.Newbied;
            LocMap = m_Map;
			SaveLoc = defloc;
			ReUseTimeMinutes = 60;
			CanUseNow = true;
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Point3D SaveLoc
		{
			get{ return m_SaveLoc; }
			set{ m_SaveLoc = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int ReUseTimeMinutes
		{
			get{ return m_ReUseTime; }
			set{ m_ReUseTime = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool CanUseNow
		{
			get{ return m_CanUseNow; }
			set{ m_CanUseNow = value; }
		}

		public override void OnDoubleClick( Mobile from )
		{
			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage( 1042010 ); //You must have the object in your backpack to use it.
				return;
			}

			from.SendMessage( "Target the location where you want to spawn when the ring is invoked." );

			from.Target = new InternalTarget( this, from );
		}
  
public override bool OnEquip( Mobile from )
      {
          if (this.Owner == null)
          {
              this.Owner = from;
          }
         else if ( this.Owner != from )
         {
           from.SendMessage( "This does not belong to you!!" );
           return false;
         }
         return base.OnEquip(from);
      }
      
		public void Target( IPoint3D p, Mobile mob )
		{
			IPoint3D orig = p;
			Map map = this.Map;

			SpellHelper.GetSurfaceTop( ref p );

			if ( map == null || !map.CanSpawnMobile( p.X, p.Y, p.Z ) )
			{
				mob.SendLocalizedMessage( 501942 ); // That location is blocked.
			}
			else if ( SpellHelper.CheckMulti( new Point3D( p ), map ) )
			{
				mob.SendLocalizedMessage( 501942 ); // That location is blocked.
			}
			else
			{
				this.SaveLoc = new Point3D( p );
                this.LocMap = mob.Map;
				mob.SendMessage( "Save location has been set!" );
			}
		}

		public class InternalTarget : Target
		{
			private LostRingOfAncientSecrets m_Owner;
			private Mobile m_mob;

			public InternalTarget( LostRingOfAncientSecrets owner, Mobile m ) : base( 12, true, TargetFlags.None )
			{
				m_Owner = owner;
				m_mob = m;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				IPoint3D p = o as IPoint3D;

				if ( p != null )
					m_Owner.Target( p, m_mob );
			}

			protected override void OnTargetFinish( Mobile from )
			{
			}
		}

		public LostRingOfAncientSecrets( Serial serial ) : base( serial )
		{
		}

		/*public override Item Dupe( int amount )
		{ 
			return base.Dupe( new LostRingOfAncientSecrets( amount ), amount ); 
		} */

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 2 ); // version
            writer.Write(m_Map);
			writer.Write( m_Owner );
			writer.Write( (bool) m_CanUseNow );
			writer.Write( (int) m_ReUseTime );
			writer.Write( (Point3D) m_SaveLoc );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
                case 2:
                    {
                        m_Map = reader.ReadMap();
                        goto case 1;
                    }
				case 1:
				{
                                        m_Owner = reader.ReadMobile();
					m_CanUseNow = reader.ReadBool();
					m_ReUseTime = reader.ReadInt();
					m_SaveLoc = reader.ReadPoint3D();
					goto case 0;
				}
				case 0:
				{
					break;
				}
			}

			if ( !m_CanUseNow )
				m_CanUseNow = true;

		}
	}
}
