using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCloner : MonoBehaviour
{
    [SerializeField] GameObject currentTile;
    [SerializeField] GameObject prefab;
    private GameObject clone;
    System.Random rand = new System.Random();
    public static List<GameObject> Tiles = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        clone = currentTile;
        for (int i = 0; i < 50; i++)
        {
            spawnBlock();
        }
    }

    void spawnBlock()
    {       
        int num = random();
        clone = Instantiate(prefab, clone.transform.GetChild(num).position, Quaternion.Euler(0,45,0));
        clone.transform.SetParent(transform);
        

    }



    int random()
    {
        int num = rand.Next(0,2);
        return num;
    }

    


    private void Update()
    {
        if (TileManager.spawnTile)
        {
            spawnBlock();
            TileManager.spawnTile = false;
        }
        
    }

    
}
