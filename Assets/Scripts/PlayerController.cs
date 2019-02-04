using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
    public Text countText;
    public Text scoreText;
    public Text winText;
    public Text lifeText;
	
	private Rigidbody rb;
    private int count;
    private int score;
    private int life;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        SetScoreText ();
        life = 3;
        SetlifeText();
        winText.text = "";
	}
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetCountText();
            SetScoreText();

        }

        if (other.gameObject.CompareTag("Pills"))
        {
            other.gameObject.SetActive(false);
            score = count - 1;
            SetScoreText();
            life = life - 1;
            SetlifeText();

        }
    }

    void SetScoreText ()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 20)
        {
            winText.text = "You Survived!";
        }
    }

    void SetlifeText()
    {
        lifeText.text = "Life: " + life.ToString();
        if (life <= 0)
        {
            winText.text = "You Have Died!";
            Destroy(rb);
        }
    }

    void SetCountText ()
    {
        countText.text = "Total: " + count.ToString();

        if (count == 12)
        {
            rb.MovePosition(new Vector3(-90, 0, 0));
        }
    }
}