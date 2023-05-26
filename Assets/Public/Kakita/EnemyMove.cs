using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float speed;
    private GameObject playerObject;
    private Rigidbody2D enemyRb;
    private Vector3 PlayerPosition;
    private Vector3 EnemyPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        enemyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce((playerObject.transform.position - transform.position).normalized * speed);
    }
}
