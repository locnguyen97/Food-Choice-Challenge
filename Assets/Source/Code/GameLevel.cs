using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameLevel : MonoBehaviour
{
    public List<GameObject> gameObjectsPoint;
    public List<GameObject> gameObjectsTg;
    [SerializeField] private Transform parentListObjPoint;
    [SerializeField] private Transform parentListObjTg;
    private bool canCheck = true;
    public void Start()
    {
        canCheck = true;
        foreach (Transform tr in parentListObjPoint)
        {
            if(tr.gameObject.activeSelf)
                gameObjectsPoint.Add(tr.gameObject);
        }
        foreach (Transform tr in parentListObjTg)
        {
            if(tr.gameObject.activeSelf)
                gameObjectsTg.Add(tr.gameObject);
        }
    }

    public void RemoveObject(GameObject obj)
    {
        gameObjectsPoint.Remove(obj);
        if (canCheck)
        {
            if (gameObjectsPoint.Count == 0)
            {
                GameManager.Instance.CheckLevelUp();
                canCheck = false;
            }
        }
    }
    


}