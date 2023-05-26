using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class InGameStream : MonoBehaviour
{
    [SerializeField] GameObject _titleItemRoot;
    [SerializeField] Button _gameStartButton;
    [SerializeField] Generator _generator;
    [SerializeField] InGameTimer _timer;
    [SerializeField] ScoreSystem _scoreSystem;
    [SerializeField] AudioSource _audioSource;

    void Awake()
    {
        // �Q�[���I�[�o�[���̃^�C�}�[�ւ̃R�[���o�b�N�o�^
        // Generator���~�߂ăQ�[���I�[�o�[�̃��b�Z�[�W���O������
        _timer.OnTimeOver += OnTimeOver;
        this.OnDisableAsObservable().Subscribe(_ => _timer.OnTimeOver -= OnTimeOver);
        
        // �{�^���N���b�N������Q�[���X�^�[�g
        _gameStartButton.onClick.AddListener(() => StartCoroutine(GameStream()));
    }

    void OnTimeOver()
    {
        GameOverMessageSender.SendMessage();
        _generator.Stop();
        _audioSource.Stop();
    }

    /// <summary>
    /// �^�C�g���{�^���������ꂽ��f�B���C���Ĕ�\��������A�G�𐶐����n�߂�
    /// </summary>
    IEnumerator GameStream()
    {
        yield return DisableTitleItem();
        _generator.Boot();
        _timer.Boot();
        _scoreSystem.Active();
        _audioSource.Play();
    }

    IEnumerator DisableTitleItem()
    {
        yield return new WaitForSeconds(0.5f);
        _titleItemRoot.SetActive(false);
    }
}
