using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosao : MonoBehaviour
{
    public Transform horizontal, vertical, center;
    public float ttl; //time to leave

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Detonate (string position, int power, Vector2 distancia)
    {
        horizontal.gameObject.SetActive(false);
        vertical.gameObject.SetActive(false);
        center.gameObject.SetActive(false);
        Destroy(gameObject, ttl);
        if (power > 0 || position == "center")
        {
            if (position == "vertical")
            {
                vertical.gameObject.SetActive(true);
            }
            else if (position == "horizontal")
            {
                horizontal.gameObject.SetActive(true);
            }
            else
            {
                center.gameObject.SetActive(true);
            }
        }
        // uma explosao vai desencadear outra explosao
        if (power > 0) // se power for maior que zero, quer dizer q ele ainda tem mais uma explosao
        {
            power--; //removo um poder de explosao

            Vector2 newPosition = transform.position; //posicao da explosao que esta acontecendo agora
            newPosition += distancia; //adiciono a distancia pra prox explosao

            GameObject explosion = Instantiate(gameObject,newPosition, transform.rotation) as GameObject; //cria explosao totalmente nova e poe nessa nova posicao
            explosion.GetComponent<Explosao>().Detonate(position, power, distancia); // e detona com os mesmos parametros  que recebi aqui
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destructive"))
        {
            Destroy(collision.gameObject);
        }
    }

}
