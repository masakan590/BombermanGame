using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MovementController : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    private Vector2 direction = Vector2.down;
    public float speed = 5f;
    public int playerNumber;

    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    public AnimatedSpriteRenderer spriteRendererDeath;
    private AnimatedSpriteRenderer activSpriteRenderer;

    public TMP_Text gameOverText; // TextMeshPro�p��TMP_Text
    public float restartDelay = 2f; // ���X�^�[�g����܂ł̒x������

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var inputX = Input.GetAxisRaw($"Horizontal_P{playerNumber}");
        var inputY = Input.GetAxisRaw($"Vertical_P{playerNumber}");


        if (inputY > 0)
        {
            SetDirection(Vector2.up, spriteRendererUp);
        }
        else if (inputY < 0)
        {
            SetDirection(Vector2.down, spriteRendererDown);
        }
        else if (inputX < 0)
        {
            SetDirection(Vector2.left, spriteRendererLeft);
        }
        else if (inputX > 0)
        {
            SetDirection(Vector2.right, spriteRendererRight);
        }
        else
        {
            SetDirection(Vector2.zero, activSpriteRenderer);
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rigidbody.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer)
    {
        direction = newDirection;

        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;

        activSpriteRenderer = spriteRenderer;
        activSpriteRenderer.idle = direction == Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion") || other.CompareTag("Enemy"))
        {
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        enabled = false;
        GetComponent<BombController>().enabled = false;

        spriteRendererUp.enabled = false;
        spriteRendererDown.enabled = false;
        spriteRendererLeft.enabled = false;
        spriteRendererRight.enabled = false;
        spriteRendererDeath.enabled = true;

        gameOverText.enabled = true; // �Q�[���I�[�o�[�̃��b�Z�[�W��\��

        Invoke(nameof(OnDeathSequenceEnded), 1.25f);
    }

    private void OnDeathSequenceEnded()
    {
        gameObject.SetActive(false);
        Invoke(nameof(RestartStage), restartDelay); // �x����ɃX�e�[�W���ăX�^�[�g
    }

    private void RestartStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���݂̃X�e�[�W���ă��[�h
    }
}
