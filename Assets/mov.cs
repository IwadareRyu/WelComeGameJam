using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Enemy = GameObject.FindGameObjectsWithTag("Enemy")[0];

    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy == null ) { return; }

        Vector3 pv = Enemy.transform.position;
        Vector3 ev = transform.position;
        GetComponent<Rigidbody2D>().velocity = (Enemy.transform.position - transform.position).normalized * 3;



        float p_vX = pv.x - ev.x;
        float p_vY = pv.y - ev.y;

        float vx = 0f;
        float vy = 0f;

        float sp = 3f;

        // 減算した結果がマイナスであればXは減算処理
        if (p_vX < 0)
        {
            vx = -sp;
        }
        else
        {
            vx = sp;
        }

        // 減算した結果がマイナスであればYは減算処理
        if (p_vY < 0)
        {
            vy = -sp;
        }
        else
        {
            vy = sp;
        }

       

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       

    }
}
