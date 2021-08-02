using UnityEngine;

public class Player : MonoBehaviour
{
    //speed which player moves
    public float speed = 6;


    float screenHalfWidthInWorldUnits;

    public event System.Action OnPlayerDeath;


    // Start is called before the first frame update
    void Start()
    {
        //for screen wrap around

        float halfPlayerWidth = transform.localScale.x / 2f;


        //orthographicsize is screen half height
        //aspect is ratio
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize; //+ halfPlayerWidth;

        //for in screen collision just change the negative to positive and vice versa
    }

    // Update is called once per frame
    void Update()
    {
        InputMovement();

    }

    void InputMovement()
    {
        //get x axis input 
        float inputX = Input.GetAxisRaw("Horizontal");
        //calculate velocity = direction * speed
        float velocity = inputX * speed;

        //move horizontal
        transform.Translate(Vector2.right * velocity * Time.deltaTime);



        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }

        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Falling Block")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }

}
