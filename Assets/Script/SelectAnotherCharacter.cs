using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAnotherCharacter : MonoBehaviour {

    private List<GameObject> _listOfRobots;

    private string _typeOfPlayer;

    private int _position;

    // Use this for initialization
    void Start () {
        if (this.tag.Equals("Player1"))
        {
            Debug.Log("P1");
            _typeOfPlayer = "Player1";
            _listOfRobots = new List<GameObject>(GameObject.FindGameObjectsWithTag("NewRobot"));
        }
        else if (this.tag.Equals("Player2"))
        {
            Debug.Log("P2");
            _typeOfPlayer = "Player2";
            _listOfRobots = new List<GameObject>(GameObject.FindGameObjectsWithTag("OldRobot"));
        }

        for(int i=0;i< _listOfRobots.Count; i++)
        {
            Debug.Log(_listOfRobots[i]);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Transform GetPositionRandomSelectedRobot()
    {

        UpdateRobotLists();

        if (_listOfRobots.Count > 0)
        {
            int _position = Random.Range(0, _listOfRobots.Count-1);
            Debug.Log("_position: " + _position);
            Debug.Log("_listOfRobots Length: " + (_listOfRobots.Count-1));
            SetPosition(_position);
            Transform _randomTransform = _listOfRobots[_position].transform;
            return _randomTransform;
        }
        return null;
    }

    public void DeleteRobot(int position)
    {
        Debug.Log("Delete2");
        GameObject g = _listOfRobots[position];
        _listOfRobots.RemoveAt(position);
        Destroy(g);
    }

    public string GetNamePlayer()
    {
        return _typeOfPlayer;
    }

    public void UpdateRobotLists()
    {
        if (this.tag.Equals("Player1"))
        {
            Debug.Log("Update1");
            _typeOfPlayer = "Player1";
            _listOfRobots = new List<GameObject>(GameObject.FindGameObjectsWithTag("NewRobot"));
        }
        else if (this.tag.Equals("Player2"))
        {
            Debug.Log("Update2");
            _typeOfPlayer = "Player2";
            _listOfRobots = new List<GameObject>(GameObject.FindGameObjectsWithTag("OldRobot"));
        }
    }

    public int GetPosition()
    {
        return _position;
    }

    public void SetPosition(int pos)
    {
        _position = pos;
    }
}
