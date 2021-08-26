using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private float score;
    private GameObject GM;
    private int status;
    public Text scoreText;
    public Text stateGame;
    public Image imageChange;
    public Sprite[] images;
    
    void Start()
    {
        score = PlayerPrefs.GetInt ("player_score");
        status = PlayerPrefs.GetInt ("player_status");
        scoreText.text = ""+score;
        GM = GameObject.Find("Game Manager");
        Destroy(GM);

        if(status == 1) {
          imageChange.sprite = images[1];
          stateGame.text = "YOU\nWIN";
        }
        else if (status == 0) {
          imageChange.sprite = images[0];
          stateGame.text = "GAME\nOVER";
        }
    }

    public void GoMenu() {
      Application.LoadLevel("menu");
    }
}
