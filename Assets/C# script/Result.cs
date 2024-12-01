using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
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
        
            text.text = player.resultplayerpos + "M"
          + "\n\nLV:" + player.Lv
          + "\nAttack Damage:" + player.damage
          + "\nAttack Speed:" + player.attackSpeed
          + "\nMax Bullet:" + player.maxBullet
          + "\nMove Speed:" + player.moveSpeed;
        

    }
}
