using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clusterizer
{
    public class ColorGenerator : IEnumerable<Color>
    {
        private IEnumerable<int> _indexGenerator;
        public ColorGenerator(IEnumerable<int> indexGenerator)
        {
            _indexGenerator = indexGenerator;
        }

        private Color GetColorFromIndex(int index)
        {
            byte red = (byte)(index & 0x000000FF);
            byte green = (byte)((index & 0x0000FF00) >> 08);
            byte blue = (byte)((index & 0x00FF0000) >> 16);
            return Color.FromArgb(red, green, blue);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var index in _indexGenerator)
            {
                yield return GetColorFromIndex(index);
            }
        }

        IEnumerator<Color> IEnumerable<Color>.GetEnumerator()
        {
            foreach (var index in _indexGenerator)
            {
                yield return GetColorFromIndex(index);
            }
        }
    }
}
