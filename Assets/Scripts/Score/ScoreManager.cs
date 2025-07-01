using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [Header("UI Settings")]
    public TextMeshProUGUI scoreText;

    [Header("Victory Settings")]
    public int targetScore = 10; // puntaje para ganar
    public string victorySceneName = "WinScene"; // nombre de la escena a cargar

    private int currentScore = 0;

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateUI();

        if (currentScore >= targetScore)
        {
            LoadVictoryScene();
        }
    }

    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = currentScore.ToString();
    }

    private void LoadVictoryScene()
    {
       SceneManager.LoadScene(victorySceneName);
    }
}
