using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageCollision : MonoBehaviour {

    private MovementPlayer mp;
    private SelectAnotherCharacter sac;
    private HitManager hm;

    public GameObject _newRobot;
    public GameObject _oldRobot;

    // Use this for initialization
    void Start () {
        mp = this.GetComponent<MovementPlayer>();
        sac = this.GetComponent<SelectAnotherCharacter>();
        hm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<HitManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Attack2") || coll.gameObject.tag.Equals("Attack1"))
        {
            mp.CanMove();  //Set movement to false

            Transform _tmpPosition = sac.GetPositionRandomSelectedRobot(); //Destroy robot too

            if (_tmpPosition != null)
            {
                string _namePlayer = sac.GetNamePlayer();
                if (_namePlayer.Equals("Player1"))
                {
                    GameObject go = Instantiate(_oldRobot, this.transform.position, this.transform.rotation);
                }
                else if (_namePlayer.Equals("Player2"))
                {
                    GameObject go = Instantiate(_newRobot, this.transform.position, this.transform.rotation);
                }

                this.transform.position = _tmpPosition.position;

                sac.DeleteRobot(sac.GetPosition());

                hm.UpdateLists(); //Update list of players

                mp.CanMove();   //Set movement to true

                sac.SetPosition(0);
            }
            else
            {
                Debug.LogError("Null returned. List empty");
            }


        }

    }
}
