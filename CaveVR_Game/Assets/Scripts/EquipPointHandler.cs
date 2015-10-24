using UnityEngine;
using System.Collections;

public class EquipPointHandler : MonoBehaviour {

    public GameObject equippedItem;

    void Awake() {

    }

	// Use this for initialization
	void Start () {
        MoveEquippedItemToPoint();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void MoveEquippedItemToPoint() {
        if (equippedItem != null) {
            equippedItem.transform.position = transform.position;
            equippedItem.transform.rotation = transform.rotation;

            equippedItem.transform.root.parent = transform;
            //equippedItem.transform
        }
        else {
            Debug.LogWarning("No Item equipped. Please make sure there is an item to equip in the Equipped Item slot");
        }
    }
}
