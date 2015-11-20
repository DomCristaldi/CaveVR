using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SimpleMotor3D), typeof(EnemyShoot))]
public class EnemySphereController : MonoBehaviour {

    private SimpleMotor3D motor;
    private EnemyShoot _shootScript;

    public GameObject AttackLocationPrefab;

    public EnemyShoot shootScript {
        get { return _shootScript; }
    }
    /*
    public Vector3 currentTarget;
    public Vector3 direcToTarget {
        get { return currentTarget - transform.position; }
    }
    */
    public AttackLocation moveLocation;
    public GameObject attackTarget;
    public Vector3 direcToTarget {
        get { return attackTarget.transform.position - transform.position; }
    }

    public float attackWaitTime = 3.0f;

    void Awake() {
        motor = GetComponent<SimpleMotor3D>();
        _shootScript = GetComponent<EnemyShoot>();

        //targetLocation = ((GameObject)Instantiate(AttackLocationPrefab, transform.position, Quaternion.identity)).GetComponent<AttackLocation>();
        //targetLocation.available = false;
    }

	// Use this for initialization
	void Start () {
        AttackFromLocationHandler.singleton.LogEnemy(this);

        //targetLocation = AttackFromLocationHandler.singleton.RequestLocation(targetLocation);

        StartCoroutine(MovementRoutine());
    }

    // Update is called once per frame
    void Update () {
        transform.rotation = Quaternion.LookRotation(attackTarget.transform.position - transform.position,
                                                     Vector3.up);
	}

    private void HandleMovement() {

        if (moveLocation == null) {
            GetNewPosition();
            //targetLocation = AttackFromLocationHandler.singleton.RequestLocation(targetLocation);
        }
        else if (moveLocation != null) {
            motor.desiredPos = moveLocation.transform.position;
        }
    }

    public void GetNewPosition() {
        moveLocation = AttackFromLocationHandler.singleton.RequestLocation(moveLocation);
    }

    private IEnumerator MovementRoutine() {

        while (true) {

            HandleMovement();

            if (motor.atPosition) {
                yield return StartCoroutine(AttackRoutine());
            }
            else {
                yield return null;
            }
        }

    }

    private IEnumerator AttackRoutine() {

        yield return new WaitForSeconds(attackWaitTime / 2.0f);

        shootScript.SpawnProjectile(transform.position, direcToTarget);

        yield return new WaitForSeconds(attackWaitTime / 2.0f);

        GetNewPosition();

        yield break;

    }

}
