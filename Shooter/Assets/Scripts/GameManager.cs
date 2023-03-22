using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour

{
    public int enemiesAlive = 0;
    public int round = 0;
    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;
    public TextMeshProUGUI roundText;
    public static GameManager Instance { get; private set; }
    private int currentRound = 1;


    // Start is called before the first frame update
    void Awake()
    {
        // Implement the Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncrementRound()
    {
        currentRound++;
    }

    public int GetCurrentRound()
    {
        return currentRound;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesAlive == 0)
        {
            round++;
            NextWave(round);
            currentRound = GameManager.Instance.GetCurrentRound();
            roundText.text = "Round: " + currentRound.ToString();
        }
    }
    public void NextWave(int round)
    {
        for(var x = 0; x < round; x++)
        {
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            enemySpawned.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>();
            enemiesAlive++;
        }
        
    }
}
