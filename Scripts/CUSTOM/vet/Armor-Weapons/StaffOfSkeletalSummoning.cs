using System; 
using Server.Network; 
using Server.Items; 
using Server.Mobiles;
using Server.Engines.VeteranRewards;

namespace Server.Items 
{ 
   [FlipableAttribute( 0xDF1, 0xDF0 )]
    public class StaffOfSkeletalSummoning : BaseStaff, IRewardItem 
   { 
      public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.WhirlwindAttack; } } 
      public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } } 
       
      public override int AosStrengthReq{ get{ return 25; } } 
      public override int AosMinDamage{ get{ return 13; } } 
      public override int AosMaxDamage{ get{ return 16; } } 
      public override int AosSpeed{ get{ return 39; } } 

      public override int OldStrengthReq{ get{ return 25; } } 
      public override int OldMinDamage{ get{ return 8; } } 
      public override int OldMaxDamage{ get{ return 33; } } 
      public override int OldSpeed{ get{ return 35; } } 

      public override int ArtifactRarity{ get{ return 10; } }

      private int fModDiv = 75;

      private bool m_IsRewardItem;
      [CommandProperty(AccessLevel.GameMaster)]
      public bool IsRewardItem
      {
          get { return m_IsRewardItem; }
          set { m_IsRewardItem = value; InvalidateProperties(); }
      }

       [Constructable] 
      public StaffOfSkeletalSummoning() : base( 0xDF1 ) 
      { 
          Name = "Staff of Skeletal Summoning"; 
          Weight = 5.0; 
         Attributes.SpellChanneling = 1; 
      } 

      public override void OnDoubleClick( Mobile from ) 
      { 
         if ( Parent != from ) 
         { 
            from.SendMessage( "You must equip this item to use it." ); 
            return; 
         }          

            if( from.Skills[SkillName.Necromancy].Value < 20 ) 
         { 
            from.SendMessage( "Your necromancy skill is not high enough to summon." ); 
            return; 
         } 
          
         IPooledEnumerable eable = from.Map.GetItemsInRange(from.Location, 10 ) ; 

         foreach( Item c in eable ) 
         {    
            if( c is Corpse) 
            { 
               Corpse corpse = (Corpse)c; 

               if( !corpse.Owner.Player ) 
               { 
                  if( from.Skills[SkillName.Necromancy].Value >= 90 ) 
                  { 
                     BaseCreature.Summon(new SkeletalMage(),from,c.Location, 0x48D, TimeSpan.FromSeconds(from.Skills[SkillName.SpiritSpeak].Value * 3) ); 
                     from.Mana -=15; 
                     c.Delete(); 
                     eable.Free(); 
                     return; 
                  } 
                  if( from.Skills[SkillName.Necromancy].Value >= 50 ) 
                  { 
                     BaseCreature.Summon(new SkeletalKnight(),from,c.Location, 0x48D, TimeSpan.FromSeconds(from.Skills[SkillName.SpiritSpeak].Value * 3) ); 
                     from.Mana -= 12; 
                     c.Delete(); 
                     eable.Free(); 
                     return; 
                  } 
                   
                  BaseCreature.Summon(new Skeleton(),from,c.Location, 0x48D, TimeSpan.FromSeconds(from.Skills[SkillName.SpiritSpeak].Value * 3) ); 
                  from.Mana -= 10; 
                  c.Delete(); 
                  eable.Free(); 
                  return; 
               } 
            } 
             
         } 
         from.SendMessage("You must be near a corpse to raise it"); 
         eable.Free(); 
      }    

      public override bool OnEquip( Mobile from ) 
      { 
          if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
            {
                from.SendMessage("This does not belong to you!!");
                return false;
            }
            else if( from.Skills[SkillName.Necromancy].Value >= 10 ) 
         { 
            double fMod = (from.Skills[SkillName.Necromancy].Value + from.Skills[SkillName.SpiritSpeak].Value) / fModDiv ; 
             
            from.FollowersMax += (int)fMod; 
         } 
         base.OnEquip(from); 
         return true; 
      } 

      public override void OnRemoved( object o ) 
      { 
         if( o is Mobile) 
         { 
            if( ((Mobile)o).Skills[SkillName.Necromancy].Value >= 10 ) 
            { 
               double fMod = (((Mobile)o).Skills[SkillName.Necromancy].Value + ((Mobile)o).Skills[SkillName.SpiritSpeak].Value) / fModDiv ; 
             
               ((Mobile)o).FollowersMax -= (int)fMod; 
            } 
         } 
          
         base.OnRemoved( o ); 
      } 

      public StaffOfSkeletalSummoning( Serial serial ) : base( serial ) 
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
