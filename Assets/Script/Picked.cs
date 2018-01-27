using UnityEngine;
using System.Collections;

public class Picked : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {


		if (coll.gameObject.GetComponent<Movement> ()) {
			coll.gameObject.GetComponent<Fire> ().munitions++;
			Destroy (this.gameObject);
		}
	}
}
