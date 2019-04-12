using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GvrLoadingCircle : MonoBehaviour {

    public Transform loadingBar;
    public Text textIndicator;
    public Text textLoading;
    [SerializeField] private float currentAmount;
    [SerializeField] private float speed;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(currentAmount < 100)
        {
            currentAmount += speed * Time.deltaTime;
            textIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
            textLoading.gameObject.SetActive(true);

        }
        else
        {
            textLoading.gameObject.SetActive(false);
            textIndicator.GetComponent<Text>().text = "DONE!";
        }
        loadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
	
	}
}
