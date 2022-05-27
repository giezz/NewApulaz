using System;
using System.IO;

namespace WinFormsEntityFrameWork
{
    /// <summary>
    /// нахуй не нужный класс
    /// </summary>
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