using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Portals : MonoBehaviour, IInteractable
{
    private static int ResourcesNum = 0;

    public static int MaxResourcesNum = 6;

    public GameObject[] floatingPortal;
    Queue<GameObject> overResources = new Queue<GameObject>();
    // GameObject[] overResources = new 
    //public GameObject[] stores;
    public Store WaterStore;
    public Store EarthStore;
    public Store FireStore;
    public Store WoodStore;


    private GameObject inRangeOpject = null;

    void Start()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Resource") && other.transform.parent == null)
        {

            if (inRangeOpject == other.gameObject)
            {
                inRangeOpject = null;
            }

            other.transform.position = RandomPortal(floatingPortal).transform.position;

            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Resource"))
        {
            inRangeOpject = other.gameObject;
        }
    }

    public void OnInteraction(Player player)
    {
        //if hand full
        if (player.Hand.childCount > 0)
        {
            // if (ResourcesNum <= MaxResourcesNum)
            {
                // if same type 


                var onHandObj = player.Hand.GetChild(0);
                //  onHandObj.GetComponent<BoxCollider>().enabled = false;
                moveResource(onHandObj, player.Hand.position, this.transform.position + Vector3.up, (t) =>
                  {
                      t.parent = null;
                      t.position = this.transform.position;
                      t.GetComponent<Rigidbody>().isKinematic = false;
                      t.GetComponent<BoxCollider>().enabled = true;
                      ResourcesNum++;

                      if (ResourcesNum > MaxResourcesNum)
                      {
                          //add the new resource to overflow resources 
                          t.gameObject.SetActive(false);
                          overResources.Enqueue(t.gameObject);
                      }

                  });

                if (onHandObj.GetComponent<Resource>().sourceType == SOURCES.STORE)
                {
                    player.resetTime();
                }
            }
        }
        else
        {

            if (inRangeOpject != null)
            {
                inRangeOpject.transform.parent = player.Hand;
                // inRangeOpject.GetComponent<BoxCollider>().enabled = false;
                moveResource(inRangeOpject.transform, inRangeOpject.transform.position, player.Hand, (t) =>
                {

                    t.GetComponent<Rigidbody>().rotation = Quaternion.Euler(Vector3.zero);
                    t.transform.position = player.Hand.position;
                    t.GetComponent<Resource>().sourceType = SOURCES.PORTAL;
                    t.GetComponent<BoxCollider>().enabled = true;
                    t.GetComponent<Rigidbody>().isKinematic = true;
                    t = null;

                    ResourcesNum--;
                    if (overResources.Count > 0 /*&& ResourcesNum <= MaxResourcesNum*/)
                    {

                        var reservedObject = overResources.Dequeue();
                        reservedObject.SetActive(true);
                        reservedObject.transform.position = RandomPortal(floatingPortal).transform.position;
                    }

                });



            }

            //try catch
        }


    }


    //public void ThrowResources(Resource resources)
    public void ThrowResources(RESOURCES resources)
    {
        // if (ResourcesNum <= MaxResourcesNum+15)
        {
            GameObject res = null;

            switch (resources)
            {
                case RESOURCES.WATER:
                    res = WaterStore.CreateResource(RandomPortal(floatingPortal));
                    break;

                case RESOURCES.EARTH:
                    res = EarthStore.CreateResource(RandomPortal(floatingPortal));
                    break;

                case RESOURCES.WOOD:
                    res = WoodStore.CreateResource(RandomPortal(floatingPortal));
                    break;

                case RESOURCES.FIRE:
                    res = FireStore.CreateResource(RandomPortal(floatingPortal));
                    break;
            }
            ResourcesNum++;

            if (ResourcesNum > MaxResourcesNum)
            {
                //add the new resource to overflow resources 
                res.SetActive(false);
                overResources.Enqueue(res);
            }

        }
        //resources[i].sourceType = SOURCES.PORTAL;
        //}
    }


    private GameObject RandomPortal(GameObject[] upperPortals)
    {
        int index = Random.Range(0, upperPortals.Length);
        GameObject currentPortal = upperPortals[index];
        return currentPortal;
    }



    private void moveResource(Transform animated, Vector3 startPos, Transform endPos, System.Action<Transform> OnDone)
    {
        StartCoroutine(movingIenumerator(animated, startPos, endPos, 0.1f, OnDone));
    }

    private IEnumerator movingIenumerator(Transform animated, Vector3 startPos, Transform endPos, float time, System.Action<Transform> OnDone)
    {
        /*
        while (true)
        {
            animated.position = Vector3.Lerp(startPos, endPos, 1000f);

            yield return new WaitForEndOfFrame();
        }
            */
        var i = 0.0;
        var rate = 1.0 / time;
        while (i < 1.0)
        {
            i += Time.deltaTime * rate;
            animated.position = Vector3.Lerp(startPos, endPos.position, (float)i);
            yield return new WaitForEndOfFrame();
        }

        OnDone(animated);
    }
    private void moveResource(Transform animated, Vector3 startPos, Vector3 endPos, System.Action<Transform> OnDone)
    {
        StartCoroutine(movingIenumerator(animated, startPos, endPos, 0.1f, OnDone));
    }

    private IEnumerator movingIenumerator(Transform animated, Vector3 startPos, Vector3 endPos, float time, System.Action<Transform> OnDone)
    {
        /*
        while (true)
        {
            animated.position = Vector3.Lerp(startPos, endPos, 1000f);

            yield return new WaitForEndOfFrame();
        }
            */
        var i = 0.0;
        var rate = 1.0 / time;
        while (i < 1.0)
        {
            i += Time.deltaTime * rate;
            animated.position = Vector3.Lerp(startPos, endPos, (float)i);
            yield return new WaitForEndOfFrame();
        }

        OnDone(animated);
    }

}
