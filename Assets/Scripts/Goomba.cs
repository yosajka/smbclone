using UnityEngine;

public class Goomba : MonoBehaviour
{
    public Sprite flatSprite;

    public GameObject point;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player.starpower)
            {
                Hit();
            }
            else if (collision.transform.DotTest(transform, Vector2.down))
            {
                Flatten();        
            } 
            else 
            {
                player.Hit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shell"))
        {
            Hit();
        }
    }

    private void Flatten()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EntityMovement>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = flatSprite;

        // increase point
        Instantiate(point, transform.position, Quaternion.identity);
        GameManager.Instance.IncreaseScore(100);

        Destroy(gameObject, 0.5f);
    }

    private void Hit()
    {
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<DeathAnimation>().enabled = true;
        
        // increase point
        Instantiate(point, transform.position, Quaternion.identity);
        GameManager.Instance.IncreaseScore(100);
        
        Destroy(gameObject, 3f);
    }
}
