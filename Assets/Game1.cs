using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Game1 : MonoBehaviour
{
    [SerializeField] GameObject answer;
    [SerializeField] GameObject num1;
    [SerializeField] GameObject op;
    [SerializeField] GameObject num2;
    [SerializeField] Transform player;

    char[] operators = {'+','-','*'};
    int n1;
    int n2;
    // Start is called before the first frame update
    void Start()
    {
        ResetInputField();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (char c in Input.inputString){
            if (c == '\b')
            {
                if (answer.GetComponent<TMP_InputField>().text.Length != 0){
                    answer.GetComponent<TMP_InputField>().text = answer.GetComponent<TMP_InputField>().text.Substring(0, answer.GetComponent<TMP_InputField>().text.Length - 1);
                }
            }
            else if ((c == '\n') || (c == '\r')){
                int a;
                int.TryParse(answer.GetComponent<TMP_InputField>().text, out a);
                if((op.GetComponent<Text>().text == "+") && (a == n1 + n2)){
                    player.GetComponent<PlayerMoney>().AddCash(10);
                    ResetInputField();
                }
                else if(op.GetComponent<Text>().text == "-" && a == n1 - n2){
                    player.GetComponent<PlayerMoney>().AddCash(10);
                    ResetInputField();
                }
                else if(op.GetComponent<Text>().text == "*" && a == n1 * n2){
                    player.GetComponent<PlayerMoney>().AddCash(10);
                    ResetInputField();
                }
                else{
                    Debug.Log("Incorrect!");
                    answer.GetComponent<TMP_InputField>().text = "";
                }
            }
            else{
                answer.GetComponent<TMP_InputField>().text += c;
            }
        }
    }

    public void ResetInputField(){
        answer.GetComponent<TMP_InputField>().text = "";
        n1 = Random.Range(-10,10);
        n2 = Random.Range(-10,10);
        num1.GetComponent<Text>().text = n1.ToString();
        num2.GetComponent<Text>().text = n2.ToString();
        op.GetComponent<Text>().text = operators[Random.Range(0,3)].ToString();
    
    }
}
