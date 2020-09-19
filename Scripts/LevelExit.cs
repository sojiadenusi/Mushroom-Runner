using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelDelay = 2f;
    [SerializeField] float levelExitSlow = 0.2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Level will load");
        StartCoroutine(WaitAndLoad());
    }
   
    IEnumerator WaitAndLoad()
    {
        Time.timeScale = levelExitSlow;
        yield return new WaitForSecondsRealtime(levelDelay);
        Time.timeScale = 1f;
        int currIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currIndex + 1);
    }
}
