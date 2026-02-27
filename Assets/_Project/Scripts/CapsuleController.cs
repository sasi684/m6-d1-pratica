using UnityEngine;

public class CapsuleController : MonoBehaviour
{

    private float _h, _v;
    Vector3 _dir;

    private void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        _dir = new Vector3(_h, 0f, _v) * 5;
    }

    private void FixedUpdate()
    {
        transform.position = transform.position + _dir * Time.fixedDeltaTime;
    }

}
