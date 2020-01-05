using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ProjectMire.NPCs
{
    public class MireSlime : ModNPC // ModNPC is used for Custom NPCs
    {
        public override void SetStaticDefaults()
        {
            // The name the enemy displays
            DisplayName.SetDefault("Mud Slime");
            
            // The frame count for the enemy
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
        }
        public override void SetDefaults()
        {
            // Enemy Hitbox Width and Height
            npc.width = 30;
            npc.height = 30;
            // The Enemies max health
            npc.lifeMax = 65;
            // Damage and Defense
            npc.damage = 25;
            npc.defense = 6;
            // The sounds the enemy makes upon hit or death
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            // The amount of money that is dropped (as a float?)
            npc.value = 110f;
            // How much the Knockback is resisted.
            npc.knockBackResist = 1f;
            // The AI Style (Slime, Worm, Fighter)
            npc.aiStyle = 1;
            // Similar to AI style
            aiType = NPCID.JungleSlime;
            // How the Enemy animates
            animationType = NPCID.JungleSlime;
            // The Banner
            banner = Item.NPCtoBanner(NPCID.JungleSlime);
            // Then we link the banner to the banner item
            bannerItem = Item.BannerToItem(banner);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            // This is a way of spawning an enemy.
            // SpawnCondition contains a few options and chance given the chance.
            // You can return any float
                return SpawnCondition.SurfaceJungle.Chance * 0.75f;
            // You can modify this to offer different scenarios
            // For example:
            /*
             * float chance - 0f
             * if(!Main.dayTime)
             * {
             *      chance += .1f
             *      if(spawnInfo.spawnTileY <= Main.rockLayer && spawnInfo.spawnTileY >= Main.worldSurface * 0.15)
             *      {
             *          chance += .2f;
             *      }
             * }
             * return chance;
             */
            // In the above example we set a float chance to 0. We then increase it based on conditions.
            // First we check if it is night. If it is, we increase by .1 then we check if the y is between Main.rockLayer and a bit above WorldSurface. If it is then we add .2.
            // In this example, the enemy is more likely to spawn on the surface and underground but can spawn if it is night.
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            // This will loop and create "dust" upon being hit.
            for (int i = 0; i < 10; i++)
            {
                int dustType = mod.DustType("MudSlime");
                int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
            }
        }

        public override void NPCLoot()
        {
            //This will make the NPC always frop this item
            Item.NewItem(npc.position, mod.ItemType("Gel"));
            //This will make the npc only frop this item 25% of the time
            if(Main.rand.Next(4) == 0)
            {
                Item.NewItem(npc.position, ItemID.Gel, 5);
            }
            // This would make the NPC only drop in hardmode
            /*
             * if(Main.hardmode)
             * {
             *      Item.NewItem(npc.position, ItemID.PinkGel, 5);
             * }
             */
        }
    }
}