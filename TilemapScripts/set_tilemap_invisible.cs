using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class set_tilemap_invisible : MonoBehaviour
{
    public Color targetColor = Color.clear;

    private Tilemap tilemap;

    void Start()
    {
        // Tilemapを取得
        tilemap = GetComponent<Tilemap>();

        if (tilemap != null)
        {
            // 初期の色を設定
            SetTilemapColor(targetColor);
        }
        else
        {
            Debug.LogError("Tilemap not found!");
        }
    }

    void SetTilemapColor(Color color)
    {
        // マテリアルの色を変更
        tilemap.color = color;
    }
}
