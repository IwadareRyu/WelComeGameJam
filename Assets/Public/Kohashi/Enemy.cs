using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D _rb;
    public GameObject player;
    public float speed;
    public float limit;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �u�Ώۂ̍��W - �����̍��W�v�ŖړI�������o��
        Vector3 pos = player.transform.position - transform.position;
        // ���K���������̂Ɉړ����x��������AddForce
        _rb.AddForce(pos.normalized * speed);
        // �������x�𒴂����猸������
        if (_rb.velocity.magnitude > limit)
        {
            _rb.velocity = new Vector2(_rb.velocity.x / 1.1f, _rb.velocity.y / 1.1f);
        }
    }
}
