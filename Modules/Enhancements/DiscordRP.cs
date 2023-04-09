using BadBird.Excel;
using Discord;
using HarmonyLib;
using MelonLoader;
using System;

namespace DeemoRebirth.Modules.DiscordRP {
    public static class Configuration {
        public static string ApplicationID = "862739690989289543";

        public static string lastLevelStageName = "";
        public static string lastLevelStageImage = "";

        public static string lastRhythmStageName = "";
        public static string lastRhythmStageImage = "";

        public static bool isRhythmStage = false;
        public static bool isSongSelected = false;

        public static Discord.Discord Client = null;

        public static Activity ClientActivity = new Activity() {
            State = "Loading...",
            Details = null,
            Timestamps = {
                Start = (new DateTimeOffset(DateTime.UtcNow)).ToUnixTimeSeconds()
            },
            Assets = {
                LargeImage = "icon_loading_downsheet",
                LargeText = "Deemo Rebirth",
                SmallImage = "",
                SmallText = ""
            },
            Instance = true,
        };
    }

    [HarmonyPatch(typeof(SongSelectBookUI), "ShowUI")]
    internal class SongSelectBookUI_ShowUI {
        private static void Postfix (SongSelectBookUI __instance) {
            if (!Config.Enhancements.DiscordRP) { return; }

            Configuration.ClientActivity.State = "Browsing the song book";
            Configuration.ClientActivity.Details = "Song Select";
            Configuration.ClientActivity.Assets.LargeImage = "icon_loading_downsheet";
            Configuration.ClientActivity.Assets.LargeText = null;

            Configuration.ClientActivity.Assets.SmallImage = "icon_stair";
            Configuration.ClientActivity.Assets.SmallText = null;

            Methods.UpdateActivity();
        }
    }

    [HarmonyPatch(typeof(SongSelectBookUI), "HideUI")]
    internal class SongSelectBookUI_HideUI {
        private static void Postfix (SongSelectBookUI __instance) {
            if (!Config.Enhancements.DiscordRP) { return; }
            if (Configuration.isSongSelected) { return; }

            Methods.SetLevelStage(Configuration.lastLevelStageName, Configuration.lastLevelStageImage);
        }
    }


    [HarmonyPatch(typeof(SongSelectBookUI), "Play")]
    internal class SongSelectBookUI_Play {
        private static void Postfix (SongSelectBookUI __instance) {
            if (!Config.Enhancements.DiscordRP) { return; }
            Configuration.isSongSelected = true;

            SongData songData = null;
            foreach (SongData data in SongInfoManager.instance.values) {
                if (data.songID == __instance.onSelectSongID) {
                    songData = data;
                    break;
                }
            }

            Configuration.ClientActivity.State = songData.songName;
            Configuration.ClientActivity.Details = __instance.songAuthor.textID.Split(':')[1];

            if (SongSelectBookUI.difficulty == SongInfo.Difficulty.Easy) {
                Configuration.ClientActivity.Assets.SmallImage = "icon_level_easy";
                Configuration.ClientActivity.Assets.SmallText = "Easy";
            } else if (SongSelectBookUI.difficulty == SongInfo.Difficulty.Normal) {
                Configuration.ClientActivity.Assets.SmallImage = "icon_level_normal";
                Configuration.ClientActivity.Assets.SmallText = "Normal";
            } else if (SongSelectBookUI.difficulty == SongInfo.Difficulty.Hard) {
                Configuration.ClientActivity.Assets.SmallImage = "icon_level_hard";
                Configuration.ClientActivity.Assets.SmallText = "Hard";
            }

            if (Configuration.lastRhythmStageName != "") { 
                Methods.SetRhythmStage(Configuration.lastRhythmStageName, Configuration.lastRhythmStageImage); 
            } else {
                Methods.UpdateActivity();
            }
        }
    }

    internal class Events {
        public static void OnApplicationStart () {
            if (!Config.Enhancements.DiscordRP) { return; }

            try {
                Configuration.Client = new Discord.Discord(Int64.Parse(Configuration.ApplicationID), (UInt64)Discord.CreateFlags.NoRequireDiscord);
            } catch (Exception e) {
                MelonLogger.Msg($"Discord Init: Error, Closing client: {e}");
                Configuration.Client = null;
                return;
            }

            Configuration.Client.SetLogHook(Discord.LogLevel.Debug, (level, message) => {
                MelonLogger.Msg($"Discord: Log [{level}] {message}");
            });

            Methods.UpdateActivity();

        }

        public static void OnUpdate () {
            if (!Config.Enhancements.DiscordRP) { return; }
            if (Configuration.Client is null) { return; }

            try {
                Configuration.Client.RunCallbacks();
            } catch (Exception e) {
                MelonLogger.Msg($"Discord: Error, Closing client: {e}");
                Configuration.Client.Dispose();
                Configuration.Client = null;
            }
        }

