using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvUi : MonoBehaviour
{
    public Text bulletCountText;
    

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        Debug.Log("PlayerÀÇ Lv °ª: " + player.Lv);
        bulletCountText.text = "LV:" + player.Lv;

    }
    

}
