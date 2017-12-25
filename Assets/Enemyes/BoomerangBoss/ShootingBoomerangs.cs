using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBoomerangs : MonoBehaviour {
    public GameObject boomerang;

    private void Start()
    {
        Instantiate(boomerang, transform.position, transform.rotation);
	}
}
