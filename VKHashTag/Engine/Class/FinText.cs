namespace VKHashTag.Engine.Class
{
    class FinText
    {
        public static string get(string s1, string s2, string s3, long x)
        {
            long n = x % 100;
            if ((n > 10) && (n < 20)) { s1 = null; s2 = null; return s3; }
            else
            {
                switch (x % 10)
                {
                    case 0:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        s1 = null; s2 = null; return s3;
                    case 1:
                        s2 = null; s3 = null; return s1;
                    case 2:
                    case 3:
                    case 4:
                        s1 = null; s3 = null; return s2;
                }
            }

            s1 = null; s2 = null; s3 = null;
            return "";
        }
    }
}
