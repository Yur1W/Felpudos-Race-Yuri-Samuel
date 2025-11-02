using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public UiManager ui;
    public PlayerMovement player;

    public int lives = 3;
    public int score = 0;
    public float distance = 0f;
    public float runSpeed = 5f;
    public bool isGameOver {get; private set; } = false; 
    public bool isVictory {get; private set; } = false;
    // Start is called before the first frame update
    void Start()
    {
        ui.UpdateLives(lives);
        ui.UpdateScore(score);
        ui.UpdateDistance(distance);

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver || isVictory)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;

        }
        distance += runSpeed * Time.deltaTime;
        ui.UpdateDistance(distance);
        
    }

    public void GameOver()
    {
        isGameOver = true;
        player.KillPlayer();
        ui.ShowGameOver(true);

    }
    public void AddToken()
    {
        if (isGameOver) return;

        score++;
        ui.UpdateScore(score);

        if (score >= 5)
        {
            Victory();
        }
    }
    public void AddLife()
    {
        
    }
     void Victory()
    {
        isVictory = true;
        player.KillPlayer();
        ui.ShowVictory(true);
    }
}

