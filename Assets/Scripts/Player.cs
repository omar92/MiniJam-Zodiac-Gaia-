using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public int playerNum;
    public Transform Hand;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void resetTime()
    {
        transform.GetComponentInChildren<PlayerTime>().reset();
    }
}
