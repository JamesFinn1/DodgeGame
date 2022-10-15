using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text currentScoreText;
    [SerializeField] private PlayerCollision playerCollison;
    private int highScore;

    private void Start()
    {
      
    }

    public void DisplayGameOver()
    {
        if (gameOverPanel != null)
        {
            // Setting canvas to higherlayer so game objects are not over text
            canvas.sortingLayerName = "Sprites";
            canvas.sortingOrder = 2;

            string path = Application.dataPath + "/HighScore.txt";
            
            if (!File.Exists(path))
            {
                CreateText(playerCollison.CoinCount.ToString()); // Adds number to text file
                highScoreText.text = playerCollison.CoinCount.ToString();
                Debug.Log("FileDosent exsists add to file");
            }
            else
            {
                int.TryParse(File.ReadAllText(path), out highScore);
                Debug.Log("CurrentCount == " + playerCollison.CoinCount + " HighScore == " + highScore);
                if(playerCollison.CoinCount > highScore)
                {
                    Debug.Log("HighScore");
                    File.WriteAllText(path, playerCollison.CoinCount.ToString());
                    highScoreText.text = playerCollison.CoinCount.ToString();
                }
                else
                {
                    highScoreText.text = File.ReadAllText(path);
                }
            }
            // Regardless add current score to death menu
            currentScoreText.text = playerCollison.CoinCount.ToString();

            gameOverPanel.SetActive(true);
        }
    }

    public void ResetGame()
    {
        canvas.sortingLayerName = "Default";
        canvas.sortingOrder = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void CreateText(string dIn)
    {
        string path = Application.dataPath + "/HighScore.txt";

        if (!File.Exists(path)) {
            File.WriteAllText(path, dIn);
        }
    }

}
