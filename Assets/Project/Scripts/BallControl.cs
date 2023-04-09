using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

	private Rigidbody rb;
	private Vector3 vel;
	public float speed = 50.0f;
	public ScoreManager scoreManager;

	void AddForce() {
		float rand = Random.Range (0, 2);
		if (rand < 1) {
			var dir = new Vector3(Random.Range(0.5f, 1), 0, Random.Range(-1, -0.5f));
            rb.AddForce (dir * speed);
		} else {
            var dir = new Vector3(Random.Range(-1, -0.5f), 0, Random.Range(-1, -0.5f));
            rb.AddForce (dir * speed);
		}
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		Invoke ("AddForce", 2);
	}

	public void ResetBall() {
		rb.velocity = new Vector3(0, 0, 0);
		transform.position = new Vector3(0, 0, 0);
        Invoke("AddForce", 1);
    }

	/*void RestartGame() {
		ResetBall ();
		Invoke ("GoBall", 1);
	}*/

	void OnTriggerEnter(Collider coll) 
	{
		if (coll.CompareTag ("Racket")) 
		{
			float xFactor = 20.0f, zFactor = 10.0f;
            float zVel = Mathf.Sign(rb.velocity.z) * (Mathf.Abs(rb.velocity.z) + Mathf.Abs(coll.gameObject.GetComponent<Rigidbody>().velocity.z) / zFactor);
			float xVel = Mathf.Sign(rb.velocity.x) * (Mathf.Abs(rb.velocity.x) + Mathf.Abs(coll.gameObject.transform.position.x - transform.position.x) / xFactor);
            rb.velocity = new Vector3(-xVel, rb.velocity.y, zVel);
		}
		if (coll.CompareTag("Wall"))
		{
			rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -rb.velocity.z);
		}
		if (coll.CompareTag("Left Void"))
		{
			scoreManager.playerTwoScored();
			ResetBall();
		}
        if (coll.CompareTag("Right Void"))
        {
			scoreManager.playerOneScored();
			ResetBall();
        }
    }

}
