using UnityEngine;

public class StickWarUnit : MonoBehaviour
{
    public float speed = 3f;
    public int direction = 1; // 1 для твоих (идут вправо), -1 для врагов (идут влево)
    public string enemyTag = "EnemyUnit"; // Тэг вражеского юнита

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Если это НАШ юнит и отдана команда ОБОРОНА — стоим на месте
        if (direction == 1 && StickWarManager.Instance.currentOrder == StickWarManager.GameOrder.Defend)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
        else
        {
            // В атаку или если это враг — берем и бежим вперед
            rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Стенка на стенку: если столкнулись с противоположным юнитом — оба удаляются
        if (other.CompareTag(enemyTag))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}