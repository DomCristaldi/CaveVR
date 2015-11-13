using UnityEngine;
using System.Collections;

public class SimpleMotor3D : MonoBehaviour {

    public enum MovementType {
        Positional = 0,
        Directional = 1,
    }
    public MovementType movementSetting;

    [SerializeField]
    private Vector3 _desiredPos;
    public Vector3 desiredPos {
        get { return _desiredPos; }
        set {
            _desiredPos = value;
            _desiredDirec = Vector3.Normalize(value - transform.position);
        }
    }

    private Vector3 _desiredDirec;
    public Vector3 desiredDirec {
        get { return _desiredDirec; }
        set { desiredPos = value - transform.position; }
    }
    
    public Vector3 truePos {
        get { return _desiredPos; }
    }
    public Vector3 trueDirec {
        get { return desiredDirec; }
    }

    //public Vector3 

    public float moveSpeed = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        HandleMovement();
	}

    private void HandleMovement() {

        switch(movementSetting) {
            case MovementType.Positional:
                transform.position = MovementToPosition();
                break;
            case MovementType.Directional:
                transform.position = MoveInDirection();
                break;
        }

    }

    /// <summary>
    /// Moves self to a position. Returns new position to set the transform to.
    /// </summary>
    private Vector3 MovementToPosition() {
        return Vector3.MoveTowards(transform.position,
                                   truePos,
                                   moveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Moves self constantly in direction. Returns a new position to set the transform to.
    /// </summary>
    /// <returns></returns>
    private Vector3 MoveInDirection() {
        return Vector3.MoveTowards(transform.position,
                                   transform.position + desiredDirec,
                                   moveSpeed * Time.deltaTime);
    }
}
