using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {
    public float Period = 5.0f;
	
	void FixedUpdate () {
        transform.Rotate(new Vector3(Random.value, Random.value, Random.value), 360 / Period * Time.deltaTime);
	}
}
