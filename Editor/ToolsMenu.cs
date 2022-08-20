#if UNITY_EDITOR

using UnityEditor;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEngine.Application;
using static UnityEditor.AssetDatabase;

namespace TeaGames.Unity.Utils.Editor
{
    public static class ToolsMenu
    {
        [MenuItem("Tools/Setup/Create Default Folders")]
        public static void CreateDefaultFolders()
        {
            CreateDirectories("_Project", "Scripts", "Art", "Scenes");
            Refresh();
        }

        [MenuItem("Tools/Setup/Create Feature Based Folders")]
        public static void CreateFeatureBasedFolders()
        {
            CreateDirectories("_Project", "Common");
            CreateDirectories("_Project/Common", "Scenes");
            Refresh();
        }

        public static void CreateDirectories(string root, params string[] dir)
        {
            var fullpath = Combine(dataPath, root);
            foreach (var newDirectory in dir)
            {
                CreateDirectory(Combine(fullpath, newDirectory));
            }
        }
    }
}

#endif
