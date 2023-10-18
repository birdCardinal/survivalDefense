using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PassiveManager : MonoBehaviour
{
    public GameObject passivePanel;
    public TextMeshProUGUI[] choiceBuff = new TextMeshProUGUI[3];
    private int[] id = new int[3];
   
    // Start is called before the first frame update
    void OnEnable()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetGameManager().TimerStop == true && passivePanel.activeSelf == false)
        {
            passivePanel.SetActive(true);
            for (int i = 0; i < id.Length; i++)
            {
                id[i] =Random.Range(0,21);
                while (GameManager.GetGameManager().Buff[id[i]] == true)
                {
                    id[i] = Random.Range(0, 21);
                }
            }
            PassiveText(id);
        }
    }
    void PassiveText(int[] Passiveid)
    {
        for (int i = 0; i < Passiveid.Length; i++)
        {
            switch (Passiveid[i])
            {
                case 0:
                    choiceBuff[i].text = "타워1을 설치할 수 있습니다";
                    break;
                case 1:
                    choiceBuff[i].text = "타워2를 설치할 수 있습니다";
                    break;
                case 2:
                    choiceBuff[i].text = "타워3을 설치할 수 있습니다";
                    break;
                case 3:
                    choiceBuff[i].text = "타워4를 설치할 수 있습니다";
                    break;
                case 4:
                    choiceBuff[i].text = "타워5를 설치할 수 있습니다";
                    break;
                case 5:
                    choiceBuff[i].text = "타워6을 설치할 수 있습니다";
                    break;
                case 6:
                    choiceBuff[i].text = "타워1이 공격시마다 5%확률로 5초 동안 공격력100%,공격속도100%버프를 획득합니다";
                    break;
                case 7:
                    choiceBuff[i].text = "타워2가 공격시마다 2초간 적의 이속을 50%만큼 감소시킵니다 이속감소는 중첩되지 않습니다";
                    break;
                case 8:
                    choiceBuff[i].text = "타워3이 사거리 내 주변 타워의 공격력을 15% 강화합니다";
                    break;
                case 9:
                    choiceBuff[i].text = "타워4가 범위피해를 입힙니다";
                    break;
                case 10:
                    choiceBuff[i].text = "타워5가 관통공격을 합니다";
                    break;
                case 11:
                    choiceBuff[i].text = "타워6이 사거리 내 은신상태가 아닌 적이 다시 은신상태로 돌아가게 하지 않습니다";
                    break;
                case 12:
                    choiceBuff[i].text = "플레이어의 공격이 적을 관통합니다";
                    break;
                case 13:
                    choiceBuff[i].text = "플레이어 사거리 내 적에게 매 5초마다 공격력만큼의 피해를 입힙니다";
                    break;
                case 14:
                    choiceBuff[i].text = "플레이어 사거리 내 은신상태가 아닌 적이 다시 은신상태로 돌아가게 하지 않습니다";
                    break;
                case 15:
                    choiceBuff[i].text = "수정핵의 최대체력과 현재 체력이 100늘어납니다";
                    break;
                case 16:
                    choiceBuff[i].text = "수정핵의 체력이 0이될경우 체력1로 되살아나며 주변의 적들을 즉사시킵니다";
                    break;
                case 17:
                    choiceBuff[i].text = "수정핵의 주변에 있는 타워는 공격력이 15% 증가됩니다";
                    break;
                case 18:
                    choiceBuff[i].text = "수정핵과 일정거리 이상 멀리 있는 타워는 공격력과 공격속도가 25% 증가됩니다";
                    break;
                case 19:
                    choiceBuff[i].text = "모든 적의 체력이 10% 감소합니다";
                    break;
                case 20:
                    choiceBuff[i].text = "타워의 최대 설치 개수가 10개 증가합니다";
                    break;
            }
        }
    }
    public void PassiveBuff(int id2)
    {
        GameManager.GetGameManager().Buff[id[id2]] = true;
        passivePanel.SetActive(false);
        GameManager.GetGameManager().TimerStop = false;
    }
}
