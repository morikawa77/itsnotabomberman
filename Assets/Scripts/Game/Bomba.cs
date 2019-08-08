using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float timeToExplode, currentTimeToExlode;
    public int power;
    public Transform[] angles;
    public Explosao explosaoPrefab;
    public float distanciaExplosao;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeToExlode += Time.deltaTime;

        if (currentTimeToExlode > timeToExplode)
            Explode();
    }

    public void Explode()
    {
        int i = 1;
        int currentPower = power;
        foreach (Transform side in angles)
        {
            i++;

            RaycastHit2D hitInfo = Physics2D.Linecast(transform.position, side.position);
            if (hitInfo.collider != null)
            {
                currentPower = 0;
            }
            else
            {
                currentPower = power;
            }

            //up,down,left,right
            Vector2 direcao = new Vector2();
            string posicao = "vertical";

            if (i == 1) direcao = Vector2.up;
            else if (i == 2) direcao = Vector2.down;
            else if (i == 3) direcao = Vector2.left;
            else if (i == 4) direcao = Vector2.right;

            if (i == 3 || i == 4)
                posicao = "horizontal";

            Vector2 newDistancia = distanciaExplosao * direcao;
                       
            InstanciaExplosao(posicao, currentPower, newDistancia);
            
        }

        InstanciaExplosao("center", 0, Vector2.zero); //explosao no local da bomba

        Destroy(gameObject);
    }

    public void InstanciaExplosao(string position, int power, Vector2 distance)
    {
        Vector3 newPosition = transform.position;
        newPosition += new Vector3(distance.x, distance.y, 0);
        GameObject explosion = Instantiate(explosaoPrefab.gameObject, newPosition, transform.rotation) as GameObject;
        explosion.GetComponent<Explosao>().Detonate(position, power, distance);
    }
}
