using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    

    [Header("Movement")]
    public float speed = 2f;
    private Vector2 velocity;
    [SerializeField]
    private Vector2 direction = Vector2.left;
    [SerializeField]
    private Vector2[] points;
    private int index = 0;
    private new Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform, true);
            
            //collision.gameObject.GetComponent<PlayerMovement>().velocity += velocity;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
        
    }

    private void Update()
    {
        velocity = speed * direction;

        if (Vector2.Distance(transform.position, points[index]) < 0.02f)
        {
            
            index += 1;
            if (index == points.Length)
            {
                index = 0;
            }
            direction = -direction;
        }
        
        transform.position = Vector2.MoveTowards(transform.position, points[index], speed * Time.deltaTime);
    }

    // private void FixedUpdate()
    // {
    //     Vector2 position = rigidbody.position;
    //     position += velocity * Time.fixedDeltaTime;

    //     rigidbody.MovePosition(position);
    // }
}
