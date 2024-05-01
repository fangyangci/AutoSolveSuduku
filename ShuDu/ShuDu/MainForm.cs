using Newtonsoft.Json;
using ShuDu.Properties;
using System.Data;
using System.Drawing.Imaging;

namespace ShuDu
{
    public partial class MainForm : Form
    {
        enum Direction
        {
            None,
            LeftTop,
            RightTop,
            LeftBottom,
            RightBottom,
            Top,
            Bottom,
            Left,
            Right
        }

        class WordData
        {
            private float _width;
            private float _height;

            public float WordWidth
            {
                get 
                {
                    if (_width == 0)
                    {
                        _width = Xs.Max() - Xs.Min();
                    }
                    return _width;
                }
            }

            public float WordHeight
            {
                get
                {
                    if (_height == 0)
                    {
                        _height = Ys.Max() - Ys.Min();
                    }
                    return _height;
                }
            }

            public List<int> Xs { get; } = new List<int>();
            public List<int> Ys { get; } = new List<int>();
            public string Text { get; }

            public WordData(string text)
            {
                Text = text;
            }
        }

        private SizeF _picInitSize;

        private Point _startPosition;
        private Direction _curDirection = Direction.None;

        private int ConstWidth => Settings.Default.ConstWidth;
        private const int ProtectSize = 0;
        private const int ConstDiff = 4;
        private int StartX
        {
            set
            {
                if (value > EndX - ProtectSize)
                {
                    Settings.Default.StartX = EndX - ProtectSize;
                    return;
                }
                if (value < pictureBox.Location.X + ProtectSize)
                {
                    Settings.Default.StartX = pictureBox.Location.X + ProtectSize;
                    return;
                }
                Settings.Default.StartX = value;
            }
            get
            {
                return Settings.Default.StartX;
            }
        }
        private int StartY
        {
            set
            {
                if (value > EndY - ProtectSize)
                {
                    Settings.Default.StartY = EndY - ProtectSize;
                    return;
                }
                if (value < pictureBox.Location.Y + ProtectSize)
                {
                    Settings.Default.StartY = pictureBox.Location.Y + ProtectSize;
                    return;
                }
                Settings.Default.StartY = value;
            }
            get
            {
                return Settings.Default.StartY;
            }
        }
        private int EndX
        {
            set
            {
                if (value < StartX + ProtectSize)
                {
                    Settings.Default.EndX = StartX + ProtectSize;
                    return;
                }
                if (value > pictureBox.Location.X + pictureBox.Width - ProtectSize)
                {
                    Settings.Default.EndX = pictureBox.Location.X + pictureBox.Width - ProtectSize;
                    return;
                }
                Settings.Default.EndX = value;
            }
            get
            {
                return Settings.Default.EndX;
            }
        }
        private int EndY
        {
            set
            {
                if (value < StartY + ProtectSize)
                {
                    Settings.Default.EndY = StartY + ProtectSize;
                    return;
                }
                if (value > pictureBox.Location.Y + pictureBox.Height - ProtectSize)
                {
                    return;
                }
                Settings.Default.EndY = value;
            }
            get
            {
                return Settings.Default.EndY;
            }
        }

        private Direction CurDirection
        {
            set
            {
                _curDirection = value;
                _startPosition = Cursor.Position;
                CurDirectionLabel.Text = _curDirection.ToString();
            }
        }

        private dynamic? _result;

        private int[,] _data = new int[9, 9];

        public MainForm()
        {
            InitializeComponent();
            _picInitSize = new SizeF(pictureBox.Width, pictureBox.Height);
            pictureBox.BringToFront();

            pictureBox.Image = Resources.Sample;

            FitPictureBox();

            RefreshScale();
        }

        private void SelectPngBtn_Click(object sender, EventArgs e)
        {
            using (var fd = new OpenFileDialog())
            {
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Load(fd.FileName);
                    FitPictureBox();
                }
            }
        }

