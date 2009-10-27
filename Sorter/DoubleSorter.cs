using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Fitness
{
    class DoubleSorter : IComparer
    {
        private SortOrder sortOrder;
        private int sortColumn = -1;

        public int Compare(object x, object y)
        {
            char[] removeChar = { '%', 'k', 'g', ' ' };

            Double firstValue = Convert.ToDouble((x as ListViewItem).SubItems[sortColumn].Text.TrimEnd(removeChar));
            Double secondValue = Convert.ToDouble((y as ListViewItem).SubItems[sortColumn].Text.TrimEnd(removeChar));

            if (sortOrder == SortOrder.Descending)
                return secondValue.CompareTo(firstValue);
            else
                return firstValue.CompareTo(secondValue);
        }

        public DoubleSorter(SortOrder so, int column)
        {
            this.sortColumn = column;
            this.sortOrder = so;
        }
    }
}
