using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

	public AudioClip[] clips;

	// Use this for initialization
	void Start () {

		//créer audio source sur l'objet;
		//mettre le son en 3d pour le spatial et regler sa porté
		//la caerma capte l'audio don celle sur le player.
		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip =  clips[Random.Range (0, clips.Length)];
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
