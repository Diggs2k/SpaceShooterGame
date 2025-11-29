using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject Asteroidexplosion;
    public GameObject playerexplosion;
    private GameController gameController;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
    
        if (other.tag == "Player")
        {
            Instantiate(playerexplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        //destruir shot e asteroide + explosao
        Instantiate(Asteroidexplosion, transform.position, transform.rotation);
        //add score
        gameController.AddScore();
        Destroy(other.gameObject);//shot
        Destroy(gameObject);//asteroide
        //Debug.Log(other.tag);

    }
}
