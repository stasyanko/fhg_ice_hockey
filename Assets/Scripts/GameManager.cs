using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    //A super script responsible for handling the status of the game

    public int player1goals;
    public int player2goals;
    public double gameLeft;

    public GameObject puck;

    public AudioSource goalAudio;

    public bool gameOver;

    public UIHandler uiHandler;

    public void addGoal(int team)
    {
        if (gameOver)
            return;

        //Team variable contains the team which owns the goal where the puck went
        //For this reason, we increase the opposing teams score
        //A bit counter-intuitive, I'll admit that
        switch (team)
        {
            case 1:
                player2goals++;
                break;
            case 2:
                player1goals++;
                break;
        }

        //Celebrate the goal
        goalAudio.Play();
        puck.transform.position = new Vector3(5.05f, 0, -10.67f);
        puck.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

	// Use this for initialization
	void Start () {
        player1goals = 0;
        player2goals = 0;
        gameLeft = 180;
        puck = GameObject.FindGameObjectWithTag("puck");

        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        gameLeft -= Time.deltaTime;

        //when game ends, show the text
        if(!gameOver && gameLeft <= 0)
        {
            gameOver = true;
            uiHandler.EndGame(player1goals, player2goals);
        }
	}
}
