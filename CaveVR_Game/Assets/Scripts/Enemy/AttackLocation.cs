using UnityEngine;
using System.Collections;

public class AttackLocation : MonoBehaviour {

    public bool available = true;

	// Use this for initialization
	void Start () {
        AttackFromLocationHandler.singleton.LogLocation(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
