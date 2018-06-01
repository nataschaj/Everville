using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;



class SpawnCoins : MonoBehaviour
{
    public GameObject coinsPrefab;
    public Vector2 center;
    public Vector2 size;
    public float spawnTime = 5f;
    public float spawnDelay = 3f;
    private TimerScript timeScript;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Spawn Started");
            InvokeRepeating("Spawn", spawnDelay, spawnTime);
            //if (timeScript.timer > 0)
            //{
            //    Debug.Log("Spawn Started");
            //    InvokeRepeating("Spawn", spawnDelay, spawnTime);
            //}
            //else
            //{
            //    Debug.Log("Spawn could not start");
            //    CancelInvoke("Spawn");
            //}
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Spawn Stopped");
            CancelInvoke("Spawn");
        }

    }

    public void Spawn()
    {
        Vector2 pos = center + new Vector2(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2));
        Instantiate(coinsPrefab, pos, Quaternion.identity);
    }

    //public void StopSpawn()
    //{
    //    CancelInvoke("Spawn"); 
    //}

    //public GameObject treePrefab;
    //[SyncVar]
    //public int numLeaves;
    //public void Spawn()
    //{
    //    GameObject tree = (GameObject)Instantiate(treePrefab, transform.position, transform.rotation);

    //    tree.GetComponent<SpawnCoins>().numLeaves = Random.Range(10, 200);
    //    NetworkServer.Spawn(tree);
    //}

}
