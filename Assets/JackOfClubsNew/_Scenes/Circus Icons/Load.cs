using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("load", 3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void load()
    {
        SceneManager.LoadScene(1);
    }
}
