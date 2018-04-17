using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public delegate void MyDelegate(string msg);
    public enum CurrentState
    {
        Zero,
        AccumulateDigits,
        AccumulateDigitsWithDecimal,
        ComputeWithPending,
        ComputeResult,
        ShowError
    }
    public class Brain
    {
        double MemoryNumber = 0;
        public string number = "";
        public string result = "";
        public string op;

        public MyDelegate invoker;
        public CurrentState currentState;
        string[] all_digits = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string[] non_zero_digits = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string[] zero_digits = { "0" };
        string[] C = { "C" };
        string[] CE = { "CE" };
        string[] operations = { "+", "-","X","÷","SQRT","Х²", "1/X", "±" };
        string[] equals = { "=" };
        string[] separators = { "." };
        string[] memory = { "MC", "MR", "MS", "M+", "M-" };

        public Brain()
        {
            currentState = CurrentState.Zero;
        }

        public void Process(string operation)
        {
            if (memory.Contains(operation))
            {
                Memory(operation);
                //Zero(true, "0");
            }
            else
            {
                switch (currentState)
                {
                    case CurrentState.Zero:
                        Zero(false, operation);
                        break;
                    case CurrentState.AccumulateDigits:
                        AccumulateDigits(false, operation);
                        break;
                    case CurrentState.AccumulateDigitsWithDecimal:
                        AccumulateDigitsWithDecimal(false, operation);
                        break;
                    case CurrentState.ComputeWithPending:
                        ComputeWithPending(false, operation);
                        break;
                    case CurrentState.ComputeResult:
                        ComputeResult(false, operation);
                        break;
                    case CurrentState.ShowError:
                        break;
                    default:
                        break;
                }
            }
        }

        private void Memory(string info)
        {
            switch (info)
            {
                case "MC":
                    MemoryNumber = 0;
                    break;
                case "MR":
                    result = MemoryNumber.ToString();
                    invoker.Invoke(result);
                    currentState = CurrentState.ComputeWithPending;
                    /*
                    result = "";
                    */
                    break;
                case "MS":
                    MemoryNumber = double.Parse(result);
                    result = "";

                    /*
                    invoker.Invoke(MemoryNumber.ToString());
                    result = "";
                    */
                    break;
                case "M+":
                    MemoryNumber = MemoryNumber + double.Parse(result);
                    result = "";

                    break;
                case "M-":
                    MemoryNumber = MemoryNumber - double.Parse(result);
                    result = "";

                    break;
                default:
                    break;
            }
        }

        public void Zero(bool isInput, string info)
        {
            if (isInput)
            {
                if (info == "C")
                {
                    number = "";
                    result = "";
                }
                if(info == "CE")
                {
                    result = "";
                }
                invoker.Invoke("0");
                currentState = CurrentState.Zero;
            }
            else
            {
                if (non_zero_digits.Contains(info))
                {
                    AccumulateDigits(true, info);
                }
                else if (zero_digits.Contains(info))
                {
                    Zero(true, info);
                }
                else if (separators.Contains(info))
                {
                    result = "0";
                    AccumulateDigitsWithDecimal(true, info);
                }
                else if (operations.Contains(info))
                {
                    result = "0";
                    ComputeWithPending(true, info);
                }
            }
        }
        public void AccumulateDigits(bool isInput, string info)
        {
            if (isInput)
            {
               
                result = result + info;
                currentState = CurrentState.AccumulateDigits;
                invoker.Invoke(result);

            }
            else
            {
                if (all_digits.Contains(info))
                {
                    AccumulateDigits(true, info);
                }
                else if (operations.Contains(info))
                {
                    ComputeWithPending(true, info);
                }
                else if (equals.Contains(info))
                {
                    ComputeResult(true, info);
                }
                else if (C.Contains(info))
                {
                    Zero(true, info);
                }
                else if (CE.Contains(info))
                {
                    Zero(true, info);
                }
                else if (separators.Contains(info))
                {
                    AccumulateDigitsWithDecimal(true, info);
                }
            }

        }
        public void AccumulateDigitsWithDecimal(bool isInput, string info)
        {
            if (isInput)
            {
                if(info =="." && !result.Contains("."))
                {
                    result += ",";
                }
                else
                {
                    result += info;
                }
                currentState = CurrentState.AccumulateDigitsWithDecimal;
                invoker.Invoke(result);
            }
            else
            {
                if (all_digits.Contains(info))
                {
                    AccumulateDigitsWithDecimal(true, info);
                }
                else if (operations.Contains(info))
                {
                    ComputeWithPending( true,info);
                }
                else if (equals.Contains(info))
                {
                    ComputeResult(true, info);
                }
            }

        }
        public void ComputeWithPending(bool isInput, string info)
        {
            if (isInput)
            {
               op = info;
                if (op == "SQRT")
                {
                     result = Math.Sqrt(double.Parse(result)).ToString();
                    if(result == "NaN")
                    {
                        result = "Error";
                    }
                    
                    invoker.Invoke(result);
                    number = result;
                    currentState = CurrentState.ComputeWithPending;
                }
                else if(op== "1/X")
                {
                    result = (1/double.Parse(result)).ToString();
                    invoker.Invoke(result);
                    number = result;
                    currentState = CurrentState.ComputeWithPending;
                }
                else if (op == "Х²")
                {
                    result =  Math.Pow(double.Parse(result),2).ToString();
                    invoker.Invoke(result);
                    number = result;
                    currentState = CurrentState.ComputeWithPending;
                }
                else if (op == "±")
                {
                    result = (-1 * double.Parse(result)).ToString();
                    invoker.Invoke(result);
                    number = result;
                    currentState = CurrentState.ComputeWithPending;

                }

                else
                {
                    if (result != "")
                    {
                        number = result;
                    }
                    result = "";
                    invoker.Invoke("0");
                    currentState = CurrentState.ComputeWithPending;
                }
            }
            else
            {
                if (all_digits.Contains(info))
                {
                    result = "";
                    AccumulateDigits(true, info);
                }
                if (operations.Contains(info))
                {
                    ComputeWithPending(true, info);
                }
                if (equals.Contains(info))
                {
                    ComputeResult(true, info);
                }
                if (C.Contains(info))
                {
                    Zero(true, info);
                }
            }
        }

        public void ComputeResult(bool isInput, string info)
        {
            if (isInput)
            {
                double r = 0;
               
                if (op == "+")
                {
                    double a1 = double.Parse(number);
                    double a2 = double.Parse(result);
                     r = a1 + a2;
                    result = r.ToString();
                }
                if (op == "-")
                {
                    double a1 = double.Parse(number);
                    double a2 = double.Parse(result);
                    r = a1 - a2;
                    result = r.ToString();
                }
                if (op == "X")
                {
                    double a1 = double.Parse(number);
                    double a2 = double.Parse(result);
                    r = a1 * a2;
                    result = r.ToString();
                }
                if (op == "÷")
                {
                    double a1 = double.Parse(number);
                    double a2 = double.Parse(result);
                    r = a1 / a2;
                    result = r.ToString();
                }
                


                if(result == "∞")
                {
                    result = "Error";
                }
                invoker.Invoke(result);
                currentState = CurrentState.ComputeResult;
            }
            else
            {
                if (zero_digits.Contains(info))
                {
                    Zero(true, info);
                }
                else if (operations.Contains(info))
                {
                    ComputeWithPending(true, info);
                }
                else if (C.Contains(info))
                {
                    Zero(true, info);
                }
            }
        }

        public void ShowError(bool isInput, string info)
        {

        }
    }
}