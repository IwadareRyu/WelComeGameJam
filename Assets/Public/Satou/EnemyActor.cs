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
    /// �_���[�W���󂯂��ۂ̏����̓v���C���[������Ă�
    /// </summary>
    public void Damage()
    {
        MessageBroker.Default.Publish(new ScoreMessageData(_socre));

        // Generator���Ŕ�\����Subscribe���Ă���̂Ō��j���ꂽ���\���ɂ���
        gameObject.SetActive(false);
    }
}
