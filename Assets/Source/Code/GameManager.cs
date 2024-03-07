using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool canDrag = true;
    private int startIndex = 0;

    private int currentIndex;
    public  List<GameObject> particleVFXs;
    [SerializeField] private List<GameLevel> levels;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        currentIndex = startIndex;
        levels[currentIndex].gameObject.SetActive(true);
        
    }

    public void CheckLevelUp()
    {
        canDrag = false;
        GameObject explosion = Instantiate(particleVFXs[Random.Range(0,particleVFXs.Count)], transform.position, transform.rotation);
        Destroy(explosion, .75f);
        Invoke(nameof(NextLevel),1.0f);
    }

    void NextLevel()
    {
        levels[currentIndex].gameObject.SetActive(false);
        currentIndex++;
        if (currentIndex >= 3)
        {
            currentIndex = startIndex;
            canDrag = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            levels[currentIndex].gameObject.SetActive(true);
            canDrag = true;
        }
        
    }
    
    
    // drag obj
    public ObjectMoveByDrag selectedObject;
    Vector3 offset;
    void Update()
    {
        if(!canDrag) return;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject && targetObject.GetComponent<ObjectMoveByDrag>() != null)
            {
                selectedObject = targetObject.GetComponent<ObjectMoveByDrag>();
                selectedObject.PickUp();
                offset = selectedObject.transform.position - mousePosition;
            }
        }
        if (selectedObject)
        {
            selectedObject.transform.position = mousePosition + offset;
        }
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            if (selectedObject)
            {
                selectedObject.CheckOnMouseUp();
            }
            selectedObject = null;
        }
    }
    
    

    public void EnableDrag()
    {
        canDrag = true;
    }
    public GameLevel GetCurLevel()
    {
        return levels[currentIndex];
    }
}