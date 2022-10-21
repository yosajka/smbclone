using UnityEngine;

public class Koopa : MonoBehaviour
{
    public Sprite shellSprite;
    public GameObject point;

    public float shellSpeed = 12f;

    private bool shelled;
    private bool pushed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!shelled && collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            
            if (player.starpower)
            {
                Hit();
            }
            else if (collision.transform.DotTest(transform, Vector2.down))
            {
                EnterShell();        
            } else {
                player.Hit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (shelled && collider.CompareTag("Player"))
        {
            if (!pushed) {
                Vector2 direction = new Vector2(transform.position.x - collider.transform.position.x, 0f);
                PushShell(direction);
            }
            else {
                Player player = collider.GetComponent<Player>();

                if (player.starpower)
                {
                    Hit();
                }
                else
                {
                    player.Hit();
                }
            }
        }
        else if (!shelled && collider.gameObject.layer == LayerMask.NameToLayer("Shell"))
        {
            Hit();
        }
    }

    private void EnterShell()
    {
        shelled = true;

        // increase point
        Instantiate(point, transform.position, Quaternion.identity);
        GameManager.Instance.IncreaseScore(100);

        GetComponent<EntityMovement>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = shellSprite;
        GetComponent<CircleCollider2D>().offset = Vector2.zero;
        
    }

    private void PushShell(Vector2 direction)
    {
        pushed = true;

        GetComponent<Rigidbody2D>().isKinematic = false;

        EntityMovement movement = GetComponent<EntityMovement>();
        movement.direction = direction.normalized;
        movement.speed = shellSpeed;
        movement.enabled = true;

        gameObject.layer = LayerMask.NameToLayer("Shell");
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

    private void OnBecameInvisible()
    {
        if (shelled)
        {
            Destroy(gameObject);
        }
    }
}

