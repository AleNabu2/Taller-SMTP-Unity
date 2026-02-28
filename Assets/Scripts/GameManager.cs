using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;

    public int score = 0;
    public int lostFruits = 0;

    public TextMeshProUGUI lostText;
    public int maxLost = 3;

    public int highScore = 0;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI emailStatusText;

    SimpleEmailSender emailSender;

    void Start()
    {
        Time.timeScale = 1f;
        
        emailSender = FindFirstObjectByType<SimpleEmailSender>();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void LoseFruit()
    {
        if (isGameOver) return;

        lostFruits++;

        if (lostText != null)
            lostText.text = "Frutas Perdidas: " + lostFruits;

        if (lostFruits >= maxLost)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);

        string subject = "";
        string body = "";

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();

            subject = "Nuevo Record en Fruit Catch";
            body = "Game Over.\n\n¡Nuevo récord!\nTu nuevo puntaje es: " + score +
                   "\n\nEste es ahora tu puntaje más alto.";
        }
        else
        {
            subject = "Game Over - Fruit Catch";
            body = "Game Over.\n\nTu puntaje fue: " + score +
                   "\nTu puntaje más alto es: " + highScore;
        }

        resultText.text = body;

        if (emailSender != null)
            emailSender.SendEmail(subject, body, emailStatusText);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}