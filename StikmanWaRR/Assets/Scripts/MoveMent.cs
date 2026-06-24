using UnityEngine;

public class MoveMent : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private float horizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // В Update ТОЛЬКО собираем нажатия клавиш
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        // ДВИГАЕМ ЧЕРЕЗ RIGIDBODY, чтобы работали стены и коллайдеры
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }
}