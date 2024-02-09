using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public float jumpHeight = 10f;
    private Rigidbody2D rb;
    private bool betterWeapon;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }
    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !betterWeapon)
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && betterWeapon)
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 1, 0), Quaternion.Euler(0, 0, -45f)); ;
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            Instantiate(bulletPrefab, transform.position + new Vector3(-0.5f, 1, 0), Quaternion.Euler(0, 0, 45f));
        }
    }
}
