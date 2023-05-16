using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeSystem : MonoBehaviour
{
    [SerializeField] private Image lifeBar;
    [SerializeField] private int maxHp;
    public int hp;

    public static PlayerLifeSystem playerLife;

    private void Start()
    {
        playerLife = this;
        lifeBar.fillAmount = 1;
    }

    public void TakeDmg(int dmg)
    {
        hp -= dmg;
        lifeBar.fillAmount = (float)hp/(float)maxHp;
        
        if(hp<=0) Death();
    }

    private void Death()
    {
        hp = maxHp;
        //StartCoroutine(ItemRemover.remov.ReplacePlayer(gameObject.GetComponent<CharacterController>()));
    }
}
