using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerScripts : MonoBehaviour
{
    Rigidbody2D _rb;
    Animator _ani;
    AudioSource _audio;
    SpriteRenderer _sprite;
    [SerializeField] Color _butAttackColor;
    [SerializeField] Color _starTimeColor;
    [SerializeField] GameObject[] _attackObj;
    [SerializeField] float _attackCoolTime = 0.5f;
    [SerializeField] float _speed = 3f;
    [SerializeField] GameObject boots;
    [SerializeField] GameObject shord;
    bool _attackCoolTimebool;
    bool _butAttackTimebool;
    bool _starTime;
    bool _attacknum;
    bool _speedUp;
    

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _ani = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        _sprite = GetComponent<SpriteRenderer>();

        foreach (var i in _attackObj)
        {
            i.SetActive(false);
        }
        boots.SetActive(false);
        shord.SetActive(false);
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

        var f = Mathf.Abs(h) + Mathf.Abs(v);
        if(_ani)_ani.SetFloat("speed",f);
    }

    IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(_attackCoolTime);
        if (!_butAttackTimebool)
        {
            _attackObj[0].SetActive(true);
            if (_audio) _audio.Play();
            yield return new WaitForSeconds(0.3f);
            _attackObj[0].SetActive(false);
            _attackObj[1].SetActive(true);
            if (_audio) _audio.Play();
            yield return new WaitForSeconds(0.3f);
            _attackObj[1].SetActive(false);
            if(_attacknum)
            {
                _attackObj[0].SetActive(true);
                if (_audio) _audio.Play();
                yield return new WaitForSeconds(0.3f);
                _attackObj[0].SetActive(false);
                _attackObj[1].SetActive(true);
                if (_audio) _audio.Play();
                yield return new WaitForSeconds(0.3f);
                _attackObj[1].SetActive(false);

            }
        }
        _attackCoolTimebool = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && !_starTime)
        {
            _butAttackTimebool = true;
            _starTime = true;
            _sprite.color = _butAttackColor;
            StartCoroutine(StarTime());
            Debug.Log("攻撃できないぞい");
        }
    }

    IEnumerator StarTime()
    {
        yield return new WaitForSeconds(5f);
        _butAttackTimebool = false;
        Debug.Log("攻撃できるぞい");
        _sprite.color = _starTimeColor;
        yield return new WaitForSeconds(3f);
        _starTime = false;
        Debug.Log("当たると痛いよ？");
        _sprite.color = Color.white;
    }

    public void AttackNumSansyo()
    {
        StartCoroutine(AttackNum());
    }

    IEnumerator AttackNum()
    {
        _attacknum = true;
        shord.SetActive(true);
        yield return new WaitForSeconds(10f);
        _attacknum = false;
        shord.SetActive(false);
    }

    public void SpeedUpSanssyo()
    {
        StartCoroutine(SpeedUp());
    }

    IEnumerator SpeedUp()
    {
        var tmpspeed = _speed;
        if (!_speedUp) _speed = _speed * 2;
        boots.SetActive(true);
        _speedUp = true;
        yield return new WaitForSeconds(10f);
        if(_speedUp) _speed = tmpspeed;
        _speedUp = false;
        boots.SetActive(false);
    }


}
