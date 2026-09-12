using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character_Interaction : MonoBehaviour
{
    public GameObject interactText;
    public TextMeshProUGUI tmp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactText = GameObject.Find("Interact Text");
        tmp = interactText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interact")
        {
            tmp.enabled = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interact")
        {
            tmp.enabled = false;
        }
    }
}
