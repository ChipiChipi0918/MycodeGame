using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnXP : MonoBehaviour
{
    public GameObject rangeObject;
    BoxCollider2D rangeCollider;

    public GameObject xp;
    



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
        StartCoroutine(RandomRespawn());
    }

    IEnumerator RandomRespawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            GameObject instantCapsul = Instantiate(xp, Return_RandomPosition(), Quaternion.identity);
        }
    }
    
}
