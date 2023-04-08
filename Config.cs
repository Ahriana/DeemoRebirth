using MelonLoader;

namespace DeemoRebirth {
    public static class BuildInfo {
        public const string Name = "DeemoRebirth";
        public const string Description = "Collection of mods to aid in more Competitive play";
        public const string Author = "Ahriana";
        public const string Company = "ScoreSpy";
        public const string Version = "1.1.0";
        public const string DownloadLink = "https://github.com/Ahriana/DeemoRebirth"; // Download Link for the Mod.  (Set as null if none)
    }

    public static class Config {
        private static readonly string FILEPATH = "UserData/Rebirth.cfg";

        private static MelonPreferences_Category _coreCategory;
        private static MelonPreferences_Category _competitiveCategory;
        private static MelonPreferences_Category _performanceCategory;

        public static void Initialize () {
            // Core config setup
            _coreCategory = MelonPreferences.CreateCategory("Core");
            _coreCategory.SetFilePath(FILEPATH);

            _coreCategory.CreateEntry<bool>("Mod Enabled", true, null, "Master Toggle to Enable or Disable the mod");

            _coreCategory.SaveToFile();

            // Competitive config setup
            _competitiveCategory = MelonPreferences.CreateCategory("Competitive");
            _competitiveCategory.SetFilePath(FILEPATH);

            _competitiveCategory.CreateEntry<bool>("Skip Intro", true, null, "Skips all intro buttons, speeds up animations, and jumps you into save select. This cannot be used if you plan to use VR mode");
            _competitiveCategory.CreateEntry<bool>("Auto Song Select", false, null, "Spawn the song book when entering the world");
            _competitiveCategory.CreateEntry<bool>("Replace Song Book Animations", true, null, "This will speed-up, replace and simplify SongBook animations for faster navigation etc");
            _competitiveCategory.CreateEntry<int>("Default Difficulty", 0, null, "Changes what difficulty will be selected in song select: Off = 0, Easy = 1, Normal = 2, Hard = 3");

            _competitiveCategory.SaveToFile();

            // Performance config setup
            _performanceCategory = MelonPreferences.CreateCategory("Performance");
            _performanceCategory.SetFilePath(FILEPATH);

            _performanceCategory.CreateEntry<bool>("Remove Gameplay Backgrounds", false, null, "Disable stage backgrounds to increase performance");
            _performanceCategory.CreateEntry<bool>("Disable VSync", true, null, "Bypasses the game's VSync clock (Unlimited FPS)");

            _performanceCategory.SaveToFile();
        }

        public static class Core {
            public static bool ModEnabled => _coreCategory.GetEntry<bool>("Mod Enabled").Value;
        }

        public static class Competitive {
            public static bool SkipIntro => _competitiveCategory.GetEntry<bool>("Skip Intro").Value;
            public static bool AutoSongBook => _competitiveCategory.GetEntry<bool>("Auto Song Select").Value;
            public static bool ReplaceSongBookAnimations => _competitiveCategory.GetEntry<bool>("Replace Song Book Animations").Value;
            public static int DefaultDifficulty => _competitiveCategory.GetEntry<int>("Default Difficulty").Value;
        }

        public static class Performance {
            public static bool RemoveGameplayBackgrounds => _performanceCategory.GetEntry<bool>("Remove Gameplay Backgrounds").Value;
            public static bool DisableVsync => _performanceCategory.GetEntry<bool>("Disable VSync").Value;
        }
    }
}
