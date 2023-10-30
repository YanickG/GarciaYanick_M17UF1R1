using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pointB"))
        {
            speed *= -1;
            Vector2 rotate = new Vector2(0, 180);
            gameObject.transform.Rotate(rotate);
        }
        if (collision.CompareTag("pointA"))
        {
            speed *= -1;
            Vector2 rotate = new Vector2(0,180);
            gameObject.transform.Rotate(rotate);
        }
    }
}
