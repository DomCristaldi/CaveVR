using UnityEngine;
using System.Collections;

public class HurtVolumeHandler : MonoBehaviour {

    public StatsHandler statsHandlerRef;
    
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Damage(float damageAmount) {
        statsHandlerRef.ChangeHealth(-damageAmount);
    }
}
