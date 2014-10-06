using UnityEngine;
using System.Collections;

public class proyectileHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag != "Player") StartCoroutine("hit");
	}

	IEnumerator hit(){
		rigidbody2D.velocity = Vector2.zero;
		yield return new WaitForSeconds(0.1f);
		Destroy(this.gameObject);
	}
}
