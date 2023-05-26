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
        // ゲームオーバー時のタイマーへのコールバック登録
        // Generatorを止めてゲームオーバーのメッセージングをする
        _timer.OnTimeOver += OnTimeOver;
        this.OnDisableAsObservable().Subscribe(_ => _timer.OnTimeOver -= OnTimeOver);
        
        // ボタンクリックしたらゲームスタート
        _gameStartButton.onClick.AddListener(() => StartCoroutine(GameStream()));
    }

    void OnTimeOver()
    {
        GameOverMessageSender.SendMessage();
        _generator.Stop();
        _audioSource.Stop();
    }

    /// <summary>
    /// タイトルボタンが押されたらディレイして非表示した後、敵を生成し始める
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
