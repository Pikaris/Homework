using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject BulletPrefab;

    Transform BulletTransform;

    Transform FireTransform;

    public float SpawnInterval = 1.0f;

    public float Spawn_Max_X = 10.0f;
    public float Spawn_Min_X = -10.0f;


    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private void Awake()
    {
        BulletTransform = GetComponent<Transform>();
    }

    void BulletSpawn()
    {
        Instantiate(BulletPrefab, GetSpawnPosition(), BulletPrefab.transform.rotation);
        Debug.Log($"{BulletPrefab.transform.rotation.z}");
    }

    Vector3 GetSpawnPosition()
    {
        Vector3 SpawnPosition = transform.position;
        SpawnPosition.x = Random.Range(Spawn_Min_X, Spawn_Max_X);
        return SpawnPosition;
    }

    IEnumerator SpawnCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(SpawnInterval);
            BulletSpawn();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 p0 = transform.position + Vector3.left * Spawn_Min_X;
        Vector3 p1 = transform.position + Vector3.left * Spawn_Max_X;
        Gizmos.DrawLine(p0, p1);
    }
}
