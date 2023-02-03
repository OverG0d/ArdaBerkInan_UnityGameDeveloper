using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Fields")]
    [SerializeField] private float speed;
    [SerializeField] private AudioClip clip;
    [SerializeField] private float volume;

    [Header("Components")]
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private AudioSource source;

    // Update is called once per frame
    void FixedUpdate()
    {

        // Player controls
        if(Input.GetKey(KeyCode.UpArrow))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            rigid.velocity = new Vector2(-speed * Time.deltaTime, rigid.velocity.y);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rigid.velocity = new Vector2(speed * Time.deltaTime, rigid.velocity.y);
        }

        // Restart Game
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("GoodFish"))
        {
            source.PlayOneShot(clip, volume);
            LevelManager.Instance.CheckWin();     
            Destroy(col.gameObject);
        }

        if (col.CompareTag("BadFish"))
        {
            source.PlayOneShot(clip, volume);
            LevelManager.Instance.CheckLoss();          
            Destroy(col.gameObject);
        }
    }
}
