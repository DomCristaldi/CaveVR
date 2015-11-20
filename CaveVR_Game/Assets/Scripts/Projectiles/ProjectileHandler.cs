using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SimpleMotor3D))]
public class ProjectileHandler : MonoBehaviour {

    SimpleMotor3D motor;

    public Vector3 moveDirection;
    public float moveSpeed;

    private bool isSetUp = false;

    public float destructionHeight = -5.0f;

    void Awake() {
        motor = GetComponent<SimpleMotor3D>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isSetUp) {

            Debug.DrawRay(transform.position, moveDirection, Color.red);
	    }

        DestroyProtocol();
    }

    public void Setup(Vector3 direction) {
        //moveDirection = direction.normalized;
        //motor.desiredDirec = direction;
        motor.desiredPos = transform.position + direction;

        isSetUp = true;
    }

    private void HandleMovement() {
        //transform.position = MovementProtocol();

        //motor.desiredDirec = moveDirection;

    }

    /*
    private Vector3 MovementProtocol() {
        return Vector3.MoveTowards(transform.position,
                                   transform.position + (moveDirection * moveSpeed),
                                   moveSpeed * Time.time);
    }
    */

    private void DestroyProtocol() {
        if (transform.position.z < destructionHeight) {
            Destroy(gameObject);
        }
    }
}
