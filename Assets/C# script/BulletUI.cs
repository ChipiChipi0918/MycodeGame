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
        
        UpdateBulletUI();
        
    }
    public void BulletReload()
    {
        Invoke("EndReload", 0.499f);
    }
    void EndReload()
    {
        player.BulletConunt = player.maxBullet;
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
        if(player.BulletConunt == -1)
        {
            bulletCountText.text = "Reloding...";
        }
        else
        {
            bulletCountText.text = player.BulletConunt + " / "+ player.maxBullet;
        }
    }

}
