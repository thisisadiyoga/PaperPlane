using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml;

namespace PaperPlane
{
    [DataContract]
    public class Paper : INotifyPropertyChanged
    {
        /// Data Members
        [DataMember]
        private String _title;
        [DataMember]
        private String[] _tags;

        /// View
        public String Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyPropertyChanged("Title");
            }
        }
        public String Tags
        {
            get
            {
                String res = "";
                for (int i = 0; i < _tags.Length; i++)
                {
                    res += i > 0 ? ", " : "";
                    res += _tags[i];
                }
                return res;
            }
            set
            {
                String[] tags = value.Split(',');
                for (int i = 0; i < tags.Length; i++)
                {
                    tags[i] = tags[i].Trim();
                }
                Array.Sort<String>(tags);
                _tags = tags;
                NotifyPropertyChanged("Tags");
            }
        }



        /// Constructors
        public Paper(String title, String[] tags)
        {
            Array.Sort<String>(tags);
            _title = title; _tags = tags;
        }
        public Paper(String title, String tagstr)
        {
            String[] tags = tagstr.Split(',');
            for (int i = 0; i < tags.Length; i++)
            {
                tags[i] = tags[i].Trim();
            }
            Array.Sort<String>(tags);
            _title = title; _tags = tags;
        }



        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
