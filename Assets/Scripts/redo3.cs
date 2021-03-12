using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class redo3 : MonoBehaviour
{
   public void redo()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
