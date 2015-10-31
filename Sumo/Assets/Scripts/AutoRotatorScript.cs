using UnityEngine;
using System.Collections;

public class AutoRotatorScript : MonoBehaviour {

    public float RotationSpeed = 10.0f;
    	
	// Update is called once per frame
	void Update () {

        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);

	}
}
