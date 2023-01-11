using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; }}

    GridManager gridManager;
    PathFinder pathFinder;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<PathFinder>();
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
        if (gridManager.GetNode(coordinates).isWalkable && !pathFinder.WillBlocPath(coordinates)) {
            bool isPlaced = towerPrefab.createTower(towerPrefab, transform.position);
            isPlaceable = isPlaced;
            gridManager.BlocNode(coordinates);
        }
    }
}
