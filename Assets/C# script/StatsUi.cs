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
                        +"\n      : " + player.attackLv + " / 8"
                        +"\n      : " + player.attackSpeedLv + " / 6"
                        +"\n      : " + player.bulletLv + " / 6"
                        +"\n      : " + player.speedLv + " / 7"
                        +"\nUpgrade Count: " + player.UpgradeChance;
    }
    

}
