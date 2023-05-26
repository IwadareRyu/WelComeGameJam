using UniRx;
using UnityEngine;

public class GameOverMessageReceiver : MonoBehaviour
{
    void Start()
    {
        MessageBroker.Default.Receive<GameOverMessage>().Subscribe(_ => gameObject.SetActive(false));
    }
}
