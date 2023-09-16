using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    public GameObject prefab;
    public float speedRate = 1f;
    public float minHieght = -1.4f;
    public float maxHeight = 1.2f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), speedRate, speedRate);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHieght, maxHeight);     // note that minHeight is -1(nagative) that is mean it's 'up' will be its down
    }

}
