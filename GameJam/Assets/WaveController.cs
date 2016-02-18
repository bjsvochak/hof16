using UnityEngine;
using System.Collections;

/// <summary>
/// Go through each enemy and wait for its delay and then spawn it.  This script is
/// set to trigger only once, then disable itself.
/// 
///  Q:  What is the delay variable on EnemySpawn?
///  A:  delay determines the number of seconds after the previous enemy that the 
///      current enemy will spawn
///      
///  Enemy Spawns example:
///  1. EnemySpawn 1 had a delay of 3.5, so 3.5 seconds pass, then the Object Pool
///     provided will spawn the enemy.
///  2. EnemySpawn 2 had no delay, so enemy 2 will spawn at the same time as enemy 1.
///  3. EnemySpawn 3 had a delay of 1.5, so 1.5 seconds pass (after enemy spawn 2) and
///     enemy 3 will then spawn.
/// </summary>
public class WaveController : MonoBehaviour {

    public Transform player;
    public Transform nodes;
    public EnemySpawn[] enemySpawns;    
    
    // Data that is only ever filled through the Unity Editor
    [System.Serializable]
    public struct EnemySpawn
    {
        public float delay;
        public ObjectPool objectPool;
    }


    void OnTriggerEnter(Collider _coll)
    {
        if(_coll.CompareTag("Player"))
        {
            StartCoroutine(WaveRoutine());

            // IMPORTANT -- the following line prevents this script from triggering more than once
            this.enabled = false;
        }
    }


    IEnumerator WaveRoutine()
    {
        Debug.Log("WavesRoutine started.");

        // Go through each enemy wait for its delay and then spawn it
        for (int currentEnemy = 0; currentEnemy < enemySpawns.Length; ++currentEnemy)
        {
            // wait for the amount of seconds specified on the delay
            yield return new WaitForSeconds(enemySpawns[currentEnemy].delay);

            // get an enemy from the object pool
            GameObject enemy = enemySpawns[currentEnemy].objectPool.GetObject();

            // get the nodes transform
            Transform enemyNodes = nodes.GetChild(currentEnemy);
            int numNodes = enemyNodes.childCount;
            EnemyMove enemyMove = enemy.GetComponent<EnemyMove>();
            enemyMove.nodes = new Transform[numNodes];
            enemyMove.player = player;

            // assign all of the nodes from the nodes transform
            for(int i = 0; i < numNodes; ++i)
                enemyMove.nodes[i] = enemyNodes.GetChild(i);
        }
    }
}
