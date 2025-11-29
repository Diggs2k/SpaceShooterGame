using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public int hazardcount;
    public Vector3 spawnvalues;
    public float spawnwait, waveWait, startwave;
    private int score, level;
    
    public TMP_Text score_text, gameover_text, restart_text, level_text;
    private bool gameOver, restart;
    private bool isPaused = false;
    void Start()
    {

        hazard.GetComponent<MoveAsteroid>().speed = -5;

        StartCoroutine(SpawnWaves());
        score = 0;
        level = 1;
        UpdateScoreText();
        UpdateLevelText();
        gameOver = false;
        restart = false;
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startwave);
        while (true)
        {
            for (int i = 0; i < hazardcount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnvalues.x, spawnvalues.x), spawnvalues.y, spawnvalues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnwait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restart_text.text = "Press <R> to restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore()
    {
        score += 10;
        UpdateScoreText();

        if (score >= level * 100)
        {
            level++;
            hazardcount += 2; 
            UpdateLevelText();

            hazard.GetComponent<MoveAsteroid>().speed -= 1;
        }
    }

    void UpdateScoreText()
    {
        score_text.text = "Score: " + score.ToString();
    }

    void UpdateLevelText()
    {
        level_text.text = "Level: " + level.ToString();
    }

    public void GameOver()
    {
        gameOver = true;
        gameover_text.text = "Game Over";
        Debug.Log(gameOver);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0;  // Pausa o jogo
            }
            else
            {
                Time.timeScale = 1;  // Retoma o jogo
            }
        }

        if(restart == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(1);
            }   
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoToMainMenu();
        }
    }
    public void GoToMainMenu()
    {
        Debug.Log("Returning to Main Menu...");
        SceneManager.LoadScene(0);
    }
}
