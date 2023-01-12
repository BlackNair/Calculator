namespace Calc.Interfaces
{
    public class ValueWork: IValue
    {
        public string Sum(string a, string b)
        {
            int result = Convert.ToInt32(a)+Convert.ToInt32(b);
            return result.ToString();
        }

        public string Div(string a, string b)
        {
            int result = Convert.ToInt32(a)/Convert.ToInt32(b);
            return result.ToString();
        }

        public string Mult(string a, string b)
        {
            int result = Convert.ToInt32(a) * Convert.ToInt32(b);
            return result.ToString();
        }

        public string Sub(string a, string b)
        {
            int result = Convert.ToInt32(a) - Convert.ToInt32(b);
            return result.ToString();
        }
    }
}
