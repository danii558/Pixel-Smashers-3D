using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] _prefabEnemy;
    public Transform _pos;

    [Header("Spawner Settings")]
    public float _timeSpawn;
    public int _allObjectSpawn;

    private void Start()
    {
        //_timeSpawn = Random.Range(1, 7); | Random time Spawn
        StartCoroutine(SpawnerObject());
    }

    IEnumerator SpawnerObject() 
    {
        for(int i = 0; i < _allObjectSpawn; i++)
        {
            Instantiate(_prefabEnemy[Random.Range(0, 4)], _pos.position, _pos.rotation); //| Random spawn enemy
            //Instantiate(_prefabEnemy[1], _pos.position, _pos.rotation);
            yield return new WaitForSeconds(_timeSpawn);
        }
        
    }
}