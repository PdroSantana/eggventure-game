using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorChanging : MonoBehaviour
{
    [SerializeField] private Transform anchor;

    public Transform getTrasnform()
	{
        return anchor;
	}
}
