using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Fitness
{
    class DateSorter : IComparer
    {
        private SortOrder sortOrder;

        public int Compare(object x, object y)
        {
            DateTime firstDate = Convert.ToDateTime((x as ListViewItem).Text);
            DateTime secondDate = Convert.ToDateTime((y as ListViewItem).Text);

            if (this.sortOrder == SortOrder.Descending)
                return secondDate.CompareTo(firstDate);
            else
                return firstDate.CompareTo(secondDate);
        }

        public DateSorter(SortOrder so)
        {
            this.sortOrder = so;
        }
    }
}
