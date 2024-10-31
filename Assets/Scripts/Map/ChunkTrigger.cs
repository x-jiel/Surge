using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    MapController mapcontroller;
    public GameObject targetMap;

    void Start()
    {
        mapcontroller = FindObjectOfType<MapController>();
    }



    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            mapcontroller.currentChunk = targetMap;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(mapcontroller.currentChunk == targetMap)
            {
                mapcontroller.currentChunk = null;
            }
        }
    }
}
