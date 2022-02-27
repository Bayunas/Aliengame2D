using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    Rigidbody2D myBody;
    [SerializeField] float speed;
    [SerializeField] float health;
    float minX, maxX, maxY, minY;
    // Start is called before the first frame update

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        Vector2 esquinaInfIz = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        float ancho = (GetComponent<Rigidbody2D>().mass) / 2;
        float largo = (GetComponent<Rigidbody2D>().mass) / 2;

        minX = esquinaInfIz.x + ancho;
        maxX = esquinaSupDer.x - ancho;
        maxY = esquinaSupDer.y - largo;
        minY = esquinaInfIz.y + largo;

    }

    // Update is called once per frame
    void Update()
    {


        Mathf.Clamp(transform.position.x, minX, maxX); 
        Mathf.Clamp(transform.position.y, minY, maxY); 

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY));

        if(maxX <= transform.position.x)
        {
            speed *= -1;
        }
        if(minX >= transform.position.x)
        {
            speed *= -1;
        }
        if(health == 0)
        {

            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
       
        myBody.velocity = new Vector2(speed,myBody.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bull")
        {
            health= health -1;
        }
        if(collision.gameObject.tag == "Big")
        {
            health = 0;
        }
    }
}
