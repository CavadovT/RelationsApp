namespace FrontToBack.Helper
{
    public static class Helper
    {
        public static void DeleteImage(string path) 
        {
           
                System.IO.File.Delete(path);
            
        }
    }
}
