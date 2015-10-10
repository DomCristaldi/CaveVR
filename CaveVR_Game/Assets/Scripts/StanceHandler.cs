using UnityEngine;
using System.Collections.Generic;

public class StanceHandler : MonoBehaviour {

    [System.Serializable]
    public class StanceInfo {
        public StanceDetectionVolumeHandler dectectVolume;
        public bool isInVolume = false;

        public StanceInfo() {

        }

        public bool CheckIsInVolume(Vector3 pos) {
            isInVolume = dectectVolume.CheckContains(pos);
            return isInVolume;
        }
    }

    public Transform weaponTf;

    //public List<StanceDetectionVolumeHandler> stanceDetectionVolumes;
    public List<StanceInfo> stanceInfos;

    public StanceInfo currentStance;

    void OnDisable() {
        currentStance = null;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdateCurrentStance();
	}

    
    //UPDATE THE STATE OF ALL STANCES AND ASSIGN THE CURRENT STANCE
    private void UpdateCurrentStance() {
        if (stanceInfos == null) { return; }

        foreach (StanceInfo sI in stanceInfos) {
            if (sI.CheckIsInVolume(weaponTf.position) == true) {
                currentStance = sI;
            }

        }

    }
}
