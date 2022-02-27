using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] float speed;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bullet2;
    [SerializeField] private float fireRate = 0.3f;
    [SerializeField]private float nextFire = 0f;
    private float rfire = 0;
    private float dfire = 3;
    float typeofbullet = 1;
    float minX, maxX, maxY, minY;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaInfIz = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        float ancho = (GetComponent<BoxCollider2D>().size.x) / 2;
        float largo = (GetComponent<BoxCollider2D>().size.y) / 2;

        minX = esquinaInfIz.x + ancho;
        maxX = esquinaSupDer.x - ancho;
        maxY = esquinaSupDer.y - largo;
        minY = esquinaInfIz.y + largo;
        float typeofbullet = 1;

    }

    // Update is called once per frame
    void Update()
    {


        float dirH = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float dirV = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(new Vector2(dirH, dirV));

        Mathf.Clamp(transform.position.x, minX, maxX); //Se asegura que el primer valor este en el rango de los siguientes.
        Mathf.Clamp(transform.position.y, minY, maxY); //Se asegura que el primer valor este en el rango de los siguientes.

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY));

        if (Input.GetKeyDown(KeyCode.E))
        {
            typeofbullet *= -1;
        }
       

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire && typeofbullet==1)
        {
            
            nextFire = Time.time + fireRate;
            Instantiate(bullet, transform.position, transform.rotation);
         
        }

        if (Input.GetKeyDown(KeyCode.Space) && typeofbullet == -1)
        {
            rfire = Time.time; 
        }
        if(Input.GetKeyUp(KeyCode.Space) && typeofbullet == -1)
        {
            Shoot();
        }




    }
    public void Shoot()
    {
        if( (Time.time - rfire) >= dfire)
        {
            Instantiate(bullet2, transform.position, transform.rotation);
        }
    }
}
