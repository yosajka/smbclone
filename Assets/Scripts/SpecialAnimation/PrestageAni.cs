using System.Collections;
using UnityEngine;

public class PrestageAni : MonoBehaviour
{
    private Vector3 destination;

    public float speed = 6f;
    public Transform pipeOpenning;


    
    private void Start()
    {
        //destination = new Vector3 (pipeOpenning.position.x, pipeOpenning)
        StartCoroutine(MoveTo(transform, pipeOpenning.position - Vector3.right * 0.5f - Vector3.up * 0.5f));
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PipeConnection (with top)")
        {
            StartCoroutine(pipeOpenning.gameObject.GetComponent<Pipe>().Enter(transform));
        }
    }

    private IEnumerator MoveTo(Transform subject, Vector3 destination)
    {
        while (Vector3.Distance(subject.position, destination) > 0.125f)
        {
            subject.position = Vector3.MoveTowards(subject.position, destination, speed * Time.deltaTime);
            yield return null;
        }

        subject.position = destination;
    }
   
}
