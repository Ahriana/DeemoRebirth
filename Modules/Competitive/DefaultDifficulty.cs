using HarmonyLib;

namespace DeemoRebirth.Modules.DefaultDifficulty {
    [HarmonyPatch(typeof(SongSelectBookUI), "ShowUI")]
    internal class SongSelectBookUI_ShowUI {
        private static void Postfix (SongSelectBookUI __instance) {

            switch (Config.Competitive.DefaultDifficulty) {
                case 1:
                    __instance.SetEasyDifficulty();
                    break;
                case 2:
                    __instance.SetNormalDifficulty();
                    break;
                case 3:
                    __instance.SetHardDifficulty();
                    break;
                default:
                    break;
            }
        }
    }
}
