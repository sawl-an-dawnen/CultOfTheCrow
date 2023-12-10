using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Cutscene : MonoBehaviour
{
    public float timer = 3f;
    public string[] destroy;

    private GameObject player;
    private VideoPlayer myVideo;
    private SceneLoader loader;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.SetActive(false);
        }
        catch { }
        try
        {
            foreach (string obj in destroy) {
                Destroy(GameObject.Find(obj));
            }
        }
        catch { }

        myVideo = GetComponent<VideoPlayer>();
        loader = GetComponent<SceneLoader>();
        myVideo.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Debug.Log(myVideo.isPlaying);
            if (!myVideo.isPlaying) {
                try { player.SetActive(true); }
                catch { }
                loader.LoadScene();
            }
        }

    }
}
