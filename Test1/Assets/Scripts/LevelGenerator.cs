using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    private const float SpawnDistance = 50f;

    [SerializeField] private Controller player;
    [SerializeField] private Transform LevelStart;
    [SerializeField] private List<Transform> LevelPartList;

    private Vector3 LevelEndPos;

    private void Awake() {
        LevelEndPos = LevelStart.Find("EndPos").position;

        int StartSpawn = 4;
        for (int i = 0; i < StartSpawn; i++)
        {
            SpawnLevel();
        }
    }

    private void Update() {
        if (Vector3.Distance(player.GetPosition(), LevelEndPos) < SpawnDistance)
        {
            SpawnLevel();
        }
    }

    private void SpawnLevel()
    {
        Transform ChosenPart = LevelPartList[Random.Range(0, LevelPartList.Count)];
        Transform LastPartTransform = SpawnLevel(ChosenPart, LevelEndPos);
        LevelEndPos = LastPartTransform.Find("EndPos").position;
    }

    private Transform SpawnLevel(Transform levelPart, Vector3 spawnPosition)
    {
        Transform LevelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return LevelPartTransform;
    }

}
