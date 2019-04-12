using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

	public float degSecond_VERT;
	public float degSecond_HORIZ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.right * Time.deltaTime * degSecond_VERT);
		transform.Rotate (Vector3.up * Time.deltaTime * degSecond_HORIZ);

	}
}
