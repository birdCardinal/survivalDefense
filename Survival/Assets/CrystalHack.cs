using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CrystalHack : MonoBehaviour
{
    public int hp;
    private bool HpBuff;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        HpBuff = false;
        hp = 100;
        slider.maxValue = hp;
        slider.minValue = 0;
        slider.value = hp;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] coll = Physics2D.OverlapCircleAll(transform.position, 5f);
        if (GameManager.GetGameManager().Buff[18] == true&&HpBuff==false)
        {
            slider.maxValue = 200;
            hp += 100;
            slider.value += 100;
            HpBuff = true;
        }
        slider.value = hp;
        if (slider.value <= 0 && GameManager.GetGameManager().Buff[16]==false)
        {
            GameManager.GetGameManager().loser = true;
        }
        else if(slider.value <= 0 && GameManager.GetGameManager().Buff[16] == true)
        {
            slider.value = 1;
            for(int i = 0; i < coll.Length; i++)
            {
                Monster monster = coll[i].GetComponent<Monster>();
                monster.hp = 0;
            }
        }
        if (GameManager.GetGameManager().Buff[17] == true)
        {
            for (int i = 0; i < coll.Length; i++)
            {
                towerScript to = coll[i].GetComponent<towerScript>();
                if (to.CrystalHackBuff == false)
                {
                    to.attack = (int)(to.attack * 1.15f);
                    to.CrystalHackBuff = true;
                }
            }
        }
    }
}
