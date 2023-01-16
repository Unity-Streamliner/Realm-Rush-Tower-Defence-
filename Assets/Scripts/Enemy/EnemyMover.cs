using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{   
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    List<Node> path = new List<Node >();
    Enemy enemy;
    GridManager gridManager;
    PathFinder pathFinder;

    void OnEnable()
    {
        ReturnToStart();
        RecalculatePath(true);
    }

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<PathFinder>();  
    }

    void RecalculatePath(bool resetPath)
    {
        StopAllCoroutines();
        path.Clear();
        if (resetPath)
        {
            path =  pathFinder.GetNewPath();
        } else {
            path =  pathFinder.GetNewPath(gridManager.GetCoordinatesFromPosition(transform.position));
        } 
        StartCoroutine(FollowPath());
    }

    void ReturnToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathFinder.StartCoordinates); 
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath() 
    {
        for (int i = 1; i < path.Count; i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates ); 
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }
}