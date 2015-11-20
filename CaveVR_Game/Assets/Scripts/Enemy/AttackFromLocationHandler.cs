using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class AttackFromLocationHandler : MonoBehaviour {

    public static AttackFromLocationHandler singleton;

    public List<AttackLocation> locations;

    public List<EnemySphereController> enemies;

    public GameObject enemyTarget;

    private System.Random randGen;

    void Awake() {
        if (singleton == null) {
            singleton = this;
        }

        if (locations == null) {
            locations = new List<AttackLocation>();
        }

        if (enemies == null) {
            enemies = new List<EnemySphereController>();
        }

        randGen = new System.Random();
    }

	// Use this for initialization
	void Start () {
	    foreach (EnemySphereController enemy in enemies) {
            enemy.attackTarget = enemyTarget;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool LogLocation(AttackLocation loc) {
        if (!locations.Contains(loc)) {
            locations.Add(loc);
            return true;
        }

        return false;
    }

    public bool LogEnemy(EnemySphereController enemy) {
        if (!enemies.Contains(enemy)) {
            enemies.Add(enemy);
            return true;
        }

        return false;
    }

    public AttackLocation RequestLocation(params AttackLocation[] exclude) {
        List<AttackLocation> possibleLocations = locations.Where<AttackLocation>(x => x.available && !exclude.Contains(x)).ToList<AttackLocation>();

        AttackLocation foundLoc = possibleLocations[Random.Range(0, possibleLocations.Count - 1)];

        foundLoc.available = false;

        return foundLoc;
    }

    public AttackLocation RequestLocation(AttackLocation currentLoc, params AttackLocation[] exclude) {

        AttackLocation foundLoc = currentLoc;

        exclude.ToList().Add(currentLoc);

        /*
        AttackLocation foundLoc = (AttackLocation) (locations.Except<AttackLocation>(exclude)
                                                            .Where<AttackLocation>(x => x.available));
        */
        List<AttackLocation> possibleLocations = locations.Where<AttackLocation>(x => x.available && !exclude.Contains(x)).ToList<AttackLocation>();

        
        if (possibleLocations != null & possibleLocations.Count > 0) {
            int index = randGen.Next(possibleLocations.Count);
            foundLoc = possibleLocations[index];


            foundLoc.available = false;

            if (currentLoc != null) {
                currentLoc.available = true;
            }
            return foundLoc;
        }

        //AttackLocation foundLoc = ElementAtOrDefault(Random.Range(0, possibleLocations.Count - 1), currentLoc);


        return currentLoc;
    }


}


