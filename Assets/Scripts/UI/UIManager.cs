using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text startScoreText;
    [SerializeField] Text highScoreText;
    [SerializeField] Text scoreText;
    [SerializeField] Text loseText;
    [SerializeField] Text loseScore;
    [SerializeField] Text loseHighScore;
    [SerializeField] Text startText;
    [SerializeField] Text startBackButtonText;
    [SerializeField] Button startBackButton;
    [SerializeField] Text mainMenuButtonText;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Image darkenPlane;
    [SerializeField] Image scoreBackground;
    [SerializeField] Image highScoreBackground;
    GameManager gameManagerScript;
    ScoreManager scoreManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        startScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore", 0).ToString();
        loseText.text = "";
        loseScore.text = "";
        loseHighScore.text = "";
        gameManagerScript = FindObjectOfType<GameManager>();
        scoreManagerScript = FindObjectOfType<ScoreManager>();
        startBackButton.interactable = true;
        mainMenuButton.interactable = false;
        //Makes the start menu button on top of other buttons so that it isn't covered up.
        startBackButton.transform.SetAsLastSibling();
    }

    private void Update()
    {
        if (gameManagerScript.playing == true)
        {
            UpdateScore();
        }
    }

    public void FirstPlay()
    {
        scoreText.text = "Score: 0";
        scoreText.GetComponent<FadeText>().StartFadeIn();
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore", 0).ToString();
        highScoreText.GetComponent<FadeText>().StartFadeIn();
        startText.GetComponent<FadeText>().StartFadeOut();
        startScoreText.GetComponent<FadeText>().StartFadeOut();
        startBackButtonText.GetComponent<FadeText>().StartFadeOut();
        startBackButton.interactable = false;
        scoreBackground.GetComponent<FadeText>().StartDarken();
        highScoreBackground.GetComponent<FadeText>().StartDarken();
        //Puts the button behind other buttons so it won't cover them up.
        startBackButton.transform.SetAsFirstSibling();
    }

    public void NewGame()
    {
        darkenPlane.GetComponent<FadeText>().StartLighten();
        loseText.GetComponent<FadeText>().StartFadeOut();
        loseScore.GetComponent<FadeText>().StartFadeOut();
        loseHighScore.GetComponent<FadeText>().StartFadeOut();
        scoreText.text = "Score: 0";
        scoreText.GetComponent<FadeText>().StartFadeIn();
        highScoreText.text = "Score: " + PlayerPrefs.GetInt("highScore", 0).ToString();
        highScoreText.GetComponent<FadeText>().StartFadeIn();
        mainMenuButtonText.GetComponent<FadeText>().StartFadeOut();
        mainMenuButton.interactable = false;
        scoreBackground.GetComponent<FadeText>().StartDarken();
        highScoreBackground.GetComponent<FadeText>().StartDarken();
    }

    public void LoseGame()
    {
        darkenPlane.GetComponent<FadeText>().StartDarken();
        scoreText.GetComponent<FadeText>().StartFadeOut();
        highScoreText.GetComponent<FadeText>().StartFadeOut();
        loseText.text = "Game Over! Tap to Restart";
        loseText.GetComponent<FadeText>().StartFadeIn();
        loseScore.text = "Score: " + scoreManagerScript.score.ToString();
        loseScore.GetComponent<FadeText>().StartFadeIn();
        loseHighScore.text = "High Score: " + PlayerPrefs.GetInt("highScore", 0).ToString();
        loseHighScore.GetComponent<FadeText>().StartFadeIn(); 
        mainMenuButtonText.GetComponent<FadeText>().StartFadeIn();
        mainMenuButton.interactable = true;
         scoreBackground.GetComponent<FadeText>().StartLighten();
        highScoreBackground.GetComponent<FadeText>().StartLighten();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + scoreManagerScript.score.ToString();
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore", 0).ToString();
        if(scoreManagerScript.score > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", scoreManagerScript.score);
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
