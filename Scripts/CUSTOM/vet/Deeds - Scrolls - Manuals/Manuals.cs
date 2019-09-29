using System;
using Server.Network;
using Server.Prompts;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Engines.VeteranRewards;

namespace Server.Items
{
    public class ManualofGainfulExercise : Item, IRewardItem
	{
        private bool m_IsRewardItem;
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }

		[Constructable]
		public ManualofGainfulExercise() : base( 0x2259 )
		{
			base.Weight = 1.0;
            base.LootType = LootType.Blessed;
			base.Name = "Manual of Gainful Exercise";
                }

		public ManualofGainfulExercise( Serial serial ) : base( serial )
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

		public override void OnDoubleClick( Mobile from )
		{
            if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
            {
                from.SendMessage("This does not belong to you!!");
                return;
            }
                        PlayerMobile mobile = from as PlayerMobile;

                        if ( !IsChildOf( from.Backpack ) ) 
                        { 
                          from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it. 
                        } 
                        else 
                        { 
			  mobile.Str += 10;
                          mobile.SendMessage( 0x5, "You have read the manual of gainful exercise and have increased your str  10!" );
                          mobile.PlaySound( 0x249 );
                          Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 1153, 0 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                          this.Delete(); 
                        }
		}
	}

    public class ManualofQuicknessofAction : Item, IRewardItem
	{
        private bool m_IsRewardItem;
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }
		[Constructable]
		public ManualofQuicknessofAction() : base( 0x2259 )
		{
			base.Weight = 1.0;
            base.LootType = LootType.Blessed;
			base.Name = "Manual of Quickness of Action";
		}

		public ManualofQuicknessofAction( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

            writer.Write((int)0); // version
            writer.Write((bool)m_IsRewardItem);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_IsRewardItem = reader.ReadBool();
		}

		public override void OnDoubleClick( Mobile from )
		{
            if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
            {
                from.SendMessage("This does not belong to you!!");
                return;
            }
                        PlayerMobile mobile = from as PlayerMobile;

                        if ( !IsChildOf( from.Backpack ) ) 
                        { 
                          from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it. 
                        } 
                        else 
                        { 
			  mobile.Dex += 10;
                          mobile.SendMessage( 0x5, "You have read the manual of quickness of action and your dex has increased by 10!" );
                          mobile.PlaySound( 0x249 );
                          Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 1153, 0 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                          this.Delete(); 
                        }
		}
	}

    public class TomeofClearThought : Item, IRewardItem
	{
        private bool m_IsRewardItem;
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }
		[Constructable]
		public TomeofClearThought() : base( 0x2259 )
		{
			base.Weight = 1.0;
            base.LootType = LootType.Blessed;
			base.Name = "Tome of Clear Thought";
                        
		}

		public TomeofClearThought( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

            writer.Write((int)0); // version
            writer.Write((bool)m_IsRewardItem);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_IsRewardItem = reader.ReadBool();
		}

		public override void OnDoubleClick( Mobile from )
		{
            if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
            {
                from.SendMessage("This does not belong to you!!");
                return;
            }
                        PlayerMobile mobile = from as PlayerMobile;

                        if ( !IsChildOf( from.Backpack ) ) 
                        { 
                          from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it. 
                        } 
                        else 
                        { 
			  mobile.Int += 10;
                          mobile.SendMessage( 0x5, "You have read the tome of clear thought and your int has increased by 10!" );
                          mobile.PlaySound( 0x249 );
                          Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 1153, 0 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                          this.Delete(); 
                        }
		}
	}

    public class BooksofExaltedDeeds : Item, IRewardItem
	{
        private bool m_IsRewardItem;
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }
		[Constructable]
		public BooksofExaltedDeeds() : base( 0x2259 )
		{
			base.Weight = 1.0;
            base.LootType = LootType.Blessed;
			base.Name = "Tome of Exalted Deeds";
                        
		}

		public BooksofExaltedDeeds( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

            writer.Write((int)0); // version
            writer.Write((bool)m_IsRewardItem);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_IsRewardItem = reader.ReadBool();
		}

		public override void OnDoubleClick( Mobile from )
		{
            if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
            {
                from.SendMessage("This does not belong to you!!");
                return;
            }
                        PlayerMobile mobile = from as PlayerMobile;

                        if ( !IsChildOf( from.Backpack ) ) 
                        { 
                          from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it. 
                        } 
                        else 
                        { 
			  mobile.Int += 10;
                          mobile.TithingPoints += 5000;
                          mobile.Skills[SkillName.Chivalry].Cap = 120;
                          mobile.SendMessage( 0x5, "You have read the tome of exalted deeds your Chivalry cap has increased to 120 and your int has increased by 10 and you have recieved 5000 tithing points!" );
                          mobile.PlaySound( 0x249 );
                          Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 1153, 0 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                          this.Delete(); 
                        }
		}
	}
    public class BooksofVileDeeds : Item, IRewardItem
	{
        private bool m_IsRewardItem;
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }
		[Constructable]
		public BooksofVileDeeds() : base( 0x2259 )
		{
			base.Weight = 1.0;
            base.LootType = LootType.Blessed;
			base.Name = "Book of Vile Deeds";

		}

		public BooksofVileDeeds( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

            writer.Write((int)0); // version
            writer.Write((bool)m_IsRewardItem);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_IsRewardItem = reader.ReadBool();
		}

		public override void OnDoubleClick( Mobile from )
		{
            if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
            {
                from.SendMessage("This does not belong to you!!");
                return;
            }
                        PlayerMobile mobile = from as PlayerMobile;

                        if ( !IsChildOf( from.Backpack ) )
                        {
                          from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
                        }
                        else
                        {
                          mobile.Skills[SkillName.Necromancy].Cap = 120;
                          mobile.Skills[SkillName.SpiritSpeak].Cap = 120;
                          mobile.SendMessage( 0x5, "You have read the tome of vile deeds your Necromancy Cap and your Spirit Speak Cap have increased to 120!" );
                          mobile.PlaySound( 0x249 );
                          Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 1153, 0 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                          this.Delete();
                        }
		}
	}
    public class ManualofWarriorsWay : Item, IRewardItem
	{
        private bool m_IsRewardItem;
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }
		[Constructable]
		public ManualofWarriorsWay() : base( 0x2259 )
		{
			base.Weight = 1.0;
            base.LootType = LootType.Blessed;
			base.Name = "Manual of the Warriors Way";

		}

		public ManualofWarriorsWay( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

            writer.Write((int)0); // version
            writer.Write((bool)m_IsRewardItem);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_IsRewardItem = reader.ReadBool();
		}

		public override void OnDoubleClick( Mobile from )
		{
            if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
            {
                from.SendMessage("This does not belong to you!!");
                return;
            }
                        PlayerMobile mobile = from as PlayerMobile;

                        if ( !IsChildOf( from.Backpack ) )
                        {
                          from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
                        }
                        else
                        {
			  mobile.Skills[SkillName.Swords].Cap = 120;
                          mobile.Skills[SkillName.Parry].Cap = 120;
                          mobile.Skills[SkillName.Tactics].Cap = 120;
                          mobile.Skills[SkillName.Macing].Cap = 120;
                          mobile.Skills[SkillName.Archery].Cap = 120;
                          mobile.Skills[SkillName.Fencing].Cap = 120;
                          mobile.Skills[SkillName.Wrestling].Cap = 120;
                          mobile.SendMessage( 0x5, "You have read the Manual of The Warriors Way, your Swordsmanship, Parrying, Macing, Wrestling, Archery, Fencing and Tactics caps have increased to 120!" );
                          mobile.PlaySound( 0x249 );
                          Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 1153, 0 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                          this.Delete();
                        }
		}
	}
    public class ManualofMerlinsWisdom : Item, IRewardItem
	{
        private bool m_IsRewardItem;
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }
		[Constructable]
		public ManualofMerlinsWisdom() : base( 0x2259 )
		{
			base.Weight = 1.0;
            base.LootType = LootType.Blessed;
			base.Name = "Manual of Merlins Wisdom";

		}

		public ManualofMerlinsWisdom( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

            writer.Write((int)0); // version
            writer.Write((bool)m_IsRewardItem);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_IsRewardItem = reader.ReadBool();
		}

		public override void OnDoubleClick( Mobile from )
		{
            if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
            {
                from.SendMessage("This does not belong to you!!");
                return;
            }
                        PlayerMobile mobile = from as PlayerMobile;

                        if ( !IsChildOf( from.Backpack ) )
                        {
                          from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
                        }
                        else
                        {
			  mobile.Skills[SkillName.Magery].Cap = 120;
                          mobile.Skills[SkillName.Meditation].Cap = 120;
                          mobile.Skills[SkillName.EvalInt].Cap = 120;
                          mobile.SendMessage( 0x5, "You have read the Manual of Merlins Wisdom, your Magery, Meditation, and Evaluate Intelligence cap has increased to 120!" );
                          mobile.PlaySound( 0x249 );
                          Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 1153, 0 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                          this.Delete();
                        }
		}
	}
    public class TomeofTrainerTips : Item, IRewardItem
	{
        private bool m_IsRewardItem;
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }
		[Constructable]
		public TomeofTrainerTips() : base( 0x2259 )
		{
			base.Weight = 1.0;
            base.LootType = LootType.Blessed;
			base.Name = "Tome of Trainer Tips";

		}

		public TomeofTrainerTips( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

            writer.Write((int)0); // version
            writer.Write((bool)m_IsRewardItem);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_IsRewardItem = reader.ReadBool();
		}

		public override void OnDoubleClick( Mobile from )
		{
            if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
            {
                from.SendMessage("This does not belong to you!!");
                return;
            }
                        PlayerMobile mobile = from as PlayerMobile;

                        if ( !IsChildOf( from.Backpack ) )
                        {
                          from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
                        }
                        else
                        {
			  mobile.Skills[SkillName.AnimalTaming].Cap = 120;
                          mobile.Skills[SkillName.Veterinary].Cap = 120;
                          mobile.Skills[SkillName.AnimalLore].Cap = 120;
                          mobile.SendMessage( 0x5, "You have read the Tome of Trainer Tips, your Animal Taming, Veterinary, and Animal Lore cap has increased to 120!" );
                          mobile.PlaySound( 0x249 );
                          Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 1153, 0 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                          this.Delete();
                        }
		}
	}
    public class TomeofSmithSecrets : Item, IRewardItem
	{
        private bool m_IsRewardItem;
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }
		[Constructable]
		public TomeofSmithSecrets() : base( 0x2259 )
		{
			base.Weight = 1.0;
            base.LootType = LootType.Blessed;
			base.Name = "Tome of Smith Secrets";

		}

		public TomeofSmithSecrets( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

            writer.Write((int)0); // version
            writer.Write((bool)m_IsRewardItem);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_IsRewardItem = reader.ReadBool();
		}

		public override void OnDoubleClick( Mobile from )
		{
            if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
            {
                from.SendMessage("This does not belong to you!!");
                return;
            }
                        PlayerMobile mobile = from as PlayerMobile;

                        if ( !IsChildOf( from.Backpack ) )
                        {
                          from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
                        }
                        else
                        {
			  mobile.Skills[SkillName.Mining].Cap = 120;
                          mobile.Skills[SkillName.Blacksmith].Cap = 120;
                          mobile.Skills[SkillName.ArmsLore].Cap = 120;
                          mobile.SendMessage( 0x5, "You have read the Tome of Smith Secrets, your Mining, Smithing, and Arms Lore cap has increased to 120!" );
                          mobile.PlaySound( 0x249 );
                          Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 1153, 0 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                          this.Delete();
                        }
		}
	}
    public class ManualForSongLovers : Item, IRewardItem
	{
        private bool m_IsRewardItem;
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }
		[Constructable]
		public ManualForSongLovers() : base( 0x2259 )
		{
			base.Weight = 1.0;
            base.LootType = LootType.Blessed;
			base.Name = "Manual For Song Lovers";

		}

		public ManualForSongLovers( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

            writer.Write((int)0); // version
            writer.Write((bool)m_IsRewardItem);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_IsRewardItem = reader.ReadBool();
		}

		public override void OnDoubleClick( Mobile from )
		{
            if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
            {
                from.SendMessage("This does not belong to you!!");
                return;
            }
                        PlayerMobile mobile = from as PlayerMobile;

                        if ( !IsChildOf( from.Backpack ) )
                        {
                          from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
                        }
                        else
                        {
			  mobile.Skills[SkillName.Musicianship].Cap = 120;
                          mobile.Skills[SkillName.Peacemaking].Cap = 120;
                          mobile.Skills[SkillName.Provocation].Cap = 120;
                          mobile.SendMessage( 0x5, "You have read the Manual For Song Lovers, your Musicianship, Peacemaking, and Provocation cap has increased to 120!" );
                          mobile.PlaySound( 0x249 );
                          Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 1153, 0 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                          this.Delete();
                        }
		}
	}
    public class TomeofBodyandSoul : Item, IRewardItem
	{
        private bool m_IsRewardItem;
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }
		[Constructable]
		public TomeofBodyandSoul() : base( 0x2259 )
		{
			base.Weight = 1.0;
            base.LootType = LootType.Blessed;
			base.Name = "Tome of Body and Mind";

		}

		public TomeofBodyandSoul( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

            writer.Write((int)0); // version
            writer.Write((bool)m_IsRewardItem);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_IsRewardItem = reader.ReadBool();
		}

		public override void OnDoubleClick( Mobile from )
		{
            if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
            {
                from.SendMessage("This does not belong to you!!");
                return;
            }
                        PlayerMobile mobile = from as PlayerMobile;

                        if ( !IsChildOf( from.Backpack ) )
                        {
                          from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
                        }
                        else
                        {
			  mobile.Skills[SkillName.Healing].Cap = 120;
                          mobile.Skills[SkillName.Anatomy].Cap = 120;
                          mobile.Skills[SkillName.Focus].Cap = 120;
                          mobile.SendMessage( 0x5, "You have read the Tome of Body and Mind, your Healing, Anatomy, and Focus cap has increased to 120!" );
                          mobile.PlaySound( 0x249 );
                          Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 1153, 0 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                          this.Delete();
                        }
		}
	}
    public class ManualofStealthyPilfering : Item, IRewardItem
	{
        private bool m_IsRewardItem;
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }
		[Constructable]
		public ManualofStealthyPilfering() : base( 0x2259 )
		{
			base.Weight = 1.0;
            base.LootType = LootType.Blessed;
			base.Name = "Manual of Stealthy Pilfering";
                        
		}

		public ManualofStealthyPilfering( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

            writer.Write((int)0); // version
            writer.Write((bool)m_IsRewardItem);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_IsRewardItem = reader.ReadBool();
		}

		public override void OnDoubleClick( Mobile from )
		{
            if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
            {
                from.SendMessage("This does not belong to you!!");
                return;
            }
                        PlayerMobile mobile = from as PlayerMobile;

                        if ( !IsChildOf( from.Backpack ) ) 
                        { 
                          from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it. 
                        } 
                        else 
                        { 
			  mobile.Skills[SkillName.Stealing].Cap = 120;
                          mobile.Skills[SkillName.Stealth].Cap = 120;
                          mobile.Skills[SkillName.Snooping].Cap = 120;
                          mobile.SendMessage( 0x5, "You have read the tome of Stealthy Pilfering and your Stealth, Snooping and Stealing cap has increased to 120!" );
                          mobile.PlaySound( 0x249 );
                          Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 1153, 0 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			  Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36F4, 33, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                          this.Delete(); 
                        }
		}
	}
}


