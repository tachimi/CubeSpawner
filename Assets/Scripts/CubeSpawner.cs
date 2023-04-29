using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cube;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var newCube = Instantiate(_cube);
            newCube.transform.position = new Vector3(Random.Range(-14, 14), 20, 3);
        }
    }
}