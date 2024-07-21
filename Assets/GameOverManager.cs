using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;
    public Button mainMenuButton;
    public Button restartButton;
    public Movement movement;

    private void Start()
    {
        // Assicurati che il pannello di Game Over sia inizialmente nascosto
        gameOverPanel.SetActive(false);

        // Aggiungi i listener ai bottoni
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        restartButton.onClick.AddListener(RestartGame);

        // Carica il punteggio massimo
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = highScore.ToString();
    }

    public void ShowGameOver(int currentScore)
    {
        movement.isGameOver = true;
        // Aggiorna il punteggio attuale e il punteggio massimo
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        currentScoreText.text = currentScore.ToString();
        highScoreText.text = highScore.ToString();

        // Mostra il pannello di Game Over
        gameOverPanel.SetActive(true);

        // Ferma il tempo
        Time.timeScale = 0;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        movement.isGameOver = false;

        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }
}
