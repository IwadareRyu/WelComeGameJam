using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    GameObject Player;
    GameObject _Enemy;
    public float Speed;

 
    void Start()
    {
        Rigidbody2D _rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        _Enemy = GameObject.Find("Homing");
    }

  
    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(Player.transform.position.x, Player.transform.position.y), Speed * Time.deltaTime);
    }
}