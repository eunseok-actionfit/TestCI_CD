#if UNITY_EDITOR
using System;
using UnityEditor;

public static class CICmdlineBuildOptions
{
    [InitializeOnLoadMethod]
    private static void ApplyFromArgs()
    {
        var args = Environment.GetCommandLineArgs();

        // -------- Android: apk / aab --------
        var idx = Array.IndexOf(args, "-androidArtifact");
        if (idx >= 0 && idx + 1 < args.Length)
        {
            var val = args[idx + 1].Trim().ToLowerInvariant();
            if (val == "aab" || val == "bundle") EditorUserBuildSettings.buildAppBundle = true;
            else if (val == "apk") EditorUserBuildSettings.buildAppBundle = false;
        }

        // -------- Build number / Version name --------
        int? buildNumber = null;

        var i = Array.IndexOf(args, "-buildNumber");
        if (i >= 0 && i + 1 < args.Length && int.TryParse(args[i + 1], out var build))
            buildNumber = build;

        var j = Array.IndexOf(args, "-versionName");
        if (j >= 0 && j + 1 < args.Length)
            PlayerSettings.bundleVersion = args[j + 1];

        if (buildNumber.HasValue)
        {
            // Android versionCode
            PlayerSettings.Android.bundleVersionCode = buildNumber.Value;

            // iOS buildNumber (string)
            PlayerSettings.iOS.buildNumber = buildNumber.Value.ToString();
        }
    }
}
#endif