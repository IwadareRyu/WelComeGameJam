using UniRx;
using UnityEngine;

public class EnemyActor : MonoBehaviour
{
    [SerializeField] int _socre;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>
    /// ダメージを受けた際の処理はプレイヤー側から呼ぶ
    /// </summary>
    public void Damage()
    {
        MessageBroker.Default.Publish(new ScoreMessageData(_socre));

        // Generator側で非表示をSubscribeしているので撃破されたら非表示にする
        gameObject.SetActive(false);
    }
}
