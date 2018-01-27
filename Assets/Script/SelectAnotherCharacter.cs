using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAnotherCharacter : MonoBehaviour {

    private GameObject[] _listOfCharacters;

	// Use this for initialization
	void Start () {
        if(this.name.Equals("Player1"))
            _listOfCharacters = GameObject.FindGameObjectsWithTag("Robot1");
        else if(this.name.Equals("Player2"))
            _listOfCharacters = GameObject.FindGameObjectsWithTag("Robot2");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
