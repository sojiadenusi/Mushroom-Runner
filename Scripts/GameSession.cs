using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;    

    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;

    private void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if(numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {       
        scoreText.text = score.ToString();
        livesText.text = playerLives.ToString();
    }

    public void AddToScore(int valueOfItem)
    {
        score += valueOfItem;
        scoreText.text = score.ToString();
    }

    public void PlayerDeath()
    {
        if(playerLives > 1)
        {
            LoseLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void LoseLife()
    {
        playerLives -= 1 ;
        var currIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currIndex);
        livesText.text = playerLives.ToString();
    }

    public void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    

    


}
