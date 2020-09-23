using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemySpawner), true)]
public class EnemySpawnerEditor : Editor
{
    void OnSceneGUI()
    {
        var enemySpawner = (EnemySpawner) target;
        var player = enemySpawner.Player;

        if (player != null)
        {
            Handles.DrawWireArc(player.transform.position, Vector3.down, Vector3.down, 360, enemySpawner.MinRadius);
        }
    }
}
