using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarEscena(string newscene) {
        //Cambia de escena hacia donde queremos salir.
        
        SceneManager.LoadScene(newscene);
    }
    public void Quit()
    {
        //Si esta en editor apaga el editor, si esta en ejecutable cierra la aplicacion.
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
        else {
            Application.Quit();
        }
    }
}