        public static void OnApplicationQuit () {
            if (!Config.Enhancements.DiscordRP) { return; }
            if (Configuration.Client == null) { return; }
            Configuration.Client.Dispose();
            Configuration.Client = null;
        }

        public static void OnSceneWasLoaded (int buildindex, string sceneName) {
            if (!Config.Enhancements.DiscordRP) { return; }

            if (sceneName == "TitleStage") {
                Configuration.isRhythmStage = false;
                Configuration.ClientActivity.State = "Main Menu";
                Configuration.ClientActivity.Details = "Deemo Rebirth";
                Configuration.ClientActivity.Assets.LargeImage = "icon_loading_downsheet";
                Configuration.ClientActivity.Assets.LargeText = "Deemo Rebirth";
                Configuration.ClientActivity.Assets.SmallImage = null;
                Configuration.ClientActivity.Assets.SmallText = null;
                Methods.UpdateActivity();
            }

            if (sceneName == "Env_TopFloor") { Methods.SetLevelStage("Top Floor", "topfloor"); }
            if (sceneName == "Env_Upstairs") { Methods.SetLevelStage("Upstairs", "upstairs"); }
            if (sceneName == "Env_Balcony") { Methods.SetLevelStage("Balcony", "balcony"); }
            if (sceneName == "Env_SecondFloor") { Methods.SetLevelStage("Second Floor", "secondfloor"); }
            if (sceneName == "Env_TrophyRoom") { Methods.SetLevelStage("Trophy Room", "trophyroom"); }
            if (sceneName == "Env_BookRoom") { Methods.SetLevelStage("Book Room", "bookroom"); }
            if (sceneName == "Env_PianoRoom") { Methods.SetLevelStage("Piano Room", "pianoroom"); }
            if (sceneName == "Env_LoftRoom") { Methods.SetLevelStage("Loft Room", "loftroom"); }
            if (sceneName == "Env_Basement") { Methods.SetLevelStage("Basement", "basement"); }
            if (sceneName == "Env_Downstairs") { Methods.SetLevelStage("Downstairs", "downstairs"); }

            if (sceneName == "RhythmSkin_TopFloor") { Methods.SetRhythmStage("Top Floor", "topfloor"); }
            if (sceneName == "RhythmSkin_Upstairs") { Methods.SetRhythmStage("Upstairs", "upstairs"); }
            if (sceneName == "RhythmSkin_Balcony") { Methods.SetRhythmStage("Balcony", "balcony"); }
            if (sceneName == "RhythmSkin_SecondFloor") { Methods.SetRhythmStage("Second Floor", "secondfloor"); }
            if (sceneName == "RhythmSkin_TrophyRoom") { Methods.SetRhythmStage("Trophy Room", "trophyroom"); }
            if (sceneName == "RhythmSkin_BookRoom") { Methods.SetRhythmStage("Book Room", "bookroom"); }
            if (sceneName == "RhythmSkin_PianoRoom") { Methods.SetRhythmStage("Piano Room", "pianoroom"); }
            if (sceneName == "RhythmSkin_LoftRoom") { Methods.SetRhythmStage("Loft Room", "loftroom"); }
            if (sceneName == "RhythmSkin_Basement") { Methods.SetRhythmStage("Basement", "basement"); }
            if (sceneName == "RhythmSkin_Downstairs") { Methods.SetRhythmStage("Downstairs", "downstairs"); }
        }
    }

    internal class Methods {

        public static void SetLevelStage (string name, string image) {
            Configuration.isSongSelected = false;
            Configuration.isRhythmStage = false;

            Configuration.lastLevelStageName = name;
            Configuration.lastLevelStageImage = image;

            Configuration.ClientActivity.State = name;
            Configuration.ClientActivity.Details = "Level Stage";
            Configuration.ClientActivity.Assets.LargeImage = image;
            Configuration.ClientActivity.Assets.LargeText = name;
            Configuration.ClientActivity.Assets.SmallImage = "icon_tree";
            Configuration.ClientActivity.Assets.SmallText = null;
            UpdateActivity();
        }

        public static void SetRhythmStage (string name, string image) {
            Configuration.isRhythmStage = true;

            Configuration.lastRhythmStageName = name;
            Configuration.lastRhythmStageImage = image;

            Configuration.ClientActivity.Assets.LargeImage = image;
            Configuration.ClientActivity.Assets.LargeText = name;
            UpdateActivity();
        }

        public static void UpdateActivity () {
            var activityManager = Configuration.Client.GetActivityManager();
            activityManager.UpdateActivity(Configuration.ClientActivity, result => {
                MelonLogger.Msg($"Discord: Update Activity {result}");
            });
        }
    }
}
