using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower tower;
   // [SerializeField] Color exploredColor;
    //public ok here because it is data
    public bool isExplored = false;
    public bool isPlaceable = true;
    
    public Waypoint exploredFrom;

    Vector2Int gridPos;
    const int gridSize = 10;

  

    public int GetGridSIze()
    {
        return gridSize;
    }
   
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize)
        );    
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isPlaceable)
        {
           // Debug.Log(gameObject.name+ " Is clicked");
            Instantiate(tower, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }

}
