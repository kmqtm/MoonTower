using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputAndStateManager : MonoBehaviour
{
    // プレイヤーのパラメータ
    public int player_life_point = 3;

    // プレイヤーの各状態
    public bool is_grounded                 = false;
    public bool is_ceiling_hit_and_in_air   = false;
    public bool is_jumping                  = false;
    public bool is_walking                  = false;
    public bool is_damaged                  = false;
    public bool is_knockbacked              = false;
    public float damaged_time               = 0.0f;
    public float invincible_time            = 1.0f;

    // 入力保存用変数
    public bool is_space_key_pressed        = false;
    public bool is_space_key_keep_pressed   = false;
    public bool is_space_key_released       = false;
    public float horizontal_input           = 0.0f;
    public Vector2 current_move_direction   = Vector2.zero;

    // 天井との衝突音が再生されたか
    private bool is_ceiling_hit_sound_played = false;

    private Rigidbody2D player_rigidbody_2d;
    private BoxCollider2D player_box_collider_2d;
    private PlayerSoundManager playerSoundManager;

    public Vector2 GetCurrentMoveDirection()
    {
        return player_rigidbody_2d.totalForce;
    }

    private void Start()
    {
        player_life_point = TitleOptionSetting.player_life_num;

        player_rigidbody_2d     = GetComponent<Rigidbody2D>();
        player_box_collider_2d  = GetComponent<BoxCollider2D>();
        playerSoundManager      = GetComponent<PlayerSoundManager>();
    }

    private void Update()
    {
        CheckIsGameover();

        // 入力受付
        CheckHorizontalInput();
        CheckSpaceKeyInput();

        // 状態制御
        WalkStateControll();
        JumpStateControll();
    }

    private void CheckIsGameover()
    {
        if (player_life_point <= 0)
        {
            // ゲームオーバーシーンへ遷移
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void CheckHorizontalInput()
    {
        horizontal_input = Input.GetAxis("Horizontal");
    }

    private void CheckSpaceKeyInput()
    {
        // スペースキーが押された瞬間のみtrue
        is_space_key_pressed = Input.GetKeyDown(KeyCode.Space);

        // スペースキーを押している間はtrue
        is_space_key_keep_pressed = Input.GetKey(KeyCode.Space);

        // スペースキーを離した瞬間のみtrue
        is_space_key_released = Input.GetKeyUp(KeyCode.Space);
}

    private void WalkStateControll()
    {
        if (horizontal_input != 0 && is_grounded)
        {
            is_walking = true;
        }
        else
        {
            is_walking = false;
        }
    }

    private void JumpStateControll()
    {
        // ジャンプ開始
        if (is_grounded && is_space_key_pressed)
        {
            is_jumping = true;
        }
        // ジャンプ終了
        else if (is_space_key_released)
        {
            is_jumping = false;
        }

        // 天井にぶつかったらジャンプ終了
        if (is_ceiling_hit_and_in_air)
        {
            is_jumping = false;
        }
    }

    private void FixedUpdate()
    {
        // 地面との衝突判定
        CheckGrounded();
        
        // 天井との衝突判定
        CheckBumpedCeiling();

        // 敵との衝突判定
        CheckHitEnemy();
    }

    private void CheckGrounded()
    {
        float distance = 0.1f;
        RaycastHit2D raycast_hit_floor = Physics2D.BoxCast(player_box_collider_2d.bounds.center, player_box_collider_2d.bounds.size, 0f, Vector2.down, distance, LayerMask.GetMask("Ground"));

        if (raycast_hit_floor.collider == true)
        {
            is_grounded = true;
        }
        else 
        { 
            is_grounded = false;
        }
        
    }

    private void CheckBumpedCeiling()
    {
        float distance = 0.1f;
        RaycastHit2D raycast_hit_ceiling = Physics2D.BoxCast(player_box_collider_2d.bounds.center, player_box_collider_2d.bounds.size, 0f, Vector2.up, distance, LayerMask.GetMask("Ground"));

        if (is_grounded == true)
        {
            is_ceiling_hit_and_in_air = false;

            is_ceiling_hit_sound_played = false;
        }
        else if (raycast_hit_ceiling.collider == true)
        {
            is_ceiling_hit_and_in_air = true;

            if (is_ceiling_hit_sound_played == false)
            {
                // 天井との衝突音を再生
                playerSoundManager.CeilingHitSoundPlay();

                is_ceiling_hit_sound_played = true;
            }
            
        }
    }

    private void CheckHitEnemy()
    {
        // ダメージ状態でない かつ 敵に衝突
        if (is_damaged == false && player_box_collider_2d.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            is_damaged = true;
            damaged_time = Time.time;

            // ダメージ処理
            LifePointDecrement();
            // ダメージ音再生
            playerSoundManager.DamagedSoundPlay();
        }
        // ダメージ時から無敵時間が経過
        else if (damaged_time + invincible_time <= Time.time)
        {
            is_damaged = false;
        }
    }

    private void LifePointDecrement()
    {
        player_life_point -= 1;
    }
}
