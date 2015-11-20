using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour {

    public int health = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Damage(int amountOfHits) {
        health -= amountOfHits;

        CheckIfDead();
    }

    private void CheckIfDead() {
        if (health <= 0) {
            //TODO: KILL CONDITION
        }
    }
}
