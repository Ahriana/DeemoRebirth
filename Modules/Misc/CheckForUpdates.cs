using MelonLoader;
using System.Net;
using System.Text.RegularExpressions;

namespace DeemoRebirth.Modules.CheckForUpdates {
    public static class Configuration {
        public static string RepositoryOwner = "Ahriana";
        public static string RepositoryName = "DeemoRebirth";
        public static string LatestReleaseUrl = "https://api.github.com/repos/" + RepositoryOwner + "/" + RepositoryName + "/releases/latest";
        public static string LatestVersion { get; set; }
        public static bool UpdateAvailable = false;
    }

    internal class Methods {
        public static void CheckForUpdates () {
            using (var client = new WebClient()) {
                client.Headers.Add("User-Agent", "Mozilla/5.0");
                client.Headers.Add("Accept", "application/vnd.github.v3+json");
                string json = client.DownloadString(Configuration.LatestReleaseUrl);
                var match = Regex.Match(json, "\"tag_name\":\"([^\"]+)\"");

                if (match.Success) {
                    Configuration.LatestVersion = match.Groups[1].Value;
                } else {
                    MelonLogger.Error($"Update check failed");
                }
            }

            if (Configuration.LatestVersion != null && Configuration.LatestVersion != $"v{BuildInfo.Version}") {
                // There is a new version available
                Configuration.UpdateAvailable = true;
                MelonLogger.Msg($"A new version of the mod is available: {Configuration.LatestVersion}");
                Modules.Watermark.Methods.OnUpdateAvailable(Configuration.LatestVersion);
            } else {
                // The mod is up-to-date
                MelonLogger.Msg("The mod is up-to-date.");
            }
        }
    }
    
    internal class Events {
        public static void OnApplicationStart () {
            Methods.CheckForUpdates();
        }
    }
}
