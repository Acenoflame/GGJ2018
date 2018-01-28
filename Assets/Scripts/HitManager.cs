using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour {

    public SelectAnotherCharacter sac1;
    public SelectAnotherCharacter sac2;

    // Use this for initialization
    void Start () {
        sac1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<SelectAnotherCharacter>();
        sac2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<SelectAnotherCharacter>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateLists()
    {
        sac1.UpdateRobotLists();
        sac2.UpdateRobotLists();
    }
}
