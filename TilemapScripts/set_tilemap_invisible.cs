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
        // Tilemap���擾
        tilemap = GetComponent<Tilemap>();

        if (tilemap != null)
        {
            // �����̐F��ݒ�
            SetTilemapColor(targetColor);
        }
        else
        {
            Debug.LogError("Tilemap not found!");
        }
    }

    void SetTilemapColor(Color color)
    {
        // �}�e���A���̐F��ύX
        tilemap.color = color;
    }
}
