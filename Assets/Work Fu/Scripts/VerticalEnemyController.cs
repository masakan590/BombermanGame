using UnityEngine;

public class VerticalEnemyController : MonoBehaviour
{
    public float moveSpeed = 2f; // �ړ����x
    public float moveDistance = 3f; // �ړ����鋗��
    private bool movingUp = true; // �ړ������̃t���O
    private Vector2 initialPosition; // �����ʒu
    private StageManager stageManager;
    void Start()
    {
        // �����ʒu��ۑ�
        initialPosition = transform.position;
        stageManager = GameObject.FindObjectOfType<StageManager>();
    }

    void Update()
    {
        // ���݈ʒu���擾
        Vector2 currentPosition = transform.position;

        // �ړ������ɉ����Ĉʒu���X�V
        if (movingUp)
        {
            transform.position = new Vector2(currentPosition.x, currentPosition.y + moveSpeed * Time.deltaTime);

            // �ړ������𒴂���������]��
            if (transform.position.y >= initialPosition.y + moveDistance)
            {
                movingUp = false;
                Flip();
            }
        }
        else
        {
            transform.position = new Vector2(currentPosition.x, currentPosition.y - moveSpeed * Time.deltaTime);

            // �ړ������𒴂���������]��
            if (transform.position.y <= initialPosition.y - moveDistance)
            {
                movingUp = true;
                Flip();
            }
        }
    }

    // �G�̌����𔽓]������֐�
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.y *= -1; // Y�������ɔ��]
        transform.localScale = theScale;
    }

    // Explosion���C���[�̃I�u�W�F�N�g�ɏՓ˂����ۂ̏���
    void OnTriggerEnter2D(Collider2D collision)
    {
        // �Փ˂����I�u�W�F�N�g��Explosion���C���[�ɑ����Ă��邩�m�F
        if (collision.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            stageManager.OnEnemyDefeated();
            // �G�I�u�W�F�N�g���폜
            Destroy(gameObject);
        }
    }
}
