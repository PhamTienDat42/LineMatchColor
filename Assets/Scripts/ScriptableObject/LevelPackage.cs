using UnityEngine;

namespace LevelPack
{
    [CreateAssetMenu(fileName = "levelpack", menuName = "ColorDotsPz/Level Pack", order = 1)]
    public class LevelPackage : ScriptableObject 
    {
        public string packName;
        public TextAsset maps;
        public bool locked;
    }
}

