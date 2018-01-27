using UnityEngine;
using System.Collections;

public class randomMovement : MonoBehaviour {

	private float movX = 0F;
	private float movY = 0F;

	public int speed = 3;
	private bool canMove;

	private float currentTime = 0F;
	public float waitTime = 1F;
	public float changeTime = 2F;
	int direction;

	// Use this for initialization
	void Start () {
	
		direction = Random.Range (0, 4);

		waitTime = waitTime - Random.Range (0.1F, 0.7F);

		changeTime = changeTime - Random.Range (0.1F, 0.5F);
	}
	
	// Update is called once per frame
	void Update () {

		if (currentTime > changeTime) {
			direction = Random.Range (0, 4);
			currentTime = 0F;

		} else {
			currentTime += Time.deltaTime;
		}

			if (direction == 0) {
				movX = 1F;
				movY = 0.0F;
			} else if (direction == 1) {
				movX = 0.0F;
				movY = 1F;
			} else if (direction == 2) {
				movX = -1F;
				movY = 0.0F;
			} else if (direction == 3) {
				movX = 0.0F;
				movY = -1F;
			}

		if (currentTime > waitTime) {
			transform.Translate (new Vector3 (movX, movY) * Time.deltaTime * speed);
			GetComponent<Animator> ().SetBool ("isWalking", true);

			if (movX > 0 || movY > 0)
			{
				
				this.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f); //(c# code)
			}
			else if (movX < 0 || movY < 0)
			{
				
				this.transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f); //(c# code)
			}
			else
			{
				GetComponent<Animator>().SetBool("isWalking", false);
			}
		}
		else 
			GetComponent<Animator> ().SetBool ("isWalking", false);

	
		GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 10f) * -1;
			

	}
}
