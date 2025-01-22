using Microsoft.Win32; // Для работы с диалогом открытия файлов
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Diagnostics;

namespace nomer_6
{
    public partial class MainWindow : Window
    {
        // Список для хранения добавленных изображений
        private List<Image> images = new List<Image>();

        // Переменные для перетаскивания изображения
        private Image selectedImage = null;
        private List<Point> selectedPoints = new List<Point>(); // Список выбранных точек
        private bool isDragging = false;
        private Point lastMousePosition;

        private List<Ellipse> markers = new List<Ellipse>(); // Список для маркеров


        public MainWindow()
        {
            InitializeComponent();
        }

        // Обработчик для кнопки "Добавить картинку"
        private void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.svg",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage(new System.Uri(openFileDialog.FileName));
                Image image = new Image
                {
                    Source = bitmap,
                    Width = 200,
                    Height = 200,
                    Stretch = Stretch.Uniform,
                    Opacity = 1
                };

                images.Add(image);
                ImageCanvas.Children.Add(image);
                Canvas.SetLeft(image, 0); // Начальная позиция X
                Canvas.SetTop(image, 0);  // Начальная позиция Y
                ImageList.Items.Add(System.IO.Path.GetFileName(openFileDialog.FileName));
            }
        }

        // Обработчик для кнопки "Удалить картинку"
        private void RemoveImageButton_Click(object sender, RoutedEventArgs e)
        {
            if (ImageList.SelectedItem != null)
            {
                int selectedIndex = ImageList.SelectedIndex;
                if (selectedIndex >= 0 && selectedIndex < images.Count)
                {
                    ImageCanvas.Children.Remove(images[selectedIndex]);
                    images.RemoveAt(selectedIndex);
                }
                ImageList.Items.RemoveAt(selectedIndex);
            }
            else
            {
                MessageBox.Show("Выберите изображение для удаления.", "Удаление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Обработчик изменения значения ползунка прозрачности
        private void OpacitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ImageList.SelectedItem != null)
            {
                int selectedIndex = ImageList.SelectedIndex;
                if (selectedIndex >= 0 && selectedIndex < images.Count)
                {
                    images[selectedIndex].Opacity = OpacitySlider.Value;
                }
            }
        }

        // Событие нажатия средней кнопки мыши
        private void ImageCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Middle && ImageList.SelectedItem != null)
            {
                int selectedIndex = ImageList.SelectedIndex;
                if (selectedIndex >= 0 && selectedIndex < images.Count)
                {
                    selectedImage = images[selectedIndex];
                    isDragging = true;
                    lastMousePosition = e.GetPosition(ImageCanvas);
                }
            }
        }

        // Событие перемещения мыши
        private void ImageCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && selectedImage != null)
            {
                Point currentMousePosition = e.GetPosition(ImageCanvas);
                double offsetX = currentMousePosition.X - lastMousePosition.X;
                double offsetY = currentMousePosition.Y - lastMousePosition.Y;

                double currentLeft = Canvas.GetLeft(selectedImage);
                double currentTop = Canvas.GetTop(selectedImage);

                Canvas.SetLeft(selectedImage, currentLeft + offsetX);
                Canvas.SetTop(selectedImage, currentTop + offsetY);

                lastMousePosition = currentMousePosition;
            }
        }

        // Событие отпускания средней кнопки мыши
        private void ImageCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Middle && isDragging)
            {
                isDragging = false;
                selectedImage = null;
            }
        }

        // Событие прокрутки колесика мыши для масштабирования
        private void ImageCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (ImageList.SelectedItem != null)
            {
                int selectedIndex = ImageList.SelectedIndex;
                if (selectedIndex >= 0 && selectedIndex < images.Count)
                {
                    selectedImage = images[selectedIndex];

                    // Изменяем размер изображения на основе направления колесика
                    double scaleFactor = e.Delta > 0 ? 1.1 : 0.9; // Увеличение или уменьшение
                    selectedImage.Width *= scaleFactor;
                    selectedImage.Height *= scaleFactor;

                    // Проверяем, связано ли второе изображение
                    if (selectedImage.Tag is Image linkedImage)
                    {
                        // Масштабируем второе изображение так же
                        linkedImage.Width *= scaleFactor;
                        linkedImage.Height *= scaleFactor;

                        // Корректируем положение второго изображения
                        double deltaX = (Canvas.GetLeft(selectedImage) - Canvas.GetLeft(linkedImage)) * (scaleFactor - 1);
                        double deltaY = (Canvas.GetTop(selectedImage) - Canvas.GetTop(linkedImage)) * (scaleFactor - 1);

                        Canvas.SetLeft(linkedImage, Canvas.GetLeft(linkedImage) + deltaX);
                        Canvas.SetTop(linkedImage, Canvas.GetTop(linkedImage) + deltaY);
                    }
                }
            }
        }


        private void ClearMarkers()
        {
            foreach (var marker in markers)
            {
                ImageCanvas.Children.Remove(marker);
            }
            markers.Clear();
        }


        private void ImageCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ImageList.SelectedItem != null)
            {
                int selectedIndex = ImageList.SelectedIndex;
                if (selectedIndex >= 0 && selectedIndex < images.Count)
                {
                    selectedImage = images[selectedIndex];

                    // Получаем координаты щелчка относительно холста
                    Point clickedPoint = e.GetPosition(ImageCanvas);

                    // Вычисляем координаты относительно изображения
                    double imageLeft = Canvas.GetLeft(selectedImage);
                    double imageTop = Canvas.GetTop(selectedImage);

                    double relativeX = clickedPoint.X - imageLeft;
                    double relativeY = clickedPoint.Y - imageTop;

                    // Проверяем, что точка внутри изображения
                    if (relativeX >= 0 && relativeX <= selectedImage.ActualWidth &&
                        relativeY >= 0 && relativeY <= selectedImage.ActualHeight)
                    {
                        selectedPoints.Add(new Point(relativeX, relativeY));

                        // Отображаем выбранную точку
                        Ellipse marker = new Ellipse
                        {
                            Width = 5,
                            Height = 5,
                            Fill = Brushes.Red,
                            Stroke = Brushes.Black,
                            StrokeThickness = 1
                        };

                        ImageCanvas.Children.Add(marker);
                        markers.Add(marker); // Добавляем маркер в список
                        Canvas.SetLeft(marker, clickedPoint.X - 2.5);
                        Canvas.SetTop(marker, clickedPoint.Y - 2.5);

                        // Проверяем, выбраны ли 4 точки
                        if (selectedPoints.Count == 4)
                        {
                            ClearMarkers(); // Удаляем старые маркеры
                            OverlayImages(); // Накладываем изображения
                            selectedPoints.Clear(); // Сбрасываем точки для нового выбора
                        }
                    }
                    else
                    {
                        MessageBox.Show("Точка должна быть внутри изображения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }

        // Наложение изображений
        private void OverlayImages()
        {
            if (selectedPoints.Count == 4 && images.Count >= 2)
            {
                // Получение двух изображений и точек
                Image image1 = images[ImageList.SelectedIndex];
                Point point1_1 = selectedPoints[0];
                Point point1_2 = selectedPoints[1];

                // Находим индекс следующего изображения
                int nextImageIndex = (ImageList.SelectedIndex + 1) % images.Count;
                Image image2 = images[nextImageIndex];
                Point point2_1 = selectedPoints[2];
                Point point2_2 = selectedPoints[3];

                // Вычисляем смещение
                double offsetX1 = point2_1.X - point1_1.X;
                double offsetY1 = point2_1.Y - point1_1.Y;

                // Устанавливаем позиции для наложения
                Canvas.SetLeft(image2, Canvas.GetLeft(image1) + offsetX1);
                Canvas.SetTop(image2, Canvas.GetTop(image1) + offsetY1);

                // Привязываем масштабирование второго изображения к первому
                image1.Tag = image2; // Сохраняем связь между изображениями

                MessageBox.Show("Изображения наложены. Вы можете указать новые точки.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Выберите по две точки на каждом из двух изображений!", "Наложение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


    }
}
