using UnityEngine;

public class LockRotation : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�Ώە�(��������)")]
    private GameObject playerObject;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }
        
    private void Update()
    {
        // �Ώە��Ǝ������g�̍��W����x�N�g�����Z�o
        Vector3 vector3 = playerObject.transform.position - this.transform.position;
        // �����㉺�����̉�]�͂��Ȃ��悤�ɂ�������Έȉ��̂悤�ɂ���B
        // vector3.y = 0f;

        // Quaternion(��]�l)���擾
        Quaternion quaternion = Quaternion.LookRotation(vector3);
        // �Z�o������]�l�����̃Q�[���I�u�W�F�N�g��rotation�ɑ��
        this.transform.rotation = quaternion;
    }
}