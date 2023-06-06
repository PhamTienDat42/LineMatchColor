using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorDotsPz
{
    public class BoardManager : MonoBehaviour
    {
        [SerializeField] private Tile tilePrefabs;
        [SerializeField] private SpriteRenderer circleFinger;

        private Tile[,] tiles;
        private int _width;
        private int _height;
        private int _screenWidth;
        private int _screenHeight;
        private float _scaleFactor;
    }
}