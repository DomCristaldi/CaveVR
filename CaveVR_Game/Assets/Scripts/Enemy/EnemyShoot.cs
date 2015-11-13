using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

    public GameObject projectile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnProjectile(Vector3 position, Vector3 direction) {

        GameObject tempProj = (GameObject)Instantiate(projectile, position, Quaternion.LookRotation(direction, Vector3.up));
        tempProj.GetComponent<ProjectileHandler>().Setup(direction);
    }
}
