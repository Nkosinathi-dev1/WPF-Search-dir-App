using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DataTable dt = new DataTable();

        List<DirData> dirData = new List<DirData>();

        // List<string> fileName= new List<string>();
        //List<string> fileVersion = new List<string>();
        public MainWindow()
        {


        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
           System.Windows.Forms.MessageBox.Show($"{dirInput.Text}");
            dirInput.Text = dirInput.Text;
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            string rootPath = "";
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    dirInput.Text = fbd.SelectedPath.ToString();
                    System.Windows.Forms.MessageBox.Show("Files found: " + fbd.SelectedPath.ToString(), "Message");                    
                    rootPath = fbd.SelectedPath.ToString();
                }
            }


            
            string extnsn = ".dll";
            int count = 0;
            //
            string tempFileName = "", tempFileVersion = "";
            

            var files_x = Directory.GetFiles(rootPath, "*.*", SearchOption.AllDirectories);
            foreach (string file in files_x)
            {
                var info = new FileInfo(file);

                if (info.Extension == extnsn)
                {


                    //Get the file path.
                    FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(System.IO.Path.GetFullPath(file));

                    //get the file name and version number.
                    dirData.Add(new DirData { fileName = myFileVersionInfo.OriginalFilename, fileVersion = myFileVersionInfo.FileVersion });
                    tempFileName = myFileVersionInfo.OriginalFilename;
                    tempFileVersion = myFileVersionInfo.FileVersion;


                        DirGrid.Items.Add(new DirData()
                        {
                            fileName = tempFileName,
                            fileVersion = tempFileVersion,

                        });
                    

                    count++;

                }
            
            }
            count = 0;
            //foreach (var rowDir in dirData)
            //{

            //    dt.Rows.Add(rowDir.fileName.ToString(), rowDir.fileVersion.ToString());
            //    this.DirGrid.DataContext.ToString();

            //}
            //count = 0;
        }

        private void myComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public class DirData
        {
            public string fileName { get; set; }
            public string fileVersion { get; set; }
        }

        private void dirInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    
  
}
