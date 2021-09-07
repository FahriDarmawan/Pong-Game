using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

    //Rigidbody 2D bole
    private Rigidbody2D rigidBody2D;

    //Besarnya gaya awal yang diberikan untuk mendorong bola
    public float xInitialForce;
    public float yInitialForce;

    // Titik asal lintasan bola saat ini
    private Vector2 trajectoryOrigin;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        trajectoryOrigin = transform.position;

        //Mulai game
        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Mengembalikan bole ke tengah layar
    void ResetBall()
    {
        //Reset posisi menjadi (0,0)
        transform.position = Vector2.zero;

        //Reset kecepatan menjadi (0,0)
        rigidBody2D.velocity = Vector2.zero;
    }

    //Inisialisasi Gerakan bola
    void PushBall()
    {
        //tentukan nilai komponen y dari gaya dorong antara -yIntialForce dan yInitialFocrce
        //float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        //tentukan nilai acak antara 0 (inklusif) dan 2 (eksklusif)
        float randomDirection = Random.Range(0, 2);

        //Jika nilainya dibawah 1, bola bergerak ke kiri
        //Jika tidak, bola bergerak ke kanan
        if (randomDirection < 1.0f)
        {
            //Gunakan gaya untuk menggerakkan bola ini
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yInitialForce));
        } 
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yInitialForce));
        }
    }


    //Game diulang
    void RestartGame()
    {
        //Kembalikan bola ke poisi semula
        ResetBall();

        //Setelah 2 detik, berikan gaya ke bola
        Invoke("PushBall", 2);
    }

    // Ketika bola beranjak dari sebuah tumbukan, rekam titik tumbukan tersebut
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    // Untuk mengakses informasi titik asal lintasan
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}
