using System;
using Server.Items;
using Server.Engines.VeteranRewards;

namespace Server.Items
{
	//[FlipableAttribute( 0x13d5, 0x13dd  )]
    public class OgreGloves : PlateGloves, IRewardItem
	{        
                public override int BasePhysicalResistance{ get{ return 2; } }
		public override int BaseFireResistance{ get{ return 4; } }
		public override int BaseColdResistance{ get{ return 3; } }
		public override int BasePoisonResistance{ get{ return 3; } }
		public override int BaseEnergyResistance{ get{ return 4; } }

		public override int InitMinHits{ get{ return 35; } }
		public override int InitMaxHits{ get{ return 45; } }

		public override int AosStrReq{ get{ return 25; } }
		public override int OldStrReq{ get{ return 25; } }

		public override int ArmorBase{ get{ return 16; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Studded; } }

        private bool m_IsRewardItem;
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }
                
		[Constructable]
		public OgreGloves() : base()
		{
			Weight = 2.0;
            ItemID = 5140;
                        Hue = 1169;
                        Identified = true;
                        Name = "guantlets of ogre power";
                        Attributes.BonusStr = 15;
                        Attributes.BonusInt = -7;
                        Attributes.WeaponDamage = 20;
                        ArmorAttributes.MageArmor = 1;
                        ArmorAttributes.SelfRepair = 3;
		}
public override bool OnEquip( Mobile from )
      {
          if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
          {
              from.SendMessage("This does not belong to you!!");
              return false;
          }
         return base.OnEquip(from);
      }
		public OgreGloves( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
            writer.Write((bool)m_IsRewardItem);
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            m_IsRewardItem = reader.ReadBool();
			if ( Weight == 1.0 )
				Weight = 2.0;
		}
	}

    public class GauntletsofDexterity : BaseArmor, IRewardItem
	{        
                public override int BasePhysicalResistance{ get{ return 2; } }
		public override int BaseFireResistance{ get{ return 4; } }
		public override int BaseColdResistance{ get{ return 3; } }
		public override int BasePoisonResistance{ get{ return 3; } }
		public override int BaseEnergyResistance{ get{ return 3; } }

		public override int InitMinHits{ get{ return 30; } }
		public override int InitMaxHits{ get{ return 40; } }

		public override int AosStrReq{ get{ return 20; } }
		public override int OldStrReq{ get{ return 10; } }

		public override int ArmorBase{ get{ return 13; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

        private bool m_IsRewardItem;
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }
                
		[Constructable]
		public GauntletsofDexterity() : base( 0x13C6 )
		{
			Weight = 2.0;
                        Name = "gauntlets of dexterity";
                        Identified = true;
                        Attributes.BonusDex = 15;
                        Attributes.WeaponDamage = 20;
                        Attributes.WeaponSpeed = 15;
        }

        public override bool OnEquip( Mobile from )
        {
          if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
          {
              from.SendMessage("This does not belong to you!!");
              return false;
          }
         return base.OnEquip(from);
        }

		public GauntletsofDexterity( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
            writer.Write((bool)m_IsRewardItem);
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            m_IsRewardItem = reader.ReadBool();
			if ( Weight == 1.0 )
				Weight = 2.0;
		}
	}
}
