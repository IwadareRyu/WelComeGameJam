using UnityEngine;
using UnityEngine.UI;

public class ResultModule : MonoBehaviour
{
    [SerializeField] GameObject _resultItemRoot;
    [SerializeField] Text _text;

    void Start()
    {
        _resultItemRoot.SetActive(false);
    }

    /// <summary>
    /// ゲームオーバー時に呼ばれてスコアを表示する
    /// </summary>
    public void Active(int score)
    {
        _resultItemRoot.SetActive(true);
        _text.text = score.ToString();
    }
}
