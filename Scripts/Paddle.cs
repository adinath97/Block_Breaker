using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float padding = 1f;
    public Vector2 paddleVelocity = new Vector2(12f, 4f);
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    float newXPos;
    float newYPos;
    Vector2 screenPosition;
    Vector2 worldPosition;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameLord.gameStart && !gameLord.gameOver && !gameLord.gamePause)
        {
            MovePlayerPaddle();
        }
    }

    private void MovePlayerPaddle()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * paddleVelocity.x;
        //var deltaY = Input.GetAxis("Vertical") * Time.fixedDeltaTime * paddleVelocity.y;
        var xPos = transform.position.x + deltaX;
        //var yPos = transform.position.y + deltaY;
        var xPosFinal = Mathf.Clamp(xPos, xMin, xMax);
        //var yPosFinal = Mathf.Clamp(yPos, yMin - padding, yMax);
        this.transform.position = new Vector2(xPosFinal, transform.position.y);

        //screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        //float mousePosInUnits = worldPosition.x;
        //newXPos = Mathf.Clamp(mousePosInUnits, xMin, xMax);
        //this.transform.position = new Vector2(newXPos, transform.position.y);

        //var deltaX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        //var newXPos = transform.position.x + deltaX;
        //var xPosFinal = Mathf.Clamp(newXPos, xMin, xMax);
        //transform.position = new Vector2(xPosFinal, transform.position.y);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
