using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float Speed = 20;

    private readonly float _speed = 135f / Screen.height; //0.075f
    private Vector2 _startPos;
    private Vector2 dir;
    private Vector3 pos;

    private Rigidbody componentRigidbody;

    private void Start()
    {
        componentRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        componentRigidbody.velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow)) componentRigidbody.velocity += Vector3.left * Speed;
        if (Input.GetKey(KeyCode.RightArrow)) componentRigidbody.velocity += Vector3.right * Speed;
        if (Input.GetKey(KeyCode.UpArrow)) componentRigidbody.velocity += Vector3.forward * Speed;
        if (Input.GetKey(KeyCode.DownArrow)) componentRigidbody.velocity += Vector3.back * Speed;


        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            var cs = Mathf.Sqrt(2) / 2;
            var sn = -Mathf.Sqrt(2) / 2;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    dir = touch.position - _startPos;
                    pos = new Vector3(dir.x * cs - dir.y * sn, 0, dir.x * sn + dir.y * cs);
                    componentRigidbody.AddForce(pos * _speed, ForceMode.Impulse);
                    break;

                case TouchPhase.Stationary:
                    componentRigidbody.AddForce(pos * _speed, ForceMode.Impulse);
                    break;
            }

        }
        else
        {
                transform.rotation = Quaternion.identity;
        }
    }
}