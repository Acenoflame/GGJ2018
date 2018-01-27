using UnityEngine;
using System.Collections;

public class moveOnOtherSide : MonoBehaviour {

	public string side = "Left";
	public int speed = 3;
	private float movX;
	private float movY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		if (side == "Left") {
			movX = 1F;
			movY = 0F;
		} else if (side == "Right") {
			movX = -1F;
			movY = 0F;
		}
			
		transform.Translate (new Vector3(movX,movY)*Time.deltaTime*speed);
	
	}
}
