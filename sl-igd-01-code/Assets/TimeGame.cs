using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGame : MonoBehaviour
{
    float roundStartDelayTime = 3;
    float roundStartTime;
    int waitTime;
    bool roundStarted;

    void Start()
    {
        print("Press the spacebar once you think the allotted time is up.");
        Invoke("SetNewRandomTime", roundStartDelayTime);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && roundStarted)
        {
            InputReceived();
        }
    }

    void InputReceived()
    {
        roundStarted = false;
        float playerWaitTime = Time.time - roundStartTime;
        float playerError = Mathf.Abs(waitTime - playerWaitTime);

        print("You waited for " + playerWaitTime + " seconds. That's " + playerError + " seconds off. " + GenerateMessage(playerError));
        Invoke("SetNewRandomTime", roundStartDelayTime);
    }

    string GenerateMessage(float playerError)
    {
        string message = "";
        if (playerError < .15f)
        {
            message = "Outstanding!";
        }
        else if (playerError < 1f)
        {
            message = "Exceeds Expectations.";
        }
        else if (playerError < 2f)
        {
            message = "Acceptable.";
        }
        else if (playerError < 3f)
        {
            message = "Poor.";
        }
        else
        {
            message = "Dreadful.";
        }
        return message;
    }

    void SetNewRandomTime()
    {
        waitTime = Random.Range(5, 21);
        roundStartTime = Time.time;
        roundStarted = true;
        print(waitTime + " seconds.");
    }
}
