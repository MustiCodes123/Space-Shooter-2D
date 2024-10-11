using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class uiManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Image _LivesImage;
    [SerializeField]
    private Text gameOverText;
    [SerializeField]
    private Text restartMessage;
    private GameManager gameManager;

    void Start()
    {
        scoreText.text = "Score: " + 0;
        gameOverText.gameObject.SetActive(false);
        restartMessage.gameObject.SetActive(false);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    public void updateScore(int playerScore) { 
    
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public void UpdateLives(int currentLives) { 
    
        _LivesImage.sprite = _liveSprites[currentLives];
        if (currentLives < 1) {
            gameManager.GameOver();
            gameOverText.gameObject.SetActive(true);
            restartMessage.gameObject.SetActive(true);
            StartCoroutine(GameOverFLicker());
        }
    }

    IEnumerator GameOverFLicker()
    {
        while (true)
        {
            gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }


}
