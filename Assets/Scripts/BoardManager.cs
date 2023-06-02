using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private int _width = 4, _height = 4;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private SpriteRenderer _boardPrefab;

    //[SerializeField] private Transform _cam;
    private Tile[,] tiles;

    private void Start()
    {
        CreateBoard();
    }

    private void CreateBoard()
    {
        tiles = new Tile[_height, _width];

        for (int x = 0; x < _width; ++x)
        {
            for(int y = 0; y < _height; ++y)
            {
                var node = Instantiate(_tilePrefab, new Vector2(x, y), Quaternion.identity);
            }
        }
        var center = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10f);

        var board = Instantiate(_boardPrefab, center, Quaternion.identity);
        board.size = new Vector2(_width, _height);
        Camera.main.transform.position = new Vector3(center.x, center.y, -10f);
    }
}
