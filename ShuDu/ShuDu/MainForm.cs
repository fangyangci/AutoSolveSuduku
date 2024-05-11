using Azure.AI.Vision.ImageAnalysis;
using Newtonsoft.Json;
using ShuDu.Properties;
using System.Data;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

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

        private Point _startPosition;
        private Direction _curDirection = Direction.None;
        private Point[]? _bottomBtns;

        private int ConstWidth => 32;
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
                if (value < ProtectSize)
                {
                    Settings.Default.StartX = ProtectSize;
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
                if (value < ProtectSize)
                {
                    Settings.Default.StartY = ProtectSize;
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
                if (value > Screen.FromControl(this).Bounds.Width - ProtectSize)
                {
                    Settings.Default.EndX = Width - ProtectSize;
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
                if (value > Height - ProtectSize)
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

        private Rectangle CurRect => new Rectangle(StartX, StartY, EndX - StartX, EndY - StartY);

        private ReadResult? _result;

        private int[,] _data = new int[9, 9];
        private PointF[,] _sudukuCells = new PointF[9, 9];

        public MainForm()
        {
            InitializeComponent();

            BackColor = Color.LimeGreen;
            TransparencyKey = Color.LimeGreen;
            TopMost = true;
            CurStatusLabel.Visible = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            RefreshScale();

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
            LoadBottomBtns();
        }

        private void LoadBottomBtns()
        {
            _bottomBtns = JsonConvert.DeserializeObject<Point[]>(Settings.Default.BottomNumJson);
            BottomBtnsReadyLabel.Visible = _bottomBtns != null;
        }

        #region SelectRect
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
            Refresh();
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
        #endregion

        private void SudukuNumbers_Click(object sender, EventArgs e)
        {
            curIndex = 0;
            Task.Run(async () =>
            {
                await ComputerVisionAsync();
                if (_result == null)
                {
                    return;
                }
                LoadDataToDataGridView();
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
            _sudukuCells = new PointF[9, 9];

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

                    var posYF = (int)Math.Round((item.Ys.Average() - cellStartPos.Y) / cellHeight);
                    var posXF = (int)Math.Round((((item.Xs.Min() + wordWidth / 2) - cellStartPos.X) / cellWidth) + i);

                    _data[posXF, posYF] = word;
                    _sudukuCells[posXF, posYF] = new PointF((float)item.Xs.Average(), (float)item.Ys.Average());
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

            var rowsY = new List<float>[9];
            var columnsX = new List<float>[9];
            for (int i = 0; i < 9; i++)
            {
                rowsY[i] = new List<float>();
                columnsX[i] = new List<float>();
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (_sudukuCells[i, j].IsEmpty)
                    {
                        continue;
                    }
                    rowsY[j].Add(_sudukuCells[i, j].Y);
                    columnsX[i].Add(_sudukuCells[i, j].X);
                }
            }

            var avgX = new float[9];
            var avgY = new float[9];
            for (int i = 0; i < 9; i++)
            {
                avgY[i] = rowsY[i].Average();
                avgX[i] = columnsX[i].Average();
            }
            for (int i = 1; i < 8; i++)
            {
                if (avgX[i] == 0)
                {
                    avgX[i] = (avgX[i - 1] + avgX[i + 1]) / 2;
                }
                if (avgY[i] == 0)
                {
                    avgY[i] = (avgY[i - 1] + avgY[i + 1]) / 2;
                }
            }
            if (avgX[0] == 0)
            {
                avgX[0] = avgX[1] * 2 - avgX[2];
            }
            if (avgY[0] == 0)
            {
                avgY[0] = avgY[1] * 2 - avgY[2];
            }

            if (avgX[8] == 0)
            {
                avgX[8] = avgX[7] * 2 - avgX[6];
            }
            if (avgY[8] == 0)
            {
                avgY[8] = avgY[7] * 2 - avgY[6];
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    _sudukuCells[i, j] = new PointF(avgX[i] + StartX, avgY[j] + StartY);
                }
            }
        }

        private int curIndex = 0;

        private void SuduCaculate_Click(object sender, EventArgs e)
        {
            var pos = Cursor.Position;
            curIndex++;
            Refresh();
            var tmpIndex = 0;
            var result = SudoCaculate.Caculate(_data);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var tmpCell = dataGridView.Rows[j].Cells[i];
                    tmpCell.Value = result[i, j];
                    if (_data[i, j] == 0)
                    {
                        tmpIndex++;
                        tmpCell.Style.BackColor = Color.White;
                        if (tmpIndex == curIndex && _bottomBtns != null)
                        {
                            MouseOperations.DoMouseClick((int)_sudukuCells[i, j].X, (int)_sudukuCells[i, j].Y);
                            MouseOperations.DoMouseClick(_bottomBtns[result[i,j]].X, _bottomBtns[result[i, j]].Y);
                        }                        
                    }
                    else
                    {
                        tmpCell.Style.BackColor = Color.LightGray;
                    }
                }
            }
            Cursor.Position = pos;
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

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            dataGridView.ClearSelection();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            //if (test)
            //{
            //    for (int i = 0; i < 9; i++)
            //    {
            //        for (int j = 0; j < 9; j++)
            //        {
            //            e.Graphics.FillRectangle(new SolidBrush(Color.Green), new Rectangle(
            //                (int)Math.Round(_sudukuCells[i, j].X) + 5,
            //                (int)Math.Round(_sudukuCells[i, j].Y) + 5,
            //                10,
            //                10
            //            ));
            //        }
            //    }
            //}
            //else
            {
                e.Graphics.DrawRectangle(new Pen(Color.Green, 3), CurRect);
            }
        }

        private void BottomNumbers_Click(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                await ComputerVisionAsync();
                if (_result == null)
                {
                    return;
                }

                var numbers = new Point[10];

                foreach (var block in _result.Blocks)
                {
                    foreach (var item in block.Lines)
                    {
                        if (!int.TryParse(item.Text, out var num))
                        {
                            continue;
                        }
                        var centerX = (int)Math.Round(item.BoundingPolygon.Select(s => s.X).Average());
                        var centerY = (int)Math.Round(item.BoundingPolygon.Select(s => s.Y).Average());
                        numbers[num] = new Point(centerX + StartX, centerY + StartY);
                    }
                }
                var numberJson = JsonConvert.SerializeObject(numbers);
                Settings.Default.BottomNumJson = numberJson;
                Settings.Default.Save();
                LoadBottomBtns();
            });
        }

        private Bitmap GetSelectBitmap()
        {
            Bitmap bitmap = new Bitmap(CurRect.Width, CurRect.Height, PixelFormat.Format32bppArgb);
            using (Graphics memoryGrahics = Graphics.FromImage(bitmap))
            {
                memoryGrahics.CopyFromScreen(CurRect.X, CurRect.Y, 0, 0, CurRect.Size, CopyPixelOperation.SourceCopy);
            }
            bitmap.Save("./selectBitMap.jpg", ImageFormat.Jpeg);
            return bitmap;
        }

        private async Task ComputerVisionAsync()
        {
            Settings.Default.Save();
            Invoke((MethodInvoker)delegate
            {
                CurStatusLabel.Visible = true;
                CurStatusLabel.Text = "Image recognizing...";
            });

            var selectBitMap = GetSelectBitmap();
            using (var ms = new MemoryStream())
            {
                selectBitMap.Save(ms, ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);
                _result = await AzureComputerVision.AnalyzeImageUrl(BinaryData.FromStream(ms));
            }

            Invoke((MethodInvoker)delegate
            {
                CurStatusLabel.Visible = false;
            });
        }
    }
}
