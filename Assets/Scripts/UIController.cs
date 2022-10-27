using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    int player1Score = 0;
    int player2Score = 0;
    TextMeshProUGUI score;
    TextMeshProUGUI winText;
    public GameObject pnb; //player and ball game object
    public GameObject goMenu; //gameover menu game object

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player1Score == 10 || player2Score == 10){
            GameOver();
        }
    }

    public void updateScore(string side){
        if(side == "Left"){
            player2Score++;
            score.text = player1Score.ToString()+ " - " +player2Score.ToString();
           
        }else if (side == "Right"){
            player1Score++;
            score.text = player1Score.ToString()+ " - " +player2Score.ToString();
        }
    }

    public void GameOver(){
        pnb.SetActive(false);
        goMenu.SetActive(true);
        winText = GameObject.Find("GameOver/Header").GetComponent<TextMeshProUGUI>();
        if(player1Score == 10){
            winText.text = "PLAYER 1 WIN";
        }else if(player2Score == 10){
            winText.text = "PLAYER 2 WIN";
        }
        player1Score = 0;
        player2Score = 0;
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void PvP(){
        SceneManager.LoadScene("Game(PvP)");
    }

    public void PvE(){
        SceneManager.LoadScene("Game(PvE)");
    }

}
