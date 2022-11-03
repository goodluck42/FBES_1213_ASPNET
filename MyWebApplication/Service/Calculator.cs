namespace MyWebApplication.Service
{
    public class Calculator
    {
        public string Calc(string expression)
        {
			double n1;
			double n2;

			if (expression.Contains('*'))
            {
                var result = expression.Split('*');

                n1 = double.Parse(result[0]);
                n2 = double.Parse(result[1]);

                return (n1 * n2).ToString();
            }
            
            if (expression.Contains('+'))
            {
				var result = expression.Split('+');

				n1 = double.Parse(result[0]);
				n2 = double.Parse(result[1]);

				return (n1 + n2).ToString();
			}
            
            if (expression.Contains('-'))
            {
				var result = expression.Split('-');

				n1 = double.Parse(result[0]);
				n2 = double.Parse(result[1]);

				return (n1 - n2).ToString();
			}
            
            if (expression.Contains('/'))
            {
				var result = expression.Split('/');

				n1 = double.Parse(result[0]);
				n2 = double.Parse(result[1]);

                if (n2 == 0)
                {
                    return string.Empty;
                }

				return (n1 / n2).ToString();
			}

			return string.Empty;
		}
    }
}
