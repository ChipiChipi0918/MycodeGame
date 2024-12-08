using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M : MonoBehaviour
{
    public Text text;


    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Mathf.Floor(player.transform.position.x) + "M";
    }
}
