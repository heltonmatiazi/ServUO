using System;
using Server;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Prompts;
using Server.Engines.VeteranRewards;

namespace Server.Items
{
        //[FlipableAttribute( 0x27A2, 0x27ED )]
    public class NeonWep : Broadsword, IRewardItem
	{
		//public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		//public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }

		public override int AosStrengthReq{ get{ return 90; } }
		public override int AosMinDamage{ get{ return 30; } }
		public override int AosMaxDamage{ get{ return 40; } }
		public override int AosSpeed{ get{ return 65; } }

		public override int OldStrengthReq{ get{ return 90; } }
		public override int OldMinDamage{ get{ return 30; } }
		public override int OldMaxDamage{ get{ return 40; } }
		public override int OldSpeed{ get{ return 50; } }

		public override int DefHitSound{ get{ return 0x23B; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

    		private static int GetNeonHue()
    		{
			switch ( Utility.Random( 4 ) )
			{
				default:
				case 0: return 1170;
				case 1: return 1370;
				case 2: return 1161;
				case 3: return 1160;
			}
		}

        private bool m_IsRewardItem;
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }

		[Constructable]
		public NeonWep() //: base( 0x27A2 )
		{
			this.Weight = 5.0;
			this.Hue = GetNeonHue();
			this.Name = "A Neon Sword";
                        this.ItemID = 10146;
                        Identified = true;
                        this.Layer = Layer.OneHanded;
                        this.LootType = LootType.Blessed;
                        this.Attributes.SpellChanneling = 1;
                        
			if (this.Hue == 1170)
				{
					this.WeaponAttributes.HitLightning = 50;
					this.WeaponAttributes.HitEnergyArea = 25;
					this.Attributes.AttackChance = 35;
                                        this.Name = "Blade of Power";
				}
				else if (this.Hue == 1370)
				{
					this.WeaponAttributes.HitPoisonArea = 65;
                                        this.WeaponAttributes.ResistPoisonBonus = 50;
                                        this.Attributes.RegenHits = 3;
					this.Attributes.AttackChance = 35;
                                        this.Name = "Toxic Blade" ;
				}
				else if (this.Hue == 1161)
				{
					this.Attributes.CastSpeed = 2;
					this.Attributes.CastRecovery = 2;
                                        this.Attributes.LowerRegCost = 20;
					this.Attributes.RegenMana = 8;
					this.Name = "Blade of Sorcery";
				}
				else if (this.Hue == 1160)
				{
					this.WeaponAttributes.HitColdArea = 65;
                                        this.WeaponAttributes.ResistColdBonus = 50;
                                        this.Attributes.RegenStam = 3;
					this.Attributes.AttackChance = 35;
					this.Name = "Freezing Blade";
				}
		}

		/*public override void OnHit( Mobile attacker, Mobile defender )
		{
			if ( Utility.RandomDouble() >= 0.9 )
				if ( Utility.RandomDouble() >= 0.5 )
					if ( attacker.Criminal )
						Spawnhell( attacker );
			base.OnHit( attacker, defender );
		}*/

		/*public override void OnDoubleClick( Mobile from )
		{
		}*/

		/*public void Spawnhell( Mobile from )
		{
			BaseCreature hell;
			hell = new VengefullSpirit();
			hell.Map = from.Map;
			hell.Location = from.Location;
			hell.Combatant = from;
		}*/

		public NeonWep( Serial serial ) : base( serial )
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
