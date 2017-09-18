using UnityEditor;
using UnityEditor.Callbacks;

namespace Agens.Stickers
{
    public class StickersBuildPostprocessor
    {
        //unity cloud has bug with building build wisth stickers. So for CloudBuild use this define 
#if WITHOUT_STICKERS
#else
        [PostProcessBuild(1)]
        public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
        {
            if (target != BuildTarget.iOS)
            {
                return;
            }

            StickersExport.WriteToProject(pathToBuiltProject);
        }
#endif
    }
}