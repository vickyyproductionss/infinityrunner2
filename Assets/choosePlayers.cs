using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class choosePlayers : MonoBehaviour
{
    public TMP_Text message;
    public List<Transform> players;
    int chosenPlayer = 0;
    private void Start()
    {
        chosenPlayer = PlayerPrefs.GetInt("chosenPlayer");
        changeCameraToselectedObject(chosenPlayer);
        Debug.Log(players.Count);
    }
    void changeCameraToselectedObject(int index)
    {
        cameraFollow.instance.setTargetTransfrom(players[index].transform);
    }
    public void selectNext()
    {
        if(chosenPlayer + 1 < players.Count)
        {
            chosenPlayer++;
            PlayerPrefs.SetInt("chosenPlayer", chosenPlayer);
            changeCameraToselectedObject(chosenPlayer);
        }
        else
        {
            StartCoroutine(showMessage("No next player.", 3));
        }
    }
    public void loadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void selectPrev()
    {
        if (chosenPlayer - 1 >= 0)
        {
            chosenPlayer--;
            PlayerPrefs.SetInt("chosenPlayer", chosenPlayer);
            changeCameraToselectedObject(chosenPlayer);
        }
        else
        {
            StartCoroutine(showMessage("No previous player.", 3));
        }
    }
    IEnumerator showMessage(string mesg, int time)
    {
        Color oldcolor = message.color;
        string mesgOld = message.text;
        message.text = mesg;
        message.color = Color.red;
        yield return new WaitForSeconds(time);
        message.text = mesgOld;
        message.color = oldcolor;
    }
}
