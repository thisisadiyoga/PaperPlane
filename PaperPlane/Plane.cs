using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Data;
using System.Runtime.Serialization;
using System.Xml;
using System.Collections.ObjectModel;

namespace PaperPlane
{
    [KnownType(typeof(Paper))]
    [DataContract]
    public class Plane
    {
        /// Data Members
        [DataMember]
        private List<Paper> _paper;

        /// View
        public ICollectionView Paper
        {
            get { return CollectionViewSource.GetDefaultView(_paper); }
            set { _paper = value.Cast<Paper>().ToList(); }
        }



        /// Constructor
        public Plane()
        {
            _paper = new List<Paper>();
            LoremIpsum();
        }



        /// Modifier
        public void Add(Paper paper) { _paper.Add(paper); }
        public void Add(String title, String[] tags) { _paper.Add(new Paper(title, tags)); }
        public void Add(String title, String tagstr) { _paper.Add(new Paper(title, tagstr)); }



        /// File System
        public void Land()
        {
            /* TODO:
             * For each element
             * - Check that the relative path links are correct (exactly the same as the tags)
             * - Add new relative path links
             * - Remove unused relative path links
             */
        }



        /// TEST
        public void LoremIpsum()
        {
            Add("1. One", "A, B, C");
            Add("2. Two", "B, C, D");
            Add("3. Three", "C, D, E, F");
            Add("4. Four", "D, E, F");
            Add("5. Five", "A, B, C");
        }
    }
}
