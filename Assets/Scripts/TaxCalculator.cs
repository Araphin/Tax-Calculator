using UnityEngine;
using SpeechLib;
using System.Threading.Tasks;
using System.Globalization;

public class TaxCalculator : MonoBehaviour
{
    // Constant rate for the Medicare Levy
    const double MEDICARE_LEVY = 0.02;
    public TMPro.TMP_InputField InputSalary;
    public TMPro.TMP_Dropdown PayPeriodDropDown;
    //Hello :)
    // Variables
    bool textToSpeechEnabled = true;

    private void Start()
    {
        Speak("Welcome to the A.T.O. Tax Calculator");
    }

    // Run this function on the click event of your 'Calculate' button
    public void Calculate()
    {
        // Initialisation of variables
        double medicareLevyPaid = 0;
        double incomeTaxPaid = 0;

        // Input
        double grossSalaryInput = GetGrossSalary();
        string salaryPayPeriod = GetSalaryPayPeriod();

        // Calculations
        double grossYearlySalary = CalculateGrossYearlySalary(grossSalaryInput, salaryPayPeriod);
        double netIncome = CalculateNetIncome(grossYearlySalary, ref medicareLevyPaid, ref incomeTaxPaid);

        // Output
        OutputResults(medicareLevyPaid, incomeTaxPaid, netIncome);
    }

    private double GetGrossSalary()
    {
        // Get from user. E.g. input box
        // Validate the input (ensure it is a positive, valid number)
        double grossYearlySalary = double.Parse(InputSalary.text);
        return grossYearlySalary;
    }

    private string GetSalaryPayPeriod()
    {
        // Get from user. E.g. combobox or radio buttons
        // string salaryPayPeriod = PayPeriodDropDown.value;

        if (PayPeriodDropDown.value == 0)
        {
            return "Weekly";
        }
        else if (PayPeriodDropDown.value == 1)
        {
            return "fortnightly";
        }
        else if (PayPeriodDropDown.value == 2)
        {
            return "Monthly";
        }
        else if (PayPeriodDropDown.value == 3)
        {
            return "Yearly";
        }
        else { return "nO"; }
    }

    private double CalculateGrossYearlySalary(double grossSalaryInput, string salaryPayPeriod)
    {
        // This is a stub, replace with the real calculation and return the result
        double grossYearlySalary = 50000;
        if (salaryPayPeriod == "Weekly")
        {
            return grossYearlySalary * 52;
        }
        else if (salaryPayPeriod == "Fortnightly")
        {
            return grossYearlySalary * 26;
        }
        else if (salaryPayPeriod == "Monthly")
        {
            return grossYearlySalary * 12;
        }
        else if (salaryPayPeriod == "Yearly")
        {
            return grossYearlySalary * 1;
        }
        return grossYearlySalary;
    }

    private double CalculateNetIncome(double grossYearlySalary, ref double medicareLevyPaid, ref double incomeTaxPaid)
    {
        // This is a stub, replace with the real calculation and return the result
        medicareLevyPaid = CalculateMedicareLevy(grossYearlySalary);
        incomeTaxPaid = CalculateIncomeTax(grossYearlySalary);
        double netIncome = grossYearlySalary - medicareLevyPaid - incomeTaxPaid;        
        return netIncome;
    }

    private double CalculateMedicareLevy(double grossYearlySalary)
    {
        // This is a stub, replace with the real calculation and return the result
        double medicareLevyPaid = 2000;        
        return medicareLevyPaid;
    }

    private double CalculateIncomeTax(double grossYearlySalary)
    {
        // This is a stub, replace with the real calculation and return the result
        double incomeTaxPaid = 15000;
        return incomeTaxPaid;
    }

    private void OutputResults(double medicareLevyPaid, double incomeTaxPaid, double netIncome)
    {
        // Output the following to the GUI
        // "Medicare levy paid: $" + medicareLevyPaid.ToString("F2");
        // "Income tax paid: $" + incomeTaxPaid.ToString("F2");
        // "Net income: $" + netIncome.ToString("F2");
    }

    // Text to Speech
    private async void Speak(string textToSpeech)
    {
        if(textToSpeechEnabled)
        {
            SpVoice voice = new SpVoice();
            await SpeakAsync(textToSpeech);
        }
    }

    private Task SpeakAsync(string textToSpeak)
    {
        return Task.Run(() =>
        {
            SpVoice voice = new SpVoice();
            voice.Speak(textToSpeak);
        });
    }
}
