using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerScripts : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] GameObject[] _attackObj;
    [SerializeField] float _attackCoolTime = 3f;
    [SerializeField] float _speed = 3f;
    bool _attackCoolTimebool;
    bool _butAttackTimebool;
    bool _starTime;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        foreach (var i in _attackObj)
        {
            i.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        var ub = Vector3.up * v;
        var rl = Vector3.right * h;
        _rb.velocity = ub * _speed + rl * _speed;
        Vector3 transy = this.transform.localScale;
        if(h != 0)transy.x = h;
        transform.localScale = transy;
        if(!_attackCoolTimebool && !_butAttackTimebool)
        {
            _attackCoolTimebool = true;
            StartCoroutine(AttackTime());
        }
    }

    IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(_attackCoolTime);
        if (!_butAttackTimebool)
        {
            _attackObj[0].SetActive(true);
            yield return new WaitForSeconds(0.3f);
            _attackObj[0].SetActive(false);
            _attackObj[1].SetActive(true);
            yield return new WaitForSeconds(0.3f);
            _attackObj[1].SetActive(false);
        }
        _attackCoolTimebool = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && !_starTime)
        {
            _butAttackTimebool = true;
            _starTime = true;
            StartCoroutine(StarTime());
            Debug.Log("攻撃できないぞい");
        }
    }

    IEnumerator StarTime()
    {
        yield return new WaitForSeconds(5f);
        _butAttackTimebool = false;
        Debug.Log("攻撃できるぞい");
        yield return new WaitForSeconds(3f);
        _starTime = false;
        Debug.Log("当たると痛いよ？");
    }
}
