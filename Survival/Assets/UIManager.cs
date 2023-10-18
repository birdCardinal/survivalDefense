using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI StageText;
    public TextMeshProUGUI GoldText;
    public GameObject GameSetPanel;
    public TextMeshProUGUI WinLoseText;
    public TextMeshProUGUI CountTowerText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StageText.text = "Stage:" + GameManager.GetGameManager().stage;
        GoldText.text = "Gold:" + GameManager.GetGameManager().GoldT;
        CountTowerText.text = "CountTower" + GameManager.GetGameManager().CountTower + "/" + GameManager.GetGameManager().MaxCountTower;
        if (GameManager.GetGameManager().winer==true)
        {
            GameManager.GetGameManager().TimerStop = true;
            GameSetPanel.SetActive(true);
            WinLoseText.text = "½Â¸®";
        }
        
        else if (GameManager.GetGameManager().loser == true)
        {
            GameManager.GetGameManager().TimerStop = true;
            GameSetPanel.SetActive(true);
            WinLoseText.text = "ÆÐ¹è";
        }
        
    }
}