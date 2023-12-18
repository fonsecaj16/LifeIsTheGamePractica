using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnimationAndSelection : MonoBehaviour
{

    Animator animator;
    public Avatar macarena;
    public Avatar hiphop;
    public Avatar house;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void selectMacarena()
    {
        transform.rotation = Quaternion.identity;
        Debug.Log("Before: " + transform.position);
        transform.position = new Vector3(1000f, 1000f, 1000f);
        Debug.Log("After: " + transform.position);
        animator.avatar = macarena;
        animator.SetBool("Macarena", true);
        animator.SetBool("House", false);
        animator.SetBool("HipHop", false);
    }
    public void selectHouse()
    {
        transform.rotation = Quaternion.identity;
        transform.position = new Vector3(1000f, 1000f, 1000f);
        animator.avatar = house;
        animator.SetBool("Macarena", false);
        animator.SetBool("House", true);
        animator.SetBool("HipHop", false);
    }
    public void selectHipHop()
    {
        transform.rotation = Quaternion.identity;
        transform.position = new Vector3(1000f, 1000f, 1000f);
        animator.avatar = hiphop;
        animator.SetBool("Macarena", false);
        animator.SetBool("House", false);
        animator.SetBool("HipHop", true);
    }

    public void selectOption()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
