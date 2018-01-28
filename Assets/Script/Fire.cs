using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	public GameObject prefab;
	public int speed = 8;
	GameObject bullet;

	public int munitions = 5;

	public bool parabola;

	public Vector3 targetPos;

	public GameObject targetObject;

	public float arcHeight = 3;

	public float shootTime = 1F;

	private bool canShoot;

	private float currentTme = 0F;

	Vector3 startPos;

	public string buttonShoot;

	// Use this for initialization
	void Start () {

		bullet = null;
		startPos = transform.position;
		canShoot = true;
	
	}
	
	// Update is called once per frame
	void Update () {

		targetPos = targetObject.transform.position;


		if (Input.GetButtonDown (buttonShoot) && canShoot && munitions > 0) {

			bullet = (GameObject)Instantiate(prefab, new Vector3(this.transform.position.x,this.transform.position.y, 0), Quaternion.identity);
			startPos = bullet.transform.position;
			//targetPos = new Vector3 (transform.position.x+10F,transform.position.y,0);
			canShoot = false;
			currentTme = 0F;
			munitions--;
		}

		if (bullet != null && !parabola) {
			bullet.transform.Translate (new Vector2 (2F, 0F) * Time.deltaTime * speed);
		} else if (bullet != null && parabola) {
			//bullet.transform.Translate (new Vector3 (2F, height) * Time.deltaTime * speed);

			float x0 = startPos.x;
			float x1 = targetPos.x;
			float dist = x1 - x0;
			float nextX = Mathf.MoveTowards (bullet.transform.position.x, x1, speed * Time.deltaTime);
			float baseY = Mathf.Lerp (startPos.y, targetPos.y, (nextX - x0) / dist);
			float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
			Vector3 nextPos = new Vector3 (nextX, baseY + arc, bullet.transform.position.z);

			// Rotate to face the next position, and then move there
			bullet.transform.rotation = LookAt2D (nextPos - bullet.transform.position);
			bullet.transform.position = nextPos;

				
			if (bullet.transform.position.y == targetObject.transform.position.y) {
				Destroy (bullet);
				bullet = null;
				currentTme = 0F;
			}



		} 
		if (bullet == null && !canShoot)
			currentTme += Time.deltaTime;
		
		if (currentTme > shootTime && !canShoot) {
			canShoot = true;
		}
			

	}

	static Quaternion LookAt2D(Vector2 forward) {
		return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
	}


}
