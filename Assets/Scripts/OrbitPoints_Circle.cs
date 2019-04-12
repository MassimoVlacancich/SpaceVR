using UnityEngine;
using System.Collections;

public class OrbitPoints_Circle : MonoBehaviour {

    public int numberOfPoints;
    public bool clockWise;
	// Use this for initialization
	void Start () {
        Vector3 origin = GameObject.Find("Center").transform.position;
        float radius = Vector3.Distance(origin, transform.position);
        Debug.Log(origin);
        int pointNum = Random.Range(0, numberOfPoints-1);

        foreach (Transform child in transform)
        {
            var i = (pointNum * 1.0f) / numberOfPoints;
            var angle = i * Mathf.PI * 2;
            var x = 0.0f;
            var z = 0.0f;
            if (clockWise)
            {
                x = Mathf.Sin(angle) * radius;
                z = Mathf.Cos(angle) * radius;
            }
            else
            {
                x = Mathf.Cos(angle) * radius;
                z = Mathf.Sin(angle) * radius;
            }

            Vector3 vectorPosition = new Vector3(x, 0.0f, z);
            var pos = vectorPosition + origin;
            child.transform.position = pos;
            child.transform.LookAt(origin);

            if(pointNum == (numberOfPoints - 1))
            {
                pointNum = 0;
            }
            else
            {
                pointNum++;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
