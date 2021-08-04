using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

	[SerializeField]
	GameObject bullet;
	public GameObject gate;
	float fireRate;
	float nextFire;

	// Use this for initialization
	void Start()
	{
		fireRate = 1.5f;
		nextFire = Time.time;
	}

	// Update is called once per frame
	void Update()
	{
		CheckIfTimeToFire();
	}

	void CheckIfTimeToFire()
	{
		if (Time.time > nextFire)
		{
			Instantiate(bullet, transform.position, Quaternion.identity);
			nextFire = Time.time + fireRate;
		}

	}
	private void OnTriggerEnter2D(Collider2D other )
	{
		if (other.transform.tag == "Bullett")
		{
			Debug.Log("enemy's dead ");
			Destroy(gameObject);
		}
		if (other.transform.tag == "Bullett")
		{
			gate.SetActive(true);
			print("colliinggg");
		}
	}
}
	
	
