using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{

    private RESOURCES type;
    public SOURCES sourceType = SOURCES.NONE;

    public GameObject[] prefabs;

    public RESOURCES Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
            var shape = GameObject.Instantiate(prefabs[(int)Type], this.transform);
            shape.transform.localScale = Vector3.one;
            shape.transform.localPosition = Vector3.zero;

            this.GetComponentsInChildren<MeshRenderer>()[0].enabled = false;
            this.GetComponentsInChildren<MeshRenderer>()[1].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        }
    }
}
