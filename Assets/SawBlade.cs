using UnityEngine;

public class SawBlade : MonoBehaviour
{
    
    public float moveSpeed = 5f;
   
    public float rotationSpeed = 50f;

    void Update()
    {
       
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        
        Vector3 rotation = transform.eulerAngles;
        rotation.z -= rotationSpeed * Time.deltaTime;
        transform.eulerAngles = rotation;
    }
}
