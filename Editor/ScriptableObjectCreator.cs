#if UNITY_EDITOR
using System.IO;
using System.Runtime.CompilerServices;

using UnityEngine;
using UnityEditor;

using JetBrains.Annotations;

namespace CGTK.Utilities.Singletons
{

    public static class ScriptableObjectCreator
    {
        private const string _DEFAULT_DIRECTORY = "Samples/CGTK.Utilities.Singletons/";

        [PublicAPI]
        public static void Create<T>(string directory = _DEFAULT_DIRECTORY)
            where T : ScriptableObject
        {
            string __fullPath = Application.dataPath + '/' + directory; 
            if (!Directory.Exists(path: __fullPath))
            {
                Debug.LogWarning(message: $"Directory {Application.dataPath + '/' + directory} doesn't exist");
                directory = "";
            }

            directory = EditorUtility.SaveFilePanel(title: "Save ScriptableObject as...", directory: directory, defaultName: "New " + typeof(T).Name, extension: "asset");
            
            //It assumes you're putting it in a subdirectory of Application.dataPath.
            //But that's the only directory where they make sense, so don't be an idiot.

            if (string.IsNullOrEmpty(directory))
            {
                Debug.LogError(message: "NO DIRECTORY SELECTED");
                return;
            }
            
            directory = directory.Remove(startIndex: 0, count: Application.dataPath.Length - 6); //-6 for "Assets" 

            if (TryCreateInstance(asset: out T __asset))
            {
                Debug.Log(message: $"Create Instance = {directory}");
                
                AssetDatabase.CreateAsset(asset: __asset, path: directory);
                AssetDatabase.Refresh();
                return;
            }
            
            Debug.LogError(message: "ScriptableObject Creation FAILED!!");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryCreateInstance<T>(out T asset)
            where T : ScriptableObject
        {
            asset = ScriptableObject.CreateInstance<T>();
            
            return (asset != null);
        }
    }

}
#endif