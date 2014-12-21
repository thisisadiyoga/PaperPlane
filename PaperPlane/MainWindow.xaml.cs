using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;

namespace PaperPlane
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// Data Member
        public Plane _plane;

        public MainWindow()
        {
            InitializeComponent();
            LoadFile();
            DataContext = _plane;
        }



        /// Save
        public void Save(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }
        private void SaveFile()
        {
            var ser = new DataContractSerializer(typeof(Plane));
            var set = new XmlWriterSettings { Indent = true };
            using (XmlWriter xw = XmlWriter.Create(Constant.SAVEFILE, set))
            {
                ser.WriteObject(xw, _plane);
            }
        }



        /// Load
        public void Load(object sender, RoutedEventArgs e)
        {
            LoadFile();
        }
        private void LoadFile()
        {
            if (File.Exists(Constant.SAVEFILE))
            {
                DataContractSerializer dcs = new DataContractSerializer(typeof(Plane));
                FileStream fs = new FileStream(Constant.SAVEFILE, FileMode.Open);
                XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                _plane = (Plane)dcs.ReadObject(reader);
                DataContext = _plane;
                fs.Close();
            }
            else
            {
                _plane = new Plane();
                SaveFile();
            }
        }



        /// Check
        public void Check(object sender, RoutedEventArgs e)
        {
            CheckFile();
        }
        private void CheckFile()
        {
        }



        /// Fly
        public void Fly(object sender, RoutedEventArgs e)
        {
            FlyFile();
        }
        private void FlyFile()
        {
        }



        /// Add
        public void Add(object sender, RoutedEventArgs e)
        {
            AddFile();
        }
        private void AddFile()
        {
        }
    }
}
