using UnityEngine;

public class CandyScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Player":
                //Increment score
                GameManager.Instance.Increment();
                Destroy(gameObject);
                break;
            case "Boundary":
                //Decrease Lives
                GameManager.Instance.DecreaseLife();
                Destroy(gameObject);
                break;
        }
    }
}