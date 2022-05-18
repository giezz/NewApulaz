using System;
using System.IO;

namespace WinFormsEntityFrameWork
{
    public class Class
    {
        void test()
        {
            try
            {
                StreamReader streamReader = new StreamReader("null");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}