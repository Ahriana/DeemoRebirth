using MelonLoader;
using UnityEngine;
using UnityEngine.XR;

namespace DeemoRebirth {
    public class DeemoRebirth :MelonMod {
        private GUIStyle labelStyle;


        public override void OnInitializeMelon () {
            Config.Initialize();
            Modules.DisableVSync.Methods.Init();
        }

        public override void OnApplicationStart () // Runs after Game Initialization.
        {
            labelStyle = new GUIStyle();
            labelStyle.fontSize = 24;
            labelStyle.normal.textColor = Color.white;
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
            GUI.Label(new Rect(10, 10, 100, 25), $"Deemo Rebirth v{BuildInfo.Version}", labelStyle);
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