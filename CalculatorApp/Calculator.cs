using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class Calculator
    {
        public enum OperatorEnum { None, Plus, Minus, Divide, Multiply }

        public decimal? Calculate()
        {
           decimal? val = 0;
            switch (this.Operator)
            {
                case OperatorEnum.Plus:
                    val = this.Factor1 + this.Factor2;
                    break;
                case OperatorEnum.Minus:
                    val = this.Factor1 - this.Factor2;
                    break;
                case OperatorEnum.Multiply:
                    val = this.Factor1 * this.Factor2;
                    break;
                case OperatorEnum.Divide:
                    val = this.Factor1 / this.Factor2;
                    break;
            }
            this.Result = val;
            return val;
        }
        public void AddInput(string value)
        {
            //convert value to decimal
            int n = 0; 
            bool b = int.TryParse(value, out n);
            if (b == true)
            {
                if (this.Factor1 != null && this.Operator != OperatorEnum.None)
                {

                    //Factor2
                    this.Factor2 = AddInputToFactor(this.Factor2, n);
                }

                else
                {
                    //factor1
                    this.Factor1 = AddInputToFactor(this.Factor1, n);
                }
                
                ////deterine which factor to put it in 
            }
            else
            {
                switch (value.ToLower())
                {
                    case "+":
                        this.Operator = OperatorEnum.Plus;
                        break;
                    case "-":
                        this.Operator = OperatorEnum.Minus;
                        break;
                    case "*": 
                    case "x":
                        this.Operator = OperatorEnum.Multiply;
                        break;
                    case "/":
                    case "\\":
                        this.Operator = OperatorEnum.Divide;
                        break;
                }
            }
        }

        private decimal? AddInputToFactor(decimal? currentval, int newval)
            {
            //if currentval is blanlk(null or 0) then set currentval = newval
            if(currentval == null || currentval == 0)
            {
                currentval = newval;
            }
            else
            {
                string s = currentval.ToString() + newval.ToString();
                decimal n;
                decimal.TryParse(s, out n);
                currentval = n;
            }
            //else concatenate newval onto currentval as a string and then tryparse into currentval 

                return currentval;
            }
        public void Clear() 
        {
            this.Factor1 = null;
            this.Factor2 = null;
            this.Operator = OperatorEnum.None;
            this.Result = null;
        }
        public string OperatorDisplay
        {
            get
            {
                string val = "";
                switch (this.Operator)
                {
                    case OperatorEnum.Minus:
                        val = "-";

                        break;
                    case OperatorEnum.Plus:
                        val = "+";
                        break;
                    case OperatorEnum.Multiply:
                        val = "*";
                        break;
                    case OperatorEnum.Divide:
                        val = "/";
                        break;
                }
                    return val;
            }
        }
        public string EquationDisplay
        {  
            get 
            {
                string s = this.Factor1 + " " + this.OperatorDisplay + " " + this.Factor2 + " = " + this.Result;

                return s;
            }
        }
        public decimal? Factor1 { get; set; }
        public decimal? Factor2 { get; set; }
        public OperatorEnum Operator { get; set; }

        public decimal? Result { get; private set; }

    }
}
