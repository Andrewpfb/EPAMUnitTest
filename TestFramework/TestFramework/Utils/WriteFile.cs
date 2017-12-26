using System.IO;


namespace TestFramework.Utils
{
    public class WriteFile
    {
        public static void Write(string text)
        {
            using (FileStream fstream = new FileStream(@"D:\logsTest.txt", FileMode.Append))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fstream.Write(array, 0, array.Length);
            }
        }
    }
}
