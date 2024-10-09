using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth, maxHealth;

    public float invincibleLength;
    private float invincibleCounter;

    private SpriteRenderer theSR;//让角色显示是否处于无敌的状态，并在start函数中调用

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        theSR = GetComponent<SpriteRenderer>();//获取角色显示透明的组件
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter>0)
        {
            invincibleCounter -= Time.deltaTime;

            if(invincibleCounter<=0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);//变全彩
            }
        }
    }
    public void DealDamage()
    {
        if (invincibleCounter <= 0)
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                gameObject.SetActive(false);
            }
            else
            {
                invincibleCounter = invincibleLength;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f); //透明
                PlayerController.instance.KnockBack();
            }
            UIController.instance.UpdateHealthDisplay();
        }
    }
}
