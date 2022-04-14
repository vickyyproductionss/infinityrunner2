using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;
public class playerController : MonoBehaviour
{
    public float maxSpeed;
    public float sideSpeed;
    public float force;
    public float forceFactor;
    public TMP_Text score;
    public TMP_Text highscoretext;
    Rigidbody playerRB;
    void Start()
    {
        this.gameObject.transform.GetChild(PlayerPrefs.GetInt("chosenPlayer")).gameObject.SetActive(true);
        playerRB = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        checkEndGame();
        updateScore();
    }
    void updateScore()
    {
        float curscore = GameManager.instance.player.transform.position.z;
        float highscore = PlayerPrefs.GetFloat("highscore");
        score.text = "Score: " + curscore.ToString("#");
        if(curscore>highscore)
        {
            PlayerPrefs.SetFloat("highscore", curscore);
        }
        highscoretext.text = "Highscore: " + highscore.ToString("#");
    }
    void checkEndGame()
    {
        if(this.gameObject.transform.position.x < -10.5 || this.gameObject.transform.position.x > 10.5 || this.gameObject.transform.position.y < -5)
        {
            GameManager.instance.GameOver();
        }
    }
    void movePlayer()
    {
        playerRB.AddForce(0, 0, force * Time.deltaTime * forceFactor, ForceMode.VelocityChange);
        if (playerRB.velocity.magnitude > maxSpeed)
        {
            Vector3 backup = Vector3.ClampMagnitude(playerRB.velocity, maxSpeed);
            playerRB.velocity = new Vector3(playerRB.velocity.x, playerRB.velocity.y, backup.z);
        }
        float dirX = CrossPlatformInputManager.GetAxis("Horizontal");
        playerRB.AddForce(dirX / 5, 0, 0, ForceMode.VelocityChange);
    }
}
