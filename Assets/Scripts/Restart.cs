using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Button MyButton;

    private void Start()
    {
        MyButton.onClick.AddListener(TaskOnClick);
    }
    // Start is called before the first frame update
    public void TaskOnClick()
    {
        SceneManager.LoadScene("InGame");
    }

}
