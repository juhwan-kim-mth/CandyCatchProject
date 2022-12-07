using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject LivesHolder;
    public GameObject GameOverPanel;
    [FormerlySerializedAs("scoreText")] public TMP_Text ScoreText;
    bool _gameOver;
    int _lives = 3;
    int _score;

    void Awake()
    {
        Instance = this;
    }

    public void Increment()
    {
        if (_gameOver) return;
        _score++;
        ScoreText.text = _score.ToString();
    }

    public void DecreaseLife()
    {
        if (_lives > 0)
        {
            _lives--;
            print(_lives);
            LivesHolder.transform.GetChild(_lives).gameObject.SetActive(false);
        }

        if (_lives <= 0)
        {
            GameOver();
        }
    }

    // XXX(Juhwan): 외부에서 사용될 계획이 있어서 public으로 선언
    // ReSharper disable once MemberCanBePrivate.Global
    public void GameOver()
    {
        _gameOver = true;
        CandySpawner.Instance.StopSpawnCandies();
        GameObject.Find("Player").GetComponent<PlayerController>().CanMove = false;
        GameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}