using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public Vector2 speed = new Vector2(2,0);
    public Rigidbody2D rbBullet;

	// Use this for initialization
	void Start () {
        rbBullet = GetComponent<Rigidbody2D>();
        rbBullet.velocity = speed * this.transform.localScale.x;
        Destroy(gameObject,1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
