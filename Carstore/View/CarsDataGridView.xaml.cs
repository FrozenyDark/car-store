﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Carstore.Model;
using Carstore.View;

namespace Carstore.View
{
    /// <summary>
    /// Interaction logic for CarsDataGridView.xaml
    /// </summary>
    public partial class CarsDataGridView : UserControl
    {

        private string _markSearch = "";
        private string _modelSearch = "";
        private string _typeSearch = "";

        private List<CarMark> _marks;
        private List<CarModel> _models;
        private List<CarType> _types;
        private List<Car> _cars;

        public CarsDataGridView()
        {
            InitializeComponent();

            using (CarstoreDBEntities db = new CarstoreDBEntities())
            {
                _cars = db.Car.ToList();
                dg.ItemsSource = _cars
                    .Select(c => new CarTableModel(c))
                    .ToList();
                _marks = db.CarMark.OrderBy(m => m.Name).ToList();
                _types = db.CarType.OrderBy(t => t.Name).ToList();
                PriceMinBox.Minimum = PriceMinBox.Value = db.Car.Min(c => c.Price);
                PriceMaxBox.Maximum = PriceMaxBox.Value = db.Car.Max(c => c.Price);
                PowerMinBox.Minimum = PowerMinBox.Value = db.Car.Min(c => c.Power);
                PowerMaxBox.Maximum = PowerMaxBox.Value = db.Car.Max(c => c.Power);
            }
            MarkBox.ItemsSource = _marks.ToList();
            TypeBox.ItemsSource = _types.ToList();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            _markSearch = "";
            _modelSearch = "";
            _typeSearch = "";
            MarkSearchBox.Text = "";
            ModelSearchBox.Text = "";
            TypeSearchBox.Text = "";
            MarkBox.SelectedIndex = -1;
            ModelBox.SelectedIndex = -1;
            ModelBox.ItemsSource = null;
            ModelBox.IsEnabled = false;
            _models = null;
            TypeBox.SelectedIndex = -1;
            MarkBox.ItemsSource = _marks.ToList();
            TypeBox.ItemsSource = _types.ToList();
            using (CarstoreDBEntities db = new CarstoreDBEntities())
            {
                _cars = db.Car.ToList();
                dg.ItemsSource = _cars
                    .Select(c => new CarTableModel(c))
                    .ToList();
                _marks = db.CarMark.OrderBy(m => m.Name).ToList();
                _types = db.CarType.OrderBy(t => t.Name).ToList();
                PriceMinBox.Minimum = PriceMinBox.Value = db.Car.Min(c => c.Price);
                PriceMaxBox.Maximum = PriceMaxBox.Value = db.Car.Max(c => c.Price);
                PowerMinBox.Minimum = PowerMinBox.Value = db.Car.Min(c => c.Power);
                PowerMaxBox.Maximum = PowerMaxBox.Value = db.Car.Max(c => c.Power);
            }
        }

        private void MarkBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (CarstoreDBEntities db = new CarstoreDBEntities())
            {
                if (MarkBox.SelectedItem is CarMark carMark)
                {
                    CarMark mark = db.CarMark.Find(carMark.Id);
                    if (mark != null)
                    {
                        _modelSearch = "";
                        _models = mark.CarModel.OrderBy(m => m.Name).ToList();
                        ModelBox.ItemsSource = _models;
                        ModelBox.IsEnabled = true;
                    }
                }
            }
        }

        private void MarkBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            MarkBox.ItemsSource = Search(_marks, ref _markSearch, e.Text[0], 
                b => string.IsNullOrWhiteSpace(_markSearch) || b.Name.Contains(_markSearch));
            MarkSearchBox.Text = _markSearch;
        }

        private void ModelBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            ModelBox.ItemsSource = Search(_models, ref _modelSearch, e.Text[0],
                b => string.IsNullOrWhiteSpace(_modelSearch) || b.Name.Contains(_modelSearch));
            ModelSearchBox.Text = _modelSearch;
        }

        private void TypeBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TypeBox.ItemsSource = Search(_types, ref _typeSearch, e.Text[0],
                b => string.IsNullOrWhiteSpace(_typeSearch) || b.Name.Contains(_typeSearch));
            TypeSearchBox.Text = _typeSearch;
        }

        private List<T> Search<T>(List<T> items, ref string search, char c, Func<T, bool> searchAction)
        {
            if (c == 8)
            {
                if (search.Length > 0)
                    search = search.Remove(search.Length - 1);
            } else
            {
                search += c;
            }
            return items.Where(searchAction).ToList();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            using (CarstoreDBEntities db = new CarstoreDBEntities())
            {
                List<Car> filteredCars = db.Car.Include("CarModel").Include("CarModel.CarMark").Include("CarPhoto").Include("CarPhoto.Photo").ToList();
                if (MarkBox.SelectedItem is CarMark mark && mark != null)
                {
                    filteredCars = filteredCars.Where(c => c.CarModel.MarkId == mark.Id).ToList();
                }
                if (ModelBox.SelectedItem is CarModel model && model != null)
                {
                    filteredCars = filteredCars.Where(c => c.ModelId == model.Id).ToList();
                }
                if (TypeBox.SelectedItem is CarType type && type != null)
                {
                    filteredCars = filteredCars.Where(c => c.TypeId == type.Id).ToList();
                }
                int minPrice = PriceMinBox.Value;
                int maxPrice = PriceMaxBox.Value;
                int minPower = PowerMinBox.Value;
                int maxPower = PowerMaxBox.Value;
                filteredCars = filteredCars.Where(
                    c => c.Price >= minPrice && c.Price <= maxPrice && c.Power >= minPower && c.Power <= maxPower
                    ).ToList();
                dg.ItemsSource = filteredCars
                        .Select(c => new CarTableModel(c))
                        .ToList();
            }
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
