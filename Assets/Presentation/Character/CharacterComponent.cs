using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterComponent : MonoBehaviour
{
    public float TargetSpeed = 1f;
    public GameObject NextPositionMarker;
    private int _direction = 1;
    private Vector3 _destination;

    private void Update()
    {
        NextPositionMarker.transform.Translate(_direction * TargetSpeed * Time.deltaTime, 0, 0);

        if (NextPositionMarker.transform.localPosition.x > 3)
        {
            _direction = -1;
        }
        else if (NextPositionMarker.transform.localPosition.x < 1)
        {
            _direction = 1;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase.Equals(TouchPhase.Began) ||
            Input.GetKeyDown("space"))
        {
            _destination = new Vector3(NextPositionMarker.transform.position.x, transform.position.y,
                transform.position.z);
        }
        Vector3.Lerp()
         GetComponent<Rigidbody2D>().MovePosition(
                new Vector3(NextPositionMarker.transform.position.x, transform.position.y,
                    transform.position.z));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("MainScene");
    }
}