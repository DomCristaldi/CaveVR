using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(EnemySphereController))]
public class EnemySphereController_Editor : Editor {

    EnemySphereController self;

    Transform targetTf;

    void OnGUI() {
        if (self == null) {
            self = (EnemySphereController)target;
        }
    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        self = (EnemySphereController)target;

        targetTf = (Transform)EditorGUILayout.ObjectField(targetTf,
                                                         typeof(Transform),
                                                         true);

        //self = (EnemySphereController)target;

        

        if (GUILayout.Button("Spawn Projectile")) {
            self.shootScript.SpawnProjectile(self.transform.position,
                                             targetTf.transform.position - self.transform.position);
        }
    }

    void OnSceneGUI() {

        self = (EnemySphereController)target;

        if (targetTf != null) {
            Debug.DrawRay(self.transform.position,
                          targetTf.transform.position - self.transform.position,
                          Color.red);
        }
    }

}
