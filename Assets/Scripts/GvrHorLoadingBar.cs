using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GvrHorLoadingBar : MonoBehaviour {
    public Transform loadingBar;
    [SerializeField] private float currentAmount;
    [SerializeField] private float speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmount < 100)
        {
            currentAmount += speed * Time.deltaTime;
        }
        loadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;

    }
}
