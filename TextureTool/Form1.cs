using System.Drawing.Imaging;
using System.Windows.Forms;

namespace TextureTool
{
    public partial class ChannelMergeTool : Form
    {
        public ChannelMergeTool()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //comboAlphaChannel.Items.AddRange(new string[] { "Red", "Green", "Blue", "Alpha", "Grayscale" });
            comboAlphaChannel.SelectedIndex = 0; // 默认选 Red
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            RGB_picture.AllowDrop = true;
            R_picture.AllowDrop = true;
            G_picture.AllowDrop = true;
            B_picture.AllowDrop = true;
            Alpha_picture.AllowDrop = true;


        }
        private async void button1_Click(object sender, EventArgs e)
        {

            Bitmap rgbImage = RGB_picture.Image != null ? new Bitmap(RGB_picture.Image) : null;
            Bitmap alphaImage = Alpha_picture.Image != null ? new Bitmap(Alpha_picture.Image) : null;

            if (rgbImage == null && alphaImage == null)
            {
                MessageBox.Show("请至少加载一张图片。");
                return;
            }

            // 尺寸匹配（取已有图最小尺寸）
            int width = 0, height = 0;
            if (rgbImage != null)
            {
                width = rgbImage.Width;
                height = rgbImage.Height;
            }
            if (alphaImage != null)
            {
                width = width == 0 ? alphaImage.Width : Math.Min(width, alphaImage.Width);
                height = height == 0 ? alphaImage.Height : Math.Min(height, alphaImage.Height);
            }

            if (rgbImage == null) rgbImage = new Bitmap(width, height);
            if (alphaImage == null) alphaImage = new Bitmap(width, height);

            // UI 设置
            progressBar1.Maximum = height;
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            Merge_RGB_button1.Enabled = false;

            Bitmap resultImage = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            int selectedChannel = comboAlphaChannel.SelectedIndex;

            await Task.Run(() =>
            {
                Rectangle rect = new Rectangle(0, 0, width, height);

                BitmapData rgbData = rgbImage.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                BitmapData alphaData = alphaImage.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                BitmapData resultData = resultImage.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                unsafe
                {
                    byte* rgbScan0 = (byte*)rgbData.Scan0;
                    byte* alphaScan0 = (byte*)alphaData.Scan0;
                    byte* resultScan0 = (byte*)resultData.Scan0;

                    int stride = rgbData.Stride;

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            int i = y * stride + x * 4;

                            byte r = rgbScan0[i + 2];
                            byte g = rgbScan0[i + 1];
                            byte b = rgbScan0[i + 0];

                            byte aSrcR = alphaScan0[i + 2];
                            byte aSrcG = alphaScan0[i + 1];
                            byte aSrcB = alphaScan0[i + 0];
                            byte aSrcA = alphaScan0[i + 3];

                            byte a = 0;
                            switch (selectedChannel)
                            {
                                case 0: a = aSrcR; break;
                                case 1: a = aSrcG; break;
                                case 2: a = aSrcB; break;
                                case 3: a = aSrcA; break;
                            }

                            resultScan0[i + 0] = b;
                            resultScan0[i + 1] = g;
                            resultScan0[i + 2] = r;
                            resultScan0[i + 3] = a;
                        }

                        Invoke(new Action(() => progressBar1.Value = y + 1));
                    }
                }

                rgbImage.UnlockBits(rgbData);
                alphaImage.UnlockBits(alphaData);
                resultImage.UnlockBits(resultData);
            });

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG 图片|*.png";
            sfd.Title = "保存合并后的图片";
            sfd.FileName = "merged_image.png";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                resultImage.Save(sfd.FileName, ImageFormat.Png);
                MessageBox.Show("图片已保存到：" + sfd.FileName);
            }

            progressBar1.Value = 0;
            Merge_RGB_button1.Enabled = true;
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择一张图片";
            ofd.Filter = "图片文件|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    RGB_picture.Image = new Bitmap(ofd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载图片失败: " + ex.Message);
                }
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            Bitmap rImg = R_picture.Image != null ? new Bitmap(R_picture.Image) : null;
            Bitmap gImg = G_picture.Image != null ? new Bitmap(G_picture.Image) : null;
            Bitmap bImg = B_picture.Image != null ? new Bitmap(B_picture.Image) : null;
            Bitmap aImg = Alpha_picture.Image != null ? new Bitmap(Alpha_picture.Image) : null;

            if (rImg == null && gImg == null && bImg == null && aImg == null)
            {
                MessageBox.Show("请至少加载一张图片。");
                return;
            }

            // 确定输出图像的大小
            int width = int.MaxValue, height = int.MaxValue;

            foreach (var img in new[] { rImg, gImg, bImg, aImg })
            {
                if (img != null)
                {
                    width = Math.Min(width, img.Width);
                    height = Math.Min(height, img.Height);
                }
            }

            if (width == int.MaxValue || height == int.MaxValue)
            {
                MessageBox.Show("图片尺寸获取失败。");
                return;
            }

            Bitmap result = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            progressBar2.Maximum = height;
            progressBar2.Value = 0;
            button2.Enabled = false;

            int rIndex = comboBox1.SelectedIndex;
            int gIndex = comboBox2.SelectedIndex;
            int bIndex = comboBox3.SelectedIndex;
            int aIndex = comboAlphaChannel.SelectedIndex;

            await Task.Run(() =>
            {
                Rectangle rect = new Rectangle(0, 0, width, height);

                BitmapData rData = rImg?.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                BitmapData gData = gImg?.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                BitmapData bData = bImg?.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                BitmapData aData = aImg?.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                BitmapData resData = result.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                unsafe
                {
                    byte* rPtr = (byte*)(rData?.Scan0 ?? IntPtr.Zero);
                    byte* gPtr = (byte*)(gData?.Scan0 ?? IntPtr.Zero);
                    byte* bPtr = (byte*)(bData?.Scan0 ?? IntPtr.Zero);
                    byte* aPtr = (byte*)(aData?.Scan0 ?? IntPtr.Zero);
                    byte* resPtr = (byte*)resData.Scan0;

                    int stride = resData.Stride;

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            int i = y * stride + x * 4;

                            resPtr[i + 2] = GetChannelValue(rPtr, i, rIndex); // R
                            resPtr[i + 1] = GetChannelValue(gPtr, i, gIndex); // G
                            resPtr[i + 0] = GetChannelValue(bPtr, i, bIndex); // B
                            resPtr[i + 3] = GetChannelValue(aPtr, i, aIndex); // A
                        }

                        Invoke(new Action(() => progressBar2.Value = y + 1));
                    }
                }

                if (rData != null) rImg.UnlockBits(rData);
                if (gData != null) gImg.UnlockBits(gData);
                if (bData != null) bImg.UnlockBits(bData);
                if (aData != null) aImg.UnlockBits(aData);
                result.UnlockBits(resData);
            });

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG 图片|*.png";
            sfd.Title = "保存合成图片";
            sfd.FileName = "merged_image.png";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                result.Save(sfd.FileName, ImageFormat.Png);
                MessageBox.Show("已保存：" + sfd.FileName);
            }

            button2.Enabled = true;
            progressBar2.Value = 0;
        }
        private unsafe byte GetChannelValue(byte* ptr, int i, int index)
        {
            if (ptr == null) return 0;

            byte r = ptr[i + 2];
            byte g = ptr[i + 1];
            byte b = ptr[i + 0];
            byte a = ptr[i + 3];

            return index switch
            {
                0 => r,                           // Red
                1 => g,                           // Green
                2 => b,                           // Blue
                3 => a,                           // Alpha
                4 => (byte)((r + g + b) / 3),     // Grayscale
                _ => 0
            };
        }

        private void Alpha_picture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择一张图片";
            ofd.Filter = "图片文件|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Alpha_picture.Image = new Bitmap(ofd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载图片失败: " + ex.Message);
                }
            }
        }

        private void R_picture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择一张图片";
            ofd.Filter = "图片文件|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    R_picture.Image = new Bitmap(ofd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载图片失败: " + ex.Message);
                }
            }
        }

        private void G_picture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择一张图片";
            ofd.Filter = "图片文件|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    G_picture.Image = new Bitmap(ofd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载图片失败: " + ex.Message);
                }
            }
        }

        private void B_picture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择一张图片";
            ofd.Filter = "图片文件|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    B_picture.Image = new Bitmap(ofd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载图片失败: " + ex.Message);
                }
            }
        }

        private void RGB_picture_DragEnter(object sender, DragEventArgs e)
        {
            // 检查是否是文件类型
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0 && IsImageFile(files[0]))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private bool IsImageFile(string path)
        {
            string ext = Path.GetExtension(path).ToLower();
            return ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp" || ext == ".gif";
        }

        private void RGB_picture_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                try
                {
                    RGB_picture.Image = new Bitmap(files[0]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载图片失败: " + ex.Message);
                }
            }
        }

        private void R_picture_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                try
                {
                    R_picture.Image = new Bitmap(files[0]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载图片失败: " + ex.Message);
                }
            }
        }

        private void G_picture_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                try
                {
                    G_picture.Image = new Bitmap(files[0]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载图片失败: " + ex.Message);
                }
            }
        }

        private void B_picture_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                try
                {
                    B_picture.Image = new Bitmap(files[0]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载图片失败: " + ex.Message);
                }
            }
        }

        private void Alpha_picture_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                try
                {
                    Alpha_picture.Image = new Bitmap(files[0]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载图片失败: " + ex.Message);
                }
            }
        }
    }
}
