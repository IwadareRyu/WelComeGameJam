using UnityEngine;

public class LockRotation : MonoBehaviour
{
    [SerializeField]
    [Tooltip("対象物(向く方向)")]
    private GameObject playerObject;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }
        
    private void Update()
    {
        // 対象物と自分自身の座標からベクトルを算出
        Vector3 vector3 = playerObject.transform.position - this.transform.position;
        // もし上下方向の回転はしないようにしたければ以下のようにする。
        // vector3.y = 0f;

        // Quaternion(回転値)を取得
        Quaternion quaternion = Quaternion.LookRotation(vector3);
        // 算出した回転値をこのゲームオブジェクトのrotationに代入
        this.transform.rotation = quaternion;
    }
}