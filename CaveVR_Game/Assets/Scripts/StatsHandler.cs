using UnityEngine;
using System.Collections;

public class StatsHandler : MonoBehaviour {

    public float health = 100.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeHealth(float damageAmount) {
        health += damageAmount; 


        if (Mathf.Sign(damageAmount) < 0.0f) {
            DamageEffects();
        }
        if (Mathf.Sign(damageAmount) > 0.0f) {
            HealEffects();
        }
    }

    private void DamageEffects() {

    }

    private void HealEffects() {

    }

}
