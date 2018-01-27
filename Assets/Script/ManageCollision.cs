using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageCollision : MonoBehaviour {

    private MovementPlayer mp;
    private SelectAnotherCharacter sac;
    public GameObject _newRobot;
    public GameObject _oldRobot;

    // Use this for initialization
    void Start () {
        mp = this.GetComponent<MovementPlayer>();
        sac = this.GetComponent<SelectAnotherCharacter>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Attack1")
        {
            mp.CanMove();  //Set movement to false

            Transform _tmpPosition = sac.GetPositionRandomSelectedRobot(1); //Destroy robot too

            string _namePlayer = sac.GetNamePlayer();
            if (_namePlayer.Equals("Player1"))
            {
                Instantiate(_newRobot, this.transform.position, this.transform.rotation);
            }
            else if (_namePlayer.Equals("Player2"))
            {
                Instantiate(_oldRobot, this.transform.position, this.transform.rotation);
            }

            this.transform.position = _tmpPosition.position;

            sac.UpdateRobotLists();

            mp.CanMove();   //Set movement to true
        }

    }
}
