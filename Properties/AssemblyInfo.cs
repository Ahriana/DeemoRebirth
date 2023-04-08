using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(DeemoRebirth.BuildInfo.Description)]
[assembly: AssemblyDescription(DeemoRebirth.BuildInfo.Description)]
[assembly: AssemblyCompany(DeemoRebirth.BuildInfo.Company)]
[assembly: AssemblyProduct(DeemoRebirth.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + DeemoRebirth.BuildInfo.Author)]
[assembly: AssemblyTrademark(DeemoRebirth.BuildInfo.Company)]
[assembly: AssemblyVersion(DeemoRebirth.BuildInfo.Version)]
[assembly: AssemblyFileVersion(DeemoRebirth.BuildInfo.Version)]
[assembly: MelonInfo(typeof(DeemoRebirth.DeemoRebirth), DeemoRebirth.BuildInfo.Name, DeemoRebirth.BuildInfo.Version, DeemoRebirth.BuildInfo.Author, DeemoRebirth.BuildInfo.DownloadLink)]
[assembly: MelonColor()]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]