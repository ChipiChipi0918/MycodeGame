using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Enemy
{
    public GameObject enemyObj;
    public float enemyspawntime;
}

public class Spawn : MonoBehaviour
{
    public GameObject rangeObject;
    BoxCollider2D rangeCollider;

    public Enemy[] enemies;

    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider2D>();
    }

    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;
        
        float range_Y= rangeCollider.bounds.size.y;
        

        range_Y = UnityEngine.Random.Range((range_Y / 2) * -1, range_Y / 2);
       
        Vector3 RandomPostion = new Vector3(2f, range_Y, 0f);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }
    
    private void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine1());
        StartCoroutine(RandomRespawn_Coroutine2());
        StartCoroutine(RandomRespawn_Coroutine3());
        StartCoroutine(RandomRespawn_Coroutine4());
        StartCoroutine(RandomRespawn_Coroutine5());
    }

    IEnumerator RandomRespawn_Coroutine1()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemies[0].enemyspawntime);

            // 생성 위치 부분에 위에서 만든 함수 Return_RandomPosition() 함수 대입
            GameObject instantCapsul = Instantiate(enemies[0].enemyObj, Return_RandomPosition(), Quaternion.identity);


        }

    }
    IEnumerator RandomRespawn_Coroutine2()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemies[1].enemyspawntime);

            // 생성 위치 부분에 위에서 만든 함수 Return_RandomPosition() 함수 대입
            GameObject instantCapsul = Instantiate(enemies[1].enemyObj, Return_RandomPosition(), Quaternion.identity);
        }

    }
    IEnumerator RandomRespawn_Coroutine3()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemies[2].enemyspawntime);

            // 생성 위치 부분에 위에서 만든 함수 Return_RandomPosition() 함수 대입
            GameObject instantCapsul = Instantiate(enemies[2].enemyObj, Return_RandomPosition(), Quaternion.identity);
        }

    }
    IEnumerator RandomRespawn_Coroutine4()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemies[3].enemyspawntime);

            // 생성 위치 부분에 위에서 만든 함수 Return_RandomPosition() 함수 대입
            GameObject instantCapsul = Instantiate(enemies[3].enemyObj, Return_RandomPosition(), Quaternion.identity);
        }

    }
    IEnumerator RandomRespawn_Coroutine5()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemies[4].enemyspawntime);

            // 생성 위치 부분에 위에서 만든 함수 Return_RandomPosition() 함수 대입
            GameObject instantCapsul = Instantiate(enemies[4].enemyObj, Return_RandomPosition(), Quaternion.identity);
        }

    }
}
