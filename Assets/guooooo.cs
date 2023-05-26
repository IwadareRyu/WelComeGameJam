using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guooooo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    private Rigidbody2D enemyRb;
    private GameObject player;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
    }
}
