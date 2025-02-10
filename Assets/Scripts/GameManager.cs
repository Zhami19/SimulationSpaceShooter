using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    private int score = 0;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
