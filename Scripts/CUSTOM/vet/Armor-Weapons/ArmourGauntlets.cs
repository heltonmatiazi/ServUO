using System;
using Server;
using Server.Mobiles;
using Server.Engines.VeteranRewards;

namespace Server.Items
{
    public class ArmourGauntlet : PlateGloves, IRewardItem
	{

		public override int ArtifactRarity{ get{ return 69; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		private CraftResource colour;
		public int damage;

        private bool m_IsRewardItem;
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }

		[Constructable]
		public ArmourGauntlet()
		{
			Name="Armour Gauntlets";
                        ItemID=5140;
            ArmorAttributes.SelfRepair = 5;
			LootType=LootType.Blessed;
		        colour=CraftResource.Iron;
			damage=0;
		}

		public ArmourGauntlet( Serial serial ) : base( serial )
		{
		}
		  public override bool OnEquip( Mobile from ) 
                {
                    if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
                    {
                        from.SendMessage("This does not belong to you!!");
                        return false;
                    }
        	if(from.Karma>=100)
        		colour= CraftResource.Gold;
        	else if(from.Karma<=-100)
        	colour= CraftResource.ShadowIron;
        	else
        		colour= CraftResource.DullCopper;
        	this.Attributes.Luck=(from.Str+from.Dex+from.Int);
        	this.EnergyBonus=70;
        	if(from.Karma>=100)
        	{
        	        this.PhysicalBonus=0;
        		this.FireBonus=70;
        		this.ColdBonus=0;
        		this.PoisonBonus=0;
       		}
        	else if(from.Karma<=-100)
        	{
        	        this.PhysicalBonus=0;
        		this.FireBonus=0;
        		this.ColdBonus=70;
        	        this.PoisonBonus=0;
        			
        	}
        	else if(from.Karma<=100&&from.Karma>=-100)
        	{
        	        this.PhysicalBonus=70;
        		this.FireBonus=0;
        		this.ColdBonus=0;
        	        this.PoisonBonus=0;
        			
        	}
                this.Identified = true;
        	this.Resource=colour;
        	from.FixedParticles( 0x373A, 10, 15, 5036, EffectLayer.Head );
        	from.SendMessage("You equip the gloves, and feel a suit of magical armor form around you!");
        	Container mobilePack = from.Backpack; 
        	if(mobilePack !=null)
        	{
        	 Item chest = from.FindItemOnLayer( Layer.InnerTorso ); 
      	if ( chest != null )
      		{
      	 mobilePack.DropItem( chest ); 
      		}
        BaseArmor chesta;
        switch ( Utility.Random( 3 ))
                {
                    case 0:
                    chesta = new PlateChest();
                    chesta.Movable=false;
        		chesta.ArmorAttributes.LowerStatReq=90;
                        chesta.Attributes.ReflectPhysical = 30;
		        chesta.Attributes.RegenHits = 2;
			chesta.Attributes.RegenStam = 1;
               		chesta.Attributes.DefendChance = 20;
                        chesta.Resource = colour;
                        chesta.Identified = true;
                        from.EquipItem(chesta);
                    break;

                    case 1:
                    chesta = new PlateChest();
                    chesta.ItemID=11016;
                    chesta.Movable=false;
        		chesta.ArmorAttributes.LowerStatReq=90;
                        chesta.Attributes.ReflectPhysical = 30;
		        chesta.Attributes.RegenHits = 2;
			chesta.Attributes.RegenStam = 1;
               		chesta.Attributes.DefendChance = 20;
                        chesta.Resource = colour;
                        chesta.Identified = true;
                        from.EquipItem(chesta);
                    break;
                    case 2:
                    chesta = new PlateChest();
                    chesta.ItemID=9793;
                    chesta.Movable=false;
        		chesta.ArmorAttributes.LowerStatReq=90;
                        chesta.Attributes.ReflectPhysical = 30;
		        chesta.Attributes.RegenHits = 2;
			chesta.Attributes.RegenStam = 1;
               		chesta.Attributes.DefendChance = 20;
                        chesta.Resource = colour;
                        chesta.Identified = true;
                        from.EquipItem(chesta);
                    break;
                }

                        /*PlateChest chesta = new PlateChest();
                        chesta.Movable=false;
        		chesta.ArmorAttributes.LowerStatReq=90;
                        chesta.Attributes.ReflectPhysical = 30;
		        chesta.Attributes.RegenHits = 2;
			chesta.Attributes.RegenStam = 1;
               		chesta.Attributes.DefendChance = 20;
                        chesta.Resource = colour;
        		//chesta.Hue=colour;
                        from.EquipItem(chesta);*/
      		
      		 Item legs = from.FindItemOnLayer( Layer.Pants ); 
      	if ( legs != null )
      		{
      	 mobilePack.DropItem( legs ); 
      		}
        
        BaseArmor legsa;
        switch ( Utility.Random( 3 ))
                {
                    case 0:
                        legsa = new PlateLegs();
                        legsa.Movable=false;
        		legsa.Resource=colour;
        		legsa.ArmorAttributes.LowerStatReq=90;
                        legsa.Attributes.ReflectPhysical = 30;
			legsa.Attributes.RegenHits = 2;
			legsa.Attributes.RegenStam = 1;
               		legsa.Attributes.DefendChance = 25;
                 legsa.Identified = true;
                        from.EquipItem(legsa);
                    break;

                    case 1:
                    legsa = new PlateLegs();
                    legsa.ItemID=9799;
                    legsa.Movable=false;
        		legsa.Resource=colour;
        		legsa.ArmorAttributes.LowerStatReq=90;
                        legsa.Attributes.ReflectPhysical = 30;
			legsa.Attributes.RegenHits = 2;
			legsa.Attributes.RegenStam = 1;
               		legsa.Attributes.DefendChance = 25;
                 legsa.Identified = true;
                        from.EquipItem(legsa);
                    break;
                    case 2:
                    legsa = new PlateLegs();
                    legsa.ItemID=11014;
                    legsa.Movable=false;
        		legsa.Resource=colour;
        		legsa.ArmorAttributes.LowerStatReq=90;
                        legsa.Attributes.ReflectPhysical = 30;
			legsa.Attributes.RegenHits = 2;
			legsa.Attributes.RegenStam = 1;
               		legsa.Attributes.DefendChance = 25;
                 legsa.Identified = true;
                        from.EquipItem(legsa);
                    break;
                }
                        /*PlateLegs legsa = new PlateLegs();
                        legsa.Movable=false;
        		legsa.Resource=colour;
        		legsa.ArmorAttributes.LowerStatReq=90;
                        legsa.Attributes.ReflectPhysical = 30;
			legsa.Attributes.RegenHits = 2;
			legsa.Attributes.RegenStam = 1;
               		legsa.Attributes.DefendChance = 25;
                        from.EquipItem(legsa);*/
      		
      		Item arms = from.FindItemOnLayer( Layer.Arms ); 
      	if ( arms != null )
      		{
      	 mobilePack.DropItem( arms ); 
      		}
        BaseArmor armsa;
        switch ( Utility.Random( 3 ))
                {
                    case 0:
                        armsa = new PlateArms();
                        armsa.Movable=false;
        		armsa.Resource=colour;
        		armsa.ArmorAttributes.LowerStatReq=90;
                        armsa.Attributes.ReflectPhysical = 10;
			armsa.Attributes.RegenHits = 1;
			armsa.Attributes.RegenStam = 1;
               		armsa.Attributes.DefendChance = 25;
                 armsa.Identified = true;
                        from.EquipItem(armsa);
                    break;

                    case 1:
                    armsa = new PlateArms();
                    armsa.ItemID=9815;
                    armsa.Movable=false;
        		armsa.Resource=colour;
        		armsa.ArmorAttributes.LowerStatReq=90;
                        armsa.Attributes.ReflectPhysical = 10;
			armsa.Attributes.RegenHits = 1;
			armsa.Attributes.RegenStam = 1;
               		armsa.Attributes.DefendChance = 25;
                 armsa.Identified = true;
                        from.EquipItem(armsa);
                    break;
                    case 2:
                    armsa = new PlateArms();
                    armsa.ItemID=11018;
                    armsa.Movable=false;
        		armsa.Resource=colour;
        		armsa.ArmorAttributes.LowerStatReq=90;
                        armsa.Attributes.ReflectPhysical = 10;
			armsa.Attributes.RegenHits = 1;
			armsa.Attributes.RegenStam = 1;
               		armsa.Attributes.DefendChance = 25;
                 armsa.Identified = true;
                        from.EquipItem(armsa);
                    break;
                }
      		        /*PlateArms armsa = new PlateArms();
                        armsa.Movable=false;
        		armsa.Resource=colour;
        		armsa.ArmorAttributes.LowerStatReq=90;
                        armsa.Attributes.ReflectPhysical = 10;
			armsa.Attributes.RegenHits = 1;
			armsa.Attributes.RegenStam = 1;
               		armsa.Attributes.DefendChance = 25;
                        from.EquipItem(armsa);*/
      		
      		Item neck = from.FindItemOnLayer( Layer.Neck ); 
      	if ( neck != null )
      		{
      	 mobilePack.DropItem( neck );
      		}
        BaseArmor necka;
        switch ( Utility.Random( 2 ))
                {
                    case 0:
                        necka = new PlateGorget();
                        necka.Movable=false;
        		necka.ArmorAttributes.LowerStatReq=90;
                        necka.Attributes.ReflectPhysical = 10;
			necka.Attributes.RegenHits = 1;
			necka.Attributes.RegenStam = 1;
               		necka.Attributes.DefendChance = 5;
        		necka.Resource=colour;
          necka.Identified = true;
                        from.EquipItem(necka);
                    break;

                    case 1:
                    necka = new PlateGorget();
                    necka.ItemID=11022;
                    necka.Movable=false;
        		necka.ArmorAttributes.LowerStatReq=90;
                        necka.Attributes.ReflectPhysical = 10;
			necka.Attributes.RegenHits = 1;
			necka.Attributes.RegenStam = 1;
               		necka.Attributes.DefendChance = 5;
        		necka.Resource=colour;
          necka.Identified = true;
                        from.EquipItem(necka);
                    break;
                    /*case 2:
                    HeaterShield shielda = new HeaterShield();
                    shielda.ItemID=11009;
                    shielda.Movable=false;
        		shielda.ArmorAttributes.LowerStatReq=90;
                        shielda.Attributes.SpellChanneling = 1;
                        shielda.Attributes.ReflectPhysical = 10;
			shielda.Attributes.RegenHits = 1;
			shielda.Attributes.RegenStam = 1;
               		shielda.Attributes.DefendChance = 5;
        		shielda.Resource=colour;
                        from.EquipItem(shielda);
                    break;*/
                }
                        /*PlateGorget necka = new PlateGorget();
                        necka.Movable=false;
        		necka.ArmorAttributes.LowerStatReq=90;
                        necka.Attributes.ReflectPhysical = 10;
			necka.Attributes.RegenHits = 1;
			necka.Attributes.RegenStam = 1;
               		necka.Attributes.DefendChance = 5;
        		necka.Resource=colour;
                        from.EquipItem(necka);*/
      		
      		Item helm = from.FindItemOnLayer( Layer.Helm ); 
      	if ( helm != null )
      		{
      	        mobilePack.DropItem( helm);
      		}
        BaseArmor helma;
        switch ( Utility.Random( 6 ))
                {
                    case 0:
                        helma = new PlateHelm();
                        helma.ItemID=5134;
                        helma.Movable=false;
        		helma.ArmorAttributes.LowerStatReq=90;
                        helma.Attributes.ReflectPhysical = 10;
			helma.Attributes.RegenHits = 1;
			helma.Attributes.RegenStam = 1;
               		helma.Attributes.DefendChance = 5;
        		helma.Resource=colour;
          helma.Identified = true;
                        from.EquipItem(helma);
                    break;

                    case 1:
                    helma = new PlateHelm();
                    helma.ItemID=9797;
                    helma.Movable=false;
        		helma.ArmorAttributes.LowerStatReq=90;
                        helma.Attributes.ReflectPhysical = 10;
			helma.Attributes.RegenHits = 1;
			helma.Attributes.RegenStam = 1;
               		helma.Attributes.DefendChance = 5;
        		helma.Resource=colour;
          helma.Identified = true;
                        from.EquipItem(helma);
                    break;
                    case 2:
                    helma = new PlateHelm();
                    helma.ItemID=11024;
                    helma.Movable=false;
        		helma.ArmorAttributes.LowerStatReq=90;
                        helma.Attributes.ReflectPhysical = 10;
			helma.Attributes.RegenHits = 1;
			helma.Attributes.RegenStam = 1;
               		helma.Attributes.DefendChance = 5;
        		helma.Resource=colour;
          helma.Identified = true;
                        from.EquipItem(helma);
                    break;
                    case 3:
                    helma = new PlateHelm();
                    helma.ItemID=11121;
                    helma.Movable=false;
        		helma.ArmorAttributes.LowerStatReq=90;
                        helma.Attributes.ReflectPhysical = 10;
			helma.Attributes.RegenHits = 1;
			helma.Attributes.RegenStam = 1;
               		helma.Attributes.DefendChance = 5;
        		helma.Resource=colour;
          helma.Identified = true;
                        from.EquipItem(helma);
                    break;
                    case 4:
                    helma = new PlateHelm();
                    helma.ItemID=11123;
                    helma.Movable=false;
        		helma.ArmorAttributes.LowerStatReq=90;
                        helma.Attributes.ReflectPhysical = 10;
			helma.Attributes.RegenHits = 1;
			helma.Attributes.RegenStam = 1;
               		helma.Attributes.DefendChance = 5;
        		helma.Resource=colour;
          helma.Identified = true;
                        from.EquipItem(helma);
                    break;
                    case 5:
                    helma = new PlateHelm();
                    helma.ItemID=5201;
                    helma.Movable=false;
        		helma.ArmorAttributes.LowerStatReq=90;
                        helma.Attributes.ReflectPhysical = 10;
			helma.Attributes.RegenHits = 1;
			helma.Attributes.RegenStam = 1;
               		helma.Attributes.DefendChance = 5;
        		helma.Resource=colour;
          helma.Identified = true;
                        from.EquipItem(helma);
                    break;
                }
                        /*PlateHelm helma = new PlateHelm();
                        helma.Movable=false;
        		helma.ArmorAttributes.LowerStatReq=90;
                        helma.Attributes.ReflectPhysical = 10;
			helma.Attributes.RegenHits = 1;
			helma.Attributes.RegenStam = 1;
               		helma.Attributes.DefendChance = 5;
        		helma.Resource=colour;
                        from.EquipItem(helma);*/
      		
      		Item shield = from.FindItemOnLayer( Layer.TwoHanded ); 
      	if ( shield != null )
      		{
                mobilePack.DropItem( shield );
      		}
        BaseArmor shielda;
        switch ( Utility.Random( 3 ))
                {
                    case 0:
                        shielda = new HeaterShield();
                        shielda.Movable=false;
        		shielda.ArmorAttributes.LowerStatReq=90;
                        shielda.Attributes.SpellChanneling = 1;
                        shielda.Attributes.ReflectPhysical = 10;
			shielda.Attributes.RegenHits = 1;
			shielda.Attributes.RegenStam = 1;
               		shielda.Attributes.DefendChance = 5;
        		shielda.Resource=colour;
          shielda.Identified = true;
                        from.EquipItem(shielda);
                    break;

                    case 1:
                    shielda = new HeaterShield();
                    shielda.ItemID=7108;
                    shielda.Movable=false;
        		shielda.ArmorAttributes.LowerStatReq=90;
                        shielda.Attributes.SpellChanneling = 1;
                        shielda.Attributes.ReflectPhysical = 10;
			shielda.Attributes.RegenHits = 1;
			shielda.Attributes.RegenStam = 1;
               		shielda.Attributes.DefendChance = 5;
        		shielda.Resource=colour;
          shielda.Identified = true;
                        from.EquipItem(shielda);
                    break;
                    case 2:
                    shielda = new HeaterShield();
                    shielda.ItemID=11009;
                    shielda.Movable=false;
        		shielda.ArmorAttributes.LowerStatReq=90;
                        shielda.Attributes.SpellChanneling = 1;
                        shielda.Attributes.ReflectPhysical = 10;
			shielda.Attributes.RegenHits = 1;
			shielda.Attributes.RegenStam = 1;
               		shielda.Attributes.DefendChance = 5;
        		shielda.Resource=colour;
          shielda.Identified = true;
                        from.EquipItem(shielda);
                    break;
                }
                        /*HeaterShield shielda = new HeaterShield();
                        shielda.Movable=false;
        		shielda.ArmorAttributes.LowerStatReq=90;
                        shielda.Attributes.SpellChanneling = 1;
                        shielda.Attributes.ReflectPhysical = 10;
			shielda.Attributes.RegenHits = 1;
			shielda.Attributes.RegenStam = 1;
               		shielda.Attributes.DefendChance = 5;
        		shielda.Resource=colour;
                        from.EquipItem(shielda);*/
      		
      		/*Item sword = from.FindItemOnLayer( Layer.FirstValid );
      	if ( sword != null )
      		{
mobilePack.DropItem( sword ); 
      		}
      Longsword sworda = new Longsword(); 
      sworda.Movable=false;
        		sworda.WeaponAttributes.UseBestSkill=1;
damage=((from.Int-(from.Str/from.Dex))/(from.Kills+1))+Utility.Random(1,7);
        		if(damage>=0)
        			        		sworda.Attributes.WeaponDamage=damage;
        		if(damage<=0)
        			        		sworda.Attributes.WeaponDamage=0;
        		sworda.Hue=colour;
      from.EquipItem(sworda); */
      		
        	}
        	return true;
        }
        public override bool OnDragLift( Mobile from )
    {
                 this.Attributes.Luck=0;
    	          this.Resource=CraftResource.Iron;
        	Container mobilePack = from.Backpack; 
        	if(mobilePack !=null)
        	{
        	 Item chest = from.FindItemOnLayer( Layer.InnerTorso ); 
      	if ( chest != null&& chest.Movable==false )
      		{
chest.Delete();
      		}
      		 Item legs = from.FindItemOnLayer( Layer.Pants ); 
      	if ( legs != null && legs.Movable==false )
      		{
legs.Delete(); 
      		}
      		Item arms = from.FindItemOnLayer( Layer.Arms ); 
      	if ( arms != null && arms.Movable==false)
      		{
arms.Delete();
      		}
      		Item neck = from.FindItemOnLayer( Layer.Neck ); 
      	if ( neck != null&& neck.Movable==false )
      		{
neck.Delete();
      		}
      		Item helm = from.FindItemOnLayer( Layer.Helm ); 
      	if ( helm != null&& helm.Movable==false )
      		{
helm.Delete() ;
      		}
      		Item shield = from.FindItemOnLayer( Layer.TwoHanded ); 
      	if ( shield != null && shield.Movable==false )
      		{
shield.Delete();
      		}
      		//Item sword = from.FindItemOnLayer( Layer.FirstValid );
      	//if ( sword != null && sword.Movable==false)
      			//{
//sword.Delete();
      			//}
        			}
        	return true;
        }
       
public override void OnRemoved( object parent )
    {
                 //PlayerMobile from = (PlayerMobile)parent;
                 PlayerMobile from = parent as PlayerMobile;
                      if( from == null )
		         return;

                 this.Attributes.Luck=0;
    	         this.Resource=CraftResource.Iron;
        	//Container mobilePack = from.Backpack;
        	//if(mobilePack !=null)
        	//{
        	 Item chest = from.FindItemOnLayer( Layer.InnerTorso );
      	if ( chest != null && chest.Movable==false )
      		{
chest.Delete();
      		}
      		 Item legs = from.FindItemOnLayer( Layer.Pants );
      	if ( legs != null && legs.Movable==false )
      		{
legs.Delete();
      		}
      		Item arms = from.FindItemOnLayer( Layer.Arms );
      	if ( arms != null && arms.Movable==false)
      		{
arms.Delete();
      		}
      		Item neck = from.FindItemOnLayer( Layer.Neck );
      	if ( neck != null&& neck.Movable==false )
      		{
neck.Delete();
      		}
      		Item helm = from.FindItemOnLayer( Layer.Helm );
      	if ( helm != null&& helm.Movable==false )
      		{
helm.Delete() ;
      		}
      		Item shield = from.FindItemOnLayer( Layer.TwoHanded );
      	if ( shield != null && shield.Movable==false )
      		{
shield.Delete();
      		}
      		//Item sword = from.FindItemOnLayer( Layer.FirstValid );
      	//if ( sword != null && sword.Movable==false)
      			//{
//sword.Delete();
      			//}
        			//}
        	base.OnRemoved( parent );//return;
        }
        
        public override DeathMoveResult OnParentDeath( Mobile parent )
		{
                        this.Attributes.Luck=0;
                        
			Item chest = parent.FindItemOnLayer( Layer.InnerTorso );
      	if ( chest != null)
      		{
chest.Delete();
      		}
      		 Item legs = parent.FindItemOnLayer( Layer.Pants );
      	if ( legs != null)
      		{
legs.Delete();
      		}
      		Item arms = parent.FindItemOnLayer( Layer.Arms );
      	if ( arms != null)
      		{
arms.Delete();
      		}
      		Item neck = parent.FindItemOnLayer( Layer.Neck );
      	if ( neck != null)
      		{
neck.Delete();
      		}
      		Item helm = parent.FindItemOnLayer( Layer.Helm );
      	if ( helm != null)
      		{
helm.Delete() ;
      		}
      		Item shield = parent.FindItemOnLayer( Layer.TwoHanded );
      	if ( shield != null)
      		{
shield.Delete();
      		}
      		//Item sword = parent.FindItemOnLayer( Layer.FirstValid );
      	//if ( sword != null)
      			//{
//sword.Delete();
      			//}
			return base.OnParentDeath( parent );
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
		}
	}
}
