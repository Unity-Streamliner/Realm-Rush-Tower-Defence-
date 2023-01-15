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
        bool willBlocPath = pathFinder.WillBlocPath(coordinates);
        if (gridManager.GetNode(coordinates).isWalkable && !willBlocPath) 
        {
            bool isSuccessful = towerPrefab.createTower(towerPrefab, transform.position);
            if (isSuccessful)
            {
                gridManager.BlocNode(coordinates);
                pathFinder.NotifyReceivers();
            }
        }
    }
}
