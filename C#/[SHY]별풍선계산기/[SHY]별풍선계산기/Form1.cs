using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _SHY_별풍선계산기
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void 베스트BJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            베스트BJToolStripMenuItem.Checked = true;
            파트너BJToolStripMenuItem.Checked = false;
            일반BJToolStripMenuItem.Checked = false;
        }

        private void 파트너BJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            베스트BJToolStripMenuItem.Checked = false;
            파트너BJToolStripMenuItem.Checked = true;
            일반BJToolStripMenuItem.Checked = false;
        }

        private void 일반BJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            베스트BJToolStripMenuItem.Checked = false;
            파트너BJToolStripMenuItem.Checked = false;
            일반BJToolStripMenuItem.Checked = true;
        }

        private void Item_Count_Text_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (베스트BJToolStripMenuItem.Checked)
                {
                    //텍박의 string형식을 int형식으로 변형
                    int convertedstring = Convert.ToInt32(Item_Count_Text.Text);

                    //convertedstring에 100을 곱해준다.
                    원금액_Label.Text = Convert.ToString(convertedstring * 100);

                    //convertedstring에 30을 곱해준다.
                    수수료액_Label.Text = Convert.ToString(convertedstring * 30);

                    //세액을 반올림해준다.(소득세3% + 주민세0.3%)
                    int 세액start = convertedstring * 70 / 1000 * 33;
                    int 세액ing1 = 세액start + 5;
                    int 세액ing2 = 세액ing1 / 10;
                    int 세액result = 세액ing2 * 10;
                    //반올림한 세액을 라벨에 띄운다.
                    세액_Label.Text = Convert.ToString(세액result);

                    //원금액 - 수수료액 - 세액
                    //수익금_Label.Text = Convert.ToString(Convert.ToInt16(원금액_Label.Text) - Convert.ToInt16(수수료액_Label.Text) - Convert.ToInt16(세액_Label.Text));
                    수익금_Label.Text = Convert.ToString(Convert.ToInt32(원금액_Label.Text) - Convert.ToInt32(수수료액_Label.Text) - 세액result);
                }
                else if (파트너BJToolStripMenuItem.Checked)
                {
                    //텍박의 string형식을 int형식으로 변형
                    int convertedstring = Convert.ToInt32(Item_Count_Text.Text);

                    //convertedstring에 100을 곱해준다.
                    원금액_Label.Text = Convert.ToString(convertedstring * 100);

                    //convertedstring에 20을 곱해준다.
                    수수료액_Label.Text = Convert.ToString(convertedstring * 20);

                    //세액을 반올림해준다.(소득세3% + 주민세0.3%)
                    int 세액start = convertedstring * 80 / 1000 * 33;
                    int 세액ing1 = 세액start + 5;
                    int 세액ing2 = 세액ing1 / 10;
                    int 세액result = 세액ing2 * 10;
                    //반올림한 세액을 라벨에 띄운다.
                    세액_Label.Text = Convert.ToString(세액result);

                    //원금액 - 수수료액 - 세액
                    //수익금_Label.Text = Convert.ToString(Convert.ToInt16(원금액_Label.Text) - Convert.ToInt16(수수료액_Label.Text) - Convert.ToInt16(세액_Label.Text));
                    수익금_Label.Text = Convert.ToString(Convert.ToInt32(원금액_Label.Text) - Convert.ToInt32(수수료액_Label.Text) - 세액result);
                }
                else
                {
                    //텍박의 string형식을 int형식으로 변형
                    int convertedstring = Convert.ToInt32(Item_Count_Text.Text);

                    //convertedstring에 100을 곱해준다.
                    원금액_Label.Text = Convert.ToString(convertedstring * 100);

                    //convertedstring에 40을 곱해준다.
                    수수료액_Label.Text = Convert.ToString(convertedstring * 40);

                    //세액을 반올림해준다.(소득세3% + 주민세0.3%)
                    int 세액start = convertedstring * 60 / 1000 * 33;
                    int 세액ing1 = 세액start + 5;
                    int 세액ing2 = 세액ing1 / 10;
                    int 세액result = 세액ing2 * 10;
                    //반올림한 세액을 라벨에 띄운다.
                    세액_Label.Text = Convert.ToString(세액result);

                    //원금액 - 수수료액 - 세액
                    //수익금_Label.Text = Convert.ToString(Convert.ToInt16(원금액_Label.Text) - Convert.ToInt16(수수료액_Label.Text) - Convert.ToInt16(세액_Label.Text));
                    수익금_Label.Text = Convert.ToString(Convert.ToInt32(원금액_Label.Text) - Convert.ToInt32(수수료액_Label.Text) - 세액result);
                }
            }
        }
    }
}
