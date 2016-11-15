using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour {
    //Updating the UI and handlers for button

    GameManager gm;
    public Text gameLeft;
    public Text player1goals;
    public Text player2goals;
    public Text gameOverText;
	
    public void ResetGame()
    {
        SceneManager.LoadScene("icehockey");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void EndGame(int player1score, int player2score)
    {
        gameOverText.text = "Game over!\nFinal score:\n" + player1score.ToString() + " - " + player2score.ToString();
    }

    // Use this for initialization
	void Start () {
        gm = GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update () {

        //Update time on screen
        int currentTime = (int)gm.gameLeft;
        int seconds = currentTime % 60;
        int minutes = currentTime / 60;
        //D2 ensures that numbers < 10 will look like 03, not 3
        gameLeft.text = "Game left: " + minutes.ToString() + ":" + seconds.ToString("D2");

        //Lowest time is 0:00
        if(seconds < 0 || minutes < 0)
        {
            gameLeft.text = "Game left: 0:00";
        }

        //Show goals
        player1goals.text = "Yellow:\n"+gm.player1goals.ToString();
        player2goals.text = "Blue:\n"+gm.player2goals.ToString();
	}
}
