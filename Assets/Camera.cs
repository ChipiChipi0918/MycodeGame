using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float cameraSpeed = 5.0f;

    public GameObject player;

    private bool usingShake = false;
    [SerializeField]
    private float m_roughness;      //거칠기 정도
    [SerializeField]
    private float m_magnitude;      //움직임 범위
    private void Start()
    {

    }
    public void Shaking()
    {
        
        StartCoroutine(Shake(0.4f));
    }
    //public void CameraS()
    //{
    //    usingShake = true;
    //}
    private void Update()
    {
        if (player.transform.position.y >= -2.75f && usingShake == false)
        {
            Vector3 dir = player.transform.position - this.transform.position;
            Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
            this.transform.Translate(moveVector);
        }
        else if(player.transform.position.y < -2.75f && usingShake == false)
        {
            Vector3 dir = player.transform.position - this.transform.position;
            Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, 0.0f, 0.0f);
            this.transform.Translate(moveVector);
        }

    }
    IEnumerator Shake(float duration)
    {


        float halfDuration = duration / 2;
        float elapsed = 0f;
        float tick = Random.Range(-5f, 5f);
        if (player.transform.position.y >= -2.75f)
        {
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime / halfDuration;

                tick += Time.deltaTime * m_roughness;
                transform.position += new Vector3(Mathf.PerlinNoise(tick, 0) - .5f, Mathf.PerlinNoise(0, tick) - .4805f, 0f) * m_magnitude * Mathf.PingPong(elapsed, halfDuration);
                Debug.Log("공중");
                yield return null;
            }
            
        }
        else
        {
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime / halfDuration;

                tick += Time.deltaTime * m_roughness;
                Vector3 position = transform.position;
                position.x += (Mathf.PerlinNoise(tick * 1.5f, 0) - 0.5f) * m_magnitude * Mathf.PingPong(elapsed, halfDuration);
                transform.position = position;
                Debug.Log("지면");
                yield return null;
                
            }
            
        }
    }
        //public void CameraSend()
        //{
        //   usingShake = false;
        //}
    }