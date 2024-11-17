using UnityEngine;

public class SawBlade : MonoBehaviour
{
    
    public float moveSpeed = 5f;
    public float rotationSpeed = 50f;
    private void Start()
    {
        //���³ʹ��ູ�մϴ�
    }
    void Update()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.z -= rotationSpeed * Time.deltaTime;
        transform.eulerAngles = rotation;
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }
}
