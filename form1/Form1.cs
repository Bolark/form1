using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form1
{
    public partial class Form1 : Form
    {
        private Button myButton;
        private Label labelMousePosition;
        private Panel sarıKare;
        private string clickElementName = "";
        private Panel pembeDaire;
        private Panel maviUcgen;
        private Panel yesilAltigen;


        int formMouseX = 0;
        int formMouseY = 0;

        private string selectType = "kare";

        public Form1()
        {
            InitializeComponent();

            // LabelMousePosition kontrolünü form üzerine ekleyin
            labelMousePosition = new Label();
            labelMousePosition.Location = new System.Drawing.Point(10, 10);
            this.Controls.Add(labelMousePosition);
            Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Controls.Add(sarıKare);
            Controls.Add(pembeDaire);
            Controls.Add(maviUcgen);
            Controls.Add(yesilAltigen);

            button1.Click += button1_Click;
            groupBox1.MouseClick += GroupBox1_Click;

            this.MouseClick += MainForm_MouseMove;

        }

        private void createYellowSquare(int mouseX, int mouseY)
        {
            Control formControl = FindControlByName("yellowPanel");
            if (formControl == null)
            {
                sarıKare = new Panel
                {
                    BackColor = Color.Yellow,
                    Size = new System.Drawing.Size(50, 50),
                    Name = $"yellowPanel",
                    Location = new System.Drawing.Point(mouseX, mouseY),
                };
                this.Controls.Add(sarıKare);
            }
        }
        private void createPinkCircle(int mouseX, int mouseY)
        {
            Control formControl = FindControlByName("pinkPanel");
            if (formControl == null)
            {
                pembeDaire = new Panel
                {
                    Name = "pinkPanel",
                    Size = new Size(50, 50),
                    Location = new Point(mouseX, mouseY),
                };

                pembeDaire.Paint += PinkCircle_Paint;
                this.Controls.Add(pembeDaire);
            }
        }

        private void createBlueTriangle(int mouseX, int mouseY)
        {
            Control formControl = FindControlByName("bluePanel");
            if (formControl == null)
            {
                maviUcgen = new Panel
                {
                    Name = "bluePanel",
                    Size = new Size(50, 50),
                    Location = new Point(mouseX, mouseY),
                };

                maviUcgen.Paint += MaviUcgen_Paint1;
                this.Controls.Add(maviUcgen);
            }
        }

        private void createGreenHexagon(int mouseX, int mouseY)
        {
            Control formControl = FindControlByName("greenPanel");
            if (formControl == null)
            {
                yesilAltigen = new Panel
                {
                    Name = "greenPanel",
                    Size = new Size(50, 50),
                    Location = new Point(mouseX, mouseY),
                };

                yesilAltigen.Paint += DrawHexagon;
                this.Controls.Add(yesilAltigen);
                // Panel'i sürükleyebilir hale getir
                yesilAltigen.Invalidate();
            }
        }

        private void DrawHexagon(object sender, PaintEventArgs e)
        {
            // Altıgenin kenar uzunluğu
            int sideLength = 50;

            var aaa = new Form1();
            // Altıgenin merkezi
            int centerX = aaa.Width / 2;
            int centerY = aaa.Height / 2;

            // Altıgenin köşe noktalarını hesapla
            Point[] hexagonPoints = CalculateHexagonPoints(centerX, centerY, sideLength);

            // Yeşil bir fırça oluştur
            using (Brush brush = new SolidBrush(Color.Green))
            {
                // Altıgeni çiz
                using (Graphics g = this.CreateGraphics())
                {
                    g.FillPolygon(brush, hexagonPoints);
                }
            }
        }


        private Point[] CalculateHexagonPoints(int centerX, int centerY, int sideLength)
        {
            Point[] hexagonPoints = new Point[6];

            for (int i = 0; i < 6; i++)
            {
                double angle = i * 2.0 * Math.PI / 6;
                int x = (int)(centerX + sideLength * Math.Cos(angle));
                int y = (int)(centerY + sideLength * Math.Sin(angle));

                hexagonPoints[i] = new Point(x, y);
            }

            return hexagonPoints;
        }

        private void PinkCircle_Paint(object sender, PaintEventArgs e)
        {
            // Get the Graphics object from PaintEventArgs.
            Graphics g = e.Graphics;

            // Get the current panel.
            Panel panel = (Panel)sender;

            // Fill the ellipse (circle) with a color (you can customize the color).
            using (Brush brush = new SolidBrush(Color.DeepPink))
            {
                g.FillEllipse(brush, 0, 0, panel.Width, panel.Height);
            }
        }

        private void MaviUcgen_Paint1(object sender, PaintEventArgs e)
        {
            int sideLength = 50;

            // Get the Graphics object from PaintEventArgs.
            Graphics g = e.Graphics;

            // Get the current panel.
            Panel panel = (Panel)sender;

            Point point1 = new Point(0, panel.Height);  // Bottom-left corner
            Point point2 = new Point(panel.Width, panel.Height);  // Bottom-right corner
            Point point3 = new Point(panel.Width / 2, 0);  // Top-middle corner

            // Fill the triangle with a color (you can customize the color).
            using (Brush brush = new SolidBrush(Color.Blue))
            {
                g.FillPolygon(brush, new Point[] { point1, point2, point3 });
            }
        }

       




        //private PaintEventHandler TrianglePanel_Paint(int mouseX, int mouseY)
        //{
        //    int sideLength = 50;

        //    Point point1 = new Point(mouseX, mouseY);
        //    Point point2 = new Point(mouseX + sideLength, mouseY);
        //    Point point3 = new Point(mouseX + sideLength / 2, mouseY - (int)(Math.Sqrt(3) * sideLength / 2));

        //    using (Graphics g = this.CreateGraphics())
        //    {
        //        g.FillPolygon(Brushes.Blue, new Point[] { point1, point2, point3 });

        //        return g;
        //    }
        //}

        //private void TrianglePanel_Paint(object sender, PaintEventArgs e)
        //{
        //    int sideLength = 50;

        //    Point point1 = new Point(mouseX, mouseY);
        //    Point point2 = new Point(mouseX + sideLength, mouseY);
        //    Point point3 = new Point(mouseX + sideLength / 2, mouseY - (int)(Math.Sqrt(3) * sideLength / 2));

        //    using (Graphics g = this.CreateGraphics())
        //    {
        //        g.FillPolygon(Brushes.Blue, new Point[] { point1, point2, point3 });
        //    }
        //}

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            //Fare pozisyonunu alan kod
            int mouseX = e.X;
            int mouseY = e.Y;

            // Alınan pozisyonu kullanarak bir şeyler yapabilirsiniz
            // Örneğin, pozisyonu bir etikete yazdırabilirsiniz
            //labelMousePosition.Text = $"Mouse Pozisyonu: X={mouseX}, Y={mouseY}";

            label5.Text = $"Mouse Pozisyonu: X={mouseX}, Y={mouseY}";

            formMouseX = mouseX;
            formMouseY = mouseY;

            switch (selectType)
            {
                case"kare":
                    createYellowSquare(mouseX, mouseY);
                    break;
                case"daire":
                    createPinkCircle(mouseX, mouseY);
                    break;
                case "ucgen":
                    createBlueTriangle(mouseX, mouseY);
                    break;
                case "altıgen":
                    createGreenHexagon(mouseX, mouseY);
                    break;

                default:
                    break;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Control formControl = FindControlByName("yellowPanel");
            if (formControl != null)
            {
                ControlExtension.Draggable(formControl, true);
            }
            Control formControl1 = FindControlByName("bluePanel");
            if (formControl1 != null)
            {
                ControlExtension.Draggable(formControl1, true);

            }
            Control formControl2 = FindControlByName("pinkPanel");
            if (formControl2 != null)
            {
                ControlExtension.Draggable(formControl2, true);

            }
            Control formControl3 = FindControlByName("greenPanel");
            if (formControl3 != null)
            {
                ControlExtension.Draggable(formControl3, true);

            }
        }

        private Control FindControlByName(string name)
        {
            // Form içinde ismi verilen kontrolü bul

            foreach (Control control in this.Controls)
            {
                if (control.Name == name)
                {
                    return control;
                }
            }

            // Eğer bulunamazsa null döndür
            return null;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            switch (selectType)
            {
                case "kare":
                    clickElementName = "yellowPanel";
                    break;
                case "daire":
                    clickElementName = "pinkPanel";
                    break;
                case "ucgen":
                    clickElementName = "bluePanel";
                    break;
                case "altıgen":
                    clickElementName = "greenPanel";
                    break;
                default:
                    clickElementName = "yellowPanel";
                    break;
            }

            Control formControl = FindControlByName(clickElementName);
            if (formControl != null)
            {
                Controls.Remove(formControl);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectType = "kare";
        }
        private void GroupBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseEventArgs = e as MouseEventArgs;

            if (mouseEventArgs != null)
            {
                // sarı kareyi tıklanan noktanın konumuna ayarlayın
                sarıKare.Location = new Point(mouseEventArgs.X + groupBox1.Left - sarıKare.Width / 2,
                                              mouseEventArgs.Y + groupBox1.Top - sarıKare.Height / 2);
     
            }

            if (mouseEventArgs != null)
            {
                pembeDaire.Location = new Point(mouseEventArgs.X + groupBox1.Left - pembeDaire.Width / 2,
                                             mouseEventArgs.Y + groupBox1.Top - pembeDaire.Height / 2);
            }

            if (mouseEventArgs != null)
            {
                maviUcgen.Location = new Point(mouseEventArgs.X + groupBox1.Left - maviUcgen.Width / 2,
                                              mouseEventArgs.Y + groupBox1.Top - maviUcgen.Height / 2);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            string controlName = string.Empty;

            switch (selectType)
            {
                case "kare":
                    controlName = "yellowPanel";
                    break;
                case "daire":
                    controlName = "pinkPanel";
                    break;
                case "ucgen":
                    controlName = "bluePanel";
                    break;
                case "altıgen":
                    controlName = "greenPanel";
                    break;
                default:
                    controlName = "yellowPanel";
                    break;
            }

            Control formControl = FindControlByName(controlName);
            if (formControl != null)
            {
                formControl.BackColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectType = "daire";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectType = "ucgen";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selectType = "altıgen";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string controlName = string.Empty;

            switch (selectType)
            {
                case "kare":
                    controlName = "yellowPanel";
                    break;
                case "daire":
                    controlName = "pinkPanel";
                    break;
                case "ucgen":
                    controlName = "bluePanel";
                    break;
                case "altıgen":
                    controlName = "greenPanel";
                    break;
                default:
                    controlName = "yellowPanel";
                    break;
            }

            Control formControl = FindControlByName(controlName);
            if (formControl != null)
            {
                formControl.BackColor = Color.Blue;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ClearControlsExceptGroupBox2();
        }
        private void ClearControlsExceptGroupBox2()
        {
            foreach (Control control in Controls)
            {
                if (control != groupBox2 && control != label5)
                {
                    control.Dispose();
                }
            }

            Controls.Clear();

            Controls.Add(groupBox2);
            Controls.Add(label5);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            OpenAndDrawShapes();
        }

        private void OpenAndDrawShapes()
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                    openFileDialog.Title = "Select a shapes file";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        List<string> shapeInfoLines = File.ReadAllLines(filePath).ToList();

                        ClearShapes();

                        foreach (string shapeInfo in shapeInfoLines)
                        {
                            string[] infoParts = shapeInfo.Split(',');

                            string controlType = infoParts[0];
                            string controlName = infoParts[1];
                            int x = int.Parse(infoParts[2]);
                            int y = int.Parse(infoParts[3]);
                            int width = int.Parse(infoParts[4]);
                            int height = int.Parse(infoParts[5]);
                            int red = int.Parse(infoParts[6]);
                            int green = int.Parse(infoParts[7]);
                            int blue = int.Parse(infoParts[8]);

                            Panel shapePanel = new Panel
                            {
                                Name = controlName,
                                Location = new Point(x, y),
                                Size = new Size(width, height),
                            };

                            if (controlName == "bluePanel")
                            {
                                shapePanel.Paint += MaviUcgen_Paint1;
                            }

                            if (controlName == "pinkPanel")
                            {
                                shapePanel.Paint += PinkCircle_Paint;
                            }

                            if (controlName == "yellowPanel")
                            {
                                shapePanel.BackColor = Color.Yellow;
                            }

                            Controls.Add(shapePanel);
                        }

                        MessageBox.Show("Şekiller başarıyla açıldı ve sahneye çizildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dosyayı açma ve çizme işlemi sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearShapes()
        {
            foreach (Control control in Controls)
            {
                if (control is Panel)
                {
                    control.Dispose();
                }
            }
        }



        private void button18_Click(object sender, EventArgs e)
        {
            SaveShapesToFile("C:\\Users\\Mollaoglu\\Desktop\\shapes.txt");
        }

        private void SaveShapesToFile(string filePath)
        {
            try
            {
                List<string> shapeInfoList = new List<string>();

                foreach (Control control in Controls)
                {
                    if (control is Panel)
                    {
                        string shapeInfo = $"{control.GetType().Name},{control.Name},{control.Location.X},{control.Location.Y},{control.Width},{control.Height},{control.BackColor.R},{control.BackColor.G},{control.BackColor.B}";

                        shapeInfoList.Add(shapeInfo);
                    }
                }

                File.WriteAllLines(filePath, shapeInfoList);

                MessageBox.Show("Şekiller başarıyla dosyaya kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dosyaya kaydetme işlemi sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string controlName = string.Empty;

            switch (selectType)
            {
                case "kare":
                    controlName = "yellowPanel";
                    break;
                case "daire":
                    controlName = "pinkPanel";
                    break;
                case "ucgen":
                    controlName = "bluePanel";
                    break;
                case "altıgen":
                    controlName = "greenPanel";
                    break;
                default:
                    controlName = "yellowPanel";
                    break;
            }

            Control formControl = FindControlByName(controlName);
            if (formControl != null)
            {
                formControl.BackColor = Color.DarkGreen;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string controlName = string.Empty;

            switch (selectType)
            {
                case "kare":
                    controlName = "yellowPanel";
                    break;
                case "daire":
                    controlName = "pinkPanel";
                    break;
                case "ucgen":
                    controlName = "bluePanel";
                    break;
                case "altıgen":
                    controlName = "greenPanel";
                    break;
                default:
                    controlName = "yellowPanel";
                    break;
            }

            Control formControl = FindControlByName(controlName);
            if (formControl != null)
            {
                formControl.BackColor = Color.Orange;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string controlName = string.Empty;

            switch (selectType)
            {
                case "kare":
                    controlName = "yellowPanel";
                    break;
                case "daire":
                    controlName = "pinkPanel";
                    break;
                case "ucgen":
                    controlName = "bluePanel";
                    break;
                case "altıgen":
                    controlName = "greenPanel";
                    break;
                default:
                    controlName = "yellowPanel";
                    break;
            }

            Control formControl = FindControlByName(controlName);
            if (formControl != null)
            {
                formControl.BackColor = Color.Black;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string controlName = string.Empty;

            switch (selectType)
            {
                case "kare":
                    controlName = "yellowPanel";
                    break;
                case "daire":
                    controlName = "pinkPanel";
                    break;
                case "ucgen":
                    controlName = "bluePanel";
                    break;
                case "altıgen":
                    controlName = "greenPanel";
                    break;
                default:
                    controlName = "yellowPanel";
                    break;
            }

            Control formControl = FindControlByName(controlName);
            if (formControl != null)
            {
                formControl.BackColor = Color.Yellow;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string controlName = string.Empty;

            switch (selectType)
            {
                case "kare":
                    controlName = "yellowPanel";
                    break;
                case "daire":
                    controlName = "pinkPanel";
                    break;
                case "ucgen":
                    controlName = "bluePanel";
                    break;
                case "altıgen":
                    controlName = "greenPanel";
                    break;
                default:
                    controlName = "yellowPanel";
                    break;
            }

            Control formControl = FindControlByName(controlName);
            if (formControl != null)
            {
                formControl.BackColor = Color.Pink;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string controlName = string.Empty;

            switch (selectType)
            {
                case "kare":
                    controlName = "yellowPanel";
                    break;
                case "daire":
                    controlName = "pinkPanel";
                    break;
                case "ucgen":
                    controlName = "bluePanel";
                    break;
                case "altıgen":
                    controlName = "greenPanel";
                    break;
                default:
                    controlName = "yellowPanel";
                    break;
            }

            Control formControl = FindControlByName(controlName);
            if (formControl != null)
            {
                formControl.BackColor = Color.DarkRed;
            }
        }
    }
}
//        public abstract class Shape
//        {
//            public Point StartPoint { get; set; }
//            public Point EndPoint { get; set; }
//            public Color Color { get; set; }

//            public abstract void Draw(Graphics g);
//        }

//        public class RectangleShape : Shape
//        {
//            public override void Draw(Graphics g)
//            {
//                using (var brush = new SolidBrush(Color))
//                {
//                    g.FillRectangle(brush, StartPoint.X, StartPoint.Y, EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y);
//                }
//            }
//        }

//        public class EllipseShape : Shape
//        {
//            public override void Draw(Graphics g)
//            {
//                using (var brush = new SolidBrush(Color))
//                {
//                    g.FillEllipse(brush, StartPoint.X, StartPoint.Y, EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y);
//                }
//            }
//        }

//        public class DrawingApplication
//        {
//            private List<Shape> shapes;
//            private Shape currentShape;
//            private Color selectedColor;

//            public Color SelectedColor { get; internal set; }

//            public DrawingApplication()
//            {
//                shapes = new List<Shape>();
//                selectedColor = Color.Black;
//            }

//            public void StartDrawing(Shape shape)
//            {
//                currentShape = shape;
//            }

//            public void EndDrawing()
//            {
//                shapes.Add(currentShape);
//                currentShape = null;
//            }

//            public void DrawAll(Graphics g)
//            {
//                foreach (var shape in shapes)
//                {
//                    shape.Draw(g);
//                }

//                if (currentShape != null)
//                {
//                    currentShape.Draw(g);
//                }
//            }

//            public void SetSelectedColor(Color color)
//            {
//                selectedColor = color;
//                if (currentShape != null)
//                {
//                    currentShape.Color = selectedColor;
//                }
//            }
//        }

//        public partial class DrawingForm : Form
//        {
//            private DrawingApplication drawingApp;
//            private Shape currentShape;

//            public DrawingForm()
//            {
//                InitializeComponent();
//                drawingApp = new DrawingApplication();
//            }

//            private void DrawingForm_MouseDown(object sender, MouseEventArgs e)
//            {
//                if (currentShape == null)
//                {
//                    if (e.X > ClientSize.Width - 200) // Sağ taraftaki menü alanının sınırları
//                    {
//                        if (e.Y < 50) // Çizim şekilleri bölgesi
//                        {
//                            if (e.Y < 10 + 25) // Dikdörtgen seçildi
//                            {
//                                currentShape = new RectangleShape();
//                            }
//                            else if (e.Y < 40 + 25) // Daire seçildi
//                            {
//                                currentShape = new EllipseShape();
//                            }
//                            // Diğer şekilleri buraya ekleyebilirsiniz
//                            currentShape.Color = drawingApp.SelectedColor;
//                            currentShape.StartPoint = e.Location;
//                            drawingApp.StartDrawing(currentShape);
//                        }
//                        else if (e.Y > 150 && e.Y < 300) // Renk seçimi bölgesi
//                        {
//                            int colorIndex = (e.Y - 150) / 25;
//                            Color selectedColor = GetColorByIndex(colorIndex);
//                            drawingApp.SetSelectedColor(selectedColor);
//                        }
//                    }
//                }
//            }

//            private void DrawingForm_MouseUp(object sender, MouseEventArgs e)
//            {
//                if (e.Button == MouseButtons.Left && currentShape != null)
//                {
//                    currentShape.EndPoint = e.Location;
//                    drawingApp.EndDrawing();
//                    currentShape = null;
//                    Refresh();
//                }
//            }

//            private void DrawingForm_Paint(object sender, PaintEventArgs e)
//            {
//                drawingApp.DrawAll(e.Graphics);
//            }

//            private Color GetColorByIndex(int index)
//            {
//                // Renk seçimi için indeks bazlı renk listesi
//                Color[] colors = { Color.Red, Color.Blue, Color.DarkGreen, Color.Orange, Color.Black, Color.Yellow, Color.Purple, Color.Maroon, Color.White };

//                if (index >= 0 && index < colors.Length)
//                {
//                    return colors[index];
//                }

//                return Color.Black;
//            }
//        }
//    }
//}
