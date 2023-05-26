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

    public int TotalScore { get; private set; }

    void Awake()
    {
        MessageBroker.Default.Receive<ScoreMessageData>().Subscribe(data => 
        {
            TotalScore += data.Score;
            _text.text = TotalScore.ToString();
        }).AddTo(this);
    }

    void Start()
    {
        // ゲーム起動時は画面にスコアが表示されないようにする
        Inactive();
    }

    /// <summary>
    /// 外部から呼ぶことでゲーム開始時に表示させる
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
