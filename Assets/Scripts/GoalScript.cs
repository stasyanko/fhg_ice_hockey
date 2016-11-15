using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

    //script for goal object.

    public int team;
    public GameManager gm;

    void OnTriggerEnter(Collider other)
    {
        //when puck goes in, add a goal
        Debug.Log("Goal");
        if (other.gameObject.tag.Equals("puck"))
        {
            gm.addGoal(team);
        }

    }

    // Use this for initialization
    void Start () {
        gm = GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>();
	}
}
