using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject rangeObject;
    BoxCollider2D rangeCollider;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public float enemy1spawntime = 2f;
    public float enemy2spawntime = 3f;
    public float enemy3spawntime = 5f;

    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider2D>();
    }

    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;
        
        float range_Y= rangeCollider.bounds.size.y;
        

        range_Y = Random.Range((range_Y / 2) * -1, range_Y / 2);
       
        Vector3 RandomPostion = new Vector3(2f, range_Y, 0f);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }
    
    private void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine1());
        StartCoroutine(RandomRespawn_Coroutine2());
        StartCoroutine(RandomRespawn_Coroutine3());
    }

    IEnumerator RandomRespawn_Coroutine1()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemy1spawntime);

            // ���� ��ġ �κп� ������ ���� �Լ� Return_RandomPosition() �Լ� ����
            GameObject instantCapsul = Instantiate(enemy1, Return_RandomPosition(), Quaternion.identity);
        }

    }
    IEnumerator RandomRespawn_Coroutine2()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemy2spawntime);

            // ���� ��ġ �κп� ������ ���� �Լ� Return_RandomPosition() �Լ� ����
            GameObject instantCapsul = Instantiate(enemy2, Return_RandomPosition(), Quaternion.identity);
        }

    }
    IEnumerator RandomRespawn_Coroutine3()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemy3spawntime);

            // ���� ��ġ �κп� ������ ���� �Լ� Return_RandomPosition() �Լ� ����
            GameObject instantCapsul = Instantiate(enemy3, Return_RandomPosition(), Quaternion.identity);
        }

    }
}
