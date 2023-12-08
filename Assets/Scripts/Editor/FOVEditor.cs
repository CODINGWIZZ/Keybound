using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(enemyMovment))]
public class FOVEditor : Editor
{
    private void OnSceneGUI()
    {
        enemyMovment fow = (enemyMovment)target;
        Handles.color = Color.blue;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.agrorange);

        Vector3 viewAngleA = fow.DirFromAngle(-fow.angle / 2, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.angle / 2, false);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.agrorange);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.agrorange);
    }
}
