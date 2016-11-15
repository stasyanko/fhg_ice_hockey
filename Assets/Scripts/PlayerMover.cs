using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {

    //script for moving players around
    //this is something that could be tidied up a lot

    public float speed = 10.0f;
    public float rotationSpeed = 900.0f;

    //this is badly named variable, and it should be player1firstSet
    //current name causes code to be a bit harder to understand
    public bool player1secondSet;
    public bool player2secondSet;

    public GameObject player1_1;
    public GameObject player1_2;
    public GameObject player1_3;
    public GameObject player1_4;

    public GameObject player2_1;
    public GameObject player2_2;
    public GameObject player2_3;
    public GameObject player2_4;

	// Use this for initialization
	void Start () {
        player1secondSet = false;
        player2secondSet = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        //Handle changing of hockeyplayers
        if (Input.GetButtonDown("PL1_Change_Set"))
        {
            //Negate the boolean variable
            player1secondSet = !player1secondSet;
            if (!player1secondSet)
            {
                player1_1.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = true;
                player1_2.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = true;
                player1_3.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = false;
                player1_4.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                player1_1.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = false;
                player1_2.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = false;
                player1_3.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = true;
                player1_4.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = true;
            }
        }

        if (Input.GetButtonDown("PL2_Change_Set"))
        {
            player2secondSet = !player2secondSet;
            if (!player2secondSet)
            {
                player2_1.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = true;
                player2_2.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = true;
                player2_3.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = false;
                player2_4.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                player2_1.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = false;
                player2_2.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = false;
                player2_3.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = true;
                player2_4.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = true;
            }
        }

        //Handle movement for both players and both sticks
        var move = new Vector3(Input.GetAxis("PL1_Vertical"), 0, Input.GetAxis("PL1_Horizontal"))*speed;
        if (!player1secondSet)
        {
            player1_1.GetComponent<Rigidbody>().AddForce(move);
        }
        else
        {
            player1_3.GetComponent<Rigidbody>().AddForce(move);

        }

        move = new Vector3(Input.GetAxis("PL1_Vertical_Right"), 0, Input.GetAxis("PL1_Horizontal_Right")) * speed;
        if (!player1secondSet)
        {
            player1_2.GetComponent<Rigidbody>().AddForce(move);
        }
        else
        {
            player1_4.GetComponent<Rigidbody>().AddForce(move);

        }


        move = new Vector3(Input.GetAxis("PL2_Vertical"), 0, Input.GetAxis("PL2_Horizontal")) * speed;
        if (!player2secondSet)
        {
            player2_1.GetComponent<Rigidbody>().AddForce(move);
        }
        else
        {
            player2_3.GetComponent<Rigidbody>().AddForce(move);

        }

        move = new Vector3(Input.GetAxis("PL2_Vertical_Right"), 0, Input.GetAxis("PL2_Horizontal_Right")) * speed;
        if (!player2secondSet)
        {
            player2_2.GetComponent<Rigidbody>().AddForce(move);
        }
        else
        {
            player2_4.GetComponent<Rigidbody>().AddForce(move);

        }

        //Handle spinning for both players
        if (Input.GetButton("PL1_Clockwise"))
        {
            if (!player1secondSet)
            {
                player1_1.GetComponent<Rigidbody>().AddTorque(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
                player1_2.GetComponent<Rigidbody>().AddTorque(new Vector3(0, rotationSpeed * Time.deltaTime, 0));

            }
            else
            {
                player1_3.GetComponent<Rigidbody>().AddTorque(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
                player1_4.GetComponent<Rigidbody>().AddTorque(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
            }
        }
        if (Input.GetButton("PL1_Counterclockwise"))
        {
            if (!player1secondSet)
            {
                player1_1.GetComponent<Rigidbody>().AddTorque(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
                player1_2.GetComponent<Rigidbody>().AddTorque(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));

            }
            else
            {
                player1_3.GetComponent<Rigidbody>().AddTorque(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
                player1_4.GetComponent<Rigidbody>().AddTorque(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
            }
        }

        if (Input.GetButton("PL2_Clockwise"))
        {
            if (!player2secondSet)
            {
                player2_1.GetComponent<Rigidbody>().AddTorque(new Vector3(0, rotationSpeed*Time.deltaTime, 0));
                player2_2.GetComponent<Rigidbody>().AddTorque(new Vector3(0, rotationSpeed * Time.deltaTime, 0));

            }
            else
            {
                player2_3.GetComponent<Rigidbody>().AddTorque(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
                player2_4.GetComponent<Rigidbody>().AddTorque(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
            }
        }
        if (Input.GetButton("PL2_Counterclockwise"))
        {
            if (!player2secondSet)
            {
                player2_1.GetComponent<Rigidbody>().AddTorque(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
                player2_2.GetComponent<Rigidbody>().AddTorque(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));

            }
            else
            {
                player2_3.GetComponent<Rigidbody>().AddTorque(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
                player2_4.GetComponent<Rigidbody>().AddTorque(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
            }
        }
    }
}
