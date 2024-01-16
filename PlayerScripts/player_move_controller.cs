using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public float player_move_speed      = 5f;
    public float player_jump_force      = 2.5f;
    public float player_hit_up_force    = 50.0f;

    private BoxCollider2D player_box_collider_2d;
    private Rigidbody2D player_rigidbody_2d;
    private PlayerInputAndStateManager playerInputAndStateManager;

    // Start is called before the first frame update
    private void Start()
    {
        player_box_collider_2d      = GetComponent<BoxCollider2D>();
        player_rigidbody_2d         = GetComponent<Rigidbody2D>();
        playerInputAndStateManager  = GetComponent<PlayerInputAndStateManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        SetWalkVelocity();
        SetJumpVelocity();

        // 敵と当たった時のノックバック処理
        MakeHitUp();
    }

    private void SetWalkVelocity()
    {
        // 左右移動
        Vector2 movement = new Vector2(playerInputAndStateManager.horizontal_input * player_move_speed, player_rigidbody_2d.velocity.y);
        player_rigidbody_2d.velocity = movement;
    }

    private void SetJumpVelocity()
    {
        // ジャンプ中の上昇
        if (playerInputAndStateManager.is_jumping && playerInputAndStateManager.is_space_key_keep_pressed)
        {
            player_rigidbody_2d.velocity = new Vector2(player_rigidbody_2d.velocity.x, player_jump_force);
        }
    }

    private void MakeHitUp()
    {
        if (playerInputAndStateManager.is_damaged == true && playerInputAndStateManager.is_knockbacked == false)
        {
            playerInputAndStateManager.is_knockbacked = true;

            // 敵とヒットして少し浮く
            player_rigidbody_2d.AddForce(new Vector2(0.0f, player_hit_up_force));
        }
        else if (playerInputAndStateManager.is_damaged == false)
        {
            playerInputAndStateManager.is_knockbacked = false;
        }
    }
}
