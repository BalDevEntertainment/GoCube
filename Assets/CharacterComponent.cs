using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterComponent : MonoBehaviour
{
    public float TargetSpeed = 1f;
    private int _direction = 1;

    private void Update()
    {
        var child = transform.Find("Target");
        child.Translate(_direction * TargetSpeed * Time.deltaTime, 0, 0);

        if (child.transform.localPosition.x > 3)
        {
            _direction = -1;
        }
        else if (child.transform.localPosition.x < 1)
        {
            _direction = 1;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase.Equals(TouchPhase.Began) ||
            Input.GetKeyDown("space"))
        {
            transform.position = child.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("MainScene");
    }
}