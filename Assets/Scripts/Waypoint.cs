using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] GameObject tower;
    void OnMouseDown() {
        if (isPlaceable) {
            print(transform.name);
            Instantiate(tower, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}
