using System.Collections.Generic;
using UnityEngine;

public class SortingScript : MonoBehaviour
{
    public GameObject prefab;
    public int numberOfObjects = 10; 

    private List<GameObject> objectsArray = new List<GameObject>();

    void Start()
    {
        GenerateObjects();
        SortObjects();
        VisualizeObjects();
    }

    void GenerateObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject obj = Instantiate(prefab, new Vector3(i * 2, Random.Range(1f, 5f), 0), Quaternion.identity);
            obj.transform.localScale = new Vector3(Random.Range(1f, 3f), 1, 1);
            obj.GetComponent<Renderer>().material.color = Random.ColorHSV();
            objectsArray.Add(obj);
        }
    }

    void SortObjects()
    {
        objectsArray.Sort((a, b) => a.transform.position.y.CompareTo(b.transform.position.y));
    }

    void VisualizeObjects()
    {
        for (int i = 0; i < objectsArray.Count; i++)
        {
            objectsArray[i].transform.position = new Vector3(i * 2, objectsArray[i].transform.position.y, 0);
        }
    }
}
