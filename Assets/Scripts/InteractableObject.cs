using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(IInteractable))]
[RequireComponent(typeof(BoxCollider))]
public class InteractableObject : MonoBehaviour
{

    public UnityEvent onActive;

    private int activeForPLayer = -1;
    private Player PLayerRefrence;


    IInteractable mySelf;

    // Use this for initialization
    void Start()
    {
        mySelf = this.GetComponent<IInteractable>();
    }

    // Update is called once per frame
    private void Update()
    {
        switch (activeForPLayer)
        {
            case 1:
                if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Mouse0))
                {
                    onActive.Invoke();
                    mySelf.OnInteraction(PLayerRefrence);
                }
                break;

            case 2:
                if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                {
                    onActive.Invoke();
                    mySelf.OnInteraction(PLayerRefrence);
                }
                break;

            case 3:
                if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                {
                    onActive.Invoke();
                    mySelf.OnInteraction(PLayerRefrence);
                }
                break;

            case 4:
                if (Input.GetKeyDown(KeyCode.Joystick4Button0))
                {
                    onActive.Invoke();
                    mySelf.OnInteraction(PLayerRefrence);
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PLayerRefrence = other.GetComponent<Player>();
            activeForPLayer = PLayerRefrence.playerNum;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PLayerRefrence = null;
            activeForPLayer = -1;
        }
    }
}
