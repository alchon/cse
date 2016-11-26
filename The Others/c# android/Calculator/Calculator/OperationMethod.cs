using System.Text;
using Jace; // 31 ���� ����

namespace Calculator
{
    static class OperationMethod
    {

        // ����� �ϴ� �޼��� 

        public static string answer(StringBuilder text)
        {
            double result = 0.00;

            // Substring(n) - n�� ��ġ���� ������

            if (!text.ToString().Substring(0).Equals("."))
            {
                if (text.Length != 0)
                {   

                    //  ���� �ڿ� �ִ°��� ���������� �˻�

                    if ((text.ToString().Substring(text.Length - 1)).Equals("+") || (text.ToString().Substring(text.Length - 1)).Equals("-") || (text.ToString().Substring(text.Length - 1)).Equals("*") || (text.ToString().Substring(text.Length - 1)).Equals("/"))
                    {
                        text.Length -= 1;
                    }
                    else
                    {
                        // Visual studio ���� 
                        // ���� - NutGet ��Ű�� ������ - ��Ű�� ������ �ܼ�
                        // Install-Package Jace �Է�
                        // https://www.nuget.org/packages/Jace

                        CalculationEngine engine = new CalculationEngine();
                        result = engine.Calculate(text.ToString());
                    }
                }
            }
            else
            {
                text.Clear();
                text.Append("0.0");
            }

            return result.ToString();
        }

        // �ڿ������� �ϳ��� �����ִ� �޼���

        public static string delete(StringBuilder text)
        {
            if (text.Length != 0)
            {
                text.Length -= 1;
            }

            return text.ToString();
        }

        // ���� ����ִ� �޼���
        // �տ� ���� �̹� ���������� �ڿ� ���� ������
        // ex) 12.5 + ���·� 2.5�� �������ϸ� .�� ������

        public static string dot(StringBuilder text, string btnText)
        {
            if (!text.ToString().Contains("."))
                if (text.ToString() == string.Empty)
                    text.Append("0.");
                else
                    text.Append(".");

            return text.ToString();
        }

        // ������ �ڿ� �ٿ��ִ� �޼���

        public static string operationDisplay(StringBuilder text, string btnText, string txtDisplay)
        {
            // IsNullOrEmpty(value) -  �Ű� ���� value�� null �̰ų� �� ���ڿ�("")�̸� true �̰�, �׷��� ������ false�Դϴ�.
            // https://msdn.microsoft.com/ko-kr/library/system.string.isnullorempty(v=vs.110).aspx
            if (!string.IsNullOrEmpty(txtDisplay))
            {
                // ���ڵڿ� �����ڰ� �ִ»��·� �� �����ڸ� ������ �����ڸ� �ٲ�� �ؽ�Ʈ�� �ѹ� ������
                // ex) text.Clear(); �� ���� ���·� 5 + ���� - �� ������ 5 + 5 - �� ����̵�
                // ex) text.Clear(); �� ������ 5 + ���� - �� ������ 5 - �� ���
                text.Clear();
                text.Append(txtDisplay);
            }

            if (text.Length == 0)
                text.Append("0");

            // ������ �ؽ�Ʈ�� �������ϰ�� �� �����ڸ� ������
            else if ((text.ToString().Substring(text.Length - 1)).Equals("+") || (text.ToString().Substring(text.Length - 1)).Equals("-") || (text.ToString().Substring(text.Length - 1)).Equals("*") || (text.ToString().Substring(text.Length - 1)).Equals("/"))
                text.Length -= 1;


            return text.Append(btnText).ToString();
        }
    }
}
