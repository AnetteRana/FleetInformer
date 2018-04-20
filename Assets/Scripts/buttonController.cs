using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour
{
    public void pressedStartButton()
    {
        Application.LoadLevel("gameScene");
    }
}
