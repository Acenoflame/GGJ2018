using UnityEngine;
using System.Collections;

public class moveOnOtherSide : MonoBehaviour {

	public string side = "Left";
	public int speed = 3;
	private float movX;
	private float movY;

	public bool isMoving = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (isMoving) {
			if (side == "Left") {
				movX = 1F;
				movY = 0F;
			} else if (side == "Right") {
				movX = -1F;
				movY = 0F;
			}
			
			transform.Translate (new Vector3 (movX, movY) * Time.deltaTime * speed);
			GetComponent<Animator> ().SetBool ("isWalking", true);
		}
	
	}

	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.GetComponent<launchObject> ())
			isMoving = true;
	}
}
