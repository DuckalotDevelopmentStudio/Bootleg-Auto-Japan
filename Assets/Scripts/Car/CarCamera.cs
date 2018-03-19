using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCamera : MonoBehaviour {

	public GameObject fp;
	public GameObject tp;

	private bool firstPerson = false;

	void Start(){
		fp.SetActive(firstPerson);
		tp.SetActive(!firstPerson);
	}

	void Update () {
		if(Input.GetKeyDown("c")){
			firstPerson = !firstPerson;
		}
		fp.SetActive(firstPerson);
		tp.SetActive(!firstPerson);
	}
}