        private void FitPictureBox()
        {
            var scaleW = pictureBox.Image.Width / _picInitSize.Width;
            var scaleH = pictureBox.Image.Height / _picInitSize.Height;
            var maxScale = Math.Max(scaleW, scaleH);
            var tmpSize = new SizeF(pictureBox.Image.Width / maxScale, pictureBox.Image.Height / maxScale);

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = tmpSize.ToSize();

            RecognizeBtn.Enabled = true;
            RefreshScale();            
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Green, 3),
                StartX - pictureBox.Location.X, StartY - pictureBox.Location.Y,
                EndX - StartX, EndY - StartY);
        }

        private void pictureBoxScale_MouseUp(object sender, MouseEventArgs e)
        {
            CurDirection = Direction.None;
        }

        private void pictureBoxScale_MouseDown(object sender, MouseEventArgs e)
        {
            var picBox = sender as PictureBox;
            if (picBox == null)
            {
                return;
            }
            Enum.TryParse(picBox.Name.Substring("pictureBox".Length), out Direction direction);
            CurDirection = direction;
        }

        private void pictureBoxScale_MouseMove(object sender, MouseEventArgs e)
        {
            if (_curDirection == Direction.None)
            {
                return;
            }

            var deltaX = Cursor.Position.X - _startPosition.X;
            var deltaY = Cursor.Position.Y - _startPosition.Y;
            _startPosition = Cursor.Position;

            switch (_curDirection)
            {
                case Direction.LeftTop:
                    StartX += deltaX;
                    StartY += deltaY;
                    RefreshScale();
                    break;
                case Direction.RightTop:
                    StartY += deltaY;
                    EndX += deltaX;
                    RefreshScale();
                    break;
                case Direction.LeftBottom:
                    StartX += deltaX;
                    EndY += deltaY;
                    RefreshScale();
                    break;
                case Direction.RightBottom:
                    EndX += deltaX;
                    EndY += deltaY;
                    RefreshScale();
                    break;
                case Direction.Top:
                    StartY += deltaY;
                    RefreshScale();
                    break;
                case Direction.Bottom:
                    EndY += deltaY;
                    RefreshScale();
                    break;
                case Direction.Left:
                    StartX += deltaX;
                    RefreshScale();
                    break;
                case Direction.Right:
                    EndX += deltaX;
                    RefreshScale();
                    break;
                default:
                    break;
            }
            pictureBox.Refresh();
        }

        private void RefreshScale()
        {
            StartX = StartX;
            StartY = StartY;
            EndX = EndX;
            EndY = EndY;

            var width = EndX - StartX - ConstWidth - ConstDiff;
            var height = EndY - StartY - ConstWidth - ConstDiff;

            pictureBoxTop.Size = pictureBoxBottom.Size = new Size(width, ConstWidth);
            pictureBoxLeft.Size = pictureBoxRight.Size = new Size(ConstWidth, height);

            pictureBoxTop.Location = new Point(StartX + ConstWidth / 2 + ConstDiff / 2, StartY - ConstWidth / 2);
            pictureBoxBottom.Location = new Point(StartX + ConstWidth / 2 + ConstDiff / 2, EndY - ConstWidth / 2);

            pictureBoxLeft.Location = new Point(StartX - ConstWidth / 2, StartY + ConstWidth / 2 + ConstDiff / 2);
            pictureBoxRight.Location = new Point(EndX - ConstWidth / 2, StartY + ConstWidth / 2 + ConstDiff / 2);

            pictureBoxLeftTop.Location = new Point(StartX - ConstWidth / 2, StartY - ConstWidth / 2);
            pictureBoxRightTop.Location = new Point(EndX - ConstWidth / 2, StartY - ConstWidth / 2);

            pictureBoxLeftBottom.Location = new Point(StartX - ConstWidth / 2, EndY - ConstWidth / 2);
            pictureBoxRightBottom.Location = new Point(EndX - ConstWidth / 2, EndY - ConstWidth / 2);
        }

        private void RecognizeBtn_Click(object sender, EventArgs e)
        {
            SuduCacalate.Text = "Image recognizing...";
            SuduCacalate.Enabled = false;
            Settings.Default.Save();
            Task.Run(async () =>
            {
                var orgImage = new Bitmap(pictureBox.Image);
                var curScaleX = pictureBox.Image.Width / (float)pictureBox.Width;
                var curScaleY = pictureBox.Image.Height / (float)pictureBox.Height;

                var tmpStartX = (StartX - pictureBox.Location.X) * curScaleX;
                var tmpStartY = (StartY - pictureBox.Location.Y) * curScaleY;
                var tmpEndX = (EndX - pictureBox.Location.X) * curScaleX;
                var tmpEndY = (EndY - pictureBox.Location.Y) * curScaleY;

                var cropArea = new RectangleF(tmpStartX, tmpStartY, tmpEndX - tmpStartX, tmpEndY - tmpStartY);

                var bmpCrop = orgImage.Clone(cropArea, orgImage.PixelFormat);
                using (var ms = new MemoryStream())
                {
                    bmpCrop.Save(ms, ImageFormat.Bmp);
                    ms.Seek(0, SeekOrigin.Begin);
                    _result = await AzureComputerVision.AnalyzeImageUrl(BinaryData.FromStream(ms));
                    Invoke((MethodInvoker)delegate
                    {
                        LoadDataToDataGridView();
                        SuduCacalate.Text = "Sudu Caculate";
                        SuduCacalate.Enabled = true;
                    });
                }
            });
        }

        private void LoadDataToDataGridView(bool useSampleJson = false)
        {
            var allData = GetResultData(useSampleJson);

            var wordWidths = allData.Select(s => s.WordWidth).ToList();
            var wordHeigths = allData.Select(s => s.WordHeight).ToList();
            wordWidths.Sort();
            wordHeigths.Sort();

            var wordWidth = wordWidths[wordWidths.Count / 2];
            var wordHeight = wordHeigths[wordHeigths.Count / 2];

            var allX = allData.SelectMany(a => a.Xs).ToList();
            var allY = allData.SelectMany(a => a.Ys).ToList();

            allX.Sort();
            allY.Sort();

            var minX = allX.Min();
            var minY = allY.Min();
            var maxX = allX.Max();
            var maxY = allY.Max();

            var tmpWidth = (maxX - minX - wordWidth) / 8;
            var tmpHeight = (maxY - minY - wordHeight) / 8;

            var avgXMin = (float)allX.Where(s => s - minX < wordWidth / 5).Average();
            var avgXMax = (float)allX.Where(s => maxX - s < wordWidth / 5).Average();

            var avgYMin = (float)allY.Where(s => s - minY < wordHeight / 5).Average();
            var avgYMax = (float)allY.Where(s => maxY - s < wordHeight / 5).Average();

            var cellWidth = (avgXMax - avgXMin - wordWidth) / 8;
            var cellHeight = (avgYMax - avgYMin - wordHeight) / 8;

            var cellStartPos = new PointF(avgXMin + wordWidth / 2, avgYMin + wordHeight / 2);

            _data = new int[9, 9];

            foreach (var item in allData)
            {
                var words = new List<int>();
                foreach (var word in item.Text)
                {
                    if (int.TryParse(word.ToString(), out var curValue) && curValue != 0)
                    {
                        words.Add(curValue);
                    }
                }
                for (int i = 0; i < words.Count; i++)
                {
                    int word = words[i];

                    var posYF = (item.Ys.Average() - cellStartPos.Y) / cellHeight;
                    var posXF = (((item.Xs.Min() + wordWidth / 2) - cellStartPos.X) / cellWidth) + i;
                    _data[(int)Math.Round(posXF), (int)Math.Round(posYF)] = word;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var tmpCell = dataGridView.Rows[j].Cells[i];
                    if (_data[i, j] == 0)
                    {
                        tmpCell.Value = string.Empty;
                        tmpCell.Style.BackColor = Color.White;
                    }
                    else
                    {
                        tmpCell.Value = _data[i, j];
                        tmpCell.Style.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void SuduCaculate_Click(object sender, EventArgs e)
        {
            var result = SudoCaculate.Caculate(_data);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var tmpCell = dataGridView.Rows[j].Cells[i];
                    tmpCell.Value = result[i, j];
                    if (_data[i, j] == 0)
                    {
                        tmpCell.Style.BackColor = Color.White;
                    }
                    else
                    {
                        tmpCell.Style.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private List<WordData> GetResultData(bool useSampleJson = false)
        {
            var allWords = new List<WordData>();
            
            var jsonResult = useSampleJson ? JsonConvert.DeserializeObject<dynamic>(Resources.SampleJson) : _result;
            if (jsonResult == null)
            {
                return allWords;
            }
            foreach (var block in jsonResult.Blocks)
            {
                foreach (var line in block.Lines)
                {
                    foreach (var word in line.Words)
                    {
                        var tmpWordData = new WordData((string)word.Text);
                        foreach (var bp in word.BoundingPolygon)
                        {
                            tmpWordData.Xs.Add((int)bp.X);
                            tmpWordData.Ys.Add((int)bp.Y);
                        }
                        allWords.Add(tmpWordData);
                    }
                }
            }
            return allWords;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 10; i++)
            {
                dataGridView.Rows.Add();
            }
            foreach (DataGridViewColumn item in dataGridView.Columns)
            {
                item.Width = dataGridView.Width / 9;
            }
            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                item.Height = dataGridView.Height / 9;
            }
            dataGridView.ClearSelection();

            LoadDataToDataGridView(true);
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            dataGridView.ClearSelection();
        }
    }
}
