using UnityEngine;

public class VelocityController : MonoBehaviour
{
    Rigidbody2D _rb;

    Vector3 _prevVelo;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(_rb.velocity.sqrMagnitude > 4.0f)
        {
            _rb.velocity = _prevVelo;
        }
        else
        {
            _prevVelo = _rb.velocity;
        }
    }
}
