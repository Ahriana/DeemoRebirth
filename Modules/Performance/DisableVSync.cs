using UnityEngine;

namespace DeemoRebirth.Modules.DisableVSync {
    public static class Methods {
        public static void Init () {
            if (!Config.Performance.DisableVsync) { return; }

            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 0;
        }
    }
}
