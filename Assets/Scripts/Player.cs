
// Author's Name - Angadjot Singh , Garima Prashar , Harnam Kaur
// Student Number - 301060981,      301093329      , 301093907
// Date last Modified - 17th april 2020
// Program Descriptor - This file includes the logic of the ball.
// Revision History - 1.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{


// declaring the variables 

	public float moveSpeed = 8.0f;
	public float topBounds = 8.3f;
	public float bottomBounds = -8.3f;
	public Vector2 startingPosition = new Vector2 (-13.0f,0.0f);

	Game game;
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
			checkUserInput ();
		}
        
    }
     

//  checking the userInput     
    void checkUserInput (){

    	if (Input.GetKey (KeyCode.UpArrow)){

    		if (transform.localPosition.y >= topBounds){
    			transform.localPosition = new Vector3 (transform.localPosition.x, topBounds, transform.localPosition.z);
    		}else{
    			transform.localPosition += Vector3.up * moveSpeed * Time.deltaTime;
    		}


    	}else if (Input.GetKey (KeyCode.DownArrow)){

    		if (transform.localPosition.y <= bottomBounds){
    			transform.localPosition = new Vector3 (transform.localPosition.x, bottomBounds, transform.localPosition.z);
    		}else{
    			transform.localPosition += Vector3.down * moveSpeed * Time.deltaTime;
    		}

    	}
    }

}
