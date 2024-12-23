using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int point = 0;

    [SerializeField] private TextMeshProUGUI pointText;

    [SerializeField] private GameObject gameOverCanvas; 
    [SerializeField] private TextMeshProUGUI gameOverPointText;

    private bool isGameOver = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPoint(int points)
    {
        point += points;
        UpdatePoint();
    }

    private void UpdatePoint()
    {
        if (pointText != null)
        {
            pointText.text = "Points: " + point.ToString();
        }


    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            gameOverCanvas.SetActive(true);
            pointText.gameObject.SetActive(false);


            if (gameOverPointText != null)
            {
                gameOverPointText.text = "Points: " + point.ToString();
            }

            if (pointText != null)
            {
                pointText.gameObject.SetActive(false);
            }

            Time.timeScale = 0f;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
