using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] private int playerLives = 3;
    [SerializeField] private float dyingDelayBeforeNextSceneLoad = 2f;
    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOver;
    
    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numGameSessions > 1)
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
        gameOver.SetActive(false);
        scoreText.text = "<size=100>Score:</size> " + score;
        livesText.text = "<size=100>Lifes:</size> " + playerLives;
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            StartCoroutine(TakeLife());
        }
        else
        {
            StartCoroutine(ResetGameSession());
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = "<size=100>Score:</size> : " + score;
    }

    IEnumerator TakeLife()
    {
        playerLives --;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        yield return new WaitForSecondsRealtime(dyingDelayBeforeNextSceneLoad);
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = "<size=100>Lifes:</size> : " + playerLives;
    }
    
    IEnumerator ResetGameSession()
    {
        gameOver.SetActive(true);
        yield return new WaitForSeconds(4);
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
