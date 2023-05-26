using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScripts : MonoBehaviour
{
    [SerializeField]Transform _playerTrans;
    [SerializeField] Vector2 _size = new Vector2(3,1);
    bool _oneattack;

    private void OnEnable()
    {
        _oneattack = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cir = new Vector2(2, 1);
        DrawBox(transform.position, _size);
        Collider2D[] col;

        col = Physics2D.OverlapBoxAll(transform.position,_size,0f);
        if(col.Length != 0 && !_oneattack)
        {
            foreach(var i in col)
            {
                if(i.gameObject.tag == "Enemy")
                {
                    //Ç±Ç±Ç…ìGÇì|ÇµÇΩéûÇÃèàóùÇèëÇ≠ÅB
                    var enemyactor = i.GetComponent<EnemyActor>();
                    enemyactor.Damage();
                    Debug.Log("ìñÇΩÇ¡ÇΩÇÊÅI");
                }
            }
            _oneattack = true;
        }
    }

    void DrawBox(Vector2 point, Vector2 size)
    {
        Vector2 rightup = new Vector2(point.x + size.x / 2, point.y + size.y / 2);
        Vector2 leftup = new Vector2(point.x - size.x / 2, point.y + size.y / 2);
        Vector2 leftdown = new Vector2(point.x - size.x / 2, point.y - size.y / 2);
        Vector2 rightdown = new Vector2(point.x + size.x / 2, point.y - size.y / 2);

        Debug.DrawLine(rightup, leftup);
        Debug.DrawLine(leftup, leftdown);
        Debug.DrawLine(leftdown, rightdown);
        Debug.DrawLine(rightdown, rightup);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //}
}
