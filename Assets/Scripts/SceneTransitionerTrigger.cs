using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionerTrigger : MonoBehaviour
{
    public int SceneIndex;
    public GameObject ExitTrigger;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneIndex);
        }
    } 
}
