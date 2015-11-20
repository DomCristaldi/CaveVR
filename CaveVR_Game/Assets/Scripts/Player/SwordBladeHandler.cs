using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class SwordBladeHandler : MonoBehaviour {

    public Collider bladeCollider;

    void OnTriggerEnter(Collider other) {


        ProjectileHandler projHandler = other.transform.root.GetComponent<ProjectileHandler>();

        if (projHandler != null) {
            projHandler.GetComponent<SimpleMotor3D>().desiredDirec *= -1.0f;
            //Debug.Log(projHandler.GetComponent<SimpleMotor3D>().desiredDirec);
        }
    }

    void Awake() {
        bladeCollider = GetComponent<BoxCollider>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
