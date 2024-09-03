using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;

    private Rigidbody rb;
    private int score;
    private float movementX;
    private float movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;

        SetScoreText();
        winText.gameObject.SetActive(false);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetScoreText()
    {
        scoreText.text = "Score : " + score.ToString();
        if (score >= 12)
        {
            winText.gameObject.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementX, 0f, movementY);
        rb.AddForce (movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
        }
        else if (other.gameObject.CompareTag("PickupNegative"))
        {
            other.gameObject.SetActive(false);
            score--;
            SetScoreText();
        }
    }
}
