using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    
        public class WrappingListBox : ListBox
        {
            public WrappingListBox()
            {
                this.DrawMode = DrawMode.OwnerDrawFixed;
                this.HorizontalScrollbar = true;
            }

            protected override void OnDrawItem(DrawItemEventArgs e)
            {
                if (e.Index < 0) return;

                e.DrawBackground();
                string text = this.Items[e.Index].ToString();

                // Малюємо текст
                e.Graphics.DrawString(text, e.Font, new SolidBrush(e.ForeColor), e.Bounds.X, e.Bounds.Y);

                e.DrawFocusRectangle();
            }

            protected override void OnMeasureItem(MeasureItemEventArgs e)
            {
                if (e.Index < 0) return;

                string text = this.Items[e.Index].ToString();

                // Визначаємо розмір тексту без обгортання
                SizeF textSize = e.Graphics.MeasureString(text, this.Font);

                // Встановлюємо ширину горизонтальної смуги прокрутки
                if (textSize.Width > this.HorizontalExtent)
                {
                    this.HorizontalExtent = (int)textSize.Width;
                }

                // Встановлюємо висоту елемента
                e.ItemHeight = this.ItemHeight;
            }
        }
    
}
