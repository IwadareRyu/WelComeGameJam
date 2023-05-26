using UniRx;
using UnityEngine;
using UnityEngine.UI;

public struct ScoreMessageData
{
    public ScoreMessageData(int score)
    {
        Score = score;
    }

    public int Score { get; private set; }
}

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] Text _label;
    [SerializeField] Text _text;
    int _totalScore;

    void Awake()
    {
        MessageBroker.Default.Receive<ScoreMessageData>().Subscribe(data => 
        {
            _totalScore += data.Score;
            _text.text = _totalScore.ToString();
        }).AddTo(this);
    }

    void Start()
    {
        // �Q�[���N�����͉�ʂɃX�R�A���\������Ȃ��悤�ɂ���
        Inactive();
    }

    /// <summary>
    /// �O������ĂԂ��ƂŃQ�[���J�n���ɕ\��������
    /// </summary>
    public void Active()
    {
        _label.text = "Score";
        _text.text = "0";
    }

    public void Inactive()
    {
        _label.text = "";
        _text.text = "";
    }
}
