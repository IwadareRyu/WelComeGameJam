using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody2D enemyP;
    private GameObject player;

    void Start()
    {
        enemyP = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");

    }

    private void FixedUpdate()
    {
        enemyP.AddForce((player.transform.position - transform.position).normalized * speed);
    }
}