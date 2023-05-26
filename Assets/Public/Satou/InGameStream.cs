using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using UnityEngine.SceneManagement;

public class InGameStream : MonoBehaviour
{
    [SerializeField] GameObject _titleItemRoot;
    [SerializeField] Button _gameStartButton;
    [SerializeField] Button _gameReturnButton;
    [SerializeField] Generator _generator;
    [SerializeField] InGameTimer _timer;
    [SerializeField] ScoreSystem _scoreSystem;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] GameObject _player;

    void Awake()
    {
        // �Q�[���I�[�o�[���̃^�C�}�[�ւ̃R�[���o�b�N�o�^
        // Generator���~�߂ăQ�[���I�[�o�[�̃��b�Z�[�W���O������
        _timer.OnTimeOver += OnTimeOver;
        this.OnDisableAsObservable().Subscribe(_ => _timer.OnTimeOver -= OnTimeOver);
        
        // �{�^���N���b�N������Q�[���X�^�[�g
        _gameStartButton.onClick.AddListener(() => StartCoroutine(GameStream()));

        // �^�C�g���ɖ߂�
        _gameReturnButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
    }

    void OnTimeOver()
    {
        GameOverMessageSender.SendMessage();
        _generator.Stop();
        _audioSource.Stop();
        _player.SetActive(false);
        _scoreSystem.Inactive();

        GetComponent<ResultModule>().Active(_scoreSystem.TotalScore);
    }

    /// <summary>
    /// �^�C�g���{�^���������ꂽ��f�B���C���Ĕ�\��������A�G�𐶐����n�߂�
    /// </summary>
    IEnumerator GameStream()
    {
        _player.SetActive(true);

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
