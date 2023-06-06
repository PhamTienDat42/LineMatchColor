//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//public class Board : MonoBehaviour
//{
//    [SerializeField] private int sizeX = 6;
//    [SerializeField] private int sizeY = 6;
//    [SerializeField] private Tile tilePrefab;
//    [SerializeField] private SpriteRenderer boardPrefab;
//    [SerializeField] private Block blockPrefab;
//    [SerializeField] private int amountBlocks;
//    private List<Tile> tileMap;
//    private List<Block> blockTile;

   

//    private void Start()
//    {
//        CreateBoard();
//    }

//    private void CreateBoard()
//    {
//        tileMap = new List<Tile>();
//        blockTile = new List<Block>();
//        // get size Camera
//        Camera mainCamera = Camera.main;
//        float cameraHeight = 2f * mainCamera.orthographicSize - 0.1f;
//        float cameraWidth = cameraHeight * mainCamera.aspect -0.1f;

//        // tile size
//        float tileSize = Mathf.Min(cameraWidth / sizeX, cameraHeight / sizeY);

//        // position start board
//        float startX = -(sizeX * tileSize) / 2f + tileSize / 2f;
//        float startY = -(sizeY * tileSize) / 2f + tileSize / 2f;
//        //tileMap = new Tile[sizeX, sizeY];

//        for (int i = 0; i < sizeX; i++)
//        {
//            for (int j = 0; j < sizeY; j++)
//            {
//                var tileObj = Instantiate(tilePrefab, transform);
//                Vector3 tilePosition = new Vector3(startX + i * tileSize, startY + j * tileSize, 0f);
//                tileObj.transform.localPosition = tilePosition;
//                tileObj.transform.localRotation = Quaternion.identity;
//                tileObj.transform.localScale = new Vector3(tileSize, tileSize, 1f);

//                tileMap.Add(tileObj);

//                //Tile tile = tileObj.GetComponent<Tile>();
//                //if (tile != null)
//                //{
//                //    tile.Init(i, j);
//                //}
//                //tileMap[i, j] = tile;
//            }
//        }

//        float boardSizeX = tileSize * sizeX + 0.1f;
//        float boardSizeY = tileSize * sizeY +0.1f;
//        var board = Instantiate(boardPrefab, Vector3.zero, Quaternion.identity);
//        board.transform.localScale = new Vector3(boardSizeX, boardSizeY, 1f);
//    }
//}

