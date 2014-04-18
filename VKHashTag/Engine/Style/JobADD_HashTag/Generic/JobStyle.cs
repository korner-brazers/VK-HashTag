using System.Windows.Controls;

namespace VKHashTag.Engine.Style.JobADD_HashTag.Generic
{
    public partial class JobStyle
    {
        private void PutUserIDhttp_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Image img = (sender as Image);
            if (img != null)
            {
                System.Diagnostics.Process.Start("https://vk.com/public" + img.Tag.ToString().Replace("-", ""));
                img = null;
            }
            sender = null; e = null;
        }
    }
}
