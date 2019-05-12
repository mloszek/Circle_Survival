using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
    [SerializeField]
    private AudioSource explosion;
    [SerializeField]
    private AudioSource hiding;
    [SerializeField]
    private AudioSource ticking;

    private static SoundsController instance;
    private static object _lock = new object();
    private static bool isShutingDown = false;

    public static SoundsController Get()
    {
        if (isShutingDown)
            return null;

        lock (_lock)
        {
            if (instance == null)
            {
                instance = (SoundsController)FindObjectOfType(typeof(SoundsController));

                if (instance == null)
                {
                    GameObject newGameObject = new GameObject(typeof(SoundsController).ToString());
                    instance = newGameObject.AddComponent<SoundsController>();
                    DontDestroyOnLoad(newGameObject);
                }
            }

            return instance;
        }
    }

    public void PlayExplosion()
    {
        explosion.Play();
    }

    public void PlayHide()
    {
        hiding.Play();
    }

    public void PlayTicking()
    {
        ticking.Play();
    }

}
