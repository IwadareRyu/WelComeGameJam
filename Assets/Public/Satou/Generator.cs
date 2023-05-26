using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] EnemyActor[] _enemyPrefabs;
    [SerializeField] Transform[] _points;
    [SerializeField] int _max = 20;
    [SerializeField] float _interval = 0.5f;

    IDisposable _disposable;
    int _current;

    void Awake()
    {
        // 破棄されるタイミングでDisposeする
        this.OnDestroyAsObservable().Subscribe(_ => _disposable?.Dispose());
    }

    /// <summary>
    /// 外部から呼ぶことで一定間隔で生成を開始する
    /// </summary>
    public void Boot()
    {
        _disposable = Observable.Interval(TimeSpan.FromSeconds(_interval))
            .Where(_ => _current < _max).Subscribe(_ => Generate());
    }

    /// <summary>
    /// ゲームオーバー時に止める
    /// </summary>
    public void Stop() => _disposable.Dispose();

    /// <summary>
    /// ランダムな敵をランダムな箇所から生成する
    /// </summary>
    void Generate()
    {
        int r = UnityEngine.Random.Range(0, _enemyPrefabs.Length);
        int p = UnityEngine.Random.Range(0, _points.Length);
        EnemyActor enemy = Instantiate(_enemyPrefabs[r], _points[p].position, Quaternion.identity);
        enemy.OnDisableAsObservable().Subscribe(_ => _current--);

        _current++;
    }
}
