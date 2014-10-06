using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	public KeyCode upMove = KeyCode.W;
	public KeyCode downMove = KeyCode.S;
	public KeyCode leftMove = KeyCode.A;
	public KeyCode rightMove = KeyCode.D;

	public KeyCode upAttack = KeyCode.UpArrow;
	public KeyCode downAttack = KeyCode.DownArrow;
	public KeyCode leftAttack = KeyCode.LeftArrow;
	public KeyCode rightAttack = KeyCode.RightArrow;

	public GameObject projectile;

	public float walkAcceleration = 50f;
	public float projectileSpeed = 10f;
	public float projectileEffectFactor = 0.5f;
	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
		moveWithKeys();
		throwProjectile();
	}

	void throwProjectile(){
		if (Input.GetKeyDown(upAttack)) {
			GameObject bullet = (GameObject)Instantiate(projectile, transform.position+Vector3.up*0.5f, Quaternion.Euler(Vector2.zero));
			bullet.rigidbody2D.velocity = Vector2.up*projectileSpeed+rigidbody2D.velocity*projectileEffectFactor;
		}
		if (Input.GetKeyDown(downAttack)) {
			GameObject bullet = (GameObject)Instantiate(projectile, transform.position-Vector3.up*0f, Quaternion.Euler(Vector2.zero));
			bullet.rigidbody2D.velocity = -Vector2.up*projectileSpeed+rigidbody2D.velocity*projectileEffectFactor;
		}
		if (Input.GetKeyDown(leftAttack)) {
			GameObject bullet = (GameObject)Instantiate(projectile, transform.position-Vector3.right*0.5f, Quaternion.Euler(Vector2.zero));
			bullet.rigidbody2D.velocity = -Vector2.right*projectileSpeed+rigidbody2D.velocity*projectileEffectFactor;
		}
		if (Input.GetKeyDown(rightAttack)) {
			GameObject bullet = (GameObject)Instantiate(projectile, transform.position+Vector3.right*0.5f, Quaternion.Euler(Vector2.zero));
			bullet.rigidbody2D.velocity = Vector2.right*projectileSpeed+rigidbody2D.velocity*projectileEffectFactor;
		}
	}

	void moveWithKeys(){
		if (Input.GetKey(upMove)) {
			//transform.Translate(Vector3.up*walkSpeed*Time.deltaTime);
			rigidbody2D.AddForce(Vector3.up*walkAcceleration);
			//rigidbody2D.velocity = Vector2.up*walkSpeed;
		}
		if (Input.GetKey(downMove)) {
			rigidbody2D.AddForce(-Vector3.up*walkAcceleration);
		}
		if (Input.GetKey(leftMove)) {
			rigidbody2D.AddForce(Vector3.left*walkAcceleration);
		}
		if (Input.GetKey(rightMove)) {
			rigidbody2D.AddForce(-Vector3.left*walkAcceleration);
		}
	}

}
