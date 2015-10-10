using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class StanceDetectionVolumeHandler : MonoBehaviour {

    public enum Side {
        Left,
        Right,
    }

    public enum StanceType {
        Roof,
        Ox,
        Plow,
        Fool
    }

    public BoxCollider col;

    public Side thisSide;
    public StanceType thisStanceType;



    void Awake() {
        col = GetComponent<BoxCollider>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool CheckContains(Vector3 pos) {
        return col.bounds.Contains(pos);
    }
}
