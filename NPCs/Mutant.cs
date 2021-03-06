using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.NPCs
{
    [AutoloadHead]
    public class Mutant : ModNPC
    {
        private static bool prehardmodeShop;
        private static bool hardmodeShop;
        private static int shopNum = 1;

        internal bool spawned;

        #region Mod Bools

        // Fargo
        public static bool FargoDownedFishEX => FargowiltasSouls.FargoSoulsWorld.downedFishronEX;

        public static bool FargoDownedAbom => FargowiltasSouls.FargoSoulsWorld.downedAbom;

        public static bool FargoDownedMutant => FargowiltasSouls.FargoSoulsWorld.downedMutant;

        public static bool MutantsDiscountCard => Main.LocalPlayer.GetModPlayer<FargowiltasSouls.FargoPlayer>().MutantsDiscountCard;

        public static bool MutantsPact => Main.LocalPlayer.GetModPlayer<FargowiltasSouls.FargoPlayer>().MutantsPact;

        // Thorium
        public static bool ThoriumDownedBird => ThoriumMod.ThoriumWorld.downedThunderBird;

        public static bool ThoriumDownedJelly => ThoriumMod.ThoriumWorld.downedJelly;

        public static bool ThoriumDownedStorm => ThoriumMod.ThoriumWorld.downedStorm;

        public static bool ThoriumDownedChamp => ThoriumMod.ThoriumWorld.downedChampion;

        public static bool ThoriumDownedScout => ThoriumMod.ThoriumWorld.downedScout;

        public static bool ThoriumDownedStrider => ThoriumMod.ThoriumWorld.downedStrider;

        public static bool ThoriumDownedBeholder => ThoriumMod.ThoriumWorld.downedFallenBeholder;

        public static bool ThoriumDownedLich => ThoriumMod.ThoriumWorld.downedLich;

        public static bool ThoriumDownedAbyss => ThoriumMod.ThoriumWorld.downedDepthBoss;

        public static bool ThoriumDownedRag => ThoriumMod.ThoriumWorld.downedRealityBreaker;

        public static bool ThoriumDownedViscount => ThoriumMod.ThoriumWorld.downedBat;

        // Calamity
        public static bool CalamityDownedScourge => CalamityMod.World.CalamityWorld.downedDesertScourge;

        public static bool CalamityDownedHive => CalamityMod.World.CalamityWorld.downedHiveMind;

        public static bool CalamityDownedPerfor => CalamityMod.World.CalamityWorld.downedPerforator;

        public static bool CalamityDownedSlime => CalamityMod.World.CalamityWorld.downedSlimeGod;

        public static bool CalamityDownedCryo => CalamityMod.World.CalamityWorld.downedCryogen;

        public static bool CalamityDownedBrim => CalamityMod.World.CalamityWorld.downedBrimstoneElemental;

        public static bool CalamityDownedCalamitas => CalamityMod.World.CalamityWorld.downedCalamitas;

        public static bool CalamityDownedLevi => CalamityMod.World.CalamityWorld.downedLeviathan;

        public static bool CalamityDownedPlague => CalamityMod.World.CalamityWorld.downedPlaguebringer;

        public static bool CalamityDownedGuardian => CalamityMod.World.CalamityWorld.downedGuardians;

        public static bool CalamityDownedProv => CalamityMod.World.CalamityWorld.downedProvidence;

        public static bool CalamityDownedDOG => CalamityMod.World.CalamityWorld.downedDoG;

        public static bool CalamityDownedYharon => CalamityMod.World.CalamityWorld.downedYharon;

        public static bool CalamityDownedSCAL => CalamityMod.World.CalamityWorld.downedSCal;

        public static bool CalamityDownedRav => CalamityMod.World.CalamityWorld.downedScavenger;

        public static bool CalamityDownedCrab => CalamityMod.World.CalamityWorld.downedCrabulon;

        public static bool CalamityDownedAstrum => CalamityMod.World.CalamityWorld.downedStarGod;

        public static bool CalamityDownedBirb => CalamityMod.World.CalamityWorld.downedBumble;

        public static bool CalamityDownedPolter => CalamityMod.World.CalamityWorld.downedPolterghast;

        public static bool CalamityDownedAquatic => CalamityMod.World.CalamityWorld.downedAquaticScourge;

        public static bool CalamityDownedAstragel => CalamityMod.World.CalamityWorld.downedAstrageldon;

        // SacredTools
        public static bool SacredDownedHarpy => SacredTools.ModdedWorld.downedHarpy;

        public static bool SacredDownedHarpy2 => SacredTools.ModdedWorld.downedRaynare;

        public static bool SacredDownedAbbadon => SacredTools.ModdedWorld.OblivionSpawns;

        public static bool SacredDownedSerpent => SacredTools.ModdedWorld.FlariumSpawns;

        public static bool SacredDownedLunar => SacredTools.ModdedWorld.downedLunarians;

        public static bool SacredDownedPump => SacredTools.ModdedWorld.downedPumpboi;

        public static bool SacreddownedDecree => SacredTools.ModdedWorld.downedDecree;

        public static bool SacreddownedPrimordia => SacredTools.ModdedWorld.downedPrimordia;

        public static bool SacreddownedAraneas => SacredTools.ModdedWorld.downedAraneas;

        // GRealm
        public static bool GRealmDownedFolivine => GRealm.MWorld.downedFolivine;

        public static bool GRealmDownedMantid => GRealm.MWorld.downedMatriarch;

        // Joost
        public static bool JoostDownedCactuar => JoostMod.JoostWorld.downedJumboCactuar;

        public static bool JoostDownedSAX => JoostMod.JoostWorld.downedSAX;

        public static bool JoostDownedGilga => JoostMod.JoostWorld.downedGilgamesh;

        // Spirit
        public static bool SpiritDownedScarab => SpiritMod.MyWorld.downedScarabeus;

        public static bool SpiritDownedFlier => SpiritMod.MyWorld.downedAncientFlier;

        public static bool SpiritDownedRaider => SpiritMod.MyWorld.downedRaider;

        public static bool SpiritDownedInfer => SpiritMod.MyWorld.downedInfernon;

        public static bool SpiritDownedDusking => SpiritMod.MyWorld.downedDusking;

        public static bool SpiritDownedIlluminant => SpiritMod.MyWorld.downedIlluminantMaster;

        public static bool SpiritDownedAtlas => SpiritMod.MyWorld.downedAtlas;

        public static bool SpiritDownedOverseer => SpiritMod.MyWorld.downedOverseer;

        public static bool SpiritDownedVine => SpiritMod.MyWorld.downedReachBoss;

        public static bool SpiritDownedUmbra => SpiritMod.MyWorld.downedSpiritCore;

        // BTFA
        public static bool BtfaTitan => ForgottenMemories.TGEMWorld.downedTitanRock;

        public static bool BtfaAcheron => ForgottenMemories.TGEMWorld.downedAcheron;

        public static bool BtfaArtery => ForgottenMemories.TGEMWorld.downedArterius;

        public static bool BtfaGhastly => ForgottenMemories.TGEMWorld.downedGhastlyEnt;

        // Bluemagic
        public static bool BlueDownedPhantom => Bluemagic.BluemagicWorld.downedPhantom;

        public static bool BlueDownedAbom => Bluemagic.BluemagicWorld.downedAbomination;

        // EotA
        public static bool AncientsDownedWorms => EchoesoftheAncients.AncientWorld.downedWyrms;

        // Crystilium
        public static bool CrystiliumDownedKing => CrystiliumMod.CrystalWorld.downedCrystalKing;

        // W1K
        public static bool W1KDownedKutku => W1KModRedux.MWorld.downedKutKu;

        public static bool W1KDownedArdorix => W1KModRedux.MWorld.downedArdorix;

        public static bool W1KDownedArborix => W1KModRedux.MWorld.downedArborix;

        public static bool W1KDownedAquatix => W1KModRedux.MWorld.downedAquatix;

        public static bool W1KDownedIvy => W1KModRedux.MWorld.downedIvy;

        public static bool W1KDownedDeath => W1KModRedux.MWorld.downedDeath;

        public static bool W1KDownedRathalos => W1KModRedux.MWorld.downedRathalos;

        public static bool W1KDownedRidley => W1KModRedux.MWorld.downedRidley;

        public static bool W1KDownedOkiku => W1KModRedux.MWorld.downedOkiku;

        // Fernium
        /*public static bool FerniumDownedMargrama => Fernium.world.downedMargrama;
        public static bool FerniumDownedLunarRex => Fernium.world.downedLunarRex;
        public static bool FerniumFernite => Fernium.world.downedFerniteTheUnpleasant;*/

        // Elements awoken
        public static bool ElementsDownedWaste => ElementsAwoken.MyWorld.downedWasteland;

        public static bool ElementsDownedInfern => ElementsAwoken.MyWorld.downedInfernace;

        public static bool ElementsDownedScourge => ElementsAwoken.MyWorld.downedScourgeFighter;

        public static bool ElementsDownedReg => ElementsAwoken.MyWorld.downedRegaroth;

        public static bool ElementsDownedCelestial => ElementsAwoken.MyWorld.downedCelestial;

        public static bool ElementsDownedObsid => ElementsAwoken.MyWorld.downedObsidious;

        public static bool ElementsDownedPerma => ElementsAwoken.MyWorld.downedPermafrost;

        public static bool ElementsDownedAque => ElementsAwoken.MyWorld.downedAqueous;

        public static bool ElementsDownedDragon => ElementsAwoken.MyWorld.downedAncientWyrm;

        public static bool ElementsDownedGuardian => ElementsAwoken.MyWorld.downedGuardian;

        public static bool ElementsDownedVoid => ElementsAwoken.MyWorld.downedVoidLeviathan;

        public static bool ElementsDownedVolcanox => ElementsAwoken.MyWorld.downedVolcanox;

        public static bool ElementsDownedAzana => ElementsAwoken.MyWorld.downedAzana;

        // Antiaris
        public static bool AntiarisDownedAntlion => Antiaris.AntiarisWorld.DownedAntlionQueen;

        public static bool AntiarisDownedKeeper => Antiaris.AntiarisWorld.DownedTowerKeeper;

        // Disarray
        public static bool DisarrayDownedPlant => Disarray.DisarrayWorld.downedPlantKing;

        public static bool DisarrayDownedCrusher => Disarray.DisarrayWorld.downedDesertCrusher;

        public static bool DisarrayDownedProbe => Disarray.DisarrayWorld.downedProbeMother;

        public static bool DisarrayDownedGeneral => Disarray.DisarrayWorld.downedTheGeneral;

        public static bool DisarrayDownedSerpent => Disarray.DisarrayWorld.downedLunarSerpent;

        public static bool DisarrayDownedCold => Disarray.DisarrayWorld.downedColdBoss;

        public static bool DisarrayDownedShadows => Disarray.DisarrayWorld.downedShadows;

        public static bool DisarrayDownedLuna => Disarray.DisarrayWorld.downedLuna;

        public static bool DisarrayDownedBell => Disarray.DisarrayWorld.downedBell;

        public static bool DisarrayDownedMech => Disarray.DisarrayWorld.downedMech;

        public static bool DisarrayDownedSludge => Disarray.DisarrayWorld.downedCosmicSludge;

        public static bool DisarrayDownedDeva => Disarray.DisarrayWorld.downedCoreOfTheDevastator;

        public static bool DisarrayDownedMeteor => Disarray.DisarrayWorld.downedMeteorzoid;

        public static bool DisarrayDownedDungeon => Disarray.DisarrayWorld.downedDungeon;

        // Cookie
        public static bool CookieDownedCookie => CookieMod.CookieModWorld.downedCookieBoss;

        public static bool CookieDownedBunny => CookieMod.CookieModWorld.downedBunny;

        // Enigma
        public static bool EnigmaDownedAnnih => Laugicality.LaugicalityWorld.downedAnnihilator;

        public static bool EnigmaDownedSlyber => Laugicality.LaugicalityWorld.downedSlybertron;

        public static bool EnigmaDownedTrain => Laugicality.LaugicalityWorld.downedSteamTrain;

        public static bool EnigmaDownedShark => Laugicality.LaugicalityWorld.downedDuneSharkron;

        public static bool EnigmaDownedHypo => Laugicality.LaugicalityWorld.downedHypothema;

        public static bool EnigmaDownedRagnar => Laugicality.LaugicalityWorld.downedRagnar;

        public static bool EnigmaDownedRocks => Laugicality.LaugicalityWorld.downedRocks;

        public static bool EnigmaDownedEther => Laugicality.LaugicalityWorld.downedTrueEtheria;

        public static bool EnigmaDownedDio => Laugicality.LaugicalityWorld.downedAnDio;

        // Trelamium
        public static bool TrelamiumAzolinth => TrelamiumMod.TrelamiumModWorld.downedAzolinth;

        public static bool TrelamiumSerpent => TrelamiumMod.TrelamiumModWorld.downedCrystallineSerpent;

        public static bool TrelamiumCumulor => TrelamiumMod.TrelamiumModWorld.downedCumulor;

        public static bool TrelamiumParadox => TrelamiumMod.TrelamiumModWorld.downedParadoxHive;

        public static bool TrelamiumPermafrost => TrelamiumMod.TrelamiumModWorld.downedPermafrost;

        public static bool TrelamiumGoliath => TrelamiumMod.TrelamiumModWorld.downedPholiotaGoliath;

        public static bool TrelamiumPyron => TrelamiumMod.TrelamiumModWorld.downedPyron;

        public static bool TrelamiumSymphony => TrelamiumMod.TrelamiumModWorld.downedSymphony;

        // Ancients Awakened
        public static bool AAMonarch => AAMod.AAWorld.downedMonarch;

        public static bool AAFungus => AAMod.AAWorld.downedFungus;

        public static bool AAGrips => AAMod.AAWorld.downedGrips;

        public static bool AABrood => AAMod.AAWorld.downedBrood;

        public static bool AAHydra => AAMod.AAWorld.downedHydra;

        public static bool AAToad => AAMod.AAWorld.downedToad;

        public static bool AADjinn => AAMod.AAWorld.downedDjinn;

        public static bool AASerpent => AAMod.AAWorld.downedSerpent;

        public static bool AASag => AAMod.AAWorld.downedSag;

        /* public static bool AARetriever => AAMod.AAWorld.downedRetriever;
           public static bool AARaider => AAMod.AAWorld.downedRaider;
           public static bool AAOrthrus => AAMod.AAWorld.downedOrthrus;
           public static bool AATruffle => AAMod.AAWorld.downedTruffle;*/

        public static bool AARajah => AAMod.AAWorld.downedRajah;

        public static bool AAEquinox => AAMod.AAWorld.downedEquinox;

        public static bool AASisters => AAMod.AAWorld.downedSisters;

        public static bool AAYamata => AAMod.AAWorld.downedYamata;

        public static bool AAYamataA => AAMod.AAWorld.downedYamata && Main.expertMode;

        public static bool AAAkuma => AAMod.AAWorld.downedAkuma;

        public static bool AAAkumaA => AAMod.AAWorld.downedAkuma && Main.expertMode;

        public static bool AAZero => AAMod.AAWorld.downedZero;

        public static bool AAZeroA => AAMod.AAWorld.downedZero && Main.expertMode;

        public static bool AAShen => AAMod.AAWorld.downedShen;

        public static bool AAShenA => AAMod.AAWorld.downedShen && Main.expertMode;

        // public static bool AAIZ => AAMod.AAWorld.downedIZ;
        // public static bool AASoC => AAMod.AAWorld.downedSoC;

        // Pinky
        public static bool PinkySlime => pinkymod.Global.Pinkyworld.downedMythrilSlime;

        public static bool PinkyValdaris => pinkymod.Global.Pinkyworld.downedValdaris;

        public static bool PinkySunlight => pinkymod.Global.Pinkyworld.downedSunlightTrader;

        public static bool PinkyAbyssmal => pinkymod.Global.Pinkyworld.downedAbyssmalDuo;

        // Redemption
        public static bool RedeChicken => Redemption.RedeWorld.downedKingChicken;

        public static bool RedeThorn => Redemption.RedeWorld.downedThorn;

        public static bool RedeKeeper => Redemption.RedeWorld.downedTheKeeper;

        public static bool RedeXeno => Redemption.RedeWorld.downedXenomiteCrystal;

        public static bool RedeEye => Redemption.RedeWorld.downedInfectedEye;

        public static bool RedePortal => Redemption.RedeWorld.downedStrangePortal;

        public static bool RedeGigipede => Redemption.RedeWorld.downedVlitch2;

        public static bool RedeCleaver => Redemption.RedeWorld.downedVlitch1;

        public static bool RedeSlayer => Redemption.RedeWorld.downedSlayer;

        public static bool RedeOmega => Redemption.RedeWorld.downedVlitch3;

        public static bool RedeThornPZ => Redemption.RedeWorld.downedThornPZ;

        public static bool RedeEaglecrestPZ => Redemption.RedeWorld.downedEaglecrestGolemPZ;

        public static bool RedeNeb => Redemption.RedeWorld.downedNebuleus;

        // Jetshift

        /*public static bool JSSnake => Jetshift.JetshiftWorld.downedSnakeBoss;
        public static bool JSReaper => Jetshift.JetshiftWorld.downedReaper;
        public static bool JSViyilblud => Jetshift.JetshiftWorld.downedViyilblud;
        public static bool JSWall => Jetshift.JetshiftWorld.downedWallofVoices;
        public static bool JSArlenon => Jetshift.JetshiftWorld.downedArlenon;
        public static bool JSAthazel => Jetshift.JetshiftWorld.downedAthazel;
        public static bool JSPolypus => Jetshift.JetshiftWorld.downedPolypus;
        public static bool JSFrezyn => Jetshift.JetshiftWorld.downedFrezyn;
        public static bool JSMortalos => Jetshift.JetshiftWorld.downedMortalos;
        public static bool JSShift => Jetshift.JetshiftWorld.downedShiftFinal;
        public static bool JSAnnihilation => Jetshift.JetshiftWorld.downedAnnihilation;
        public static bool JSCCP1 => Jetshift.JetshiftWorld.downedCCP1;
        public static bool JSCCP2 => Jetshift.JetshiftWorld.downedCCP2;
        public static bool JSCosmic => Jetshift.JetshiftWorld.downedCosmicMystery;*/

        // Ocram
        public static bool OcramOcram => Ocram.OcramWorld.downedOcram;

        // Celestial Skies
        public static bool CSkiesObserver => CSkies.CWorld.downedObserver;

        public static bool CSkiesObserverV => CSkies.CWorld.downedObserverV;

        public static bool CSkiesStarcore => CSkies.CWorld.downedStarcore;

        public static bool CSkiesHeartcore => CSkies.CWorld.downedHeartcore;

        #endregion

        public override bool Autoload(ref string name)
        {
            name = "Mutant";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mutant");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = NPC.downedMoonlord ? 50 : 15;
            npc.lifeMax = NPC.downedMoonlord ? 5000 : 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
            Main.npcCatchable[npc.type] = true;
            npc.catchItem = (short)mod.ItemType("Mutant");
            npc.buffImmune[BuffID.Suffocation] = true;

            if (Fargowiltas.ModLoaded["FargowiltasSouls"] && FargoDownedMutant)
            {
                npc.lifeMax = 7700000;
                npc.defense = 400;
            }
        }

        public override void AI()
        {
            npc.breath = 200;
            if (!spawned)
            {
                spawned = true;
                if (Fargowiltas.ModLoaded["FargowiltasSouls"] && FargoDownedMutant)
                {
                    npc.lifeMax = 7700000;
                    npc.life = npc.lifeMax;
                    npc.defense = 400;
                }
            }
        }

        public static bool FargoMutantBossAlive => FargowiltasSouls.NPCs.FargoSoulsGlobalNPC.BossIsAlive(ref FargowiltasSouls.NPCs.FargoSoulsGlobalNPC.mutantBoss, ModLoader.GetMod("FargowiltasSouls").NPCType("MutantBoss"));

        public override bool CanTownNPCSpawn(int numTownnpcs, int money)
        {
            if (Fargowiltas.ModLoaded["FargowiltasSouls"] && FargoMutantBossAlive)
            {
                return false;
            }
            return FargoWorld.DownedBools["boss"];
        }

        public override string TownNPCName()
        {
            string[] names = { "Flacken", "Dorf", "Bingo", "Hans", "Fargo", "Grim", "Furgo", "Fargu", "Terrance", "Catty N. Pem", "Tom", "Weirdus", "Polly" };
            return Main.rand.Next(names);
        }

        public override string GetChat()
        {
            List<string> dialogue = new List<string>
            {
                "Savagery, barbarism, bloodthirst, that's what I like seeing in people.",
                "The stronger you get, the more stuff I sell. Makes sense, right?",
                "There's something all of you have that I don't... Death perception, I think it's called?",
                "It would be pretty cool if I sold a summon for myself...",
                "The only way to get stronger is to keep buying from me and in bulk too!",
                "Why are you looking at me like that, all I did was eat an apple.",
                "Don't bother with anyone else, all you'll ever need is right here.",
                "You're lucky I'm on your side.",
                "Thanks for the house, I guess.",
                "Why yes I would love a ham and swiss sandwich.",
                "Should I start wearing clothes? ...Nah.",
                "It's not like I can actually use all the gold you're spending.",
                "Violence for violence is the law of the beast.",
                "Those guys really need to get more creative. All of their first bosses are desert themed!",
                "You say you want to know how a Mutant and Abominationn are brothers? You're better off not knowing.",
                "I'm all you need for a calamity.",
                "Everything shall bow before me! ...after you make this purchase.",
                "It's clear that I'm helping you out, but uh.. what's in this for me? A house you say? I eat zombies for breakfast.",
                "Can I jump? No, I don't have something called a 'spacebar'.",
                "Got your nose, I needed one to replace mine.",
                "What's a Terry?",
                "Why do so many creatures carry around a weird looking blue doll? The world may never know.",
                "Impending doom approaches. ...If you don't buy anything of course.",
                "I've heard of a '3rd dimension', I wonder what that looks like.",
                "Boy don't I look fabulous today.",
                "You have fewer friends than I do eyes.",
                "The ocean is a dangerous place, I wonder where Diver is?",
                "Do you know what an Ee-arth is?",
                "I can't even spell 'apotheosis', do you expect me to know what it is?",
                "Where do monsters get their gold from? ...I don't have pockets you know.",
                "Dogs are cool and all, but cats don't try to bite my brain.",
                "Beware the green dragon... What's that face mean?",
                "Where is this O-hi-o I keep hearing about.",
                "I've told you 56 times already, I'm busy... Oh wait you want to buy something, I suppose I have time.",
                "I've heard of a 'Soul of Souls' that only exists in 2015.",
                "Adding EX after everything makes it way more difficult.",
                "I think that all modern art looks great, especially the bloody stuff.",
                "How many guides does it take to change a lightbulb? ... I don't know, how about you ask him.",
                "Good thing I don't have a bed, I'd probably never leave it.",
                "What's this about an update? Sounds rare.",
                "If you need me I'll be slacking off somewhere.",
                "What do you mean who is Fargo!",
                "Have you seen the ech cat?",
                "I don't understand music nowadays, I prefer some smooth jazz... or the dying screams of monsters.",
                "Cthulhu's got nothing on me!",
            };

            if (Fargowiltas.ModLoaded["FargowiltasSouls"])
            {
                dialogue.AddWithCondition("Now that you've defeated the big guy, I'd say it's time to start collecting those materials!", NPC.downedMoonlord);

                if (FargoDownedMutant)
                {
                    dialogue.Add("What's that? You want to fight me? ...sure, I guess.");
                }
                else if (FargoDownedFishEX || FargoDownedAbom)
                {
                    dialogue.Add("What's that? You want to fight me? ...maybe if I had a reason.");
                }
            }
            else
            {
                dialogue.Add("What's that? You want to fight me? ...you're not worthy you rat.");
            }

            dialogue.AddWithCondition("Why would you do this.", Fargowiltas.ModLoaded["CalamityMod"]);
            dialogue.AddWithCondition("I feel a great imbalance in this world.", Fargowiltas.ModLoaded["CalamityMod"] && Fargowiltas.ModLoaded["ThoriumMod"]);
            dialogue.AddWithCondition("A great choice, shame about that first desert boss thing though.", Fargowiltas.ModLoaded["ThoriumMod"]);
            dialogue.AddWithCondition("A bit spooky tonight, isn't it.", Main.pumpkinMoon);
            dialogue.AddWithCondition("I'd ask for a coat, but I don't think you have any my size.", Main.snowMoon);
            dialogue.AddWithCondition("Weather seems odd today, wouldn't you agree?", Main.slimeRain);
            dialogue.AddWithCondition("Lovely night, isn't it?", Main.bloodMoon);
            dialogue.AddWithCondition("I hope the constant arguing I'm hearing isn't my fault.", Main.bloodMoon);
            dialogue.AddWithCondition("I'd follow and help, but I'd much rather sit around right now.", !Main.dayTime);

            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (BirthdayParty.PartyIsUp)
            {
                if (partyGirl >= 0)
                {
                    dialogue.Add($"{Main.npc[partyGirl].GivenName} is the one who invited me, I don't understand why though.");
                }
                
                dialogue.Add("I don't know what everyone's so happy about, but as long as nobody mistakes me for a Pigronata, I'm happy too.");
            }

            int lumberJack = NPC.FindFirstNPC(mod.NPCType("LumberJack"));
            if (lumberJack >= 0)
            {
                dialogue.Add($"It's okay {Main.npc[npc.whoAmI].GivenName}, just don't look straight into {Main.npc[lumberJack].GivenName}'s eyes. He can't scare you that way...");
            }

            int nurse = NPC.FindFirstNPC(NPCID.Nurse);
            if (nurse >= 0)
            {
                dialogue.Add($"Whenever we're alone, {Main.npc[nurse].GivenName} keeps throwing syringes at me, no matter how many times I tell her to stop!");
            }

            int witchDoctor = NPC.FindFirstNPC(NPCID.WitchDoctor);
            if (witchDoctor >= 0)
            {
                dialogue.Add($"Please go tell {Main.npc[witchDoctor].GivenName} to drop the 'mystical' shtick, I mean, come on! I get it, you make tainted water or something.");
            }

            int dryad = NPC.FindFirstNPC(NPCID.Dryad);
            if (dryad >= 0)
            {
                dialogue.Add($"Why does {Main.npc[dryad].GivenName}'s outfit make my wings flutter?");
            }

            int stylist = NPC.FindFirstNPC(NPCID.Stylist);
            if (stylist >= 0)
            {
                dialogue.Add($"{Main.npc[stylist].GivenName} once gave me a wig... I look hideous with long hair.");
            }

            int truffle = NPC.FindFirstNPC(NPCID.Truffle);
            if (truffle >= 0)
            {
                dialogue.Add("That mutated mushroom seems like my type of fella.");
            }

            int tax = NPC.FindFirstNPC(NPCID.TaxCollector);
            if (tax >= 0)
            {
                dialogue.Add($"{Main.npc[tax].GivenName} keeps asking me for money, but he won't accept my spawners!");
            }

            int guide = NPC.FindFirstNPC(NPCID.Guide);
            if (guide >= 0)
            {
                dialogue.Add($"Any idea why {Main.npc[guide].GivenName} is always cowering in fear when I get near him?");
            }

            int cyborg = NPC.FindFirstNPC(NPCID.Cyborg);
            if (truffle >= 0 && witchDoctor >= 0 && cyborg >= 0 && Main.rand.NextBool(52))
            {
                dialogue.Add($"If any of us could play instruments, I'd totally start a band with {Main.npc[witchDoctor].GivenName}, {Main.npc[truffle].GivenName}, and {Main.npc[cyborg].GivenName}.");
            }

            if (partyGirl >= 0)
            {
                dialogue.Add($"Man, {Main.npc[partyGirl].GivenName}'s confetti keeps getting stuck to my wings");
            }

            int demoman = NPC.FindFirstNPC(NPCID.Demolitionist);
            if (demoman >= 0)
            {
                dialogue.Add($"I'm surprised {Main.npc[demoman].GivenName} hasn't blown a hole in the floor yet, on second thought that sounds fun.");
            }

            int tavernkeep = NPC.FindFirstNPC(NPCID.DD2Bartender);
            if (tavernkeep >= 0)
            {
                dialogue.Add($"{Main.npc[tavernkeep].GivenName} keeps suggesting I drink some beer, something tells me he wouldn't like me when I'm drunk though.");
            }

            int dyeTrader = NPC.FindFirstNPC(NPCID.DyeTrader);
            if (dyeTrader >= 0)
            {
                dialogue.Add($"{Main.npc[dyeTrader].GivenName} wants to see what I would look like in blue... I don't know how to feel.");
            }

            return Main.rand.Next(dialogue);
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            switch (shopNum)
            {
                case 1:
                    button = "Pre Hardmode";
                    break;

                case 2:
                    button = "Hardmode";
                    break;

                default:
                    button = "Post Moon Lord";
                    break;
            }

            if (Main.hardMode)
            {
                button2 = "Cycle Shop";
            }

            if (NPC.downedMoonlord)
            {
                if (shopNum >= 4)
                {
                    shopNum = 1;
                }
            }
            else
            {
                if (shopNum >= 3)
                {
                    shopNum = 1;
                }
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;

                switch (shopNum)
                {
                    case 1:
                        prehardmodeShop = true;
                        hardmodeShop = false;
                        break;
                    case 2:
                        hardmodeShop = true;
                        prehardmodeShop = false;
                        break;
                    default:
                        prehardmodeShop = false;
                        hardmodeShop = false;
                        break;
                }
            }
            else if (!firstButton && Main.hardMode)
            {
                shopNum++;
            }
        }

        public static void AddItem(bool check, string mod, string item, int price, ref Chest shop, ref int nextSlot)
        {
            if (!check || shop is null)
            {
                return;
            }

            shop.item[nextSlot].SetDefaults(ModLoader.GetMod(mod).ItemType(item));
            shop.item[nextSlot].value = price;

            // Lowered prices with discount card and pact
            if (Fargowiltas.ModLoaded["FargowiltasSouls"])
            {
                float modifier = 1f;
                if (MutantsDiscountCard)
                {
                    modifier -= 0.2f;
                }

                if (MutantsPact)
                {
                    modifier -= 0.3f;
                }

                shop.item[nextSlot].value = (int)(shop.item[nextSlot].value * modifier);
            }

            nextSlot++;
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            //int tracker = Fargowiltas.summonTracker.SortedSummons.Capacity;
            Main.NewText(Fargowiltas.summonTracker.SortedSummons[0].itemName);

            AddItem(!Main.expertMode, "Fargowiltas", "ExpertToggle", 1000000, ref shop, ref nextSlot);
            AddItem(Main.expertMode, "Fargowiltas", "Overloader", 400000, ref shop, ref nextSlot);







            if (prehardmodeShop)
            {
                if (Fargowiltas.ModLoaded["FargowiltasSouls"])
                {
                    AddItem(true, "FargowiltasSouls", "Masochist", 10000, ref shop, ref nextSlot); // mutants gift, dam meme namer
                }

                foreach (MutantSummonInfo summon in Fargowiltas.summonTracker.SortedSummons)
                {
                    //phm
                    if (summon.progression <= 6f)
                    {
                        AddItem(summon.downed(), summon.modSource, summon.itemName, summon.price, ref shop, ref nextSlot);
                    }
                }




                




                if (Fargowiltas.ModLoaded["Redemption"])
                {
                    // The Mighty King Chicken
                    AddItem(RedeChicken, "Redemption", "EggCrown", 50000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["AAMod"])
                {
                    // Mushroom Monarch
                    AddItem(AAMonarch, "AAMod", "IntimidatingMushroom", 20000, ref shop, ref nextSlot);
                    AddItem(AAFungus, "AAMod", "ConfusingMushroom", 20000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["SpiritMod"])
                {
                    // Scarabeus
                    AddItem(SpiritDownedScarab, "SpiritMod", "ScarabIdol", 20000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Disarray"])
                {
                    AddItem(DisarrayDownedPlant, "Disarray", "YoungSapling", 20000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["TrelamiumMod"])
                {
                    AddItem(TrelamiumGoliath, "TrelamiumMod", "MycelialCluster", 20000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ThoriumMod"])
                {
                    // Grand Thunderbird
                    AddItem(ThoriumDownedBird, "ThoriumMod", "StormFlare", 50000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Redemption"])
                {
                    AddItem(RedeThorn, "Redemption", "HeartOfTheThorns", 60000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Disarray"])
                {
                    AddItem(DisarrayDownedCrusher, "Disarray", "ScorpionIdol", 60000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CalamityMod"])
                {
                    // Desert Scourge
                    AddItem(CalamityDownedScourge, "CalamityMod", "DriedSeafood", 20000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["AAMod"])
                {
                    // Grips of Chaos
                    AddItem(AAGrips, "AAMod", "CuriousClaw", 80000, ref shop, ref nextSlot);
                    AddItem(AAGrips, "AAMod", "InterestingClaw", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["SacredTools"])
                {
                    AddItem(SacreddownedDecree, "SacredTools", "DecreeSummon", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Redemption"])
                {
                    // Keeper
                    if (WorldGen.crimson)
                    {
                        AddItem(RedeKeeper, "Redemption", "MysteriousTabletCrimson", 80000, ref shop, ref nextSlot);
                    }
                    else
                    {
                        AddItem(RedeKeeper, "Redemption", "MysteriousTabletCorrupt", 80000, ref shop, ref nextSlot);
                    }
                }

                if (Fargowiltas.ModLoaded["W1KModRedux"])
                {
                    AddItem(W1KDownedKutku, "W1KModRedux", "GoldenFeather", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Laugicality"])
                {
                    AddItem(EnigmaDownedShark, "Laugicality", "TastyMorsel", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Laugicality"])
                {
                    AddItem(EnigmaDownedHypo, "Laugicality", "ChilledMesh", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Disarray"])
                {
                    AddItem(DisarrayDownedProbe, "Disarray", "ProbeCaller", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Laugicality"])
                {
                    AddItem(EnigmaDownedRagnar, "Laugicality", "MoltenMess", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ElementsAwoken"])
                {
                    AddItem(ElementsDownedWaste, "ElementsAwoken", "WastelandSummon", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CalamityMod"])
                {
                    // Crabulon
                    AddItem(CalamityDownedCrab, "CalamityMod", "DecapoditaSprout", 40000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["AAMod"])
                {
                    // Broodmother
                    AddItem(AABrood, "AAMod", "DragonBell", 100000, ref shop, ref nextSlot);

                    // Hydra
                    AddItem(AAHydra, "AAMod", "HydraChow", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Redemption"])
                {
                    // Strange Portal
                    AddItem(RedePortal, "Redemption", "UnstableCrystal", 100000, ref shop, ref nextSlot);
                    AddItem(RedePortal, "Redemption", "GeigerCounter", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CookieMod"])
                {
                    AddItem(CookieDownedCookie, "CookieMod", "BloodyCookie", 100000, ref shop, ref nextSlot);
                    AddItem(CookieDownedCookie, "CookieMod", "CursedCookie", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["TrelamiumMod"])
                {
                    AddItem(TrelamiumCumulor, "TrelamiumMod", "StormyCloud", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ThoriumMod"])
                {
                    // Queen Jellyfish
                    AddItem(ThoriumDownedJelly, "ThoriumMod", "JellyfishResonator", 100000, ref shop, ref nextSlot);

                    // Viscount
                    AddItem(ThoriumDownedViscount, "Fargowiltas", "ViscountSummon", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Disarray"])
                {
                    AddItem(DisarrayDownedGeneral, "Disarray", "TornBattleArmor", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CalamityMod"])
                {
                    // Perforators
                    AddItem(CalamityDownedPerfor, "CalamityMod", "BloodyWormFood", 100000, ref shop, ref nextSlot);

                    // Hive Mind
                    AddItem(CalamityDownedHive, "CalamityMod", "Teratoma", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["GRealm"])
                {
                    // Folvine
                    AddItem(GRealmDownedFolivine, "GRealm", "JungleBait", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["SpiritMod"])
                {
                    AddItem(SpiritDownedVine, "SpiritMod", "ReachBossSummon", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Jetshift"])
                {
                    // Viyilblud
                    // AddItem(JSViyilblud, "Jetshift", "CorruptedShard", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Disarray"])
                {
                    AddItem(DisarrayDownedSerpent, "Disarray", "MoonStone", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["TrueEater"])
                {
                    AddItem(NPC.downedBoss3, "TrueEater", "SpitterSpawner", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Jetshift"])
                {
                    // Serperannus
                    // AddItem(JSSnake, "Jetshift", "SoilBall", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["SpiritMod"])
                {
                    AddItem(SpiritDownedFlier, "SpiritMod", "JewelCrown", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Antiaris"])
                {
                    AddItem(AntiarisDownedAntlion, "Antiaris", "AntlionDoll", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["SacredTools"])
                {
                    // Flaming Pumpkin
                    AddItem(SacredDownedPump, "SacredTools", "PumpkinLantern", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["AAMod"])
                {
                    AddItem(AADjinn, "AAMod", "DjinnLamp", 150000, ref shop, ref nextSlot);
                    AddItem(AASerpent, "AAMod", "SubzeroCrystal", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CSkies"])
                {
                    AddItem(CSkiesObserver, "CSkies", "CosmicEye ", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CookieMod"])
                {
                    AddItem(CookieDownedBunny, "CookieMod", "BunnyCrown ", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["TrelamiumMod"])
                {
                    AddItem(TrelamiumSymphony, "TrelamiumMod", "LamentedPearl", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["pinkymod"])
                {
                    AddItem(PinkySunlight, "pinkymod", "STItem", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["W1KModRedux"])
                {
                    AddItem(W1KDownedIvy, "W1KModRedux", "CursedFlower", 150000, ref shop, ref nextSlot);
                    AddItem(W1KDownedArdorix, "W1KModRedux", "FieryEgg", 150000, ref shop, ref nextSlot);
                    AddItem(W1KDownedArborix, "W1KModRedux", "GrassyEgg", 150000, ref shop, ref nextSlot);
                    AddItem(W1KDownedAquatix, "W1KModRedux", "WateryEgg", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["AAMod"])
                {
                    // Truffle Toad
                    AddItem(AAToad, "AAMod", "Toadstool", 15000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["SpiritMod"])
                {
                    // Starplate Raider
                    AddItem(SpiritDownedRaider, "SpiritMod", "StarWormSummon", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ThoriumMod"])
                {
                    // Granite Core
                    AddItem(ThoriumDownedStorm, "ThoriumMod", "UnstableCore", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ElementsAwoken"])
                {
                    AddItem(ElementsDownedInfern, "ElementsAwoken", "InfernaceSummon", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Disarray"])
                {
                    AddItem(DisarrayDownedCold, "Disarray", "PermaFreeze", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CalamityMod"])
                {
                    // Slime God
                    AddItem(CalamityDownedSlime, "CalamityMod", "OverloadedSludge", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ForgottenMemories"])
                {
                    AddItem(BtfaAcheron, "ForgottenMemories", "Unstable_Wisp", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["SacredTools"])
                {
                    AddItem(SacredDownedHarpy, "SacredTools", "HarpySummon", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ThoriumMod"])
                {
                    // Buried Champion
                    AddItem(ThoriumDownedChamp, "ThoriumMod", "AncientBlade", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Laugicality"])
                {
                    AddItem(EnigmaDownedDio, "Laugicality", "AncientAwakener", 150000, ref shop, ref nextSlot);
                }

                // alpha cactus worm - joost
                if (Fargowiltas.ModLoaded["ThoriumMod"])
                {
                    // Star Scouter
                    AddItem(ThoriumDownedScout, "ThoriumMod", "StarCaller", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Jetshift"])
                {
                    // Torvames
                    // AddItem(JSReaper, "Jetshift", "Curse", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["AAMod"])
                {
                    // Sagittarius
                    AddItem(AASag, "AAMod", "Lifescanner", 150000, ref shop, ref nextSlot);
                }
                
                AddItem(Main.hardMode, "Fargowiltas", "DeathBringerFairy", 500000, ref shop, ref nextSlot);
            }
            else if (hardmodeShop)
            {
                foreach (MutantSummonInfo summon in Fargowiltas.summonTracker.SortedSummons)
                {
                    //hm
                    if (summon.progression > 6f && summon.progression <= 14)
                    {
                        AddItem(summon.downed(), summon.modSource, summon.itemName, summon.price, ref shop, ref nextSlot);
                    }
                }


                if (Fargowiltas.ModLoaded["Redemption"])
                {
                    AddItem(RedeEye, "Redemption", "XenoEye", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ThoriumMod"])
                {
                    // Borean Strider
                    AddItem(ThoriumDownedStrider, "ThoriumMod", "StriderTear", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Jetshift"])
                {
                    // Wall of Voices
                    // AddItem(JSWall, "Jetshift", "CursedWall", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["TrelamiumMod"])
                {
                    AddItem(TrelamiumPyron, "TrelamiumMod", "SolarMandibleTotem", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ForgottenMemories"])
                {
                    AddItem(BtfaArtery, "ForgottenMemories", "BloodClot", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Antiaris"])
                {
                    AddItem(AntiarisDownedKeeper, "Antiaris", "PocketCursedMirror", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["SpiritMod"])
                {
                    // Infernon
                    AddItem(SpiritDownedInfer, "SpiritMod", "CursedCloth", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CalamityMod"])
                {
                    // Cryogen
                    AddItem(CalamityDownedCryo, "CalamityMod", "CryoKey", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Disarray"])
                {
                    AddItem(DisarrayDownedShadows, "Disarray", "EnhancedShadowFragment", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CSkies"])
                {
                    AddItem(CSkiesStarcore, "CSkies", "Transmitter ", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ThoriumMod"])
                {
                    // Coznix
                    AddItem(ThoriumDownedBeholder, "ThoriumMod", "VoidLens", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ForgottenMemories"])
                {
                    AddItem(BtfaTitan, "ForgottenMemories", "anomalydetector", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["W1KModRedux"])
                {
                    AddItem(W1KDownedRathalos, "W1KModRedux", "MysteryTicket", 250000, ref shop, ref nextSlot);
                    AddItem(W1KDownedRidley, "W1KModRedux", "MetroidCapsule", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["AAMod"])
                {
                    // Retriever
                    // AddItem(AARetriever, "AAMod", "CyberneticClaw", 250000, ref shop, ref nextSlot);
                    // Raider Ultima
                    // AddItem(AARaider, "AAMod", "CyberneticBell", 250000, ref shop, ref nextSlot);
                    // Orthrus X
                    // AddItem(AAOrthrus, "AAMod", "ScrapHeap", 250000, ref shop, ref nextSlot);
                    // Techno Truffle
                    // AddItem(AATruffle, "AAMod", "CyberneticShroom", 250000, ref shop, ref nextSlot);
                    // All Storm bosses
                    // AddItem((AARetriever && AARaider && AAOrthrus), "Fargowiltas", "CyberneticAmalgam", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Ocram"])
                {
                    AddItem(OcramOcram, "Ocram", "item_suspicious_looking_skull", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Jetshift"])
                {
                    // Arlenon
                    // AddItem(JSArlenon, "Jetshift", "PearlOfTheSky", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Jetshift"])
                {
                    // Athazel
                    // AddItem(JSAthazel, "Jetshift", "TridentOfDoom", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["pinkymod"])
                {
                    AddItem(PinkySlime, "pinkymod", "MythrilGel", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["TrelamiumMod"])
                {
                    AddItem(TrelamiumPermafrost, "TrelamiumMod", "TemporalLens", 400000, shop: ref shop, nextSlot: ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["SpiritMod"])
                {
                    // Dusking
                    AddItem(SpiritDownedDusking, "SpiritMod", "DuskCrown", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Disarray"])
                {
                    AddItem(DisarrayDownedLuna, "Disarray", "MastersPresent", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CalamityMod"])
                {
                    // Brimstone Elemental
                    AddItem(CalamityDownedBrim, "CalamityMod", "CharredIdol", 200000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["SpiritMod"])
                {
                    // Etheral Umbra
                    AddItem(SpiritDownedUmbra, "SpiritMod", "UmbraSummon", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Disarray"])
                {
                    AddItem(DisarrayDownedBell, "Disarray", "ABell", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CalamityMod"])
                {
                    // Aquatic Scourge
                    AddItem(CalamityDownedAquatic, "CalamityMod", "Seafood", 200000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Laugicality"])
                {
                    AddItem(EnigmaDownedAnnih, "Laugicality", "MechanicalMonitor", 400000, ref shop, ref nextSlot);
                    AddItem(EnigmaDownedSlyber, "Laugicality", "SteamCrown", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ElementsAwoken"])
                {
                    AddItem(ElementsDownedScourge, "ElementsAwoken", "ScourgeFighterSummon", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ElementsAwoken"])
                {
                    AddItem(ElementsDownedReg, "ElementsAwoken", "RegarothSummon", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Laugicality"])
                {
                    AddItem(EnigmaDownedTrain, "Laugicality", "SuspiciousTrainWhistle", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Disarray"])
                {
                    AddItem(DisarrayDownedMech, "Disarray", "MechPrism", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["SacredTools"])
                {
                    AddItem(SacredDownedHarpy2, "SacredTools", "HarpySummon2", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ThoriumMod"])
                {
                    // Lich
                    AddItem(ThoriumDownedLich, "ThoriumMod", "LichCatalyst", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CalamityMod"])
                {
                    // Calamitas
                    AddItem(CalamityDownedCalamitas, "CalamityMod", "BlightedEyeball", 300000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["SpiritMod"])
                {
                    // Illumant Master
                    AddItem(SpiritDownedIlluminant, "SpiritMod", "ChaosFire", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["W1KModRedux"])
                {
                    AddItem(W1KDownedOkiku, "W1KModRedux", "OminousMask", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Redemption"])
                {
                    AddItem(RedeSlayer, "Redemption", "KingSummon", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["pinkymod"])
                {
                    AddItem(PinkyValdaris, "pinkymod", "ValdarisItem", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CalamityMod"])
                {
                    // Leviathan
                    AddItem(CalamityDownedLevi, "Fargowiltas", "LeviathanSummon", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Laugicality"])
                {
                    AddItem(EnigmaDownedEther, "Laugicality", "EmblemOfEtheria", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CalamityMod"])
                {
                    // Astrageldon
                    AddItem(CalamityDownedAstragel, "CalamityMod", "AstralChunk", 250000, ref shop, ref nextSlot);

                    // Astrum Deus
                    AddItem(CalamityDownedAstrum, "CalamityMod", "Starcore", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["pinkymod"])
                {
                    AddItem(PinkyAbyssmal, "pinkymod", "MindGodItem", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Jetshift"])
                {
                    // Shift
                    // AddItem(JSShift, "Jetshift", "ForbiddenGem", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["SacredTools"])
                {
                    AddItem(SacreddownedPrimordia, "SacredTools", "PrimordiaSummon", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ElementsAwoken"])
                {
                    AddItem(ElementsDownedCelestial, "ElementsAwoken", "CelestialSummon", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ElementsAwoken"])
                {
                    AddItem(ElementsDownedPerma, "ElementsAwoken", "PermafrostSummon", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ElementsAwoken"])
                {
                    AddItem(ElementsDownedObsid, "ElementsAwoken", "ObsidiousSummon", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ThoriumMod"])
                {
                    // Abyssion
                    AddItem(ThoriumDownedAbyss, "Fargowiltas", "AbyssionSummon", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["TrueEater"])
                {
                    AddItem(NPC.downedPlantBoss, "TrueEater", "MimicKey", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CalamityMod"])
                {
                    // Plaguebringer Goliath
                    AddItem(CalamityDownedPlague, "CalamityMod", "Abomination", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CrystiliumMod"])
                {
                    // Crystal King
                    AddItem(CrystiliumDownedKing, "CrystiliumMod", "CrypticCrystal", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["W1KModRedux"])
                {
                    AddItem(W1KDownedDeath, "W1KModRedux", "DungeonMasterGuide", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Bluemagic"])
                {
                    AddItem(BlueDownedPhantom, "Bluemagic", "PaladinEmblem", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ElementsAwoken"])
                {
                    AddItem(ElementsDownedAque, "ElementsAwoken", "AqueousSummon", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["SpiritMod"])
                {
                    // Atlas
                    AddItem(SpiritDownedAtlas, "SpiritMod", "StoneSkin", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CalamityMod"])
                {
                    // Ravager
                    AddItem(CalamityDownedRav, "CalamityMod", "AncientMedallion", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Bluemagic"])
                {
                    AddItem(BlueDownedAbom, "Bluemagic", "FoulOrb", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Jetshift"])
                {
                    // Polypus
                    // AddItem(JSPolypus, "Jetshift", "RottenShrimp", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ElementsAwoken"])
                {
                    AddItem(ElementsDownedDragon, "ElementsAwoken", "AncientDragonSummon", 750000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Redemption"])
                {
                    AddItem(RedeCleaver, "Redemption", "CorruptedHeroSword", 750000, ref shop, ref nextSlot);
                    AddItem(RedeGigipede, "Redemption", "CorruptedWormMedallion", 750000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["AAMod"])
                {
                    AddItem(AARajah, "AAMod", "GoldenCarrot", 750000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ElementsAwoken"])
                {
                    AddItem(ElementsDownedGuardian, "ElementsAwoken", "GuardianSummon", 750000, ref shop, ref nextSlot);
                }
            }
            else
            {
                foreach (MutantSummonInfo summon in Fargowiltas.summonTracker.SortedSummons)
                {
                    //post ml
                    if (summon.progression > 14f)
                    {
                        AddItem(summon.downed(), summon.modSource, summon.itemName, summon.price, ref shop, ref nextSlot);
                    }
                }


                if (Fargowiltas.ModLoaded["AAMod"])
                {
                    AddItem(AASisters, "AAMod", "FlamesOfAnarchy", 1000000, ref shop, ref nextSlot);

                    // Equinox Worms
                    AddItem(AAEquinox, "AAMod", "EquinoxWorm", 1000000, ref shop, ref nextSlot);

                    // sisters
                    AddItem(AASisters, "AAMod", "FlamesOfAnarchy ", 1000000, ref shop, ref nextSlot);

                    // Akuma
                    AddItem(AAAkuma, "AAMod", "DraconianSigil", 1000000, ref shop, ref nextSlot);

                    // Yamata
                    AddItem(AAYamata, "AAMod", "DreadSigil", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CSkies"])
                {
                    AddItem(CSkiesObserverV, "CSkies", "VoidEye ", 1000000, ref shop, ref nextSlot);
                    AddItem(CSkiesHeartcore, "CSkies", "PassionRune ", 2000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Jetshift"])
                {
                    // Oculus
                    // Frezyn
                    // AddItem(JSFrezyn, "Jetshift", "Cryogen", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Redemption"])
                {
                    // Omega Obliterator
                    AddItem(RedeOmega, "Redemption", "OmegaRadar", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["TrelamiumMod"])
                {
                    AddItem(TrelamiumAzolinth, "TrelamiumMod", "PlanetaryBeacon", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Disarray"])
                {
                    AddItem(DisarrayDownedSludge, "Disarray", "VileSlimeBall", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["SpiritMod"])
                {
                    // Overseer
                    AddItem(SpiritDownedOverseer, "SpiritMod", "SpiritIdol", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["TrelamiumMod"])
                {
                    AddItem(TrelamiumParadox, "TrelamiumMod", "WarpedMirror", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ElementsAwoken"])
                {
                    AddItem(ElementsDownedVolcanox, "ElementsAwoken", "VolcanoxSummon", 1000000, ref shop, ref nextSlot);
                    AddItem(ElementsDownedVoid, "ElementsAwoken", "VoidLeviathanSummon", 1000000, ref shop, ref nextSlot);
                    AddItem(ElementsDownedAzana, "ElementsAwoken", "AzanaSummon", 1000000, ref shop, ref nextSlot);
                }

                // abomination rematch - blue
                if (Fargowiltas.ModLoaded["Jetshift"])
                {
                    // Mortalos
                    // AddItem(JSMortalos, "Jetshift", "TheVoid", 1000000, ref shop, ref nextSlot);
                    // Shift Rematch
                    // AddItem(JSMortalos, "Jetshift", "ArtifactOfTheVoid", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["SacredTools"])
                {
                    // Abbadon
                    AddItem(SacredDownedAbbadon, "SacredTools", "ShadowWrathSummonItem", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CalamityMod"])
                {
                    // Profaned Guardians
                    AddItem(CalamityDownedGuardian, "CalamityMod", "ProfanedShard", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["JoostMod"])
                {
                    // Cactuar
                    AddItem(JoostDownedCactuar, "JoostMod", "Cactusofdoom", 5000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Disarray"])
                {
                    AddItem(DisarrayDownedDeva, "Disarray", "EyeOfSouls", 5000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CalamityMod"])
                {
                    // Providence
                    AddItem(CalamityDownedProv, "CalamityMod", "ProfanedCore", 10000000, ref shop, ref nextSlot);
                }

                // void marshal -true eater
                if (Fargowiltas.ModLoaded["SacredTools"])
                {
                    AddItem(SacredDownedSerpent, "SacredTools", "SerpentSummon", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["GRealm"])
                {
                    // Mantid Matriarch
                    AddItem(GRealmDownedMantid, "GRealm", "CrownOfMantodea", 10000000, ref shop, ref nextSlot);

                    // Rift Daemon - When he's released
                }

                if (Fargowiltas.ModLoaded["JoostMod"])
                {
                    AddItem(JoostDownedSAX, "JoostMod", "InfectedArmCannon", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Disarray"])
                {
                    AddItem(DisarrayDownedMeteor, "Disarray", "RandomSpaceRock", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["SacredTools"])
                {
                    // Lunarians
                    AddItem(SacredDownedLunar, "SacredTools", "MoonEmblem", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["ThoriumMod"])
                {
                    // Ragnorok
                    AddItem(ThoriumDownedRag, "ThoriumMod", "RagSymbol", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["EchoesoftheAncients"])
                {
                    AddItem(AncientsDownedWorms, "EchoesoftheAncients", "Wyrm_Rune", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["JoostMod"])
                {
                    AddItem(JoostDownedGilga, "JoostMod", "Excalipoor", 15000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Disarray"])
                {
                    AddItem(DisarrayDownedDungeon, "Disarray", "DungeonAmalgamation", 15000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Redemption"])
                {
                    // Thorn Rematch
                    AddItem(RedeThornPZ, "Redemption", "LifeFruitOfThorns", 15000000, ref shop, ref nextSlot);

                    // Eaglecrest Rematch
                    AddItem(RedeEaglecrestPZ, "Redemption", "AncientSigil", 15000000, ref shop, ref nextSlot);

                    // Nebuleus
                    AddItem(RedeNeb, "Redemption", "NebSummon", 15000000, ref shop, ref nextSlot);
                }

                // spirit of purity
                if (Fargowiltas.ModLoaded["AAMod"])
                {
                    // AddItem(AASoC, "AAMod", "SpatialWheel ", 1500000, ref shop, ref nextSlot);
                    // Zero
                    AddItem(AAZero, "AAMod", "ZeroTesseract", 15000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["CalamityMod"])
                {
                    // Bumblebirb
                    AddItem(CalamityDownedBirb, "CalamityMod", "BirbPheromones", 5000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.ModLoaded["Jetshift"])
                {
                    // Crystal Conflict
                    // AddItem(JSCCP2, "Jetshift", "CrownOfConflict", 20000000, ref shop, ref nextSlot);
                }

                // spirit of chaos

                // spirit of purity rematch
                if (Fargowiltas.ModLoaded["AAMod"])
                {
                    // Shen Doragon
                    AddItem(AAShen, "AAMod", "ChaosSigil", 20000000, ref shop, ref nextSlot);

                    // Infinity Zero
                    // AddItem(AAIZ, "AAMod", "InfinityOverloader", 30000000, ref shop, ref nextSlot);
                }

                // Fishron EX
                if (Fargowiltas.ModLoaded["FargowiltasSouls"])
                {
                    AddItem(FargoDownedFishEX, "FargowiltasSouls", "TruffleWormEX", 10000000, ref shop, ref nextSlot);
                }

                // Abominationn
                if (Fargowiltas.ModLoaded["FargowiltasSouls"])
                {
                    AddItem(FargoDownedAbom, "FargowiltasSouls", "AbomsCurse", 10000000, ref shop, ref nextSlot);
                }

                // Mutant
                if (Fargowiltas.ModLoaded["FargowiltasSouls"])
                {
                    AddItem(FargoDownedMutant, "FargowiltasSouls", "MutantsCurse", 20000000, ref shop, ref nextSlot);
                }

                AddItem(true, "Fargowiltas", "AncientSeal", 100000000, ref shop, ref nextSlot);

                if (Fargowiltas.ModLoaded["FargowiltasSouls"])
                {
                    Player player = Main.player[Main.myPlayer];

                    foreach (Item item in player.armor)
                    {
                        if (item != null && item.type == ModLoader.GetMod("FargowiltasSouls").ItemType("EternitySoul"))
                        {
                            AddItem(true, "FargowiltasSouls", "EternitySoul", 99000000, ref shop, ref nextSlot);
                        }
                    }
                }
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            if (Fargowiltas.ModLoaded["FargowiltasSouls"] && FargoDownedMutant)
            {
                damage = 720;
                knockback = 10f;
            }
            else if (NPC.downedMoonlord)
            {
                damage = 500;
                knockback = 10f;
            }
            else if (Main.hardMode)
            {
                damage = 60;
                knockback = 5f;
            }
            else
            {
                damage = 20;
                knockback = 4f;
            }
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            if (NPC.downedMoonlord)
            {
                cooldown = 1;
            }
            else if (Main.hardMode)
            {
                cooldown = 20;
                randExtraCooldown = 25;
            }
            else
            {
                cooldown = 30;
                randExtraCooldown = 30;
            }
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            if (Fargowiltas.ModLoaded["FargowiltasSouls"] && FargoDownedMutant)
            {
                projType = ModLoader.GetMod("FargowiltasSouls").ProjectileType("MutantSpearThrownFriendly");
            }
            else if (NPC.downedMoonlord)
            {
                projType = mod.ProjectileType("PhantasmalEyeProjectile");
            }
            else if (Main.hardMode)
            {
                projType = mod.ProjectileType("MechEyeProjectile");
            }
            else
            {
                projType = mod.ProjectileType("EyeProjectile");
            }

            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            if (Fargowiltas.ModLoaded["FargowiltasSouls"] && FargoDownedMutant)
            {
                multiplier = 25f;
                randomOffset = 0f;
            }
            else
            {
                multiplier = 12f;
                randomOffset = 2f;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 8; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, Scale: 0.8f);
                }

                Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/MutantGore3"));

                pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/MutantGore2"));

                pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/MutantGore1"));
            }
            else
            {
                for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, Scale: 0.6f);
                }
            }
        }
    }
}
