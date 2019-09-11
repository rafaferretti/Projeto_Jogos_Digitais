using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private float max_x;
    [SerializeField]
    private float min_x;
    [SerializeField]
    private float max_y;
    [SerializeField]
    private float min_y;
    public Transform player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, min_x, max_x),Mathf.Clamp(player.position.y,min_y,max_y),transform.position.z);
	}
}
