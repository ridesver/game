using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsScript : MonoBehaviour {

    private BoxCollider2D bounds;
    private CameraController theCamera;

	// Use this for initialization
	void Start () {
	//создание ограничения на обзор камеры, чтобы оно не выходило за рамки карты
        bounds = GetComponent<BoxCollider2D>();
        theCamera = FindObjectOfType<CameraController>();
        theCamera.SetBounds(bounds);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
