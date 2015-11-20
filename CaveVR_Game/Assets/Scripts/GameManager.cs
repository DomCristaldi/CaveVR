using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AttackFromLocationHandler))]
public class GameManager : MonoBehaviour {

    public static GameManager singleton;

    private AttackFromLocationHandler _attackLocationHandler;
    public AttackFromLocationHandler attackLocationHandler {
        get { return _attackLocationHandler; }
    }

    void Awake() {
        if (singleton == null) {
            singleton = this;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
