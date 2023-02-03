using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fish : MonoBehaviour
{
    [Header("Fields")]
    public bool leftSide;
    [SerializeField] private float speed;
    [SerializeField] private float timeuntilDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeuntilDestroyed);
    }

    void Update()
    {
        if(leftSide)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * -speed * Time.deltaTime);
        }
    }
}
