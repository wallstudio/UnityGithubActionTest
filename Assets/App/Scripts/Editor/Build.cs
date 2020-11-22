using UnityEngine;
using UnityEditor;
using System.IO;

public static class Build
{

	[MenuItem("Build/Both")]
	public static void BuildBoth()
	{
		BuildAndroid();
		BuildIOS();
	}

	[MenuItem("Build/Android")]
	public static void BuildAndroid()
	{
		var args = System.Environment.GetCommandLineArgs();
		Debug.Log($"Command line arguments:\n{string.Join("\n", args)}");

    	const string exportPath = "Build/android";
		if(Directory.Exists(exportPath))
		{
			Directory.Delete(exportPath, true);
		}
		BuildPipeline.BuildPlayer(new EditorBuildSettingsScene[0], exportPath, BuildTarget.Android, BuildOptions.AcceptExternalModificationsToPlayer);
		Directory.Move("Temp/StagingArea/Il2Cpp/il2cppOutput", Path.Combine(exportPath, "__il2cpp"));
	}

    [MenuItem("Build/IOS")]
	public static void BuildIOS()
	{
		var args = System.Environment.GetCommandLineArgs();
		Debug.Log($"Command line arguments:\n{string.Join("\n", args)}");

    	const string exportPath = "Build/ios";
		if(Directory.Exists(exportPath))
		{
			Directory.Delete(exportPath, true);
		}
		BuildPipeline.BuildPlayer(new EditorBuildSettingsScene[0], exportPath, BuildTarget.iOS, BuildOptions.AcceptExternalModificationsToPlayer);
	}
}