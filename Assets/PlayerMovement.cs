using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    public float speed = 5.0f;
    private GameManager gameManager;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update() {
        float dValue = Keyboard.current.dKey.value;
        float aValue = Keyboard.current.aKey.value;
        float wValue = Keyboard.current.wKey.value;
        float sValue = Keyboard.current.sKey.value;
        
        float h = dValue - aValue;
        float v = wValue - sValue;
        moveDirection = new Vector2(h, v).normalized;
    }
    void FixedUpdate() {
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.CompareTag("Enemy")) {
            if (gameManager != null && gameManager.currentScore >= gameManager.targetScore) {
                return;
            }
            //if we didn't won yet then we lost here 
            Debug.Log("you lose");
        }
        else if (other.gameObject.CompareTag("Coin")) {
            Coin coin = other.GetComponent<Coin>();
            if (coin != null && gameManager != null) {
                gameManager.AddScore(coin.coinValue);
            }
            Destroy(other.gameObject);
        }
    }
}