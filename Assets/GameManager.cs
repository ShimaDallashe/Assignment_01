using UnityEngine;

public class GameManager : MonoBehaviour {
    [Header("Coin Settings")]
    public GameObject coinPrefab;
    private int orangeValue = 50;
    private int greenValue = 20;
    private int blueValue = 10;
    
    private Color orangeColor = new Color(1.0f, 0.5f, 0.0f);
    private Color greenColor = Color.green;
    private Color blueColor = Color.blue;

    [Header("Game State")]
    public int currentScore = 0;
    public int targetScore = 1000;
    private int currentActiveCoins = 0;
    
    [Header("Spawn Range")]
    public float minX = -6f;
    public float maxX = 6f;
    public float minY = -3f;
    public float maxY = 3f;
    void Start() {
        SpawnBatch();
    }

    void SpawnBatch() {
        for (int i = 0; i < 5; i++) {
            SpawnSingleCoin();
        }
    }

    void SpawnSingleCoin() {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(randomX, randomY, 0f);
        
        GameObject newCoin = Instantiate(coinPrefab, spawnPos, Quaternion.identity);
        currentActiveCoins++;
        
        int randomType = Random.Range(0, 3);
        SpriteRenderer renderer = newCoin.GetComponent<SpriteRenderer>();
        Coin coinScript = newCoin.GetComponent<Coin>();

        if (randomType == 0) {
            renderer.color = orangeColor;
            coinScript.coinValue = orangeValue;
        }
        else if (randomType == 1) {
            renderer.color = greenColor;
            coinScript.coinValue = greenValue;
        }
        else if (randomType == 2) {
            renderer.color = blueColor;
            coinScript.coinValue = blueValue;
        }
    }
    
    public void AddScore(int amount) {
        currentScore += amount;
        currentActiveCoins--;
        
        if (currentScore >= targetScore) {
            Debug.Log("you won");
        }
        if (currentActiveCoins <= 0) {
            SpawnBatch();
        }
    }
}