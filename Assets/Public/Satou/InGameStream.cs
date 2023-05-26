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
        // ゲームオーバー時のタイマーへのコールバック登録
        // Generatorを止めてゲームオーバーのメッセージングをする
        _timer.OnTimeOver += OnTimeOver;
        this.OnDisableAsObservable().Subscribe(_ => _timer.OnTimeOver -= OnTimeOver);
        
        // ボタンクリックしたらゲームスタート
        _gameStartButton.onClick.AddListener(() => StartCoroutine(GameStream()));

        // タイトルに戻る
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
    /// タイトルボタンが押されたらディレイして非表示した後、敵を生成し始める
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
