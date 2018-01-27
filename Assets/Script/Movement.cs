using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public int speed = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		float movX = Input.GetAxis ("Horizontal");
		float movY = Input.GetAxis ("Vertical");

		transform.Translate (new Vector3(movX,movY)*Time.deltaTime*speed);



	}
}
