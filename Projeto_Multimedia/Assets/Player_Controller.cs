using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public  Rigidbody rb;
    public GameObject shot;
    public Transform shotSpawn;
    public float speed,tilt;
    public float xmin, xmax, zmin, zmax;
    public float fireRate;
    private float nextfire;
    private AudioSource shotsound;
    // Start is called before the first frame update
    void Start()
    {
        shotsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //mover nave com teclas
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movimento = new Vector3(moveHorizontal,0,moveVertical);
        rb.velocity = movimento * speed;

        //Limitar posicao e area do jogo
        rb.position = new Vector3(Mathf.Clamp(rb.position.x,xmin,xmax), 0, Mathf.Clamp(rb.position.z,zmin,zmax));

        //rodar a nave
        rb.rotation = Quaternion.Euler(0,0,rb.velocity.x*tilt);


        //////////////////////////////////////////////////////////////////////////////////
        ///disparar tiros
        /////////////////////////////////////////////////////////////////////////////////
        ///

        if (Input.GetButton("Fire1")&&Time.time>nextfire)
        {
            nextfire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            shotsound.Play();
        }
        
    }
}
