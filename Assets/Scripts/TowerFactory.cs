using UnityEngine;
using System.Collections.Generic;
public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower tower;
    [SerializeField] int towerLimit = 5;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        //Todo numTowers = queue size
        int numTowers = towerQueue.Count;

        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
            numTowers++;
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(tower, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform.transform;
        towerQueue.Enqueue(newTower);       
        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {    
        var oldTower = towerQueue.Dequeue();
        oldTower.baseWaypoint.isPlaceable = true;
        oldTower.transform.position = newBaseWaypoint.transform.position;
        newBaseWaypoint.isPlaceable = false;

        towerQueue.Enqueue(oldTower);
    }  
}
