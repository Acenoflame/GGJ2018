using UnityEngine;
using System.Collections;

public class MovementPlayer : MonoBehaviour {

	public int _speed = 3;

	public int _speed2 = 5;

    public Transform _player;
    public Transform _target;

    public string strXLeftStick;
    public string strYLeftStick;
    public string strXRightStick;
    public string strYRightStick;

    float movXLeftStick;
    float movYLeftStick;
    float movXRightStick;
    float movYRightStick;

    private bool _canMove = true;

	private float prevX;
	private float prevY;

    // Use this for initialization
    void Start () {
        movXLeftStick = Input.GetAxis(strXLeftStick);
        movYLeftStick = Input.GetAxis(strYLeftStick);
        movXRightStick = Input.GetAxis(strXRightStick);
        movYRightStick = Input.GetAxis(strYRightStick);
    }
	
	// Update is called once per frame
	void Update () {
        
        if (_canMove)
        {
            movXLeftStick = Input.GetAxis(strXLeftStick);
            movYLeftStick = Input.GetAxis(strYLeftStick);
            movXRightStick = Input.GetAxis(strXRightStick);
            movYRightStick = Input.GetAxis(strYRightStick);

            if (movXLeftStick < 0)
                _player.localScale.Scale(new Vector3(-0.4F, _player.localScale.y, _player.localScale.z));


            _player.Translate(new Vector3(movXLeftStick, movYLeftStick) * Time.deltaTime * _speed);

            _target.Translate(new Vector3(movXRightStick, movYRightStick) * Time.deltaTime * _speed2);

            if (prevX != movXLeftStick || prevY != movYLeftStick)
                GetComponent<Animator>().SetBool("isWalking", true);
            else
                GetComponent<Animator>().SetBool("isWalking", false);

            prevX = movXLeftStick;
            prevY = movYLeftStick;

            GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 10f) * -1;
        }
	}

    public void CanMove()
    {
        _canMove = !_canMove;
    }
}
