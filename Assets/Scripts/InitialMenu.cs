using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;

public class InitialMenu : MonoBehaviour
{

    bool playerOne;
    bool playerTwo;
    bool goToTutorial;
    public GameObject playerUno;
    public GameObject playerDue;
    public GameObject pressStart;
    public GameObject toFadeIn;
    public AudioClip menuSelection;
    public AudioClip Theme;
    AudioSource audioSource;
    public bool canBePlayed1;
    public bool canBePlayed2;
    public bool canBePlayed3;
    public bool canTutorial;
    public bool last;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(Theme);

    }


    void Update()
    {
            if (last == true && (Input.GetButtonDown("Fire1") || Input.GetButtonDown("P2Fire1"))|| Input.GetButtonDown("Restart"))
            {
            
                SceneManager.LoadScene("Test");
            }
            if (goToTutorial == true && Input.GetButtonDown("Restart"))
            {

            canTutorial = true;
            if (canBePlayed3 == true)
                {
                audioSource.PlayOneShot(menuSelection, 1);
                canBePlayed3 = false;
                }
                
                
                
            }
            if (Input.GetButtonDown("Fire1"))
            {
                if  (canBePlayed1 == true)
                {
                    audioSource.PlayOneShot(menuSelection, 1);
                }               
                canBePlayed1 = false;
                playerOne = true;
                playerUno.SetActive(true);
            }

            if (Input.GetButtonDown("P2Fire1"))
            {
                if (canBePlayed2 == true)
                {
                    audioSource.PlayOneShot(menuSelection, 1);
                }
                canBePlayed2 = false;
                playerTwo = true;
                playerDue.SetActive(true);
            }


            if (playerOne == true && playerTwo == true)
            {
                goToTutorial = true;
                pressStart.SetActive(true);

            }
            if (canTutorial == true)
            {
                toFadeIn.SetActive(true);
                last = true;
            }

            



            
    }
}

