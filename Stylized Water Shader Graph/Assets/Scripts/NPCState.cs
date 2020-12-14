using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NPCState : MonoBehaviour
{
    // Start is called before the first frame update

    public BoxCollider player;
    public BoxCollider NPCP;
    public BoxCollider NPCS;
    public BoxCollider NPCC;

    public GameObject sheep;
    public GameObject cat;
    public GameObject pengun;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (0 == 0)
        {
            Destroy(pengun);
        }
        if (NPCC.isTrigger)
        {
            Destroy(cat);
        }
        if (NPCS.isTrigger)
        {
            Destroy(sheep);
        }*/
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.name == sheep.name)
        {
            Destroy(gameObject);
            Destroy(collider.gameObject);
            //GameState.Instance.IncreaseScore(20);
        }
        else if (collider.gameObject.name == pengun.name)
        {
            Destroy(gameObject);
            Destroy(collider.gameObject);
            //GameState.Instance.InitiateGameOver();
        }
        else if (collider.gameObject.name == cat.name)
        {
            Destroy(gameObject);
            //GameState.Instance.IncreaseScore(20);
        }
    }
}
