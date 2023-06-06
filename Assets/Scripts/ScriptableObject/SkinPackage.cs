using UnityEngine;

namespace LevelPack
{
    [CreateAssetMenu(fileName = "skinpackage", menuName = "ColorDotsPz/Skin Pack", order = 1)]
    public class SkinPackage : ScriptableObject
    {
        [Tooltip("Colores a usar en este tema")]
        public Color[] colores = new Color[6];
    }
}
