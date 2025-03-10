using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgm : MonoBehaviour
{
    public AudioClip[] arrAudio;

    AudioSource myaudio;

    public Player player;

    private bool bossSound = false;
    // Start is called before the first frame update
    void Start()
    {
        
        myaudio = this.GetComponent<AudioSource>();

        myaudio.Stop();
        myaudio.clip = arrAudio[0];
        myaudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        /*
         myaudio = this.GetComponent<EcECE>(); 
         */
    }
    public void BossSound()
    {
        if (bossSound == false)
        {
            myaudio.clip = arrAudio[1];
            myaudio.Play();
            bossSound = true;
        }
    }
}
