//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Board : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private int sizeX = 6;
    [SerializeField] private int sizeY = 6;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private SpriteRenderer boardPrefab;
    [SerializeField] private Block blockPrefab; 
    public List<BlockType> blockTypes;
    private List<Tile> tileMap;
    private List<Block> blockTile;
    private BlockType GetBlockTypeByValue(int value) => blockTypes.First(t => t.Value == value);

    private void Start()
    {
        CreateBoard();
    }

    private void CreateBoard()
    {
        tileMap = new List<Tile>();
        blockTile = new List<Block>();
        // get size Camera
        Camera mainCamera = Camera.main;
        float cameraHeight = 2f * mainCamera.orthographicSize - 0.1f;
        float cameraWidth = cameraHeight * mainCamera.aspect -0.1f;

        // tile size
        float tileSize = Mathf.Min(cameraWidth / sizeX, cameraHeight / sizeY);

        // position start board
        float startX = -(sizeX * tileSize) / 2f + tileSize / 2f;
        float startY = -(sizeY * tileSize) / 2f + tileSize / 2f;
        //tileMap = new Tile[sizeX, sizeY];

        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                var tileObj = Instantiate(tilePrefab, transform);
                Vector3 tilePosition = new Vector3(startX + i * tileSize, startY + j * tileSize, 0f);
                tileObj.transform.localPosition = tilePosition;
                tileObj.transform.localRotation = Quaternion.identity;
                tileObj.transform.localScale = new Vector3(tileSize, tileSize, 1f);

                tileMap.Add(tileObj);

                //Tile tile = tileObj.GetComponent<Tile>();
                //if (tile != null)
                //{
                //    tile.Init(i, j);
                //}
                //tileMap[i, j] = tile;
            }
        }

        float boardSizeX = tileSize * sizeX + 0.1f;
        float boardSizeY = tileSize * sizeY +0.1f;
        var board = Instantiate(boardPrefab, Vector3.zero, Quaternion.identity);
        board.transform.localScale = new Vector3(boardSizeX, boardSizeY, 1f);

        SpawnBlocks(2);
    }

    private void SpawnBlocks(int amout)
    {
        var freeNodes = tileMap.Where(n => n.isOccupiedBlock == null).OrderBy(b => Random.value).ToList();

        foreach(var tile in freeNodes.Take(amout))
        {
            var block = Instantiate(blockPrefab, tile.Pos, Quaternion.identity);
            block.Init(GetBlockTypeByValue(2));
        }

        if(freeNodes.Count() == 1)
        {
            return;
        }
    }
}

[SerializeField] 
public struct BlockType{
    public int Value;
    public Color color;
}