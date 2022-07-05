using UnityEngine;

public class DownWall : MonoBehaviour
{
    public Starter starter;

    private void Start()
    {
        starter = GameObject.Find("Starter").GetComponent<Starter>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        starter.Restart();
    }
}
