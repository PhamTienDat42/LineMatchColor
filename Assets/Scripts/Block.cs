using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int Value;
    [SerializeField] private SpriteRenderer spriteRendererBlock;

    public void Init(BlockType blockType)
    {
        Value = blockType.Value;
        spriteRendererBlock.color = blockType.color;
    }

}
