using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampCardFunction : MonoBehaviour
{
    public GameObject player = null;
    private StampCard stampCard;

    private bool hasCollided;
    private string labelText;

    // Start is called before the first frame update
    void Start()
    {
        if (player != null)
            stampCard = player.GetComponent<StampCard>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnGUI()
    {
        if (hasCollided)
        {
            GUI.Box(new Rect(140, Screen.height - 50, Screen.width - 300, 120), (labelText));
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == player.gameObject.tag)
        {
            hasCollided = true;
            labelText = "Press E to Check Stamps";
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == player.gameObject.tag)
        {
            hasCollided = true;
            labelText = "Press E to Check Stamps";
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == player.gameObject.tag)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ToggleStampCard(true);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        hasCollided = false;
        ToggleStampCard(false);
    }

    public void ToggleStampCard()
    {
        stampCard.toggleStampCard();
    }

    public void ToggleStampCard(bool toggle)
    {
        stampCard.toggleStampCard(toggle);
    }
}
