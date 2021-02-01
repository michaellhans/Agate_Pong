using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballControl : MonoBehaviour
{
    // Rigidbody 2D Power Up
    private Rigidbody2D rigidBody2D;

    // Besarnya gaya awal yang diberikan untuk mendorong power up
    public float constForce;
    public float xInitialForce;
    public float yInitialForce;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        this.gameObject.SetActive(false);

        // Mulai game
        RestartGame();
    }


    // Update is called once per frame
    void Update()
    {

    }

    void HideButton()
    {
        this.gameObject.SetActive(false);
    }

    void PushFireball()
    {
        this.gameObject.SetActive(true);

        // Tentukan nilai komponen y dari gaya dorong antara -yInitialForce dan yInitialForce
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        // Tentukan nilai acak antara 0 (inklusif) dan 2 (eksklusif)
        float randomDirection = Random.Range(0, 2);

        // Jika nilainya di bawah 1, power up bergerak ke kiri. 
        // Jika tidak, power up bergerak ke kanan.
        if (randomDirection < 1.0f)
        {
            // Gunakan gaya untuk menggerakkan power up ini.
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce).normalized * constForce);
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce).normalized * constForce);
        }
    }

    void ResetFireball()
    {
        // Reset posisi menjadi (0,0)
        transform.position = Vector2.zero;

        // Reset kecepatan menjadi (0,0)
        rigidBody2D.velocity = Vector2.zero;
    }

    public void RestartGame()
    {
        // Kembalikan bola ke posisi semula
        ResetFireball();

        // Setelah random detik, berikan gaya ke fireball
        int randomSeconds = 30;
        Invoke("PushFireball", randomSeconds);
    }
}
