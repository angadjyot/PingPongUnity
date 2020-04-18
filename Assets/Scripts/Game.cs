
// Author's Name - Angadjot Singh , Garima Prashar , Harnam Kaur
// Student Number - 301060981,      301093329      , 301093907
// Date last Modified - 17th april 2020
// Program Descriptor - This file includes the logic of the ball.
// Revision History - 1.0


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{ 

// declaring the variables 
    private GameObject ball;
    private int computerScore;
    private int playerScore;

    private GameObject hudCanvas;
    private Hud hud;

    private GameObject paddleComputer;

    public int winningScore = 2;


// enum for the game state 
    public enum GameState{
        Playing,GameOver,Paused,Launched
    }

    public GameState gameState = GameState.Launched;

    // Start is called before the first frame update
    void Start()
    {
    
        paddleComputer = GameObject.Find ("computer_paddle");

        hudCanvas = GameObject.Find ("HUD_Canvas");
        hud = hudCanvas.GetComponent<Hud> ();

        hud.playAgain.text = "PRESS SPACEBAR TO PLAY";
    }

    // Update is called once per frame
    void Update()
    {
        CheckScore ();
        CheckInput ();
    }


// function for checking the state of the function 
    void CheckInput (){

        if (gameState == GameState.Paused || gameState == GameState.Playing){
             if (Input.GetKeyUp (KeyCode.Space)){
                pauseResumeGame (); 
            }
        }

        if (gameState == GameState.Launched || gameState == GameState.GameOver){
            if (Input.GetKeyUp (KeyCode.Space)){
                StartGame ();
            }
        }
    }


// function for checking the score 
    void CheckScore (){

        if (playerScore >= winningScore || computerScore >= winningScore){ 

            if (playerScore >= winningScore && computerScore < playerScore - 1){
                // player's wins
                PlayerWins ();
            } else if (computerScore >= winningScore && playerScore < computerScore - 1) {
                // computer's wins
                 ComputerWins ();   
            }
        }

    }

// function for spawning the ball  
    void spawanBall (){
        ball = GameObject.Instantiate ((GameObject)Resources.Load ("Prefabs/ball", typeof(GameObject)));
        ball.transform.localPosition = new Vector3 (12,0,-2);
    }

// function if the player wins
    private void PlayerWins (){ 
        hud.winPlayer.enabled = true;
        GameOver (); 
    }    

// function if the computer wins
    private void ComputerWins (){
        hud.winComputer.enabled = true;
        GameOver ();
    } 

// function for the computer point
    public void ComputerPoint (){
         computerScore ++;
         hud.computerScore.text = computerScore.ToString ();
         NextRound ();
    }

// function for the player point
    public void PlayerPoint (){
        playerScore ++;
        hud.playerScore.text = playerScore.ToString ();
        NextRound ();
    }


//  function for starting the initial values
    private void StartGame() {
        playerScore = 0;
        computerScore = 0;

        
        hud.playerScore.text = "0";
        hud.computerScore.text = "0";
        hud.winComputer.enabled = false;
        hud.winPlayer.enabled = false;


        hud.playAgain.enabled = false;

        gameState = GameState.Playing;

        paddleComputer.transform.localPosition = new Vector3 (paddleComputer.transform.localPosition.x, 0, paddleComputer.transform.localPosition.z);

        spawanBall ();

    }

// checking the state for the game 
    private void NextRound (){

    if (gameState == GameState.Playing){
        paddleComputer.transform.localPosition = new Vector3 (paddleComputer.transform.localPosition.x, 0, paddleComputer.transform.localPosition.z);

        GameObject.Destroy (ball.gameObject);
        spawanBall ();
        }
    }


// game over function 
    private void GameOver (){
        GameObject.Destroy (ball.gameObject);
        hud.playAgain.text = "PRESS SPACEBAR TO PLAY AGAIN";
        hud.playAgain.enabled = true;
        gameState = GameState.GameOver;
    }


// function for checking the state of the game 
    private void pauseResumeGame (){
        if (gameState == GameState.Paused) { 

            gameState = GameState.Playing;
            hud.playAgain.text = "GAME IS PAUSED PRESS SPACE TO CONTINUE PLAYING";
            hud.playAgain.enabled = false;

        }else {

             gameState = GameState.Paused; 
             hud.playAgain.text = "GAME IS PAUSED PRESS SPACE TO CONTINUE PLAYING";  
             hud.playAgain.enabled = true;
        }
    }

}
