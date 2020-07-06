using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage1;
    public PLayerHealth player;

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        player = hitInfo.GetComponent<PLayerHealth>();
        if (player.transform.CompareTag("Player"))
        {
            player.TakeDamage(damage1);
        }
    }
}
