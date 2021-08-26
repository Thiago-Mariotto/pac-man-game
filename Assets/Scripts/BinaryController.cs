using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Runtime.InteropServices;

public class BinaryController : MonoBehaviour
{
    public Text[] trybeBirth;
    public Text textDecryptButton;
    public GameObject title; 
    public GameObject canvas;
    private GameObject dots;
    public GameManager GM;
    public VideoPlayer videoPlayer;
    private bool gameIsEnd = false;
    public GameObject Ghosts;
    public GameObject letters; 
    public Button decryptButton;
    public Button menuButton;
    public Button skipButton;
    
    private int cryptedRows = 1;

    private string[] binaryText = new string[] {
      "01010100",
      "01110010",
      "01111001",
      "01100010", 
      "01100101", 
      "00100000",
      "00110010", 
      "00100000", 
      "01100001", 
      "01101110", 
      "01101111", 
      "01110011"  
    };

    private string[] correctString = new string[] {
      "T",
      "R",
      "Y",
      "B",
      "E",
      " ",
      "2",
      " ",
      "A",
      "N",
      "O",
      "S"
    };

    [DllImport("__Internal")]
    private static extern void PlayVideo();
    
    void Start()
    {
        InvokeRepeating("ChangeTexts", 1f, 0.07f);
    }

    void Update(){
        if (GameManager.score >= 2 && !gameIsEnd){
            canvas.SetActive(true);
            title.SetActive(true);
        }

        ScoreController();

        dots = GameObject.FindWithTag("pacdot");
        if(GameManager.score > 3350){
            textDecryptButton.text = "CONVERT";
        }
    }

    string MatrixNumbers () {
        string myText = "";
        for(int i = 0; i < 8; i++) {
            int number = Random.Range(0 , 10);
            if(number <= 5){
                number = 0;
            } else {
                number = 1;
            }

            number.ToString();
            myText += number;

        }

        return myText;
    }

    void ChangeTexts () {
          for (int i = cryptedRows; i <= trybeBirth.Length ; i++) {
              trybeBirth[i - 1].text = MatrixNumbers();
          }
        
    }

    void ScoreController (){
        if (GameManager.score > 280 && GameManager.score <= 281){
            trybeBirth[cryptedRows].gameObject.SetActive(true); 
            decryptButton.gameObject.SetActive(true);
        }

        if (GameManager.score >= cryptedRows * 280 && cryptedRows <= trybeBirth.Length) {
            decryptButton.gameObject.SetActive(true);
        
            trybeBirth[cryptedRows - 1].text = binaryText[cryptedRows - 1];
            trybeBirth[cryptedRows - 1].color = new Color(124f/255f , 255f/255f, 202f/255f);

            if(cryptedRows == 12){
                trybeBirth[cryptedRows - 1].gameObject.SetActive(true);

            } else if (cryptedRows < 12) {
                trybeBirth[cryptedRows].gameObject.SetActive(true);

            } else {
                return ; 

            }
            cryptedRows += 1;

        }
    }

    public void ConvertBinary () { 
        if (cryptedRows >= trybeBirth.Length && GameManager.score > 3350) {
            gameIsEnd = true;
            StartCoroutine (translateBinary()); 
            PlayVideo();
        }
    }

    IEnumerator translateBinary () {
        title.SetActive(false);
        decryptButton.gameObject.SetActive(false);  
        Ghosts.SetActive(false);

        for (int i = 0; i < 12; i++) {
            trybeBirth[i].gameObject.SetActive(true);
            trybeBirth[i].color = new Color(124f/255f , 255f/255f, 202f/255f);
            trybeBirth[i].text = correctString[i];
            yield return new WaitForSeconds(0.4f);
        }
        yield return new WaitForSeconds(1f);
        letters.SetActive(false);
        PlayerPrefs.SetInt ("player_status", 1);
        PlayerPrefs.SetInt ("player_score", GameManager.score);
        Application.LoadLevel("over");
       
    }

  
}
