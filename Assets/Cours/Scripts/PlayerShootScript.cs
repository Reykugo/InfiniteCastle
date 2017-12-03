using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour {

	[SerializeField]
	Transform BulletStartPosition;

	[SerializeField]
	private GameObject PrefabBullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			GameObject Bullet = Instantiate<GameObject> (PrefabBullet);
			Bullet.transform.position = BulletStartPosition.position;
			Bullet.GetComponent<Rigidbody> ().AddForce (BulletStartPosition.forward * 1000);
		}

	}
}
