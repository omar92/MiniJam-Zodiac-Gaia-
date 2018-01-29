using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTime : MonoBehaviour
{

    private Player player;
    //private GameObject player;
    private int PlayerNum;
    private Image timeImage;
    //public Portals portalScript;
    // private float fillAmount;

    // Use this for initialization
    void Start()
    {
        //player = GetComponent<Player>();
        timeImage = GetComponentInChildren<Image>();
        player = transform.GetComponentInParent<Player>();
        //player = this.transform.parent.gameObject;
        //fillAmount = timeImage.fillAmount;

        //PlayerNum = player.playerNum;
        //StartCoroutine(onCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (timeImage.fillAmount > 0)
        {
            timeImage.fillAmount -= 1.0f / GameManager.inistance.waitingTime * Time.deltaTime;
        }
        else
        {
            SoundManager.inistance.PlayTimer();
            //Queue myQ = new Queue();
            for (int i = 0; i < 4; i++)
            {
                if (GameManager.inistance.playersResources[player.playerNum - 1].GetResource(i) > 0)
                {
                    GameManager.inistance.playersResources[player.playerNum - 1].ReduceResource((RESOURCES)i);
                    reset();
                    Portals portal = GameObject.FindObjectOfType<Portals>();
                    portal.ThrowResources((RESOURCES)i);

                }
            }

        }
    }
    public void reset()
    {
        timeImage.fillAmount = 1f;
    }

}
