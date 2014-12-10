using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RollingFromText : MonoBehaviour
{
    public int[] diceResults;
    public bool toText;
    public Text txt;
    public Text reset;
    public InputField inputField;
    public int numberOfDice;
    public string Suffix;
    public bool doSuffix;
    public int Total;
    public Text[] txtDice;
    public Text total;

    void Start()
    {
        reset.text = "Type a number between 1 and " + diceResults.Length; //Resetting text
    }
    public void RollDice()
    {
        int.TryParse(inputField.text, out numberOfDice); //Getting a number that we can work with!
        if (numberOfDice > diceResults.Length) //A check to see if the number is too big for the max that I set (2345 in this case)
        {
            numberOfDice = diceResults.Length;
            reset.text = "Number too big!  I set it to " + diceResults.Length;
        }
        for (int i = 0; i < numberOfDice; i++) //Gettting our dice results, thats all to get 2345+ results 2 lines...
        {
            diceResults[i] = Random.Range(1, 7);
        }
        ParseResults(); //Accessing the function below
    }
    public void ParseResults()
    {
        txt.text = "Parsing Results \n"; //A pseudo-reset kinda thing!
        Total = 0; //Resetting our total amount (all dice together!
        for (int i = 0; i < txtDice.Length; i++)
        {
            txtDice[i].text = ""; //Resetting all our txtDice (so we can track how many ones/two/3/4/5/6's you got
        }

        for (int i = 0; i < numberOfDice; i++) //Going through the dice we just rolled!
        {
            if (!toText) //If we just want the digits (i.e. 1, 7.)
            {
                txt.text += diceResults[i] + GetSuffix(diceResults[i]); //Just add the digit and the suffix
            }
            if (toText) //If we want it in text (i.e. One, Seven.)
            {
                txt.text += Text(diceResults[i]); //Access the function text and give it your number!
            }
            if (i < numberOfDice - 1) //If you are not on the last number add a comma and a space!
            {
                txt.text += ", ";
            }
            else if (i == numberOfDice - 1) //Else if you are on the last number add a fullstop!
            {
                txt.text += ".";
                Debug.Log("Added Fullstop on " + (i + 1)); //A nifty little debug just to check if we have fullstops right!
            }
            Total += diceResults[i]; //Add your dice number to the total!
            txtDice[diceResults[i]].text += diceResults[i] + ""; //For the corresponding txtdice add a digit on the end for example (111111111)
        }
        total.text = "Total: " + Total; //total.text is equal to total!
        for (int i = 0; i < txtDice.Length; i++) //Going through each txtdice!
        {
            txtDice[i].text = i + ": " + txtDice[i].text.Length; //Getting the length of the object we added above for example (111111111 becomes 9)
            //Make sure that you have 7 text dices and the element 0 is an object off the screen or is unactive!
        }
    }
    public void RollRandom()//For when we roll a random amount of dice
    {
        inputField.text = "" + Random.Range(1, diceResults.Length); //This way is so you can see how many dice you rolled and to prevent a repeat of code!
        RollDice();
    }
    public void Change() //When you change from text mode to number mode and vice versa (one TO 1)
    {
        toText = !toText; //Change text to what text doesn't equal! A.k.a. if toText = true it now equals false vice versa
        if (inputField.text != "") //This won't run if there is no text/number
            //This is just so it doesn't re do the results and you can make sure they line up!
        {
            ParseResults();
        }
    }
    public string Text(int Dice) //My function for returning a text to add!
    {
        string Final = ""; //Just a variable that we will give out!
        switch (Dice) //The variable that we want!
                //Okay I know this isn't done great but It works fine and if I wanted to change
                //One to Unicorn I could!!!!
        {
            case 1:
                Final = "One";
                break;
            case 2:
                Final = "Two";
                break;
            case 3:
                Final = "Three";
                break;
            case 4:
                Final = "Four";
                break;
            case 5:
                Final = "Five";
                break;
            case 6:
                Final = "Six";
                break;
        }
        return Final; //Give it back the number!
    }
    public string GetSuffix(int dice) //Getting a suffix!
    {
        if (doSuffix) //If you in suffix mode! Too make code better running!
        {
            switch (dice) //Same as above text function but for suffix's it works great I know I could do a default
                    //But I decided just to go safe in case something went wrong!
            {
                case 1:
                    Suffix = "st";
                    break;
                case 2:
                    Suffix = "nd";
                    break;
                case 3:
                    Suffix = "rd";
                    break;
                case 4:
                    Suffix = "th";
                    break;
                case 5:
                    Suffix = "th";
                    break;
                case 6:
                    Suffix = "th";
                    break;
            }
        }
        else //If you not in suffix mode just give it an empty string!
        {
            Suffix = "";
        }
        return Suffix; //Give it a suffix (empty or something)
    }
    public void SwitchSuffix() //Same as change function but for suffix!
    {
        doSuffix = !doSuffix; //Change suffix to what suffix doesn't equal! A.k.a. if doSuffix = true it now equals false vice versa
        if (inputField.text != "") //If there is text/number then give the results!
        {
            ParseResults();
        }
    }
}
