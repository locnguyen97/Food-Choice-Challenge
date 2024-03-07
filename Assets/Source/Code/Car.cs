using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Car : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GameManager.Instance.canDrag)
        {
            CheckAndMove();
        }
    }

    void CheckAndMove()
    {
        
        
    }
    
    public void Move(Transform target,bool done)
    {
        StartCoroutine(MoveToTarget(target,done));
    }

    IEnumerator MoveToTarget(Transform target,bool done)
    {
        var dis = Vector3.Distance(target.position , transform.position);
        var dir = target.position - transform.position;
        while (dis > 0.1f)
        {
            yield return new WaitForEndOfFrame();
            transform.position = transform.position + dir * 0.013f;
            dis = Vector3.Distance(target.position , transform.position);
        }

        transform.position = target.position;
        transform.rotation = Quaternion.Euler(0,0,0);
        CheckOnMoveDone(done);
        if (done)
        {
            target.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
            target.GetComponent<SpriteRenderer>().enabled = true;
        }
        //GameManager.Instance.GetCurLevel().RemoveObject(gameObject);
    }

    void CheckOnMoveDone(bool done)
    {
        
    }
}
