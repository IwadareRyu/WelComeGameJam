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
            // 非表示にするとスコアが入っていしまうのでスケールを0にする
            transform.localScale = Vector3.zero;
        }).AddTo(this);
    }

    /// <summary>
    /// ダメージを受けた際の処理はプレイヤー側から呼ぶ
    /// </summary>
    public void Damage()
    {
        MessageBroker.Default.Publish(new ScoreMessageData(_socre));

        GetComponent<AudioSource>().Play();
        // Generator側で非表示をSubscribeしているので撃破されたら非表示にする
        DOVirtual.DelayedCall(0.5f, () => gameObject.SetActive(false));

        Instantiate(_defeatedPrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
    }
}
