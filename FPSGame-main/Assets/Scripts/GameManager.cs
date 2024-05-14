using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int enemyLeft = 10;
    public float timeLeft = 60;

    public List<GameObject> enemies;
    public float spawnTerm = 3;

    bool isPlaying = true;

    float lastSpawn = 0;
    int enemyIndex = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                GameOverScene();

            }

            lastSpawn -= Time.deltaTime ;
            if(lastSpawn <= 0 )
            {
                if(enemyIndex < enemies.Count)
                {
                    enemies[enemyIndex].SetActive(true);
                    enemyIndex++;
                    lastSpawn+=spawnTerm;
                }
            }
        }
    }

    public void EnemyDied()
    {
        enemyLeft--;

        if (enemyLeft<=0)
        {
            GameOverScene();
        }
    }

    public void GameOverScene()
    {
        isPlaying = false;
        SceneManager.LoadScene("GameOverScene");
    }

}
