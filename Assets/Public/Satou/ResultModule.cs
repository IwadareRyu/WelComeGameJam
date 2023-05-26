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
    /// �Q�[���I�[�o�[���ɌĂ΂�ăX�R�A��\������
    /// </summary>
    public void Active(int score)
    {
        _resultItemRoot.SetActive(true);
        _text.text = score.ToString();
    }
}
