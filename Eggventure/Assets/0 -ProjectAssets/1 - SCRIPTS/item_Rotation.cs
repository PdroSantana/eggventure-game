using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_Rotation : MonoBehaviour
{
    [SerializeField] private float rotSpeed = 30;
    [SerializeField] private Transform item_transform;
    void FixedUpdate()
    {
        transform.Rotate(item_transform.forward * Time.fixedDeltaTime * rotSpeed);
    }
}
