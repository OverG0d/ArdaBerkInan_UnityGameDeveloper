using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    private static LevelManager _instance;

    public static LevelManager Instance { get { return _instance; } }

    [Header("Fields")]
    [SerializeField] private int lives;
    [SerializeField] private int points;
    [SerializeField] private int numOfPointsGained;
    [SerializeField] private int pointsToWin;

    [Header("Texts")]
    [SerializeField] private Text pointsText;
    [SerializeField] private Text livesText;
    [SerializeField] private Text winConditionText;
    [SerializeField] private Text restartText;
    [SerializeField] private Text quitText;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        pointsText.text = "Points:" + points;
        livesText.text = "Lives:" + lives;
    }

    public void CheckWin()
    {
        points += numOfPointsGained;
        pointsText.text = "Points:" + points;
    
        if (points >= pointsToWin)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    public void CheckLoss()
    {
        lives--;
        livesText.text = "Lives:" + lives;
              
        if (lives <= 0)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
