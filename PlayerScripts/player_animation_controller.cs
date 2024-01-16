/* 
 * 参考資料
 * [1]URL: https://nekojara.city/unity-object-blink#%E3%83%AC%E3%83%B3%E3%83%80%E3%83%A9%E3%83%BC%E3%82%92%E7%82%B9%E6%BB%85%E3%81%95%E3%81%9B%E3%82%8B
 * 取得日 2023-12-26
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Sprite player_sprite_1;
    public Sprite player_sprite_2;
    public Sprite player_sprite_3;
    public float damaged_render_time_cycle = 1.0f;

    private float damaged_render_time   = 0.0f;
    private float time_since_last_swap  = 0.0f;
    private float swap_interval_second  = 0.1f;
    private SpriteRenderer player_sprite_renderer;
    private PlayerInputAndStateManager playerInputAndStateManager;

    // Start is called before the first frame update
    private void Start()
    {
        playerInputAndStateManager      = GetComponent<PlayerInputAndStateManager>();
        player_sprite_renderer          = GetComponent<SpriteRenderer>();
        player_sprite_renderer.sprite   = player_sprite_1;
    }

    // Update is called once per frame
    private void Update()
    {
        DamegedSpriteRender();
        UpdatePlayerSprite();
        UpdatePlayerDirection();
    }

    private void DamegedSpriteRender()
    {
        // 参考[1]
        damaged_render_time += Time.deltaTime;

        if (playerInputAndStateManager.is_damaged == true)
        {
            // 0~damaged_render_time_cycleの範囲の値を取得
            var damaged_render_repeat_value = Mathf.Repeat(damaged_render_time, damaged_render_time_cycle);

            player_sprite_renderer.enabled = (damaged_render_repeat_value >= damaged_render_time_cycle * 0.5f);
        }
        else
        {
            player_sprite_renderer.enabled = true;
        }
    }

    private void UpdatePlayerSprite()
    {
        // 歩き
        if (playerInputAndStateManager.is_walking)
        {
            time_since_last_swap += Time.deltaTime;

            if (time_since_last_swap >= swap_interval_second)
            {
                SwapSprites();
                time_since_last_swap = 0f;
            }
        }
        // ニュートラル
        else if (playerInputAndStateManager.is_grounded)
        {
            player_sprite_renderer.sprite = player_sprite_1;
        }
        // 天井にぶつかってから地面につくまで
        else if (playerInputAndStateManager.is_ceiling_hit_and_in_air)
        {
            player_sprite_renderer.sprite = player_sprite_3;
        }
        // 空中にいる間
        else
        {
            player_sprite_renderer.sprite = player_sprite_2;
        }
    }

    private void UpdatePlayerDirection()
    {
        float horizontal_input = Input.GetAxis("Horizontal");

        // 入力によって画像を反転
        if (horizontal_input > 0)
        {
            player_sprite_renderer.flipX = false;
        }
        else if (horizontal_input < 0)
        {
            player_sprite_renderer.flipX = true;
        }
    }

    private void SwapSprites()
    {
        // 画像を差し替え
        if (player_sprite_renderer.sprite == player_sprite_1)
        {
            player_sprite_renderer.sprite = player_sprite_2;
        }
        else
        {
            player_sprite_renderer.sprite = player_sprite_1;
        }
    }
}
