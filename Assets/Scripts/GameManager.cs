using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameoverText;
    public TextMeshProUGUI liveText;
    public Button replayButton;
    public GameObject titleScreen;
    public bool isGameActive;

    public GameObject pauseMenuUI; // Tham chiếu đến UI tạm dừng
    
    private bool isPaused = false;


    private int score;
    private int live;
    private float spawnRate = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Hiện thị menu tạm dừng
        Time.timeScale = 0f; // Tạm dừng thời gian
        isPaused = true; // Đánh dấu trạng thái là tạm dừng
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Ẩn menu tạm dừng
        Time.timeScale = 1f; // Tiếp tục thời gian
        isPaused = false; // Đánh dấu trạng thái là không tạm dừng
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        live = 3;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLive(0);
        titleScreen.SetActive(false);
    }

    public void UpdateScore(int addToScore)
    {
        score += addToScore;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLive(int dropToLive)
    { 
        live -= dropToLive;
        if (live < 0)
        {
            live = 0;
        }
        liveText.text = "Lives: " + live;
        if (live == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameoverText.gameObject.SetActive(true);
        isGameActive = false;
        replayButton.gameObject.SetActive(true);
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
