using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour, IInteractable
{


    public RESOURCES storeType;
    public GameObject ResourcePref;




    public void OnInteraction(Player player)
    {

        //if hand full
        if (player.Hand.childCount > 0)
        {
            // if same type 
            var onHandObj = player.Hand.GetChild(0);
            if (onHandObj.GetComponent<Resource>().Type == storeType)
            {
                var playerResources = GameManager.inistance.playersResources[player.playerNum - 1];

                moveResource(onHandObj,  player.Hand.position, this.transform, () => {
                    SoundManager.inistance.PlayPut(); ///playing sound
                    playerResources.IncreaseResource(storeType);
                    Destroy(onHandObj.gameObject);
                });

                /////////check for the winner

               
                //take from hand
            }
            // if not same
            else
            {
                //nothing
            }
        }
        else
        {
            //if hand empty
            var playerResources = GameManager.inistance.playersResources[player.playerNum - 1];
            if (playerResources.GetResource(storeType) > 0)
            {
                playerResources.ReduceResource(storeType);
                var res = CreateResource(player);
                SoundManager.inistance.PlayTake(); ///playing sound
                 res.transform.parent = player.Hand;
                moveResource(res.transform, this.transform.position, player.Hand, ()=> {

                   
                });
            }
        }
    }

    private GameObject CreateResource(Player player)
    {
        var newResource = GameObject.Instantiate(ResourcePref);
        newResource.transform.position = Vector3.zero;
        // newResource.tag = "Resource";
        //  newResource.layer = 8;
       // newResource.transform.parent = player.Hand;

        //  newResource.transform.position = player.Hand.position;

        newResource.GetComponent<MeshRenderer>().material = this.GetComponent<MeshRenderer>().material;

        newResource.GetComponent<Rigidbody>().isKinematic = true;

        var resourceScript = newResource.GetComponent<Resource>();
        resourceScript.Type = storeType;
        resourceScript.sourceType = SOURCES.STORE;

        return newResource;
    }

    public GameObject CreateResource(GameObject parent)
    {
        Debug.Log("second CreateResource");
        var newResource = GameObject.Instantiate(ResourcePref);
        newResource.transform.parent = null;// parent.transform;
        newResource.transform.position = parent.transform.position;


        newResource.GetComponent<Rigidbody>().isKinematic = false;

        var resourceScript = newResource.GetComponent<Resource>();
        resourceScript.Type = storeType;
        resourceScript.sourceType = SOURCES.PORTAL;

        return newResource;
    }


    private void moveResource(Transform animated, Vector3 startPos, Transform endPos, Action OnDone)
    {
        StartCoroutine(movingIenumerator(animated, startPos, endPos, .1f, OnDone));
    }

    private IEnumerator movingIenumerator(Transform animated, Vector3 startPos, Transform endPos, float time, Action OnDone)
    {
        var i = 0.0;
        var rate = 1.0 / time;
        while (i < 1.0)
        {
            i += Time.deltaTime * rate;
            animated.position = Vector3.Lerp(startPos, endPos.position, (float)i);
            yield return new WaitForEndOfFrame();
        }

        OnDone();
    }

}
