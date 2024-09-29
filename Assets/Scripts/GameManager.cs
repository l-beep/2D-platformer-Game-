using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;

    public static Vector2 lastCheckPointPos = new Vector2(-6.35f,0);

    public static int numberofCoins;

    public TextMeshProUGUI coinsText;
    public CinemachineVirtualCamera VCam;

    public GameObject[] playerPrefabs;
    int characterIndex;

    public static bool isLevelComplete;
    public GameObject levelCompleteScreen;


    private void Awake()
    {
        isLevelComplete = false;


       characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
       GameObject player = Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);

        VCam.m_Follow = player.transform;
        numberofCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        isGameOver = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
        
    }


    private void Update()
    {


        if (isLevelComplete)
        {
            levelCompleteScreen.SetActive(true);
        }
        coinsText.text = numberofCoins.ToString();
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void FinishLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
