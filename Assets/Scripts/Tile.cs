using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; }}

    void OnMouseDown() {
        if (isPlaceable) {
            print(transform.name);
            if (towerPrefab.createTower(towerPrefab, transform.position)) 
            {
                isPlaceable = false;
            }
        }
    }
}
