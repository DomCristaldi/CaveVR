using UnityEngine;
using System.Collections;

//This script controls the pointer. It also performs the raycast used to interact with menus, etc.
public class PointerControl : MonoBehaviour 
{
	public Transform pointer;
	GameObject pointer_stick;

	public GameObject current_hit;	//The gameobject that the raycast is currently "hitting".
	public Vector3 current_hit_point;

	LineRenderer line;
	public float texScaleModifier = 10;
	public float texScrollSpeed = 1;
	Transform pbox;
	
	// Use this for initialization
	void Start () {


		pointer = GameObject.Find("PointerRoot").transform;
		pointer_stick = GameObject.Find("Pointer_stick").gameObject;
		line = pointer_stick.GetComponent<LineRenderer>();
		pbox = GameObject.Find("Pointer").transform;
	}
	
	public void Update()
	{
		//Debug.Log (current_hit);
	}
	
	// Update is called once per frame
	public void UpdatePointer (float x, float y, float z, float rotx, float roty, float rotz) 
	{
		// all of these angles seem to want to be inverted.  why?
		rotx=360-rotx;
		roty=360-roty;
		rotz=360-rotz; 
		pointer.localEulerAngles = new Vector3(rotx, roty, rotz);
		pointer.localPosition = new Vector3(x,y,z);
		//Debug.Log (pointer.localPosition);
	}

}
