using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class InitialMenu : MonoBehaviour {

    bool playerOne;
    bool playerTwo;
    bool gameReady;
    public GameObject playerUno;
    public GameObject playerDue;
    public GameObject pressStart;
	
	
	void Update ()
    {
        if (gameReady == true && (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")))
        {
            SceneManager.LoadScene("Test");
        }
        if (Input.GetButtonDown("Fire1"))
        {
            playerOne = true;
            playerUno.SetActive(true);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            playerTwo = true;
            playerDue.SetActive(true);
        }

        if (playerOne == true && playerTwo == true)
        {
            gameReady = true;
            pressStart.SetActive(true);
        } 


    }
}
