using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScripts : MonoBehaviour
{
    [SerializeField]item _item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            var player = collision.GetComponent<PlayerScripts>();
            if(_item == item.AttackNumUp)
            {
                player.AttackNumSansyo();
            }
            if(_item == item.SpeedUp)
            {
                player.SpeedUpSanssyo();
            }
            Destroy(gameObject);
        }
    }

    enum item
    {
        SpeedUp,
        AttackNumUp,
    }
}
