using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private BoxCollider2D enemy_box_collider_2d;

    public enum MovementType
    {
        Horizontal,
        Vertical
    }

    // 敵が動くかどうか
    public bool isMove = true;
    // 移動の種類（横か縦）
    public MovementType moveType;
     // 移動速度
    public float moveSpeed = 5f;

    private void Start()
    {
        enemy_box_collider_2d = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if (isMove)
        {
            Move();
        }
    }

    private void Move()
    {
        float horizontalInput = (moveType == MovementType.Horizontal) ? 1f : 0f;
        float verticalInput = (moveType == MovementType.Vertical) ? 1f : 0f;

        // 移動ベクトル
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // 移動処理
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);

        // 当たり判定をチェックして反転
        CheckWallCollision();
    }

    private void CheckWallCollision()
    {
        float distance = 0.2f;
        RaycastHit2D raycast_hit = Physics2D.BoxCast(enemy_box_collider_2d.bounds.center, enemy_box_collider_2d.bounds.size, 0f, GetMovementDirection(), distance, LayerMask.GetMask("EnemyBound"));
        
        // レイが何かに当たった場合
        if (raycast_hit == true)
        {
            // 進行方向を逆向きにする
            Rotate180Degrees();
        }
    }

    private Vector2 GetMovementDirection()
    {
        if (moveType == MovementType.Horizontal)
        {
            return transform.right;
        }
        else
        {
            return transform.up;
        }
    }

    void Rotate180Degrees()
    {
        // 現在の回転を取得
        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation;

        if (moveType == MovementType.Horizontal)
        {
            // Y軸を中心に180度回転させる
            newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y + 180f, currentRotation.eulerAngles.z);
        }
        else
        {
            // X軸を中心に180度回転させる
            newRotation = Quaternion.Euler(currentRotation.eulerAngles.x + 180f, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z);
        }

        

        // 回転を適用
        transform.rotation = newRotation;
    }
}
