using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delta.Models
{
    public class MyDelta
    {
        private string? _valueA;
        private double _a;
        private string? _verificA
        {
            get => this._valueA;
            set
            {
                if (!int.TryParse(value, out int n)) throw new Exception ("Favor informe apenas valores numericos...[A]");
                _valueA = value;
            }
        }
        private string? _valueB;
        private double _b;
        private string? _verificB
        {
            get => this._valueB;
            set
            {
                if (!int.TryParse(value, out int n)) throw new Exception ("Favor informe apenas valores numericos...[B]");
                _valueB = value;
            }
        }
        private string? _valueC;
        private double _c;
        private string? _verificC
        {
            get => this._valueC;
            set
            {
                if (!int.TryParse(value, out int n)) throw new Exception ("Favor informe apenas valores numericos...[C]");
                _valueC = value;
            }
        }
        public MyDelta (string? a, string? b, string? c)
        {
            this._verificA = a;
            this._valueB = b;
            this._valueC = c;
        }

        private void Converter ()
        {
            this._a = Convert.ToDouble (this._valueA);
            this._b = Convert.ToDouble (this._valueB);
            this._c = Convert.ToDouble (this._valueC);
        }
        public (double delta, double x1, double x2) ValueX ()
        {
            Converter();
            //b2 - 4 ac
            double bpow = Math.Pow (_b, 2);
            double cCalc = (-4 * _a )*_c;
            double delta = cCalc < 0 ? bpow - cCalc : bpow + cCalc;

            double x1 = 0;
            double x2 = 0;

            double raiz = Math.Sqrt (delta);
            double bX = -_b;

            x1 = (bX + raiz) / 2;
            x2 = (bX - raiz) / 2;

            return (delta, x1, x2);
        }
    }
}