using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; }}

    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }

    void Start()
    {
        if (gridManager != null) {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
            if (!isPlaceable)
            {
                gridManager.BlocNode(coordinates);
            }
        }
    }

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
