using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winScript : MonoBehaviour {
   public static winScript inistance = null;
    private void Awake()
    {
        inistance = this;
    }

    public void  SetWiner(int player)
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(i == player-1);
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(1);
    }
}
