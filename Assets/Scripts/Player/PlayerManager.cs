using UnityEngine.SceneManagement;
using UnityEngine;
using Cinemachine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;
    public GameObject timerpanel;
   
 
   

    public static Vector2 lastCheckPointPos = new Vector2(-3,1);

    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI besttiimeText;
    private float startTime;

    public CinemachineVirtualCamera VCam;
    public GameObject[] playerPrefabs;
    int characterIndex;
    private bool stoptime;

    
   
     

    private void Awake()
    {
        
        characterIndex =  PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player =  Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
        VCam.m_Follow = player.transform;
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        isGameOver = false;
        stoptime = false;
        startTime = Time.time;
       
    }

    void Update()
    {
        TimerUpdate();

        coinsText.text = numberOfCoins.ToString();
        
        if (isGameOver)
        {
            timerpanel.SetActive(false);
            stoptime = true;
            gameOverScreen.SetActive(true);
           // AudioManager.instance.Play("GameOver");
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
    public void Exit()
    {
        Application.Quit();
    }

    private void TimerUpdate()
    {
        if (stoptime)
        {
            return;
        }
        else
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            timerText.text = minutes + ":" + seconds;
            besttiimeText.text = minutes + ":" + seconds;
        }
              
        
    }
    


}
