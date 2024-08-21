using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f; // �ړ����x
    public float moveDistance = 3f; // �ړ����鋗��
    private bool movingRight = true; // �ړ������̃t���O
    private Vector2 initialPosition; // �����ʒu

    void Start()
    {
        // �����ʒu��ۑ�
        initialPosition = transform.position;
    }

    void Update()
    {
        // ���݈ʒu���擾
        Vector2 currentPosition = transform.position;

        // �ړ������ɉ����Ĉʒu���X�V
        if (movingRight)
        {
            transform.position = new Vector2(currentPosition.x + moveSpeed * Time.deltaTime, currentPosition.y);

            // �ړ������𒴂���������]��
            if (transform.position.x >= initialPosition.x + moveDistance)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.position = new Vector2(currentPosition.x - moveSpeed * Time.deltaTime, currentPosition.y);

            // �ړ������𒴂���������]��
            if (transform.position.x <= initialPosition.x - moveDistance)
            {
                movingRight = true;
                Flip();
            }
        }
    }

    // �G�̌����𔽓]������֐�
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // Explosion���C���[�̃I�u�W�F�N�g�ɏՓ˂����ۂ̏���
    void OnTriggerEnter2D(Collider2D collision)
    {
        // �Փ˂����I�u�W�F�N�g��Explosion���C���[�ɑ����Ă��邩�m�F
        if (collision.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            // �G�I�u�W�F�N�g���폜
            Destroy(gameObject);
        }
    }
}
