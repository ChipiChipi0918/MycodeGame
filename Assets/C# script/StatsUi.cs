using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUi : MonoBehaviour
{
    public Text StatsText;
    

    public Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {

        StatsText.text = "Attack Damage:" + player.damage
                        +"\nAttack Speed:" + player.attackSpeed
                        +"\nMax Bullet:" + player.maxBullet
                        +"\nMove Speed:" + player.moveSpeed;
    }
    

}
