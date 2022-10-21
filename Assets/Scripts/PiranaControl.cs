using UnityEngine;

public class PiranaControl : MonoBehaviour
{
    private GameObject player;
    private Pirana pirana;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pirana = GetComponent<Pirana>();
    }

    private void Update()
    {
        if (Mathf.Abs(player.transform.position.x - transform.position.x) < 2f)
        {
            pirana.enabled = false;
        }

        else
        {
            pirana.enabled = true;
        }
    }
}
