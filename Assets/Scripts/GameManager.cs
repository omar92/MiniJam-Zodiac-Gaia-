using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public struct PLayerResources
{
    private int[] resources;



    public int GetResource(RESOURCES resource)
    {
        if (resources == null)
        {
            this.resources = new int[4];
        }
        return this.resources[(int)resource];
    }

    public int GetResource(int resource)
    {
        if (resources == null)
        {
            this.resources = new int[4];
        }
        return this.resources[(int)resource];
    }

    internal void ReduceResource(RESOURCES resource)
    {
        this.resources[(int)resource] -= 1;
    }

    internal void IncreaseResource(RESOURCES resource)
    {
        this.resources[(int)resource] += 1;
    }

    public void SetResource(RESOURCES resource, int value)
    {
        if (resources == null)
        {
            resources = new int[4];
        }
        this.resources[(int)resource] = value;
        isDirty = true;
    }
    public bool isDirty;

}


public class GameManager : MonoBehaviour
{

    [SerializeField]
    public int initialResources = 20;
    public float waitingTime;
    int winerPLayer = -1;

    public PLayerResources[] playersResources = new PLayerResources[4];
    public static GameManager inistance = null;


    private void Awake()
    {
        if (GameManager.inistance == null)
        {
            inistance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;
        for (int i = 0; i < playersResources.Length; i++)
        {
            playersResources[i].SetResource(RESOURCES.WOOD, i == (int)RESOURCES.WOOD ? initialResources : 0);
            playersResources[i].SetResource(RESOURCES.FIRE, i == (int)RESOURCES.FIRE ? initialResources : 0);
            playersResources[i].SetResource(RESOURCES.WATER, i == (int)RESOURCES.WATER ? initialResources : 0);
            playersResources[i].SetResource(RESOURCES.EARTH, i == (int)RESOURCES.EARTH ? initialResources : 0);
        }

    }

    // Update is called once per frame
    void Update()
    {/*
        if (zooming)
        {
            if (movingTowardsTarget == true)
            {
                movingTowardsTarget = false;
            }
            else
            {
                movingTowardsTarget = true;
            }
        }
        if (movingTowardsTarget)
        {

        }*/
    }

    public void WinningNation(int playerNum)
    {
        //  Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();

        winerPLayer = playerNum;
        winScript.inistance.SetWiner(playerNum);
        Time.timeScale = 0.0001f;
        //switch (playerNum)
        //{
        //    case 1:
        //        Vector3 player1Pos = GameObject.Find("WaterPLayer").transform.Find("FocusPoint").transform.position;
        //        cam.transform.position = player1Pos;//Vector3.MoveTowards(cam.transform.position, player1Pos, 35.0f * Time.deltaTime);
        //        break;

        //    case 2:
        //        Vector3 player2Pos = GameObject.Find("EarthPLayer").GetComponent<Transform>().Find("FocusPoint").transform.position;
        //        cam.transform.position = player2Pos;//Vector3.MoveTowards(cam.transform.position, player2Pos, 35.0f * Time.deltaTime);
        //        break;

        //    case 3:
        //        Vector3 player3Pos = GameObject.Find("WoodPlayer").GetComponent<Transform>().Find("FocusPoint").transform.position;
        //        cam.transform.position = player3Pos;//Vector3.MoveTowards(cam.transform.position, player3Pos, 35.0f * Time.deltaTime);
        //        break;

        //    case 4:
        //        Vector3 player4Pos = GameObject.Find("FirePlayer").GetComponent<Transform>().Find("FocusPoint").transform.position;
        //        cam.transform.position = player4Pos;//Vector3.MoveTowards(cam.transform.position, player4Pos, 35.0f * Time.deltaTime);
        //        break;
        //}


    }
}
