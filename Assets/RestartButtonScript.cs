using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void OnBtnClick()
    {
        Debug.Log("¿€µø");
        SceneManager.LoadScene("GameScreen");
    }
    // Start is called before the first frame update
    
}
