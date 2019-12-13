using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    Animator _animator;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    
    public void OpenOrClose()
    {
        if (_animator.GetBool("open"))
        {
            _animator.SetBool("open", false);
            arrow.SetActive(true);
        }
        else
        {
            _animator.SetBool("open", true);
            arrow.SetActive(false);
        }
    }
}
