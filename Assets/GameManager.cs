using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject LivesHolder;
    public GameObject GameOverPanel;
    public Text scoreText;
    private bool gameOver = false;
    private int lives = 3;

    void Awake()
    {
        instance = this;
    }
    private int score=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Increment()
    {
        if (!gameOver)
        {
            score++;
            scoreText.text = score.ToString();
            // print(score);
        }
        
    }

    public void DecreaseLife()
    {
        if (lives > 0)
        {
            lives--;
            print(lives);
            LivesHolder.transform.GetChild(lives).gameObject.SetActive(false);
            
        }

        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOver = true;
        CandySpawner.instance.StopSpawnCandies();
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        GameOverPanel.SetActive(true);
    }
}
