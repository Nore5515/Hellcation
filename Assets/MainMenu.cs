using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject attributions;

    public void Begin(){
         SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void ToggleAttributions(){
        attributions.SetActive(!attributions.activeSelf);
    }
}
