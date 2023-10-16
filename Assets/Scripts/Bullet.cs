using Mirror;
using UnityEngine;

public class Bullet : NetworkBehaviour
{
    public float speed = 50;
    public int dmg = 5;
    public PlayerHealth owner;
    PlayerHealth target;

    public void Start()
    {
        Invoke("AutoDestroy", 3f);
    }
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.gameObject.GetComponent<PlayerHealth>();

            target.TakeDmg(dmg);
            if (target.health <= 0)
            {
                target.DestroyPlayer();
                owner.KillScore();
            }
            CancelInvoke();
            Cmd_AutoDestroy();
        }
    }

    [Command(requiresAuthority = false)]
    private void Cmd_AutoDestroy()
    {
        NetworkServer.Destroy(gameObject);
    }
}
