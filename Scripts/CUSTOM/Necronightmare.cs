using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a Necromare corpse" )]
	public class Necromare : BaseMount
	{
		[Constructable]
		public Necromare() : this( "a Necromare" )
		{
		}

		[Constructable]
        public Necromare(string name)
            : base(name, 0x74, 0x3EA7, AIType.AI_NecroMage, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
                  Name = "a necro nightmare";
			BaseSoundID = 0xA8;
                  Hue = 2173;
			SetStr( 396, 425 );
			SetDex( 186, 305 );
			SetInt( 186, 325 );

			SetHits( 298, 315 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Fire, 40 );
			SetDamageType( ResistanceType.Energy, 20 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.EvalInt, 110.4, 150.0 );
			SetSkill( SkillName.Magery, 110.4, 115.0 );
			SetSkill( SkillName.MagicResist, 85.3, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 80.5, 92.5 );
                        SetSkill( SkillName.Necromancy, 100.6, 110.5 );
                        SetSkill( SkillName.SpiritSpeak, 99.1, 100.5 );

			Fame = 14000;
			Karma = -14000;

			VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 115.1;

			switch ( Utility.Random( 3 ) )
			{
				case 0:
				{
					BodyValue = 116;
					ItemID = 16039;
					break;
				}
				case 1:
				{
					BodyValue = 178;
					ItemID = 16041;
					break;
				}
				case 2:
				{
					BodyValue = 179;
					ItemID = 16055;
					break;
				}
			}

			PackItem( new SulfurousAsh( Utility.RandomMinMax( 3, 5 ) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.LowScrolls );
			AddLoot( LootPack.Potions );
		}

		public override int GetAngerSound()
		{
			if ( !Controlled )
				return 0x16A;

			return base.GetAngerSound();
		}

		//public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public Necromare( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 0x16A )
				BaseSoundID = 0xA8;
		}
	}
}
