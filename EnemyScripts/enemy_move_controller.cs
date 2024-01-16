using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private BoxCollider2D enemy_box_collider_2d;

    public enum MovementType
    {
        Horizontal,
        Vertical
    }

    // �G���������ǂ���
    public bool isMove = true;
    // �ړ��̎�ށi�����c�j
    public MovementType moveType;
     // �ړ����x
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

        // �ړ��x�N�g��
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // �ړ�����
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);

        // �����蔻����`�F�b�N���Ĕ��]
        CheckWallCollision();
    }

    private void CheckWallCollision()
    {
        float distance = 0.2f;
        RaycastHit2D raycast_hit = Physics2D.BoxCast(enemy_box_collider_2d.bounds.center, enemy_box_collider_2d.bounds.size, 0f, GetMovementDirection(), distance, LayerMask.GetMask("EnemyBound"));
        
        // ���C�������ɓ��������ꍇ
        if (raycast_hit == true)
        {
            // �i�s�������t�����ɂ���
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
        // ���݂̉�]���擾
        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation;

        if (moveType == MovementType.Horizontal)
        {
            // Y���𒆐S��180�x��]������
            newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y + 180f, currentRotation.eulerAngles.z);
        }
        else
        {
            // X���𒆐S��180�x��]������
            newRotation = Quaternion.Euler(currentRotation.eulerAngles.x + 180f, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z);
        }

        

        // ��]��K�p
        transform.rotation = newRotation;
    }
}
