using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{

    public int playerNum;

    public Text[] values = new Text[5];

    // Use this for initialization
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.inistance.playersResources[playerNum - 1].isDirty)
        {
            values[(int)RESOURCES.EARTH].text = GameManager.inistance.playersResources[playerNum - 1].GetResource(RESOURCES.EARTH).ToString();
            values[(int)RESOURCES.WATER].text = GameManager.inistance.playersResources[playerNum - 1].GetResource(RESOURCES.WATER).ToString();
            values[(int)RESOURCES.FIRE].text = GameManager.inistance.playersResources[playerNum - 1].GetResource(RESOURCES.FIRE).ToString();
            values[(int)RESOURCES.WOOD].text = GameManager.inistance.playersResources[playerNum - 1].GetResource(RESOURCES.WOOD).ToString();
            // GameManager.inistance.playersResources[playerNum].isDirty = false;

            int leastNum = 10000;
            for (int i = 0; i < 4; i++)
            {
               var resNum =  GameManager.inistance.playersResources[playerNum - 1].GetResource(i);
                if(resNum < leastNum)
                {
                    leastNum = resNum;

                  

                }
            }
          
            if (leastNum == 5)
            {
                GameManager.inistance.WinningNation(playerNum);
                this.enabled = false;
            }

            values[4].text = leastNum.ToString();
        }
    }
}
