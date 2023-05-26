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
        // 「対象の座標 - 自分の座標」で目的方向を出す
        Vector3 pos = player.transform.position - transform.position;
        // 正規化したものに移動速度をかけてAddForce
        _rb.AddForce(pos.normalized * speed);
        // 制限速度を超えたら減速する
        if (_rb.velocity.magnitude > limit)
        {
            _rb.velocity = new Vector2(_rb.velocity.x / 1.1f, _rb.velocity.y / 1.1f);
        }
    }
}
