using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	public GameObject prefab;
	public int speed = 5;
	GameObject bullet;

	public bool parabola;
	public float height;
	public bool up;

	[Tooltip("Position we want to hit")]
	public Vector3 targetPos;


	[Tooltip("How high the arc should be, in units")]
	public float arcHeight = 1;


	Vector3 startPos;

	// Use this for initialization
	void Start () {

		bullet = null;
		startPos = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {




		if (Input.GetButtonDown ("Fire1")) {

			bullet = (GameObject)Instantiate(prefab, new Vector3(this.transform.position.x,this.transform.position.y, 0), Quaternion.identity);
			startPos = bullet.transform.position;
			targetPos = new Vector3 (transform.position.x+10F,transform.position.y,0);
		}

		if (bullet != null && !parabola) {
			bullet.transform.Translate (new Vector2 (2F, 0F) * Time.deltaTime * speed);
		} else if(bullet != null && parabola) {
			//bullet.transform.Translate (new Vector3 (2F, height) * Time.deltaTime * speed);

			float x0 = startPos.x;
			float x1 = targetPos.x;
			float dist = x1 - x0;
			float nextX = Mathf.MoveTowards(bullet.transform.position.x, x1, speed * Time.deltaTime);
			float baseY = Mathf.Lerp(startPos.y, targetPos.y, (nextX - x0) / dist);
			float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
			Vector3 nextPos = new Vector3(nextX, baseY + arc, bullet.transform.position.z);

			// Rotate to face the next position, and then move there
			bullet.transform.rotation = LookAt2D(nextPos - bullet.transform.position);
			bullet.transform.position = nextPos;
				

		}

	}

	static Quaternion LookAt2D(Vector2 forward) {
		return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
	}


}
