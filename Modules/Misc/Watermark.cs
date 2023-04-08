using UnityEngine;

namespace DeemoRebirth.Modules.Watermark {
    public static class Configuration {
        public static GUIStyle LabelStyle { get; set; }
        public static string LabelText { get; set; } = "Deemo Rebirth";
    }

    internal class Events {
        public static void OnApplicationStart () {
            Configuration.LabelStyle = new GUIStyle();
            Configuration.LabelStyle.fontSize = 18;
            Configuration.LabelStyle.normal.textColor = Color.white;

            Configuration.LabelText = $"Deemo Rebirth v{BuildInfo.Version}";
        }

        public static void OnGUI () {
            GUI.Label(new Rect(10, 10, 100, 25), Configuration.LabelText, Configuration.LabelStyle);
        }
    }
    
    internal class Methods {
        public static void OnUpdateAvailable (string version) {
            Configuration.LabelText = $"Deemo Rebirth v{BuildInfo.Version} - <b><color=red>Update Available [{version}]</color></b>";
        }
    }
}
