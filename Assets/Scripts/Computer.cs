
// Author's Name - Angadjot Singh , Garima Prashar , Harnam Kaur
// Student Number - 301060981,      301093329      , 301093907
// Date last Modified - 17th april 2020
// Program Descriptor - This file includes the logic of the ball.
// Revision History - 1.0



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{

	// declaring the variables 
    public float moveSpeed = 8.0f;
	public float topBounds = 8.3f;
	public float bottomBounds = -8.3f;
	public Vector2 startingPosition = new Vector2 (13.0f,0.0f);

	private GameObject ball;
	private Vector2 ballPos;	

	private Game game;

    // Start is called before the first frame update
    void Start()
    {
		game = GameObject.Find ("Game").GetComponent<Game> ();
    	transform.localPosition = (Vector3)startingPosition;    
    }

    // Update is called once per frame
    void Update()
    {
		if (game.gameState == Game.GameState.Playing){
			Move ();
		}
    }
     

// function for the ball for the computer player  
	void Move (){
   
		if (!ball)
		   ball = GameObject.FindGameObjectWithTag ("ball");

		if (ball.GetComponent<Ball> ().ballDirection == Vector2.right) {
			ballPos = ball.transform.localPosition;

			if (transform.localPosition.y > bottomBounds && ballPos.y < transform.localPosition.y){
				transform.localPosition += new Vector3 (0, -moveSpeed * Time.deltaTime, 0);
			}

			if (transform.localPosition.y < topBounds && ballPos.y > transform.localPosition.y){
				transform.localPosition += new Vector3 (0, moveSpeed * Time.deltaTime, 0);
			}

		} 	

	} 

}
