using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAnotherCharacter : MonoBehaviour {

    private GameObject[] _listOfRobots;

    private string _typeOfPlayer;

	// Use this for initialization
	void Start () {
        if (this.tag.Equals("Player1"))
        {
            _typeOfPlayer = "Player1";
            _listOfRobots = GameObject.FindGameObjectsWithTag("NewRobot");
        }
        else if (this.tag.Equals("Player2"))
        {
            _typeOfPlayer = "Player2";
            _listOfRobots = GameObject.FindGameObjectsWithTag("OldRobot");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Transform GetPositionRandomSelectedRobot(int deleteRobot)
    {
        int _position = Random.Range(0, _listOfRobots.Length);
        Transform _randomTransform = _listOfRobots[_position].transform;
        if (deleteRobot == 1)
        {
            DeleteRobot(_position);
        }
        return _randomTransform;
    }

    private void DeleteRobot(int deleteRobot)
    {
        if (deleteRobot==1)
        {
            Destroy(_listOfRobots[deleteRobot].gameObject);
        }
    }

    public string GetNamePlayer()
    {
        return _typeOfPlayer;
    }

    public void UpdateRobotLists()
    {
        if (this.tag.Equals("Player1"))
        {
            _typeOfPlayer = "Player1";
            _listOfRobots = GameObject.FindGameObjectsWithTag("NewRobot");
        }
        else if (this.tag.Equals("Player2"))
        {
            _typeOfPlayer = "Player2";
            _listOfRobots = GameObject.FindGameObjectsWithTag("OldRobot");
        }
    }
}
