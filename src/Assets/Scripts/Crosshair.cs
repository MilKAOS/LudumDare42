using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {
	
	private AudioSource audioSource;
	private AudioClip shotClip;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
    public void DoAShot()
    {
        shotClip = Resources.Load<AudioClip>(string.Format("{0}", GetShotSoundName()));
        audioSource.clip = shotClip;
        audioSource.Play();
    }
    private string GetShotSoundName()
    {
        var rndSound = UnityEngine.Random.Range(0, 8);
        switch (rndSound)
        {
            case 0:
                return "Sounds/shot01";
            case 1:
                return "Sounds/shot02";
            case 2:
                return "Sounds/shot03";
            case 3:
                return "Sounds/shot04";
            case 4:
                return "Sounds/shot05";
            case 5:
                return "Sounds/shot06";
            case 6:
                return "Sounds/shot07";
            case 7:
                return "Sounds/shot08";
            default:
                throw new System.ArgumentException("sound missing");
        }
    }
    
    // Update is called once per frame
    void Update () {

        Vector3 pos = this.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);

        var target = GameObject.Find("Crosshair");
        target.transform.position = new Vector3(pos.x, pos.y, -9);
		
		if (Input.GetMouseButtonDown(0)) 
		{
			DoAShot();
		}
	}
}
