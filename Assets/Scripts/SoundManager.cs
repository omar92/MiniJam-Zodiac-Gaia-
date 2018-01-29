using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioClip takeResourceStore;
    public AudioClip putResourceStore;
    public AudioClip timer;

    public static SoundManager inistance = null;
    public AudioClip[] x;

    AudioSource audioSource = null;



    void Awake(){
        inistance = this;
        audioSource = this.GetComponent<AudioSource>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public  void PlayTake()
    {
        audioSource.PlayOneShot(takeResourceStore);
        Debug.Log("takeResourceStore");
       // audioSource.Play();
    }

    public  void PlayPut()
    {
        audioSource.PlayOneShot(putResourceStore);
        Debug.Log("putResourceStore");
    }

    public void PlayTimer()
    {
        audioSource.PlayOneShot(timer);
        Debug.Log("timer");
    }

}
