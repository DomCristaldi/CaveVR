using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SimpleMotor3D), typeof(EnemyShoot))]
public class EnemySphereController : MonoBehaviour {

    private SimpleMotor3D motor;
    private EnemyShoot _shootScript;

    public EnemyShoot shootScript {
        get { return _shootScript; }
    }

    public Vector3 currentTarget;
    public Vector3 direcToTarget {
        get { return currentTarget - transform.position; }
    }

    void Awake() {
        motor = GetComponent<SimpleMotor3D>();
        _shootScript = GetComponent<EnemyShoot>();
    }

	// Use this for initialization
	void Start () {
        motor.desiredPos = Vector3.one;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
