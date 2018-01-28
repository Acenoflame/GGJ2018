using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitManager : MonoBehaviour {

    public SelectAnotherCharacter sac1;
    public SelectAnotherCharacter sac2;

    private int _pointsP1 = 3;
    private int _pointsP2 = 3;
    public GameObject hack1;
    public GameObject hack2;
    public GameObject hack3;
    public GameObject gear1;
    public GameObject gear2;
    public GameObject gear3;
    public Text Timer;

    private float timerValue = 60;

    // Use this for initialization
    void Start () {
        sac1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<SelectAnotherCharacter>();
        sac2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<SelectAnotherCharacter>();
	}

    // Update is called once per frame
    void Update()
    {
        BeginCountdown();
        if (timerValue > 0)
            Timer.text = "Timer " + (int)timerValue;
        else
            Timer.text = "Time Expired";
        if (_pointsP1 == 2)
            hack1.SetActive(false);
        if (_pointsP1 == 1)
            hack2.SetActive(false);
        if (_pointsP2 == 2)
            gear1.SetActive(false);
        if (_pointsP2 == 1)
            gear2.SetActive(false);
        if (_pointsP2 == 0)
            gear3.SetActive(false);
        if (_pointsP1 == 0)
            hack3.SetActive(false);
    }

    void BeginCountdown()
    {
        timerValue -= Time.deltaTime;
        if (timerValue <= 0)
        {
            //Do something
            Debug.Log("Fine tempo");
            CheckLowestVictoryCondition();
        }
    }

    public void UpdateLists()
    {
        sac1.UpdateRobotLists();
        sac2.UpdateRobotLists();
    }

    public void DecreasePoints(int playerSelection) {
        if (playerSelection == 1)
        {
            _pointsP1--;
            Debug.Log("_pointsP1: " + _pointsP1);
        }
        else if(playerSelection == 2)
        {
            _pointsP2--;
            Debug.Log("_pointsP2: " + _pointsP2);
        }
    }

    public void CheckVictoryCondition()
    {
        if(_pointsP1<=0)
        {
            Debug.Log("Player 1 WINS");
        }
        else if (_pointsP2 <= 0)
        {
            Debug.Log("Player 2 WINS");
        }
    }

    public void CheckLowestVictoryCondition()
    {
        if (_pointsP1 < _pointsP2)
        {
            Debug.Log("Player 2 WINS");
        }
        else if (_pointsP2 < _pointsP1)
        {
            Debug.Log("Player 1 WINS");
        }
        else if(_pointsP1 == _pointsP2)
        {
            Debug.Log("Fine gioco. Pareggio");
            //Far uscire la UI
            //Reset game
        }
    }
}
