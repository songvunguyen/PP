using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    int player1Score = 0;
    int player2Score = 0;
    TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(string side){
        if(side == "Left"){
            player1Score++;
            score.text = player1Score.ToString()+ " - " +player2Score.ToString();
           
        }else if (side == "Right"){
            player2Score++;
            score.text = player1Score.ToString()+ " - " +player2Score.ToString();
        }
    } 

}
