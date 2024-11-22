using UnityEngine;
using UnityEngine.UI;

public class BulletUI : MonoBehaviour
{
    public Text bulletCountText;
    public Player player;

    void Start()
    {
        
    }

    private void Update()
    {
        Debug.Log(player.BulletConunt);
        UpdateBulletUI();
        if (Input.GetKeyDown(KeyCode.R))
        {
            player.BulletConunt = 0;
            Invoke("EndReload", 0.499f);
        }
    }
    void EndReload()
    {
        player.BulletConunt = 5;
    }
    public void BulletCounting()
    {
        if (player.BulletConunt > 0)
        {
            player.BulletConunt--;          
        }
        UpdateBulletUI();
    }
    public void UpdateBulletUI()
    {
        //bulletCountText.text = player.BulletConunt + " / 5";
        if(player.BulletConunt == 10)
        {
            bulletCountText.text = "Reloding...";
        }
        else
        {
            bulletCountText.text = player.BulletConunt + " / 5";
        }
    }

}
