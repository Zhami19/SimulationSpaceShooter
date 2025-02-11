using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TMPro.EditorUtilities;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private GameObject _gameOverPanel;

    private int score = 0;


    public bool isGameOver = false;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreText.text = "Score: " + score;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver()
    {
        Debug.Log("Game Over");
        _gameOverPanel.SetActive(true);
        isGameOver = true;
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }

    
}
