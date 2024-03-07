using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectMoveByDrag : MonoBehaviour
{
    [SerializeField] List<GameObject> particleVFXs;

    private Vector3 startPos;
    private Transform target;

    private void Start()
    {
       //transform.rotation = new Quaternion(0,0,Random.Range(0,360),0);
    }

    private void OnEnable()
    {
        startPos = transform.position;
    }

    public void PickUp()
    {
        //transform.rotation = new Quaternion(0,0,0,0);
    }

    public void CheckOnMouseUp()
    {
        //transform.position = startPos;
        if (target)
        {
            if (target.GetComponent<SpriteRenderer>().sprite.name == GetComponent<SpriteRenderer>().sprite.name)
            {
                target.GetComponent<SpriteRenderer>().color =new Color(255,255,255);
                GameObject explosion = Instantiate(particleVFXs[Random.Range(0,particleVFXs.Count)], transform.position, transform.rotation);
                Destroy(explosion, .75f);
                transform.gameObject.SetActive(false);
                GameManager.Instance.GetCurLevel().RemoveObject(gameObject);
                Destroy(gameObject);
            }
            else
            {
                transform.position = startPos;
            }
        }
        else
        {
            transform.position = startPos;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<SpriteRenderer>().sprite.name == GetComponent<SpriteRenderer>().sprite.name)
        {
            target = collision.transform;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<SpriteRenderer>().sprite.name == GetComponent<SpriteRenderer>().sprite.name)
        {
            target = null;
        }
    }
}
