using UnityEngine;
using System.Collections;

public class MovementPlayer : MonoBehaviour {

	public int _speed = 3;

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

            _player.Translate(new Vector3(movXLeftStick, movYLeftStick) * Time.deltaTime * _speed);
            _target.Translate(new Vector3(movXRightStick, movYRightStick) * Time.deltaTime * _speed);
        }

	}

    public void CanMove()
    {
        _canMove = !_canMove;
    }
}
