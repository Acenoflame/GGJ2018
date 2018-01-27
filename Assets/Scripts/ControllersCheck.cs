using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllersCheck : MonoBehaviour
{
    private int _numberOfControllerConnected = 0;

    private GameObject[] _listOfPlayers;
    private int _numberOfPlayer = 0;

    private void Start()
    {
        _listOfPlayers = GameObject.FindGameObjectsWithTag("Player");
        
        string[] names = Input.GetJoystickNames();

        for (int x = 0; x < names.Length; x++)
        {
            //print(names[x].Length);
            //Debug.Log(names[x]);
            if (names[x].Length == 33)
            {
                print("XBOX ONE CONTROLLER IS CONNECTED");
                //set a controller bool to true
                _numberOfControllerConnected++;
            }
        }
        //ActivePlayers();

        /*foreach (GameObject g in _listOfPlayers)
        {
            g.SetActive(false);
        }*/
    }

    void Update()
    {
        string[] names = Input.GetJoystickNames();
        //Debug.Log("namesLenght: " + names.Length);
        //Debug.Log("_numberOfControllerConnected: " + _numberOfControllerConnected);
        if (_numberOfControllerConnected != names.Length)
        {
            _numberOfControllerConnected = 0;
            Debug.Log("Entreo");
            for (int x = 0; x < names.Length; x++)
            {
                //print(names[x].Length);
                //Debug.Log(names[x]);
                if (names[x].Length == 33)
                {
                    print("XBOX ONE CONTROLLER IS CONNECTED");
                    //set a controller bool to 
                    _numberOfControllerConnected++;
                }
            }
            ActivePlayers();
        }
    }

    private void ActivePlayers()
    {
        Debug.Log("Active");
        if (_numberOfControllerConnected > 1)
        {
            int _remainder = 4 - _numberOfControllerConnected;

            Debug.Log("_numberOfControllerConnected: " + _numberOfControllerConnected);
            Debug.Log("_remainder: " + _remainder);

            for (int i = 0; i < _numberOfControllerConnected; i++)
            {
                Debug.Log("_SETACTIVE");
                _listOfPlayers[i].SetActive(true);
            }

            for (int i = _numberOfControllerConnected; i < _remainder; i++)
            {
                Debug.Log("_NOTACTIVE");
                _listOfPlayers[i].SetActive(false);
            }
        }
        else
        {
            Debug.LogError("Please connect 2 joystick to play.");
        }
        
    }
}