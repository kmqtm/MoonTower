using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class enemy_animation : MonoBehaviour
{
    public Sprite enemy_sprite_1;
    public Sprite enemy_sprite_2;
    public float animation_swap_interval_second = 0.1f;

    private float time_since_last_swap = 0.0f;
    
    private SpriteRenderer enemy_sprite_renderer;

    // Start is called before the first frame update
    void Start()
    {
        enemy_sprite_renderer = GetComponent<SpriteRenderer>();
        enemy_sprite_renderer.sprite = enemy_sprite_1;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEnemySprite();
    }

    private void UpdateEnemySprite()
    {
        time_since_last_swap += Time.deltaTime;

        if (time_since_last_swap >= animation_swap_interval_second)
        {
            SwapSprites();
            time_since_last_swap = 0f;
        }
    }

    private void SwapSprites()
    {
        // ‰æ‘œ‚ğ·‚µ‘Ö‚¦
        if (enemy_sprite_renderer.sprite == enemy_sprite_1)
        {
            enemy_sprite_renderer.sprite = enemy_sprite_2;
        }
        else
        {
            enemy_sprite_renderer.sprite = enemy_sprite_1;
        }
    }
}
