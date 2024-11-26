using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class xpMaxXpUi : MonoBehaviour
{
    public Text xpText;
    

    public Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        
        xpText.text = player.xp + "/" + player.maxXp;

    }
    

}
