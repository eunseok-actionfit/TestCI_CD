#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

public static class AndroidVersioning
{
    // game-ci/unity-builder에서 buildMethod로 호출
    public static void ApplyAndroidVersionCodeFromArgs()
    {
        if (TryGetArgValue("-androidVersionCode", out var codeStr) && int.TryParse(codeStr, out var code))
        {
            PlayerSettings.Android.bundleVersionCode = code;
            Debug.Log($"[CI] Set Android bundleVersionCode(versionCode) = {code}");
        }
        else
        {
            Debug.Log("[CI] -androidVersionCode not provided. Keeping existing bundleVersionCode.");
        }
    }

    private static bool TryGetArgValue(string key, out string value)
    {
        var args = Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length - 1; i++)
        {
            if (args[i] == key)
            {
                value = args[i + 1];
                return true;
            }
        }
        value = null;
        return false;
    }
}
#endif