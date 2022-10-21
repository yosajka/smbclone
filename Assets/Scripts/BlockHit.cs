using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class BlockHit : MonoBehaviour
{
    public int maxHits = -1;
    public Sprite emptyBlock;

    public GameObject item;

    private bool animating;

    // use for breaking brick effect
    public UnityEvent _break;
    public GameObject _breakParticles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!animating && maxHits !=0 && collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.DotTest(transform, Vector2.up))
            {
                if (collision.gameObject.GetComponent<Player>().big && item == null)
                {
                    _break?.Invoke();
                }
                else
                {
                    Hit();
                }
                
            }
        }
    }

    private void Hit()
    {

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Animator animator = GetComponent<Animator>();

        spriteRenderer.enabled = true;

        maxHits--;

        if (maxHits == 0)
        {
            spriteRenderer.sprite = emptyBlock;

            if (animator != null)
            {
                animator.enabled = false;
            }
            
            StartCoroutine(Animate());
        }

        if (item != null)
        {
            Instantiate(item, transform.position, Quaternion.identity);
        } 
        
        StartCoroutine(Animate());
        
    }

    public void SpawnParticles()
    {
        Instantiate(_breakParticles, transform.position, Quaternion.identity);
    }

    public IEnumerator Animate()
    {
        animating = true;

        Vector3 restingPosition = transform.localPosition;
        Vector3 animatedPosition = restingPosition + Vector3.up * 0.5f;

        yield return Move(restingPosition, animatedPosition);
        yield return Move(animatedPosition, restingPosition);

        animating = false;

    }

    private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duration = 0.125f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            transform.localPosition = Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = to;
    }
}