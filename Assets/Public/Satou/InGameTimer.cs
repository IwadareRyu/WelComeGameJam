using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using UnityEngine.Events;
using UniRx.Triggers;

public class InGameTimer : MonoBehaviour
{
    [SerializeField] int _timeLimit = 10;
    [SerializeField] Text _text;

    public event UnityAction OnTimeOver;
    IDisposable _disposable;

    void Awake()
    {
        this.OnDestroyAsObservable().Subscribe(_ => _disposable?.Dispose());
    }

    /// <summary>
    /// 1秒ごとに時間を更新して終了時にコールバックを呼ぶタイマーを起動する
    /// </summary>
    public void Boot()
    {
        _disposable = Observable.Timer(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1))
            .Select(time => _timeLimit - time)
            .TakeWhile(time => time >= 0)
            .DoOnCompleted(() => OnTimeOver?.Invoke())
            .Subscribe(time => _text.text = time.ToString());
    }
}
