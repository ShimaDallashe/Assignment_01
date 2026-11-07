using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed = 3.0f;
    private Rigidbody2D rb;
    private Transform playerTransform;
    private Vector2 moveDirection;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            playerTransform = player.transform;
        }
    }
    void Update() {
        if (playerTransform != null)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            moveDirection = new Vector2(direction.x, direction.y);
        }
    }
    void FixedUpdate() {
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
    }
}