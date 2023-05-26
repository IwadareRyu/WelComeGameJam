using UniRx;
using UnityEngine;
using DG.Tweening;

public class EnemyActor : MonoBehaviour
{
    [SerializeField] int _socre;
    [SerializeField] GameObject _defeatedPrefab;

    void Awake()
    {
        MessageBroker.Default.Receive<GameOverMessage>().Subscribe(_ =>
        {
            // ��\���ɂ���ƃX�R�A�������Ă����܂��̂ŃX�P�[����0�ɂ���
            transform.localScale = Vector3.zero;
        }).AddTo(this);
    }

    /// <summary>
    /// �_���[�W���󂯂��ۂ̏����̓v���C���[������Ă�
    /// </summary>
    public void Damage()
    {
        MessageBroker.Default.Publish(new ScoreMessageData(_socre));

        GetComponent<AudioSource>().Play();
        // Generator���Ŕ�\����Subscribe���Ă���̂Ō��j���ꂽ���\���ɂ���
        DOVirtual.DelayedCall(0.5f, () => gameObject.SetActive(false));

        Instantiate(_defeatedPrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
    }
}
