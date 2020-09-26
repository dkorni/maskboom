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
            Handles.color = Color.red;
            Handles.DrawWireDisc(player.transform.position, Vector3.down, enemySpawner.MinRadius);
            Handles.color = Color.blue;
            Handles.DrawWireDisc(player.transform.position, Vector3.down, enemySpawner.MaxRadius);
        }
    }
}
