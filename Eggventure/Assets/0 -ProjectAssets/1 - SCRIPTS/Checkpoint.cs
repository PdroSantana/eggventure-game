using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    [SerializeField] private Transform checkpointSpawn;
    [SerializeField] private GameObject flag;
    [SerializeField] private GameObject actvParticles;
    public Transform getSpawnPos()
    {
        flag.SetActive(true);
        return checkpointSpawn;
    }
}
