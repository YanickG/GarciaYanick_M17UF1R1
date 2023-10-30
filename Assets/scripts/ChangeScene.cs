using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int sceneBuildIndex;

    //Cambia de nivel si el collider es un jugador
    //Pasa a otra escena

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger entered");

        if(other.tag == "Player")
        {
            //ha entrado el jugador, cambia el nivel
            print("Switching scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }

}
