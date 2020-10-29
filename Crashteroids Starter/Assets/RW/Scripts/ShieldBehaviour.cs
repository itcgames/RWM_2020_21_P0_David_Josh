using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    public float lifeTime = 3.0f;
    [SerializeField]
    private GameObject playerObj;
    [SerializeField]
    private Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Death", lifeTime);
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerObj.GetComponent<Ship>().setSheild();
        this.transform.position = playerObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = playerObj.transform.position;
    }
    void Death()
    {
        Destroy(this.gameObject);
        playerObj.GetComponent<Ship>().killSheild();
    }
}
