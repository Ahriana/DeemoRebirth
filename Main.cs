﻿using MelonLoader;
using UnityEngine.XR;

namespace DeemoRebirth {
    public static class BuildInfo {
        public const string Name = "DeemoRebirth";
        public const string Description = "Collection of mods to aid in more Competitive play";
        public const string Author = "Ahriana";
        public const string Company = "ScoreSpy";
        public const string Version = "1.0.0";
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class DeemoRebirth :MelonMod {
        public override void OnInitializeMelon () {
            Config.Initialize();
            Modules.DisableVSync.Methods.Init();
        }

        public override void OnApplicationStart () // Runs after Game Initialization.
        {
            // MelonLogger.Msg("OnApplicationStart");
        }

        public override void OnApplicationLateStart () // Runs after OnApplicationStart.
        {
            // MelonLogger.Msg("OnApplicationLateStart");
        }

        public override void OnSceneWasLoaded (int buildindex, string sceneName) // Runs when a Scene has Loaded and is passed the Scene's Build Index and Name.
        {
            // MelonLogger.Msg("OnSceneWasLoaded: " + buildindex.ToString() + " | " + sceneName);
        }

        public override void OnSceneWasInitialized (int buildindex, string sceneName) // Runs when a Scene has Initialized and is passed the Scene's Build Index and Name.
        {
            Modules.RemoveGameplayBackgrounds.Events.OnSceneWasInitialized(buildindex, sceneName);
            // MelonLogger.Msg("OnSceneWasInitialized: " + buildindex.ToString() + " | " + sceneName);
        }

        public override void OnUpdate () // Runs once per frame.
        {
            // MelonLogger.Msg("OnUpdate");
        }

        public override void OnFixedUpdate () // Can run multiple times per frame. Mostly used for Physics.
        {
            // MelonLogger.Msg("OnFixedUpdate");
        }

        public override void OnLateUpdate () // Runs once per frame after OnUpdate and OnFixedUpdate have finished.
        {
            // MelonLogger.Msg("OnLateUpdate");
        }

        public override void OnGUI () // Can run multiple times per frame. Mostly used for Unity's IMGUI.
        {
            // MelonLogger.Msg("OnGUI");
        }

        public override void OnApplicationQuit () // Runs when the Game is told to Close.
        {
            // MelonLogger.Msg("OnApplicationQuit");
        }

        public override void OnPreferencesSaved () // Runs when Melon Preferences get saved.
        {
            // MelonLogger.Msg("OnPreferencesSaved");
        }

        public override void OnPreferencesLoaded () // Runs when Melon Preferences get loaded.
        {
            // MelonLogger.Msg("OnPreferencesLoaded");
        }
    }
}