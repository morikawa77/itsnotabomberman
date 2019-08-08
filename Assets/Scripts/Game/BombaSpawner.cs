using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaSpawner : MonoBehaviour
{
    public GameObject bomb;
    public int firePower = 1;
    int numberOfBomb = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && numberOfBomb >= 1)
        {
            Vector2 spawnPos = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
            var newBomb = Instantiate(bomb, spawnPos, Quaternion.identity) as GameObject;
            newBomb.GetComponent<Bomba2>().firePower = firePower;
            numberOfBomb--;
            Invoke("AddBomb", 1);
        }
    }

    public void AddBomb()
    {
        numberOfBomb++;
    }
}
