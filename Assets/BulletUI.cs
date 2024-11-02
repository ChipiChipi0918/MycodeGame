using UnityEngine;
using UnityEngine.UI;

public class BulletUI : MonoBehaviour
{
    public Text bulletCountText;   
    public int bulletCount = 5;  

    void Start()
    {
        // 텍스트 초기화
        UpdateBulletUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            UpdateBulletUI();
            Invoke("EndReload", 0.5f);
            UpdateBulletUI();
            bulletCount = 5;
        }
    }
    void EndReload()
    {
        bulletCount = 5;
    }
    public void BulletCounting()
    {
         
        
        if (bulletCount > 0)
        {
            bulletCount--;          
            
        }
        UpdateBulletUI();

    }
    public void UpdateBulletUI()
    {
        bulletCountText.text = bulletCount + " / 5";
    }

}
