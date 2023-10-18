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
                    choiceBuff[i].text = "Ÿ��1�� ��ġ�� �� �ֽ��ϴ�";
                    break;
                case 1:
                    choiceBuff[i].text = "Ÿ��2�� ��ġ�� �� �ֽ��ϴ�";
                    break;
                case 2:
                    choiceBuff[i].text = "Ÿ��3�� ��ġ�� �� �ֽ��ϴ�";
                    break;
                case 3:
                    choiceBuff[i].text = "Ÿ��4�� ��ġ�� �� �ֽ��ϴ�";
                    break;
                case 4:
                    choiceBuff[i].text = "Ÿ��5�� ��ġ�� �� �ֽ��ϴ�";
                    break;
                case 5:
                    choiceBuff[i].text = "Ÿ��6�� ��ġ�� �� �ֽ��ϴ�";
                    break;
                case 6:
                    choiceBuff[i].text = "Ÿ��1�� ���ݽø��� 5%Ȯ���� 5�� ���� ���ݷ�100%,���ݼӵ�100%������ ȹ���մϴ�";
                    break;
                case 7:
                    choiceBuff[i].text = "Ÿ��2�� ���ݽø��� 2�ʰ� ���� �̼��� 50%��ŭ ���ҽ�ŵ�ϴ� �̼Ӱ��Ҵ� ��ø���� �ʽ��ϴ�";
                    break;
                case 8:
                    choiceBuff[i].text = "Ÿ��3�� ��Ÿ� �� �ֺ� Ÿ���� ���ݷ��� 15% ��ȭ�մϴ�";
                    break;
                case 9:
                    choiceBuff[i].text = "Ÿ��4�� �������ظ� �����ϴ�";
                    break;
                case 10:
                    choiceBuff[i].text = "Ÿ��5�� ��������� �մϴ�";
                    break;
                case 11:
                    choiceBuff[i].text = "Ÿ��6�� ��Ÿ� �� ���Ż��°� �ƴ� ���� �ٽ� ���Ż��·� ���ư��� ���� �ʽ��ϴ�";
                    break;
                case 12:
                    choiceBuff[i].text = "�÷��̾��� ������ ���� �����մϴ�";
                    break;
                case 13:
                    choiceBuff[i].text = "�÷��̾� ��Ÿ� �� ������ �� 5�ʸ��� ���ݷ¸�ŭ�� ���ظ� �����ϴ�";
                    break;
                case 14:
                    choiceBuff[i].text = "�÷��̾� ��Ÿ� �� ���Ż��°� �ƴ� ���� �ٽ� ���Ż��·� ���ư��� ���� �ʽ��ϴ�";
                    break;
                case 15:
                    choiceBuff[i].text = "�������� �ִ�ü�°� ���� ü���� 100�þ�ϴ�";
                    break;
                case 16:
                    choiceBuff[i].text = "�������� ü���� 0�̵ɰ�� ü��1�� �ǻ�Ƴ��� �ֺ��� ������ ����ŵ�ϴ�";
                    break;
                case 17:
                    choiceBuff[i].text = "�������� �ֺ��� �ִ� Ÿ���� ���ݷ��� 15% �����˴ϴ�";
                    break;
                case 18:
                    choiceBuff[i].text = "�����ٰ� �����Ÿ� �̻� �ָ� �ִ� Ÿ���� ���ݷ°� ���ݼӵ��� 25% �����˴ϴ�";
                    break;
                case 19:
                    choiceBuff[i].text = "��� ���� ü���� 10% �����մϴ�";
                    break;
                case 20:
                    choiceBuff[i].text = "Ÿ���� �ִ� ��ġ ������ 10�� �����մϴ�";
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
