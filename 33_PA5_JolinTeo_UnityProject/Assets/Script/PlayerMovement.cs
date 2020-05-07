using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    public GameObject CoinText;
    public int TriggerEnterCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        Movement();
        Win();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0, 0, speed) * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            //Add 1 to score
            TriggerEnterCount += 1;
            CoinText.GetComponent<Text>().text = "Coin collected : " + TriggerEnterCount;
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "Hazard")
        {
            SceneManager.LoadScene(1);
        }
    }

   public void Win()
    {
        if (TriggerEnterCount == 5)
        {
            SceneManager.LoadScene(2);
        }
    }
}
