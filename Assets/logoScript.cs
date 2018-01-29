using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logoScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitForTime(.5f));
       
	}

    private IEnumerator WaitForTime(float v)
    {
        yield return new WaitForSeconds(v);
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
