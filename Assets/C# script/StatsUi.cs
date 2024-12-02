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

        StatsText.text ="LV: " + player.Lv
                        +"\nAttack Lv: " + player.attackLv + " / 8"
                        +"\nAttack Speed Lv: " + player.attackSpeedLv + " / 6"
                        +"\nMax Bullet Lv: " + player.bulletLv + " / 6"
                        +"\nMove Speed Lv: " + player.speedLv + " / 7"
                        +"\nUpgrade Count: " + player.UpgradeChance;
    }
    

}
