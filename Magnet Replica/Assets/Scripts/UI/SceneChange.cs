using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public enum scene
    {
        first,
        second
    }

    public scene sceneChanger;

    public void OnClick()
    {
        SceneManager.LoadScene((int)sceneChanger);
    }
}
